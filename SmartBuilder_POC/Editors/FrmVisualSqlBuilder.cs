using MaterialSkin;
using SmartBuilder_POC.Controls;
using SmartBuilder_POC.Editors;
using SmartBuilder_POC.Helpers;
using SmartBuilder_POC.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Forms;

namespace SmartBuilder_POC.Forms
{
    public partial class FrmVisualSqlBuilder : MaterialSkin.Controls.MaterialForm
    {
        private readonly IDatabaseSchemaProvider _db;
        private readonly String conn;
        private readonly List<string> _allTables;
        private readonly Dictionary<string, string> _tableAliases = new Dictionary<string, string>();
        private readonly List<JoinDefinition> _joins = new List<JoinDefinition>();
        private readonly Dictionary<string, Color> _tableColors = new Dictionary<string, Color>();
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
        private char _nextAlias = 'a';
        private int _nextColorIndex = 0;

        public string SelectedTable => cmbTabelas.SelectedItem?.ToString();
        public FrmVisualSqlBuilder(string connectionString)
        {
            InitializeComponent();
            pnlCanvas.Paint += pnlCanvas_Paint;

            conn = connectionString;
            IDatabaseSchemaProvider schemaProvider = new DatabaseExplorer(connectionString);
            _db = schemaProvider;
            _allTables = _db.GetTabelas().ToList();

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

        private void pnlCanvas_Paint(object sender, PaintEventArgs e)
        {
            foreach (var join in _joins)
            {
                // Ache os blocos de campo pelo alias/tabela/campo
                var origem = pnlCanvas.Controls
                    .OfType<FieldBlockControl>()
                    .FirstOrDefault(b => b.TableAlias == join.SourceAlias && b.FieldName == join.SourceField);

                var destino = pnlCanvas.Controls
                    .OfType<FieldBlockControl>()
                    .FirstOrDefault(b => b.TableAlias == join.TargetAlias && b.FieldName == join.TargetField);

                if (origem != null && destino != null)
                {
                    // Pegue o centro de cada bloco/campo
                    var pt1 = pnlCanvas.PointToClient(origem.Parent.PointToScreen(origem.Location));
                    pt1.Offset(origem.Width / 2, origem.Height / 2);

                    var pt2 = pnlCanvas.PointToClient(destino.Parent.PointToScreen(destino.Location));
                    pt2.Offset(destino.Width / 2, destino.Height / 2);

                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using (var pen = new Pen(Color.Red, 2))
                    {
                        e.Graphics.DrawLine(pen, pt1, pt2);
                    }
                }
            }
        }
        private void PnlCanvas_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
                e.Effect = DragDropEffects.Copy;

        }

        private void PnlCanvas_DragDrop(object sender, DragEventArgs e)
        {
            string field = e.Data.GetData(DataFormats.Text)?.ToString();
            var table = SelectedTable;
            bool exists = pnlCanvas.Controls
       .OfType<FieldBlockControl>()
       .Any(b => b.TableName == table && b.FieldName == field);

            if (string.IsNullOrEmpty(field) || string.IsNullOrEmpty(table))
                return;
            if (exists)
            {
                MessageBox.Show(
                    $"O campo “{field}” da tabela “{table}” já foi adicionado.",
                    "Campo duplicado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Se não existir, cria o bloco normalmente
            var alias = GetAliasForTable(table);
            var color = GetColorForTable(table);

            var block = new FieldBlockControl(field, alias, table, color)
            {
                Location = pnlCanvas.PointToClient(new Point(e.X, e.Y))
            };
            block.EnableMove();
            block.OnSolicitarJoin += CampoSolicitouJoin;
            block.OnRemoveJoin += FieldBlock_OnRemoveJoin;
            pnlCanvas.Controls.Add(block);
            pnlCanvas.Invalidate();
            /*if (!string.IsNullOrEmpty(campo) && !string.IsNullOrEmpty(tabela))
            {
                string alias = GetAliasForTable(tabela);
                Color color = GetColorForTable(tabela);
                var blocoCampo = new FieldBlockControl(campo, alias, tabela, color);
                Point pt = pnlCanvas.PointToClient(new Point(e.X, e.Y));
                blocoCampo.Location = pt;
                blocoCampo.EnableMove();
                blocoCampo.OnSolicitarJoin += CampoSolicitouJoin;
                pnlCanvas.Controls.Add(blocoCampo);

                blocoCampo.MouseDoubleClick += Block_MouseDoubleClick;
                foreach (Control c in blocoCampo.Controls)
                    c.MouseDoubleClick += Block_MouseDoubleClick;
          } */

        }
        private void FieldBlock_OnRemoveJoin(object sender, EventArgs e)
        {
            var fb = sender as FieldBlockControl;
            if (fb == null) return;

            // Remove _todas_ as definições de join onde seja origem ou destino
            _joins.RemoveAll(j =>
                (j.SourceAlias == fb.TableAlias && j.SourceField == fb.FieldName) ||
                (j.TargetAlias == fb.TableAlias && j.TargetField == fb.FieldName)
            );

            // Redesenha o canvas sem os JOINs removidos
            pnlCanvas.Invalidate();
        }
        private void Block_OnRemoveBlock(object sender, EventArgs e)
        {
            var bloco = (FieldBlockControl)sender;
            pnlCanvas.Controls.Remove(bloco);
            pnlCanvas.Invalidate();
        }

        private void Block_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var ctrl = sender as Control;
            while (ctrl != null && !(ctrl is FieldBlockControl))
                ctrl = ctrl.Parent;

            if (ctrl is FieldBlockControl bloco &&
                MessageBox.Show("Remover este campo do SELECT?",
                                "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                pnlCanvas.Controls.Remove(bloco);
                bloco.Dispose();
                pnlCanvas.Invalidate();
            }
            /* // Sobe a hierarquia até encontrar o FieldBlockControl
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
             }*/
        }

        private string GerarFromComJoins()
        {
            var blocoPrincipal = pnlCanvas.Controls.OfType<FieldBlockControl>().FirstOrDefault();
            string tabelaPrincipal = blocoPrincipal.TableName;
            string aliasPrincipal = blocoPrincipal.TableAlias;

            string fromClause = $"{tabelaPrincipal} AS {aliasPrincipal}";
            foreach (var join in _joins)
            {
                fromClause += $"\n {join.JoinType.ToUpper()} {join.TargetTable.ToUpper()} AS {join.TargetAlias.ToUpper()} ON " +
                              $"{join.SourceAlias.ToUpper()}.{join.SourceField.ToUpper()} = {join.TargetAlias.ToUpper()}.{join.TargetField.ToUpper()}";
            }

            return fromClause;
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
                .Select(fb => $"{fb.TableAlias.ToUpper()}.{fb.FieldName.ToUpper()}")
                .ToList()
                ;

            // 3. FROM: pega todas as tabelas únicas presentes nos blocos
            var tabelas = fieldBlocks
                .GroupBy(fb => new { fb.TableAlias, fb.TableName }) // Adicione uma propriedade TableName no FieldBlockControl!
                .Select(g => $"{g.Key.TableName.ToUpper()} AS {g.Key.TableAlias.ToUpper()}")
                .ToList();

            //string fromClause = string.Join(", ", tabelas);
            string fromClause = GerarFromComJoins();

            // 4. WHERE: pega filtros definidos nos blocos
            var wheres = pnlCanvas.Controls
                .OfType<FieldBlockControl>()
                .Where(fb => !string.IsNullOrWhiteSpace(fb.FilterOperator))
                .Select(fb =>
                {
                    string campo = $"{fb.TableAlias.ToUpper()}.{fb.FieldName.ToUpper()}";
                    string op = fb.FilterOperator.ToUpper();
                    string valor = fb.FilterValue ?? "";

                    if (op == "IS NULL" || op == "IS NOT NULL")
                    {
                        return $"{campo.ToUpper()} {op.ToUpper()}";
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
                            return $"{campo.ToUpper()} BETWEEN '{v1.Replace("'", "''")}' AND '{v2.Replace("'", "''")}'";
                        }
                        else
                        {
                            // Se não estiver no formato esperado, gera o texto bruto mesmo
                            return $"{campo.ToUpper()} BETWEEN {valor.ToUpper()}";
                        }
                    }
                    else if (op == "IN" || op == "NOT IN")
                    {
                        // Espera-se que o usuário digite: 1,2,3  ou  'a','b','c'
                        string lista = valor;
                        if (!valor.Trim().StartsWith("("))
                            lista = "(" + valor + ")";
                        return $"{campo.ToUpper()} {op} {lista.ToUpper()}";
                    }
                    else if (op == "LIKE" || op == "NOT LIKE")
                    {
                        return $"{campo.ToUpper()} {op.ToUpper()} '%{valor.Replace("'", "''").ToUpper()}%'";
                    }
                    else
                    {
                        // Operadores simples (=, <>, >, <, >=, <=)
                        return $"{campo.ToUpper()} {op.ToUpper()} '{valor.Replace("'", "''").ToUpper()}'";
                    }
                })
                    .ToList();

            string whereClause = wheres.Any() ? "WHERE " + string.Join(" AND ", wheres) : "";
            // GROUP BY
            var groupByCampos = pnlCanvas.Controls
                .OfType<FieldBlockControl>()
                .Where(fb => fb.IsGroupBy)
                .Select(fb => $"{fb.TableAlias.ToUpper()}.{fb.FieldName.ToUpper()}")
                .ToList();

            string groupByClause = groupByCampos.Any() ? "GROUP BY " + string.Join(", ", groupByCampos) : "";

            // ORDER BY
            var orderByCampos = pnlCanvas.Controls
                .OfType<FieldBlockControl>()
                .Where(fb => fb.IsOrderBy)
                .Select(fb => $"{fb.TableAlias.ToUpper()}.{fb.FieldName.ToUpper()} {fb.OrderDirection.ToUpper()}")
                .ToList();

            string orderByClause = orderByCampos.Any() ? "ORDER BY " + string.Join(", ", orderByCampos) : "";

            // SQL final:
            var linhas = new List<string>
            {
                $"SELECT {string.Join(", ", campos)}",
                $" FROM {fromClause}"
            };

            if (!string.IsNullOrWhiteSpace(whereClause))
                linhas.Add(whereClause);
            if (!string.IsNullOrWhiteSpace(groupByClause))
                linhas.Add(groupByClause);
            if (!string.IsNullOrWhiteSpace(orderByClause))
                linhas.Add(orderByClause);

            string sql = string.Join("\n", linhas) + ";";
            //MessageBox.Show(sql, "SQL Gerado");
            var frm = new FrmSqlViewer(sql, conn);
            frm.ShowDialog();
        }

        private void pnlPallete_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void CarregarTabelas()
        {
            // Use seu DatabaseExplorer/serviço de banco
            //var tables = _db.GetTabelas();
            //cmbTabelas.Items.Clear();
            //cmbTabelas.Items.AddRange(tables.ToArray());
            cmbTabelas.Items.AddRange(_allTables.ToArray());
            cmbTabelas.DropDownStyle = ComboBoxStyle.DropDownList;
            if (cmbTabelas.Items.Count > 0) cmbTabelas.SelectedIndex = 0;


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
            if (MessageBox.Show(
             "Deseja realmente limpar todos os blocos da tela?",
             "Confirmar",
             MessageBoxButtons.YesNo,
             MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // 1) Remove todos os controles (blocos de campo e pontos de conexão)
            pnlCanvas.Controls.Clear();

            // 2) Limpa a lista de joins para que não sejam mais desenhados
            _joins.Clear();

            // 3) (Opcional) Se você usar outra estrutura de conexões, limpe-a também
            // RefreshConnectorPoints();

            // 4) Reseta eventuais estados auxiliares (aliases, cores, etc.)
            _tableAliases.Clear();
            _tableColors.Clear();
            _nextAlias = 'a';
            _nextColorIndex = 0;

            // 5) Força o repaint do painel — agora sem nenhum join desenhado
            pnlCanvas.Invalidate();

        }
        private void CampoSolicitouJoin(object sender, EventArgs e)
        {
            var blocoOrigem = (FieldBlockControl)sender;

            // 1) Monta o dicionário de tabelas/campos (igual você já faz)
            var tabelasComCampos = new Dictionary<string, FrmJoinEditor.TabelaInfo>();
            foreach (var block in pnlCanvas.Controls.OfType<FieldBlockControl>())
            {
                if (!tabelasComCampos.ContainsKey(block.TableName))
                    tabelasComCampos[block.TableName] = new FrmJoinEditor.TabelaInfo
                    {
                        Alias = block.TableAlias,
                        Campos = new List<string>()
                    };
                if (!tabelasComCampos[block.TableName].Campos.Contains(block.FieldName))
                    tabelasComCampos[block.TableName].Campos.Add(block.FieldName);
            }

            // 2) Abre o editor de joins, passando origem
            var frmJoin = new FrmJoinEditor(
                tabelasComCampos,
                blocoOrigem.TableName,
                blocoOrigem.TableAlias,
                blocoOrigem.FieldName);

            if (frmJoin.ShowDialog() != DialogResult.OK)
                return;

            // 3) Use AS PRÓPRIAS PROPRIEDADES do FrmJoinEditor, já separadas:
            string sourceAlias = frmJoin.SourceAlias;
            string sourceTable = frmJoin.SourceTable;
            string sourceField = frmJoin.SourceField;

            string targetAlias = frmJoin.TargetAlias;
            string targetTable = frmJoin.TargetTable;
            string targetField = frmJoin.TargetField;

            // 4) Cria e adiciona o join
            var novoJoin = new JoinDefinition
            {
                SourceTable = sourceTable,
                SourceAlias = sourceAlias,
                SourceField = sourceField,
                TargetTable = targetTable,
                TargetAlias = targetAlias,
                TargetField = targetField,
                JoinType = frmJoin.JoinType
            };

            _joins.Add(novoJoin);
            pnlCanvas.Invalidate();
        }
    }
}
