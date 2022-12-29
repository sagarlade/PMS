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

namespace PharmacyManagementSystemCSharp
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True");
            con.Open();
            string gen = string.Empty;
            if (radioButton1.Checked)
            {
                gen = "Male";
            }
            else
            {
                gen = "Female";
            }
            try
            {
                string str = "Insert into cust(name,gen,mob,addr) values('"+textBox2.Text +"','"+ gen +"','"+ textBox3.Text  +"','"+ textBox4.Text  +"');";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                string str1 = "select max(Id) from cust;";
                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Inserted Customer Data SuccessFully..");
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True");
            con.Open();
            try
            {
                string getcust = "Select name,gen,mob,addr from cust where Id='" + Convert.ToInt32(textBox1.Text) + "';";
                SqlCommand cmd = new SqlCommand(getcust, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr.GetValue(0).ToString();
                    textBox3.Text = dr.GetValue(2).ToString();
                    textBox4.Text = dr.GetValue(3).ToString();
                    if (dr["gen"].ToString() == "Male")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Id.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void Customer_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True");
            con.Open();
            string str = "Select max(Id) from cust;";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string val = dr[0].ToString();
                if (val == "")
                {
                    textBox1.Text = "1";
                }
                else
                {
                    int a;
                    a = Convert.ToInt32(dr[0].ToString());
                    a = a + 1;
                    textBox1.Text = a.ToString();
                }
            }
        }
    }
}
