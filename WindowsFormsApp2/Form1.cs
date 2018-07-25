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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                String text = textBox1.Text;
                SqlConnection con = null;
                String connectionstring;
                connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Medical;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                con = new SqlConnection(connectionstring);
                con.Open();
                String cmd = "SELECT Medicine_Id,Medicine_Name,units,price FROM Medicine Where Medicine_Id like '" + text + "%'";
                SqlCommand command = new SqlCommand(cmd, con);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    try
                    {
                        DataRow r = ds.Tables[0].Rows[i];
                        MyCollection.Add(r.Field<String>(0));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error");
                    }
                }
                textBox1.AutoCompleteCustomSource = MyCollection;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
