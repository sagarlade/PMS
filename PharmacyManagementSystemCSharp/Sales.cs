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
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pharmacyDataSet2.sales' table. You can move, or remove it, as needed.
            this.salesTableAdapter.Fill(this.pharmacyDataSet2.sales);
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True");
            con.Open();
            string str = "Select max(Id) from sales;";
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
                string str = "Insert into sales(c_id,name,gen,mob,addr,m_id,m_name,mfg,exp,a_on,price) values('" + textBox2.Text + "','" + textBox3.Text + "','"+ gen +"','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "')";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                string str1 = "select max(Id) from sales;";
                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Inserted Sales Data SuccessFully..");
                    using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True"))
                    {
                        string str2 = "Select * from sales";
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
                    textBox9.Text = "";
                    textBox10.Text = "";
                    textBox11.Text = "";
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True");
            con.Open();
            try
            {
                string getcust = "Select name,gen,mob,addr from cust where Id='" + textBox2.Text + "';";
                SqlCommand cmd = new SqlCommand(getcust, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox3.Text = dr.GetValue(0).ToString();
                    textBox4.Text = dr.GetValue(1).ToString();
                    textBox5.Text = dr.GetValue(2).ToString();
                    if (dr["gen"].ToString() == "Male")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True");
            con.Open();
            try
            {
                string getcust = "Select name,mfg,exp,a_on,price from Medi where Id='" + textBox6.Text + "';";
                SqlCommand cmd = new SqlCommand(getcust, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox7.Text = dr.GetValue(0).ToString();
                    textBox8.Text = dr.GetValue(1).ToString();
                    textBox9.Text = dr.GetValue(2).ToString();
                    textBox10.Text = dr.GetValue(3).ToString();
                    textBox11.Text = dr.GetValue(4).ToString();
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
                string getcust = "Select c_id,name,gen,mob,addr,m_id,m_name,mfg,exp,a_on,price from sales where Id='" + Convert.ToInt32(textBox1.Text) + "';";
                SqlCommand cmd = new SqlCommand(getcust, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr.GetValue(0).ToString();
                    textBox3.Text = dr.GetValue(1).ToString();
                    if (dr["gen"].ToString() == "Male")
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
                    textBox9.Text = dr.GetValue(8).ToString();
                    textBox10.Text = dr.GetValue(9).ToString();
                    textBox11.Text = dr.GetValue(10).ToString();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
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
                string getcust = "update sales set c_id='" + textBox2.Text + "',name='" + textBox3.Text + "',gen='" + gen + "',mob='" + textBox4.Text + "',addr='" + textBox5.Text + "',m_id='" + textBox6.Text + "',m_name='" + textBox7.Text + "',mfg='" + textBox8.Text + "',exp='" + textBox9.Text + "',a_on='"+ textBox10.Text  +"',price='" +textBox11.Text + "' where Id='" + textBox1.Text + "'; ";
                SqlCommand cmd = new SqlCommand(getcust, con);
                cmd.ExecuteNonQuery();
                string str1 = "select max(Id) from sales;";
                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Sales Data Updated Successfully.");
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox7.Text = "";
                    textBox8.Text = "";
                    textBox9.Text = "";
                    textBox10.Text = "";
                    using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True"))
                    {
                        string str2 = "Select * from sales";
                        SqlCommand cmd2 = new SqlCommand(str2, con1);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = new BindingSource(dt, null);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Sales Id.");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True");
            con.Open();
            try
            {
                string str = "delete from sales where Id='" + textBox1.Text + "';";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sales Record Deleted Successfully.");
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                using (con)
                {
                    string str2 = "Select * from sales";
                    SqlCommand cmd2 = new SqlCommand(str2, con);
                    SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    dataGridView1.DataSource = new BindingSource(dt, null);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
