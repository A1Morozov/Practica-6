using System;
using System.Windows.Forms;

namespace Practica6
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonAdmin_Click(object sender, EventArgs e)
        {
            openchild(panel2, new FormAdmin());
        }
        private void buttonBan_Click(object sender, EventArgs e)
        {
            openchild(panel2, new FormBan());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 Win = new Form1();
            Win.Show();
            this.Hide();
        }
        private void buttonPlayer_Click(object sender, EventArgs e)
        {
            openchild(panel2, new FormPlayer());
        }

    }
}
