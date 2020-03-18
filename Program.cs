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

namespace Me
{
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = false;
            button4.Visible = true;
            button3.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox2.Visible = true;
            textBox1.Visible = false;
            button4.Visible = false;
            button3.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string age1 = textBox2.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string name1 = textBox1.Text;
            // Build connection string
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.UserID = "sa";
            builder.Password = "nadya";      
            builder.InitialCatalog = "Students";
            

            
            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();
          
                        SqlCommand command;
                        SqlDataReader dataReader;
                        String sql ,Output="";

                        sql = "SELECT Name ,Age ,Class ,[Class letter] ,Number FROM dbo.Info WHERE Name LIKE '" + name1 + "%'";
                        command = new SqlCommand(sql,connection);

                        dataReader = command.ExecuteReader();
                        {
                            while (dataReader.Read())
                            {
                                Output = Output + dataReader.GetString(0) +"-"+ dataReader.GetString(1) + "-" + dataReader.GetDecimal(2) + "-" + dataReader.GetString(3) + "-" + dataReader.GetString(4) + Environment.NewLine;
                            }
                        }
                        label2.Text=Output;

                    
                }

                finally
                {
                    connection.Close();
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string age1 = textBox2.Text;
            // Build connection string
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "localhost";
            builder.UserID = "sa";
            builder.Password = "nadya";
            builder.InitialCatalog = "Students";



            using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
            {
                try
                {
                    connection.Open();

                    SqlCommand command;
                    SqlDataReader dataReader;
                    String sql, Output1 = "";

                    sql = "SELECT Name ,Age ,Class ,[Class letter] ,Number FROM dbo.Info WHERE Age LIKE '" + age1 + "%'";
                    command = new SqlCommand(sql, connection);

                    dataReader = command.ExecuteReader();
                    {
                        while (dataReader.Read())
                        {
                            Output1 = Output1 + dataReader.GetString(0) + "-" + dataReader.GetString(1) + "-" + dataReader.GetDecimal(2) + "-" + dataReader.GetString(3) + "-" + dataReader.GetString(4) + Environment.NewLine;
                        }
                    }
                    label2.Text = Output1;


                }

                finally
                {
                    connection.Close();
                }
            }

        }
    }

}



