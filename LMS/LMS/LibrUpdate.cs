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
    public partial class LibrUpdate : Form
    {
        public LibrUpdate()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\LMS\\LMS\\Library.mdf;Integrated Security=True;User Instance=True");
            SqlCommand com = new SqlCommand("UPDATE Librarian SET Lib_name='"+textBox1.Text+"',Lib_password ='"+textBox2.Text+"',Lib_no='"+textBox3.Text+"',Lib_addr='"+richTextBox1.Text+"' where Lib_id='"+textBox4.Text+"'", sc);
            sc.Open();
            //com.ExecuteNonQuery();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            MessageBox.Show("Updated");
            DisplayData();
        }
        public void DisplayData()
        {
            SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\LMS\\LMS\\Library.mdf;Integrated Security=True;User Instance=True");
            SqlCommand com = new SqlCommand("SELECT * from Librarian", sc);
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
