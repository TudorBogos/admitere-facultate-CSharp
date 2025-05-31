using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace admitere_facultate_C_
{

    public static class LayoutHelper
    {
        /// <summary>
        /// Centers a control horizontally in its parent, with an optional top offset
        /// </summary>
        /// <param name="c"></param>
        /// <param name="spacing"></param>
        public static void ComponentCenter(Control c,int spacing=0)
        {
            if (c.Parent == null) return;

            c.Left = (c.Parent.ClientSize.Width - c.Width) / 2;
            c.Top = (c.Parent.ClientSize.Height - c.Height) / 2 + spacing;
        }

        /// <summary>
        /// Positions a control 'c' below another control 'reference' with optional vertical spacing.
        /// </summary>
        /// <param name="c"></param>
        /// <param name="reference"></param>
        /// <param name="spacing"></param>
        public static void ComponentBelow(Control c, Control reference, int spacing = 20)
        {
            if (c.Parent == null || reference.Parent == null) return;

            c.Left = (reference.Parent.ClientSize.Width - c.Width) / 2;
            c.Top = reference.Bottom + spacing;
        }

        /// <summary>
        /// Centers a control 'c' horizontally within its parent container (form or panel).
        /// </summary>
        /// <param name="c"></param>
        public static void CenterHorizontally(Control c)
        {
            if (c.Parent != null)
                c.Left = (c.Parent.ClientSize.Width - c.Width) / 2;
        }

        /// <summary>
        /// Automatically resizes a DataGridView to fit its content.
        /// </summary>
        /// <param name="grid"></param>
        public static void AutoResizeDataGridView(DataGridView grid)
        {
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            grid.RowHeadersVisible = false;
            grid.ScrollBars = ScrollBars.Vertical;
        }

    }

}
