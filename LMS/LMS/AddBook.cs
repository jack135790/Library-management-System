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
    public partial class AddBook : Form
    {
        //public static string ib = "";
        
        public AddBook()
        {
            InitializeComponent();
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Yes")
            {
                SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\LMS\\LMS\\Library.mdf;Integrated Security=True;User Instance=True");
                SqlCommand com = new SqlCommand("INSERT into Book (isbn,bookname,bookauthor,issuedate,returndate,issuebook,returnstatus) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text.ToString() + "','" + dateTimePicker2.Text.ToString() + "','"+comboBox1.SelectedItem+"','"+comboBox2.SelectedItem+"') ", sc);
                sc.Open();
                com.ExecuteNonQuery();
               
                MessageBox.Show("Inserted");
                DisplayData();
            }
            else
            {
                SqlConnection sc = new SqlConnection("Data Source=.\\SQLEXPRESS;AttachDbFilename=C:\\Users\\admin\\Desktop\\LMS\\LMS\\Library.mdf;Integrated Security=True;User Instance=True");
                SqlCommand com = new SqlCommand("INSERT into Book (isbn,bookname,bookauthor,issuebook) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','"  + comboBox1.SelectedItem + "') ", sc);
                sc.Open();
                com.ExecuteNonQuery();
                MessageBox.Show("Inserted");
                DisplayData();
                
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "No")
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                comboBox2.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                comboBox2.Enabled = true;
            }
        }

        private void AddBook_Load(object sender, EventArgs e)
        {
            
        }

      

      
    }
}
