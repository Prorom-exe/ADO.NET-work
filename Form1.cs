using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsF
{
    public partial class Form1 : Form

    {   //connect witg sql
        public string StrConn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Projects\WindowsF\Database1.mdf;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

         public void Form1_Load(object sender, EventArgs e)
        {
           
            
             // viev data base                         
            string StrCmd = "SELECT * FROM Clients";
            SqlDataAdapter AdapClients = new SqlDataAdapter(StrCmd,StrConn);
            DataTable Clients = new DataTable();
            AdapClients.Fill(Clients);
            dataGridView1.DataSource = Clients;
        }
        //Search clients
        private void button2_Click(object sender, EventArgs e)

         {
            string Sort = textBox1.Text;

            string StrCmd = $"SELECT * FROM Clients Where Name = N'{Sort}'";
            SqlDataAdapter AdapClients = new SqlDataAdapter(StrCmd, StrConn);
            DataTable Clients = new DataTable();
            AdapClients.Fill(Clients);
            dataGridView1.DataSource = Clients;





        }

         void button3_Click(object sender, EventArgs e)
        {
            string StrCmd = "SELECT * FROM Clients";
            SqlDataAdapter AdapClients = new SqlDataAdapter(StrCmd, StrConn);
            DataTable Clients = new DataTable();
            AdapClients.Fill(Clients);
            dataGridView1.DataSource = Clients;
        }
        // Costmeat 
        int Chiken = 130;
        int Beef = 400;
        int Pig = 200;

        private float math(string meat) 
        {
            switch (meat)
            {
                case "Курица":
                    return Chiken;
                    
                case "Говядина":
                    return Beef;
                    
                case "Свинина":
                    return Pig;
                    
                default:
                    return 0;
                    
            }
        } 
        private void label4_Click(object sender, EventArgs e)
        {
            this.label4.Text = "Говядина - 400р/кг \n Свинина-200р/кг \n Курица-130р/кг";

        }
        // add... in DB

        private void button1_Click(object sender, EventArgs e)


        {
            float cost = (float)numericUpDown1.Value * math(textBox1.Text);
            string SqlExpression = $"INSERT INTO Clients (Name,Meat,Mass,Cost) VALUES({textBox1.Text}{textBox2.Text}{(int)numericUpDown1.Value}{cost}) ";
            using (SqlConnection connection = new SqlConnection(StrConn))
            {
                connection.Open();
            }
               
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
