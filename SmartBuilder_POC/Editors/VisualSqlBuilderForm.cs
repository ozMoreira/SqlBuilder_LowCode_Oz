using MaterialSkin;
using SmartBuilder_POC.Controls;
using SmartBuilder_POC.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace SmartBuilder_POC.Forms
{
    public partial class VisualSqlBuilderForm : MaterialSkin.Controls.MaterialForm
    {
        private readonly IDatabaseSchemaProvider _db;
        private readonly Dictionary<string, string> _tableAliases = new Dictionary<string, string>();
        private char _nextAlias = 'a';
        private readonly Dictionary<string, Color> _tableColors = new Dictionary<string, Color>();
        private int _nextColorIndex = 0;
        private readonly Color[] _palette = new Color[]
            {
                Color.LightSkyBlue,
                Color.LightGreen,
                Color.LightSalmon,
                Color.LightPink,
                Color.Khaki,
                Color.LightSteelBlue,
                Color.Plum,
                Color.PeachPuff,
            };

        public string SelectedTable => cmbTabelas.SelectedItem?.ToString();
        public VisualSqlBuilderForm(string connectionString)
        {
            InitializeComponent();
            IDatabaseSchemaProvider schemaProvider = new DatabaseExplorer(connectionString);

            _db = schemaProvider;
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.BlueGrey800,   // azul escuro acinzentado
                Primary.BlueGrey900,   // sombra ainda mais escura
                Primary.BlueGrey500,   // claro (opcional)
                Accent.LightBlue200,   // destaque (botões de check, foco, etc.)
                TextShade.WHITE);
            btnLimparCanvas.Text = "\uf51a";
            pnlCanvas.AllowDrop = true;
            LoadPalette();
            CarregarTabelas();
            pnlCanvas.DragEnter += PnlCanvas_DragEnter;
            pnlCanvas.DragDrop += PnlCanvas_DragDrop;
            btnLimparCanvas.Click += btnLimparCanvas_Click;
        }

        private void LoadPalette()
        {
            var preview = new SelectBlockControl
            {
                Location = new Point(20, 20)
            };

            // Evento no preview (área azul "vazia")
            preview.MouseDown += (s, e) =>
            {
                if (e.Button == MouseButtons.Left)
                    DoDragDrop("SELECT", DragDropEffects.Copy);
            };

            // Evento na label interna do preview (área de texto)
            if (preview.Controls.Count > 0 && preview.Controls[0] is Label lbl)
            {
                lbl.MouseDown += (s, e) =>
                {
                    if (e.Button == MouseButtons.Left)
                        DoDragDrop("SELECT", DragDropEffects.Copy);
                };
            }

            pnlPallete.Controls.Add(preview);
        }

        private void PnlCanvas_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;

        }

        private void PnlCanvas_DragDrop(object sender, DragEventArgs e)
        {
            string campo = e.Data.GetData(DataFormats.Text)?.ToString();
            var tabela = SelectedTable;
            if (!string.IsNullOrEmpty(campo) && !string.IsNullOrEmpty(tabela))
            {
                string alias = GetAliasForTable(tabela);
                Color color = GetColorForTable(tabela);
                var blocoCampo = new FieldBlockControl(campo, alias, tabela, color);
                Point pt = pnlCanvas.PointToClient(new Point(e.X, e.Y));
                blocoCampo.Location = pt;
                blocoCampo.EnableMove();
                pnlCanvas.Controls.Add(blocoCampo);

                blocoCampo.MouseDoubleClick += Block_MouseDoubleClick;
                foreach (Control c in blocoCampo.Controls)
                    c.MouseDoubleClick += Block_MouseDoubleClick;
            }
        }

        private void Block_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Sobe a hierarquia até encontrar o FieldBlockControl
            Control block = sender as Control;
            while (block != null && !(block is FieldBlockControl))
                block = block.Parent;

            if (block is FieldBlockControl bloco)
            {
                if (MessageBox.Show("Remover este campo do SELECT?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    pnlCanvas.Controls.Remove(bloco);
                    bloco.Dispose();
                }
            }
        }


        private void BtnGenerateSql_Click(object sender, EventArgs e)
        {
            // 1. Obtenha todos os blocos de campo do canvas
            var fieldBlocks = pnlCanvas.Controls
                .OfType<FieldBlockControl>()
                .ToList();

            if (fieldBlocks.Count == 0)
            {
                MessageBox.Show("Nenhum campo selecionado!", "SQL Gerado");
                return;
            }

            // 2. SELECT: campos formatados como alias.campo
            var campos = fieldBlocks
                .Select(fb => $"{fb.TableAlias}.{fb.FieldName}")
                .ToList();

            // 3. FROM: pega todas as tabelas únicas presentes nos blocos
            var tabelas = fieldBlocks
                .GroupBy(fb => new { fb.TableAlias, fb.TableName }) // Adicione uma propriedade TableName no FieldBlockControl!
                .Select(g => $"{g.Key.TableName} AS {g.Key.TableAlias}")
                .ToList();

            string fromClause = string.Join(", ", tabelas);

            // 4. WHERE: pega filtros definidos nos blocos
            var wheres = pnlCanvas.Controls
                .OfType<FieldBlockControl>()
                .Where(fb => !string.IsNullOrWhiteSpace(fb.FilterOperator))
                .Select(fb =>
                {
                    string campo = $"{fb.TableAlias}.{fb.FieldName}";
                    string op = fb.FilterOperator;
                    string valor = fb.FilterValue ?? "";

                if (op == "IS NULL" || op == "IS NOT NULL")
                {
                    return $"{campo} {op}";
                }
                else if (op == "BETWEEN")
                {
                    // Espera-se que o usuário digite algo como: 10 AND 20
                    // Ou se quiser, pode criar dois campos separados no editor!
                    var partes = valor.Split(new[] { "AND" }, StringSplitOptions.None);
                    if (partes.Length == 2)
                    {
                        string v1 = partes[0].Trim();
                        string v2 = partes[1].Trim();
                        return $"{campo} BETWEEN '{v1.Replace("'", "''")}' AND '{v2.Replace("'", "''")}'";
                    }
                    else
                    {
                        // Se não estiver no formato esperado, gera o texto bruto mesmo
                        return $"{campo} BETWEEN {valor}";
                    }
                }
                else if (op == "IN" || op == "NOT IN")
                {
                    // Espera-se que o usuário digite: 1,2,3  ou  'a','b','c'
                    string lista = valor;
                    if (!valor.Trim().StartsWith("("))
                        lista = "(" + valor + ")";
                    return $"{campo} {op} {lista}";
                }
                else if (op == "LIKE" || op == "NOT LIKE")
                {
                    return $"{campo} {op} '%{valor.Replace("'", "''")}%'";
                }
                else
                {
                    // Operadores simples (=, <>, >, <, >=, <=)
                    return $"{campo} {op} '{valor.Replace("'", "''")}'";
                }
            })
                    .ToList();

            string whereClause = wheres.Any() ? "WHERE " + string.Join(" AND ", wheres) : "";
            // GROUP BY
            var groupByCampos = pnlCanvas.Controls
                .OfType<FieldBlockControl>()
                .Where(fb => fb.IsGroupBy)
                .Select(fb => $"{fb.TableAlias}.{fb.FieldName}")
                .ToList();

            string groupByClause = groupByCampos.Any() ? "GROUP BY " + string.Join(", ", groupByCampos) : "";

            // ORDER BY
            var orderByCampos = pnlCanvas.Controls
                .OfType<FieldBlockControl>()
                .Where(fb => fb.IsOrderBy)
                .Select(fb => $"{fb.TableAlias}.{fb.FieldName} {fb.OrderDirection}")
                .ToList();

            string orderByClause = orderByCampos.Any() ? "ORDER BY " + string.Join(", ", orderByCampos) : "";

            // SQL final:
            string sql = $"SELECT {string.Join(", ", campos)}\nFROM {fromClause}\n{whereClause}\n{groupByClause}\n{orderByClause};";// GROUP BY
            
            MessageBox.Show(sql, "SQL Gerado");
        }

        private void pnlPallete_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CarregarTabelas()
        {
            // Use seu DatabaseExplorer/serviço de banco
            var tables = _db.GetTabelas();
            cmbTabelas.Items.Clear();
            cmbTabelas.Items.AddRange(tables.ToArray());
        }

        private void cmbTabelas_SelectedIndexChanged(object sender, EventArgs e)
        {
            var tabelaSelecionada = cmbTabelas.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(tabelaSelecionada))
                return;

            // Gera alias se ainda não existir
            if (!_tableAliases.ContainsKey(tabelaSelecionada))
            {
                _tableAliases[tabelaSelecionada] = _nextAlias.ToString();
                _nextAlias++;
            }

            var campos = _db.GetCampos(tabelaSelecionada);
            lstCampos.Items.Clear();
            lstCampos.Items.AddRange(campos.ToArray());
        }

        private void lstCampos_MouseDown(object sender, MouseEventArgs e)
        {
            if (lstCampos.SelectedItem != null && e.Button == MouseButtons.Left)
                lstCampos.DoDragDrop(lstCampos.SelectedItem.ToString(), DragDropEffects.Copy);
        }

        private string GetAliasForTable(string tableName)
        {
            if (string.IsNullOrEmpty(tableName))
                return "";

            if (!_tableAliases.TryGetValue(tableName, out string alias))
            {
                alias = _nextAlias.ToString();
                _tableAliases[tableName] = alias;
                _nextAlias++;
            }
            return alias;
        }
        private Color GetColorForTable(string tableName)
        {
            if (!_tableColors.TryGetValue(tableName, out var color))
            {
                color = _palette[_nextColorIndex % _palette.Length];
                _tableColors[tableName] = color;
                _nextColorIndex++;
            }
            return color;
        }

        private void btnLimparCanvas_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente limpar todos os blocos da Tela?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                pnlCanvas.Controls.Clear();
            }

        }
    }
}
