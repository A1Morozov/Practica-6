using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Practica6
{
    public partial class FormBan : Form
    {
        DataSet ds;
        SqlDataAdapter adapter;
        SqlCommandBuilder commandBuilder;
        string connectionString = @"Data Source=DESKTOP-S49R6FM/SQLEXPRESS; Initial Catalog=Practica6; Integrated Security=True";
        string sql = "SELECT * FROM Ban_list";

        public FormBan()
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

        private void FormBan_Load(object sender, EventArgs e)
        {
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables[0].NewRow();
            ds.Tables[0].Rows.Add(row);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                dataGridView1.Rows.Remove(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                adapter = new SqlDataAdapter(sql, connection);
                commandBuilder = new SqlCommandBuilder(adapter);
                adapter.InsertCommand = new SqlCommand("INSERT INTO Ban_list(ID, Player_id, Administrators_id, Ban_type_id, Ban_time, Comment_from_admin) VALUES ('', '', '', '', '', '')", connection);
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int, 35, "ID"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Player_id", SqlDbType.Int, 35, "Player_id"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Administrators_id", SqlDbType.Int, 35, "Administrators_id"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Ban_type_id", SqlDbType.Int, 35, "Ban_type_id"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Ban_time", SqlDbType.NVarChar, 150, "Ban_time"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Comment_from_admin", SqlDbType.NVarChar, 220, "Comment_from_admin"));

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
        private void button4_Click(object sender, EventArgs e)
        {
            openchild(panel1, new FormBan());
        }
    }

}
