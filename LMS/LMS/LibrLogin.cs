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
    public partial class LibrLogin : Form
    {
        public LibrLogin()
        {
            InitializeComponent();
        }

        private void LibrLogin_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DisplayData();
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

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do You Want To Update Book", "UpdateBooks", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                UpdateBook ub = new UpdateBook();
                ub.Show();
            }
            else
            {
                MessageBox.Show("You have Cancel");
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DeleteBook db = new DeleteBook();
            db.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {    
            SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\LMS\\LMS\\Library.mdf;Integrated Security=True;User Instance=True");
            SqlCommand com = new SqlCommand("SELECT * from Librarian where Lib_id='"+textBox1.Text+"'and Lib_password='"+textBox2.Text+"'", sc);
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            //dataGridView1.DataSource = dt;
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Invalid Login ");
            }
            else
            {
                MessageBox.Show("Success");
                linkLabel1.Enabled = true;
                linkLabel2.Enabled = true;
                linkLabel3.Enabled = true;
                linkLabel4.Enabled = true;
                button1.Enabled = false;
                button2.Enabled = true;
                linkLabel5.Enabled = true;
                linkLabel6.Enabled = true;


            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr=MessageBox.Show("Do You Want To Add Book","AddBooks",MessageBoxButtons.YesNo);
             if (dr == DialogResult.Yes)
            {
                 AddBook ad=new AddBook();
                 ad.Show();
            }
            else
            {
                MessageBox.Show("You have Cancel");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Logout");
            button1.Enabled = true;
            button2.Enabled = false;
            linkLabel1.Enabled = false;
            linkLabel2.Enabled = false;
            linkLabel3.Enabled = false;
            linkLabel4.Enabled = false;
            linkLabel5.Enabled = false;
            linkLabel6.Enabled = false;

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\LMS\\LMS\\Library.mdf;Integrated Security=True;User Instance=True");
            SqlCommand com = new SqlCommand("SELECT * from Book where issuebook LIKE '%Yes%' ", sc);
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\LMS\\LMS\\Library.mdf;Integrated Security=True;User Instance=True");
            SqlCommand com = new SqlCommand("SELECT * from Book where returnstatus LIKE '%Yes%' ", sc);
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        
    }
}
