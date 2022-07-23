using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ConnectingToSql.connectToSql;

namespace ConnectingToSql
{
    public partial class Form1 : Form
    {
        connectSQLServer conSqlServ = new connectSQLServer();
        SqlConnection sqlcon = new SqlConnection();
        SqlCommand cmd = new SqlCommand();

        public Form1()
        {
            InitializeComponent();
           // sqlcon = conSqlServ.GetConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connstring = @"Data Source =RODINASUS\SQLEXPRESS01;Initial Catalog=Testdb;Integrated Security=true";
            SqlConnection con = new SqlConnection(connstring);
            con.Open();
            string query = "Select * from Employee";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string output = "Output = " + reader.GetValue(0) + "-" + reader.GetValue(1) + "-" + reader.GetValue(2)+ "-" + reader.GetValue(3)+ "-" + 
                    reader.GetValue(4);
                textBox1.Text += reader.GetValue(0).ToString()+ " " + reader.GetValue(1).ToString()+ " " + reader.GetValue(2).ToString()+ " " + 
                    reader.GetValue(3).ToString() + " " + reader.GetValue(4).ToString() + Environment.NewLine;
                // Hämtar data från SQL och sedan visar det på textboxen
            }

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            sqlcon = conSqlServ.GetConnection();
            MessageBox.Show("Connect Succesfull!");

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            cmd = new SqlCommand("insert into student(stdName,stdClass,stdAdress,stdContact)values('"+txtName.Text+"','"+cmbClass.Text+"','"+txtAdress.Text+"','"+txtContact.Text+"')",sqlcon);
            cmd.ExecuteNonQuery();
            MessageBox.Show("RECORDS INSERTED GOOD JOB!");
            sqlcon.Close();

        }
    }
}
