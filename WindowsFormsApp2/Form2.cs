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

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string text1 = textBox1.Text;
                string text2 = textBox3.Text;
                string text3 = textBox2.Text;
                string text4 = textBox4.Text;
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Medical;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                conn = new SqlConnection(conn.ConnectionString);
                conn.Open();
               // String cmd = "INSERT into Medicine(Medicine_Id,Medicine_Name,Units,Price) VALUES (@text1,@text2,@text3,@text4)";
                SqlCommand command = new SqlCommand("INSERT Medicine(Medicine_Id, Medicine_Name, Units, Price) VALUES(@text1, @text2, @text3, @text4);", conn);
                command.Parameters.AddWithValue("@text1", text1);
                command.Parameters.AddWithValue("@text2", text2);
                command.Parameters.AddWithValue("@text3", text3);
                command.Parameters.AddWithValue("@text4", text4);
                command.ExecuteNonQuery();
                MessageBox.Show("success");
                conn.Close();
                this.Close();
            }
            catch (SqlException exc )when (exc.Number==2601)
            {
              MessageBox.Show("Already existed");
               
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            String text = textBox1.Text;
            SqlConnection con = null;
            String connectionstring;
            connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Medical;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            con = new SqlConnection(connectionstring);
            con.Open();
            String cmd = "SELECT Medicine_Id FROM Medicine";
            SqlCommand command = new SqlCommand(cmd, con);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
           for(int i=0;i<ds.Tables[0].Rows.Count;i++)
            {
                try
                {
                    DataRow r = ds.Tables[0].Rows[i];
                    MyCollection.Add(r.Field<String>(0));
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Error");
                }
            }
            textBox1.AutoCompleteCustomSource = MyCollection;
            con.Close();
        }
    }
}
//CREATE TABLE[dbo].[Medicine]
//(

//   [Id] INT          IDENTITY(1, 1) NOT NULL,

//[Medicine_Id]   VARCHAR(50) NOT NULL,

//[Medicine_Name] VARCHAR(50) NOT NULL,

//[Units]         INT NOT NULL,
//    [Price] INT NOT NULL,
//    PRIMARY KEY CLUSTERED([Id] ASC)
//);
