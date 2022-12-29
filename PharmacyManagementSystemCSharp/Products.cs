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
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
        }

        private void Products_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pharmacyDataSet1.Medi' table. You can move, or remove it, as needed.
            this.mediTableAdapter.Fill(this.pharmacyDataSet1.Medi);
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True");
            con.Open();
            string str = "Select max(Id) from Medi;";
            SqlCommand cmd = new SqlCommand(str, con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                String val = dr[0].ToString();
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
            try
            {
                string str = "Insert into Medi(name,quantity,mfg,exp,box_no,a_on,price,s_id,s_name) values('" + textBox2.Text + "','" + textBox6.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox3.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "');";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                string str1 = "select max(Id) from Medi;";
                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Inserted Medicine Data SuccessFully..");
                    using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True"))
                    {
                        String str2 = "Select * from Medi";
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
                string getcust = "Select name,quantity,mfg,exp,box_no,a_on,price,s_id,s_name from Medi where Id='" + Convert.ToInt32(textBox1.Text) + "';";
                SqlCommand cmd = new SqlCommand(getcust, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr.GetValue(0).ToString();
                    textBox6.Text = dr.GetValue(1).ToString();
                    textBox4.Text = dr.GetValue(2).ToString();
                    textBox5.Text = dr.GetValue(3).ToString();
                    textBox7.Text = dr.GetValue(4).ToString();
                    textBox3.Text = dr.GetValue(5).ToString();
                    textBox8.Text = dr.GetValue(6).ToString();
                    textBox9.Text = dr.GetValue(7).ToString();
                    textBox10.Text = dr.GetValue(8).ToString();
                }
                else
                {
                    MessageBox.Show("Invalid Medicine Id.");
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
            try
            {
                string getcust = "update Medi set name='"+ textBox2.Text + "',quantity='" + textBox6.Text + "',mfg='" + textBox4.Text + "',exp='" + textBox5.Text + "',box_no='" + textBox7.Text + "',a_on='" + textBox3.Text + "',price='" + textBox8.Text + "',s_id='" + textBox9.Text + "',s_name='" + textBox10.Text + "' where Id='"+ textBox1.Text  +"'";
                SqlCommand cmd = new SqlCommand(getcust, con);
                cmd.ExecuteNonQuery();
                string str1 = "select max(Id) from Medi;";
                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Medicine Data Updated Successfully.");
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
                        string str2 = "Select * from Medi";
                        SqlCommand cmd2 = new SqlCommand(str2, con1);
                        SqlDataAdapter sda = new SqlDataAdapter(cmd2);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        dataGridView1.DataSource = new BindingSource(dt, null);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Medicine Id.");
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
                string str = "delete from Medi where Id='"+ textBox1.Text +"';";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Medicine Deleted Successfully.");
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
                    String str2 = "Select * from Medi";
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
