using System.Drawing;
using System.Windows.Forms;

namespace admitere_facultate_C_
{
    public static class FormHelper
    {
        public static void ConfigureForm(Form form, Size clientSize, Size minSize, bool centerOnScreen = true)
        {   
            form.ClientSize = clientSize;
            form.MinimumSize = minSize;

            if (centerOnScreen)
                form.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
