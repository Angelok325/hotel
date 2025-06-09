using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace Project_HMS
{
    public partial class Login : Form

      {   
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.16.0;Data Source=C:\\Users\\User\\Documents\\Database411.accdb";
        private TextBox userInputTextBox;
        private Label UserLabel1;
        private Label PasswordLabel1;
 
        
        public Login()
        {
            InitializeComponent();
           
        }

        public static class FormSwitcher
        {
            public static void SwitchMainForm(Form Login, Form ManagerDashboard)
            {
                Login.Hide();
                ManagerDashboard.Show();
                //Form2.FormClosed += (s, args) => Form1.Show();
            }
        }
            private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string FIO = txtUserid.Text;
                string Password = txtPassword.Text;
                
                    int UserID = AuthenticateUser(FIO, Password);
                    
                if (UserID != -1)
                    {
                    ManagerDashboard board = new ManagerDashboard();
                    FormSwitcher.SwitchMainForm(this, board);

                 }
                  else
                  {
                      MessageBox.Show("Неверное имя пользователя или пароль.");
                  }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private int AuthenticateUser(string FIO, string Password)
        {

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                using (OleDbCommand command = new OleDbCommand("SELECT UserID FROM Users WHERE [FIO] = @FIO AND [Password] = @Password", connection))
                {
                    command.Parameters.Add("@FIO", OleDbType.VarChar).Value = FIO;
                    command.Parameters.Add("@Password", OleDbType.VarChar).Value = Password;
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtUserid.Text = "";
            this.txtPassword.Text = "";
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
