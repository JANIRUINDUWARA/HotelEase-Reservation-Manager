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
using System.Data.SqlClient;

namespace HotelReservationSystem___CW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source=JANIRU_INDUWARA\SQLEXPRESS; Initial Catalog=Hotel_Management_System; Integrated Security=True";

            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //command
            string sql = "SELECT MAX(c_id) FROM customer_table";
            SqlCommand com = new SqlCommand(sql, con);

            SqlDataReader dr = com.ExecuteReader();
            string cur_id = null;
            string new_id = null;

            if (dr.Read() && dr[0] != DBNull.Value)
            {
                cur_id = dr.GetValue(0).ToString();
                if (cur_id.Length >= 4)
                {
                    int id = Convert.ToInt32(cur_id.Substring(2, 2));
                    id++;
                    if (id < 10)
                    {
                        new_id = "C00" + id;
                    }
                    else if (id < 100)
                    {
                        new_id = "C0" + id;
                    }
                    else if (id < 1000)
                    {
                        new_id = "C" + id;
                    }
                }
                else
                {                    
                    MessageBox.Show("Unexpected customer ID format.");
                }
            }
            else
            {                
                new_id = "C001";
            }

            this.c_id.Text = new_id;
            con.Close();
        }

        private void save_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source =JANIRU_INDUWARA\SQLEXPRESS; Initial Catalog = Hotel_Management_System; Integrated Security = True";

            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //command
            string sql = "INSERT INTO customer_table(c_id,first_name,last_name,email,room_type,no_guests,Arrival_Date,Departure_Date)" +
                "VALUES(@c_id,@first_name,@last_name,@email,@room_type,@no_guests,@Arrival_Date,@Departure_Date)";

            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@c_id", this.c_id.Text);
            com.Parameters.AddWithValue("@first_name", this.first_name.Text);
            com.Parameters.AddWithValue("@last_name", this.last_name.Text);
            com.Parameters.AddWithValue("@email", this.email.Text);
            com.Parameters.AddWithValue("@room_type", this.room_type.Text);
            com.Parameters.AddWithValue("@no_guests", Convert.ToInt32(this.no_guests.Value));
            com.Parameters.AddWithValue("@Arrival_Date", this.Arrival_Date.Text);
            com.Parameters.AddWithValue("@Departure_Date", this.Departure_Date.Text);

            //Execute command to insert data
            int ret = com.ExecuteNonQuery();
            MessageBox.Show("Customer added : " + ret);

            //Disconnect from server
            con.Close();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}