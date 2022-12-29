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
    public partial class Supplier : Form
    {
        public Supplier()
        {
            InitializeComponent();
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pharmacyDataSet.supp' table. You can move, or remove it, as needed.
            this.suppTableAdapter.Fill(this.pharmacyDataSet.supp);
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True");
            con.Open();
            string str = "Select max(Id) from supp;";
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
            try
            {
                string str = "Insert into supp(name,email,mobile,addr,s_code) values('" + textBox2.Text + "','" + textBox4.Text  + "','" + textBox5.Text + "','" + textBox6.Text + "','"+ textBox3.Text +"');";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                string str1 = "select max(Id) from supp;";
                SqlCommand cmd1 = new SqlCommand(str1, con);
                SqlDataReader dr = cmd1.ExecuteReader();
                if (dr.Read())
                {
                    MessageBox.Show("Inserted Supplier Data SuccessFully..");
                    using (SqlConnection con1 = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Sagar\Desktop\C# Programe\PMS\PharmacyManagementSystemCSharp\pharmacy.mdf"";Integrated Security=True"))
                    {
                        string str2 = "Select * from supp";
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
                string getcust = "Select name,email,mobile,addr,s_code from supp where Id='" + Convert.ToInt32(textBox1.Text) + "';";
                SqlCommand cmd = new SqlCommand(getcust, con);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    textBox2.Text = dr.GetValue(0).ToString();
                    textBox3.Text = dr.GetValue(4).ToString();
                    textBox4.Text = dr.GetValue(1).ToString();
                    textBox5.Text = dr.GetValue(2).ToString();
                    textBox6.Text = dr.GetValue(3).ToString();
                }
                else
                {
                    MessageBox.Show("Invalid Supplier Id.");
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

        }
    }
}
