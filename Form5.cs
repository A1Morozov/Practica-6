using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Practica6
{
    public partial class FormAdmin : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        string connectionString = @"Data Source=DESKTOP-S49R6FM/SQLEXPRESS; Initial Catalog=Practica6; Integrated Security=True";
        string sql = "SELECT * FROM Administrators";

        public FormAdmin()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);

                ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            
            this.administratorsTableAdapter.Fill(this.pR3DataSet.Administrators);

        }

        private void button_Add_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);
        }

        private void button_Del_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                commandBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = new SqlCommand("INSERT INTO Administrators(ID, Nickname, Email, Server_name) VALUES ('', '', '', '')", connection);
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 35, "ID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Nickname", SqlDbType.NVarChar, 150, "Nickname"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Email", SqlDbType.NVarChar, 150, "Email"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Server_name", SqlDbType.NVarChar, 35, "Server_name"));

                adapter.Update(ds);
            }
        }

        void openchild(Panel pen, Form emptyF)
        {
            emptyF.TopLevel = false;
            emptyF.FormBorderStyle = FormBorderStyle.None;
            emptyF.Dock = DockStyle.Fill;
            pen.Controls.Add(emptyF);
            emptyF.BringToFront();
            emptyF.Show();

        }
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            openchild(panel1, new FormAdmin());
        }
    }
}
