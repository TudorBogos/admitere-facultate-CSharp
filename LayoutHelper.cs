using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace admitere_facultate_C_
{

    public static class LayoutHelper
    {
        /// <summary>
        /// Centers a control in its parent container (form or panel).
        /// </summary>
        public static void ComponentCenter(Control c)
        {
            if (c.Parent == null) return;

            c.Left = (c.Parent.ClientSize.Width - c.Width) / 2;
            c.Top = (c.Parent.ClientSize.Height - c.Height) / 2;
        }

        /// <summary>
        /// Centers control 'c' horizontally under control 'reference' with optional vertical spacing.
        /// </summary>
        public static void ComponentBelow(Control c, Control reference, int spacing = 20)
        {
            if (c.Parent == null || reference.Parent == null) return;

            c.Left = (reference.Parent.ClientSize.Width - c.Width) / 2;
            c.Top = reference.Bottom + spacing;
        }

        /// <summary>
        /// Centers a control horizontally in its parent container (form or panel).
        /// </summary>
        public static void CenterHorizontally(Control c)
        {
            if (c.Parent != null)
                c.Left = (c.Parent.ClientSize.Width - c.Width) / 2;
        }

    }

}
