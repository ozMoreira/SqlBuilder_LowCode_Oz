// FormResizer.cs - utilitário para ajuste dinâmico do tamanho do form

using System;
using System.Windows.Forms;

namespace SmartBuilder_POC.Services
{
    public static class FormResizer
    {
        public static void Adjust(Form form, FlowLayoutPanel pnlTables, TableLayoutPanel tlpMain, int minFormWidth)
        {
            var screen = Screen.FromControl(form).WorkingArea;
            int maxWidth = screen.Width;
            int maxHeight = screen.Height;
            int extraMargin = 80;

            // Altura base (componentes fora do painel de tabelas)
            int baseHeight = form.Height - pnlTables.Height;

            // Cálculo da largura total dos blocos
            int totalBlockWidth = 0;
            int blockHeight = 0;
            int blocksCount = 0;
            foreach (Control block in pnlTables.Controls)
            {
                totalBlockWidth += block.Width + block.Margin.Horizontal;
                blockHeight = block.Height + block.Margin.Vertical;
                blocksCount++;
            }

            // Largura do painel da direita (ex: painel SQL)
            int rightPanelWidth = tlpMain.GetControlFromPosition(1, 0)?.Width ?? 400;
            int desiredTotalWidth = totalBlockWidth + rightPanelWidth + extraMargin;
            int newWidth = Math.Min(Math.Max(desiredTotalWidth, minFormWidth), maxWidth);

            // Verifica se houve quebra de linha
            bool hasLineBreak = (desiredTotalWidth >= maxWidth);

            // Estima quantos blocos cabem por linha e quantas linhas temos
            int col0Width = newWidth - rightPanelWidth - extraMargin;
            int blocksPerRow = Math.Max(1, col0Width / (pnlTables.Controls.Count > 0 ? pnlTables.Controls[0].Width : 1));
            int rows = (int)Math.Ceiling((double)blocksCount / blocksPerRow);

            // Altura ajustada caso tenha quebra de linha
            int newHeight = form.Height;
            if (hasLineBreak)
            {
                int totalBlocksHeight = rows * blockHeight;
                newHeight = Math.Min(baseHeight + totalBlocksHeight + extraMargin, maxHeight);
            }

            // Aplica nova largura/altura e centraliza
            if (form.Width != newWidth || form.Height != newHeight)
            {
                form.Width = newWidth;
                form.Height = newHeight;

                form.Left = (screen.Width - form.Width) / 2;
                form.Top = (screen.Height - form.Height) / 2;
            }
        }
    }
}
