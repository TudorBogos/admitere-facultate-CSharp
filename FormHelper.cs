using System.Drawing;
using System.Windows.Forms;

namespace admitere_facultate_C_
{
    public static class FormHelper
    {
        /// <summary>
        /// Configures a form with specified client size, minimum size, and optional center on screen setting.
        /// </summary>
        /// <param name="form"></param>
        /// <param name="clientSize"></param>
        /// <param name="minSize"></param>
        /// <param name="centerOnScreen"></param>
        public static void ConfigureForm(Form form, Size clientSize, Size minSize, bool centerOnScreen = true)
        {   
            form.ClientSize = clientSize;
            form.MinimumSize = minSize;

            if (centerOnScreen)
                form.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
