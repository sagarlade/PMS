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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void Payment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pharmacyDataSet3.pay' table. You can move, or remove it, as needed.
            this.payTableAdapter.Fill(this.pharmacyDataSet3.pay);
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True");
            con.Open();
            string str = "Select max(Id) from pay;";
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True");
            con.Open();
            string paymet = string.Empty;
            if (radioButton1.Checked)
            {
                paymet = "Cash";
            }
            else
            {
                paymet = "Online";
            }
            try
            {
                string str = "Insert into pay(s_id,name,mobile,addr,m_name,a_on,price,pay_type) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + paymet + "');";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                string str1 = "select max(Id) from pay;";
                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Inserted Payment Data SuccessFully..");
                    using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True"))
                    {
                        string str2 = "Select * from pay";
                        SqlCommand cmd2 = new SqlCommand(str2, con1);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = new BindingSource(dt, null);
                    }
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    
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
                string getcust = "Select s_id,name,mobile,addr,m_name,a_on,price,pay_type from pay where Id='" + Convert.ToInt32(textBox1.Text) + "';";
                SqlCommand cmd = new SqlCommand(getcust, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr.GetValue(0).ToString();
                    textBox3.Text = dr.GetValue(1).ToString();
                    if (dr["pay_type"].ToString() == "Cash")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                    textBox4.Text = dr.GetValue(3).ToString();
                    textBox5.Text = dr.GetValue(4).ToString();
                    textBox6.Text = dr.GetValue(5).ToString();
                    textBox7.Text = dr.GetValue(6).ToString();
                    textBox8.Text = dr.GetValue(7).ToString();
                    
                }
                else
                {
                    MessageBox.Show("Invalid Payment Id.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True");
            con.Open();
            try
            {
                string getcust = "Select name,mob,addr,m_name,a_on,price from sales where Id='" + textBox2.Text + "';";
                SqlCommand cmd = new SqlCommand(getcust, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox3.Text = dr.GetValue(0).ToString();
                    textBox4.Text = dr.GetValue(1).ToString();
                    textBox5.Text = dr.GetValue(2).ToString();
                    textBox6.Text = dr.GetValue(3).ToString();
                    textBox7.Text = dr.GetValue(4).ToString();
                    textBox8.Text = dr.GetValue(5).ToString();
                }
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
