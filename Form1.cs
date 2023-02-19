using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Practica6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAuto_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-S49R6FM/SQLEXPRESS; Initial Catalog=Practica6; Integrated Security=True";
            SqlConnection conn = new SqlConnection(connectionString);
            bool success = false;
            try
            {
                const string comand = "SELECT * FROM Authorizations WHERE Login_=@Login_ AND Password_=@Password_";
                SqlCommand check = new SqlCommand(comand, conn);
                check.Parameters.AddWithValue("@Login_", textBoxLogin.Text);
                check.Parameters.AddWithValue("@Password_", textBoxPass.Text);
                conn.Open();


                using (var dataReader = check.ExecuteReader())
                {
                    success = dataReader.Read();
                }
            }
            finally
            {
                conn.Close();
            }
            if (success)
            {
                Form2 Win = new Form2();
                Win.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль!");
            }

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
