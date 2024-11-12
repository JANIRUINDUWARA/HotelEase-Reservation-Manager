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
    public partial class billsection : Form
    {
        public billsection()
        {
            InitializeComponent();
        }

        private void load_Click(object sender, EventArgs e)
        {
            //create a connection with SQL server
            string cs = @"Data Source=JANIRU_INDUWARA\SQLEXPRESS;initial Catalog=Hotel_Management_System;Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //Define a command
            string sql = "Select * from customer_table";
            SqlCommand com = new SqlCommand(sql, con);

            //access data using datareader method
            SqlDataReader dr = com.ExecuteReader();
            dr.Read();

            //bind data with controls
            this.c_id.Text = dr.GetValue(0).ToString();
            this.first_name.Text = dr.GetValue(1).ToString();
            this.last_name.Text = dr.GetValue(2).ToString();
            this.email.Text = dr.GetValue(3).ToString();
            this.room_type.Text = dr.GetValue(4).ToString();
            this.no_guests.Text = dr.GetValue(5).ToString();
            this.Arrival_Date.Text = dr.GetValue(6).ToString();
            this.Departure_Date.Text = dr.GetValue(7).ToString();

            //calculate section
            this.c_first_name.Text = dr.GetValue(1).ToString();
            this.c_room_type.Text = dr.GetValue(4).ToString();
            this.c_no_guests.Text = dr.GetValue(5).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Create a Connection with SQL Server
            string cs = @"Data Source=JANIRU_INDUWARA\SQLEXPRESS;initial Catalog=Hotel_Management_System;Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //Define a Command
            string sql = "SELECT * FROM customer_table WHERE c_id=@c_id";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@c_id", this.search.Text);

            //Access Data using DataReader Method
            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read() == true)
            {
                //Bind Data with Controls
                this.c_id.Text = dr.GetValue(0).ToString();
                this.first_name.Text = dr.GetValue(1).ToString();
                this.last_name.Text = dr.GetValue(2).ToString();
                this.email.Text = dr.GetValue(3).ToString();
                this.room_type.Text = dr.GetValue(4).ToString();
                this.no_guests.Text = dr.GetValue(5).ToString();
                this.Arrival_Date.Text = dr.GetValue(6).ToString();
                this.Departure_Date.Text = dr.GetValue(7).ToString();

                //Calculation section
                this.c_first_name.Text = dr.GetValue(1).ToString();
                this.c_room_type.Text = dr.GetValue(4).ToString();
                this.c_no_guests.Text = dr.GetValue(5).ToString();

            }
            else
            {
                MessageBox.Show("No records found");
            }

            //Disconnect from Server
            con.Close();
        }

        private void Calculate_Click(object sender, EventArgs e)
        {
            try
            {
                int price;
                string cs = @"Data Source=JANIRU_INDUWARA\SQLEXPRESS;Initial Catalog=Hotel_Management_System;Integrated Security=True";

                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    // Calculate the price based on room type
                    string c_room_type = this.c_room_type.Text;
                    if (c_room_type == "Executive Room")
                    {
                        price = 10000;
                    }
                    else if (c_room_type == "Deluxe Room")
                    {
                        price = 5000;
                    }
                    else if (c_room_type == "Standard Room")
                    {
                        price = 3000;
                    }
                    else
                    {
                        throw new Exception("Invalid room type.");
                    }

                    // Calculate the total bill
                    int c_no_guests = Convert.ToInt32(this.c_no_guests.Text);
                    int no_of_days = Convert.ToInt32(this.no_of_days.Text);
                    int total_bill = (price * no_of_days) + (c_no_guests * 1000 * no_of_days);

                    // Set the calculated total bill to the text box
                    this.total_bill.Text = total_bill.ToString();

                    // Insert the data into billtbl
                    string sql = "INSERT INTO billtbl(bill_no, c_first_name, c_room_type, c_no_guests, no_of_days, total_bill) " +
                                 "VALUES(@bill_no, @c_first_name, @c_room_type, @c_no_guests, @no_of_days, @total_bill)";

                    using (SqlCommand com = new SqlCommand(sql, con))
                    {
                        com.Parameters.AddWithValue("@bill_no", this.bill_no.Text);
                        com.Parameters.AddWithValue("@c_first_name", this.c_first_name.Text);
                        com.Parameters.AddWithValue("@c_room_type", c_room_type);
                        com.Parameters.AddWithValue("@c_no_guests", c_no_guests);
                        com.Parameters.AddWithValue("@no_of_days", no_of_days);
                        com.Parameters.AddWithValue("@total_bill", total_bill); 

                        com.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                MessageBox.Show("SQL Error: " + sqlEx.Message);
            }
            catch (FormatException formatEx)
            {
                MessageBox.Show("Format Error: " + formatEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void g_bill_no_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=JANIRU_INDUWARA\SQLEXPRESS;initial Catalog=Hotel_Management_System;Integrated Security = True";

            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //command
            string sql1 = "SELECT MAX(bill_no) FROM billtbl";
            SqlCommand com1 = new SqlCommand(sql1, con);

            SqlDataReader dr1 = com1.ExecuteReader();
            string bill_id = null;
            string new_id = null;

            if (dr1.Read() && dr1[0] != DBNull.Value)
            {
                bill_id = dr1.GetValue(0).ToString();
                if (bill_id.Length >= 4)
                {
                    int id = Convert.ToInt32(bill_id.Substring(2, 2));
                    id++;
                    if (id < 10)
                    {
                        new_id = "B00" + id;
                    }
                    else if (id < 100)
                    {
                        new_id = "B0" + id;
                    }
                    else if (id < 1000)
                    {
                        new_id = "B" + id;
                    }
                }
                else
                {
                    MessageBox.Show("Unexpected Bill ID format.");
                }
            }
            else
            {
                new_id = "B001";
            }

            this.bill_no.Text = new_id;
            con.Close();
        }

        private void billsection_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source=JANIRU_INDUWARA\SQLEXPRESS;initial Catalog=Hotel_Management_System;Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM billtbl",con );
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void print_Click(object sender, EventArgs e)
        {
            billreport billreport = new billreport(bill_no.Text);
            billreport.Show();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
