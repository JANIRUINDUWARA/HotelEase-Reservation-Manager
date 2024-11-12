using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservationSystem___CW
{
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=JANIRU_INDUWARA\SQLEXPRESS;initial Catalog=Hotel_Management_System;Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            string sql = "SELECT * FROM usertbl WHERE username=@username AND password=@password";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@username", this.textBox1.Text);
            com.Parameters.AddWithValue("@password", this.textBox2.Text);

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read() == true)
            {
                mainform main = new mainform();
                main.Show();
                this.Hide();
            }
           
            con.Close();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = '\0';
            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}

