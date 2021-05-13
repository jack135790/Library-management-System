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
    public partial class AddLibrarian : Form
    {
        public AddLibrarian()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\LMS\\LMS\\Library.mdf;Integrated Security=True;User Instance=True");
            SqlCommand com = new SqlCommand("INSERT into Librarian (Lib_id,Lib_name,Lib_Password,Lib_no,Lib_addr) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text.ToString() + "','" + richTextBox1.Text +  "') ", sc);
            sc.Open();
            com.ExecuteNonQuery();
            MessageBox.Show("Inserted");
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
