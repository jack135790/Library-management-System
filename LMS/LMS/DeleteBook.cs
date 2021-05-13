using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LMS
{
    public partial class DeleteBook : Form
    {
        public DeleteBook()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "No")
            {

                SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\LMS\\LMS\\Library.mdf;Integrated Security=True;User Instance=True");
                SqlCommand com = new SqlCommand("DELETE Book where isbn='" + textBox1.Text + "' and issuebook='" + textBox2.Text + "'", sc);
                sc.Open();
                //com.ExecuteNonQuery();
                SqlDataAdapter sda = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;

                MessageBox.Show("Deleted");
                DisplayData();

            }
            else
            {
                MessageBox.Show("Issue book cannot be deleted");
            }
            
        }
        public void DisplayData()
        {
            SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\LMS\\LMS\\Library.mdf;Integrated Security=True;User Instance=True");
            SqlCommand com = new SqlCommand("SELECT * from Book", sc);
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void DeleteBook_Load(object sender, EventArgs e)
        {
           //comboBox1 =AddBook.ib;
            DisplayData();
        }

       
        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
 
        }
    }
}
