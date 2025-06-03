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
        /// Redimensioneaza un DataGridView pentru a se potrivi cu continutul sau.
        /// Ajusteaza automat latimea coloanelor si seteaza inaltimea maxima.
        /// </summary>
        /// <param name="grid">Controlul DataGridView</param>
        /// <param name="maxHeight">Inaltimea maxima dorita (default: 300)</param>
        public static void ResizeDataGridView(DataGridView grid, int maxHeight = 300)
        {
            if (grid == null || grid.Columns.Count == 0) return;

            // Setari de afisare
            grid.RowHeadersVisible = false;
            grid.ScrollBars = ScrollBars.Vertical;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Calculeaza latimea totala
            int totalWidth = 0;
            foreach (DataGridViewColumn col in grid.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                totalWidth += col.Width;
            }

            // Adauga latimea barei de scroll
            totalWidth += SystemInformation.VerticalScrollBarWidth + 15;

            // Aplica dimensiuni
            grid.Width = totalWidth;
            grid.Height = maxHeight;
        }

        /// <summary>
        /// Centreaza o lista de controale vertical si orizontal in parinte.
        /// Foloseste spatiere constanta intre ele.
        /// </summary>
        /// <param name="controls">Lista de controale</param>
        /// <param name="spacing">Spatierea verticala intre controale</param>
        public static void CenterControlsVertically(params Control[] controls)
        {
            if (controls == null || controls.Length == 0) return;

            Control parent = controls[0].Parent;
            if (parent == null) return;

            int totalHeight = controls.Sum(c => c.Height) + (controls.Length - 1) * 10;

            int startTop = (parent.ClientSize.Height - totalHeight) / 2;

            foreach (var control in controls)
            {
                control.Left = (parent.ClientSize.Width - control.Width) / 2;
                control.Top = startTop;
                startTop += control.Height + 10;
            }
        }


    }

}
