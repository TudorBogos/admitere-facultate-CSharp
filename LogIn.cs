using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pqc.Crypto.Lms;

namespace admitere_facultate_C_
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
            FormHelper.ConfigureForm(this,new Size(400, 250), Size.Empty, true);
            textBoxPassword.PasswordChar = '*';
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            // Centreaza tableLayoutPanel1 in form
            LayoutHelper.ComponentCenter(tableLayoutPanel1);

            // Re-centreaza tableLayoutPanel1 la redimensionare
            this.Resize += (s, ev) =>
            {
                LayoutHelper.ComponentCenter(tableLayoutPanel1);
            };
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked) // Student mode
            {
                textBoxPassword.PasswordChar = '\0'; // Show CNP
                label1.Text = "Nume,Prenume";
                label2.Text = "CNP";
                textBoxPassword.Text = "";
                textBoxUser.Text = "";
                label3.Text= "Se va introduce nume complet in forma nume,prenume. \nEx: Popescu,Ion";

                // Hook KeyPress event to allow only digits
                textBoxPassword.KeyPress += OnlyAllowDigits;
            }
            else // Admin mode
            {
                textBoxPassword.PasswordChar = '*'; // Hide password
                label1.Text = "Username";
                label2.Text = "Parola";
                textBoxPassword.Text = "";
                textBoxUser.Text = "";
                label3.Text = "Pentru studenti va rog dati check la casuta Student.";

                // Remove digit-only filter if switching back
                textBoxPassword.KeyPress -= OnlyAllowDigits;
            }
        }

        private void OnlyAllowDigits(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {

            string user = textBoxUser.Text;
            string pass = textBoxPassword.Text;
            bool isStudent = checkBox1.Checked;

            if (Auth.Login(user, pass, isStudent))
            {
                MessageBox.Show("Autentificare reusita!");
                this.Hide(); // Ascunde fereastra de login
                if (isStudent)
                {
                    // Deschide fereastra pentru studenti
                    var studentForm = new StudentForm();
                    studentForm.ShowDialog();
                    this.Show();
                }
                else
                {
                    // Deschide fereastra pentru admin
                    var adminForm = new AdminForm();
                    adminForm.ShowDialog();
                    this.Show();
                }
            }
            else
            {
                MessageBox.Show("Informatii de login gresite.");
            }
        }
    }
}
