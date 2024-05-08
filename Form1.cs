using System.Net.Security;

namespace Login
{
    public partial class Form1 : Form
    {
        private const string UserDataFilepath = "UserData.txt";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (AuthenticateUser(username, password))
            {

                Empleado em = new Empleado();
                em.Show();
            }
            else
            {
                MessageBox.Show("Credenciales invalidas");
            }


        }

        private bool AuthenticateUser(string username, string password)
        {
            string[] lines = File.ReadAllLines(@"C:\Users\dmendoza\source\repos\Login\DatosdUsuario.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(';');
                if (parts.Length == 2)
                {
                    string storedUsername = parts[0];
                    string storedPassword = parts[1];

                    if (username == storedUsername && password == storedPassword)
                    {
                        return true;
                    }
                }
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
