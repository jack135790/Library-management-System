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
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void AdminLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "admin" && textBox2.Text == "123")
            {
                // label3.Text = "Login";
                MessageBox.Show("Login success");
                linkLabel1.Enabled = true;
                linkLabel2.Enabled = true;
                linkLabel3.Enabled = true;
                linkLabel4.Enabled = true;
                button2.Enabled = true;
                button1.Enabled = false;
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
            }
                
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you Want to add?", "Add", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                AddLibrarian al = new AddLibrarian();
                al.Show();
            }
            else
            {
                MessageBox.Show("You have Cancel");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\LMS\\LMS\\Library.mdf;Integrated Security=True;User Instance=True");
            SqlCommand com = new SqlCommand("SELECT * from Librarian", sc);
            sc.Open();
            SqlDataAdapter sda = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you Want to Update?", "Update", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                LibrUpdate lu = new LibrUpdate();
                lu.Show();
            }
            else
            {
                MessageBox.Show("You have cancel operation");
            }
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you Want to Delete?", "Delete", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                DeleteLibr dl = new DeleteLibr();
                dl.Show();
            }
            else
            {
                MessageBox.Show("You have cancel operation");
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
            DataTable dt = new DataTable();
            dataGridView1.DataSource = dt;
        }

       
    }
}
