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
    public partial class Database : Form
    {
        DataSet ds;
        int i = 0;
        public Database()
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
            this.first_name.Text= dr.GetValue(1).ToString(); 
            this.last_name.Text = dr.GetValue(2).ToString(); 
            this.email.Text = dr.GetValue(3).ToString();
            this.room_type.Text = dr.GetValue(4).ToString();
            this.no_guests.Text = dr.GetValue(5).ToString();
            this.Arrival_Date.Text = dr.GetValue(6).ToString();
            this.Departure_Date.Text = dr.GetValue(7).ToString();
            
            //Disconnect From Server 
            con.Close();
        }

        private void loaddap_Click(object sender, EventArgs e)
        {
            //create a connection with SQL server
            string cs = @"Data Source=JANIRU_INDUWARA\SQLEXPRESS;initial Catalog=Hotel_Management_System;Integrated Security = True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //Define a command
            string sql = "Select * from customer_table";
            SqlCommand com = new SqlCommand(sql, con);

            //access data using dataAdaptor method
            SqlDataAdapter dap = new SqlDataAdapter(com);
            ds = new DataSet();
            dap.Fill(ds);

            //bind data with controls
            this.c_id.Text = ds.Tables[0].Rows[0][0].ToString();
            this.first_name.Text= ds.Tables[0].Rows[0][1].ToString();
            this.last_name.Text = ds.Tables[0].Rows[0][2].ToString();
            this.email.Text = ds.Tables[0].Rows[0][3].ToString();
            this.room_type.Text = ds.Tables[0].Rows[0][4].ToString();
            this.no_guests.Text = ds.Tables[0].Rows[0][5].ToString();
            this.Arrival_Date.Text = ds.Tables[0].Rows[0][6].ToString();
            this.Departure_Date.Text = ds.Tables[0].Rows[0][7].ToString();

            this.dataGridView1.DataSource = ds.Tables[0];
            this.dataGridView1.Refresh();

            //Disconnect From Server 
            con.Close();
            
        }

        private void next_Click(object sender, EventArgs e)
        {
            if (i < ds.Tables[0].Rows.Count - 1)
            {
                i++;
                //Bind data with Controls
                this.c_id.Text = ds.Tables[0].Rows[i][0].ToString();
                this.first_name.Text = ds.Tables[0].Rows[i][1].ToString();
                this.last_name.Text = ds.Tables[0].Rows[i][2].ToString();
                this.email.Text = ds.Tables[0].Rows[i][3].ToString();
                this.room_type.Text = ds.Tables[0].Rows[i][4].ToString();
                this.no_guests.Text = ds.Tables[0].Rows[i][5].ToString();
                this.Arrival_Date.Text = ds.Tables[0].Rows[i][6].ToString();
                this.Departure_Date.Text = ds.Tables[0].Rows[i][7].ToString();
            }            
        }

        private void previous_Click(object sender, EventArgs e)
        {
            if (i > 0)
            {
                i--;                
                this.c_id.Text = ds.Tables[0].Rows[i][0].ToString();
                this.first_name.Text = ds.Tables[0].Rows[i][1].ToString();
                this.last_name.Text = ds.Tables[0].Rows[i][2].ToString();
                this.email.Text = ds.Tables[0].Rows[i][3].ToString();
                this.room_type.Text = ds.Tables[0].Rows[i][4].ToString();
                this.no_guests.Text = ds.Tables[0].Rows[i][5].ToString();
                this.Arrival_Date.Text = ds.Tables[0].Rows[i][6].ToString();
                this.Departure_Date.Text = ds.Tables[0].Rows[i][7].ToString();
            }
        }

        private void first_Click(object sender, EventArgs e)
        {
            i = 0;
            //Bind data with Controls
            this.c_id.Text = ds.Tables[0].Rows[i][0].ToString();
            this.first_name.Text = ds.Tables[0].Rows[i][1].ToString();
            this.last_name.Text = ds.Tables[0].Rows[i][2].ToString();
            this.email.Text = ds.Tables[0].Rows[i][3].ToString();
            this.room_type.Text = ds.Tables[0].Rows[i][4].ToString();
            this.no_guests.Text = ds.Tables[0].Rows[i][5].ToString();
            this.Arrival_Date.Text = ds.Tables[0].Rows[i][6].ToString();
            this.Departure_Date.Text = ds.Tables[0].Rows[i][7].ToString();
        }

        private void last_Click(object sender, EventArgs e)
        {
            i = ds.Tables[0].Rows.Count - 1;
            //Bind data with Controls
            this.c_id.Text = ds.Tables[0].Rows[i][0].ToString();
            this.first_name.Text = ds.Tables[0].Rows[i][1].ToString();
            this.last_name.Text = ds.Tables[0].Rows[i][2].ToString();
            this.email.Text = ds.Tables[0].Rows[i][3].ToString();
            this.room_type.Text = ds.Tables[0].Rows[i][4].ToString();
            this.no_guests.Text = ds.Tables[0].Rows[i][5].ToString();
            this.Arrival_Date.Text = ds.Tables[0].Rows[i][6].ToString();
            this.Departure_Date.Text = ds.Tables[0].Rows[i][7].ToString();
        }

        private void save_Click(object sender, EventArgs e)
        {
            //Create a Connection
            string cs = @"Data Source=JANIRU_INDUWARA\SQLEXPRESS;initial Catalog=Hotel_Management_System;Integrated Security = True";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();

            //Command
            string sql = "INSERT INTO customer_table(c_id,first_name,last_name,email,room_type,no_guests,Arrival_Date,Departure_Date)" +
                "VALUES(@c_id,@first_name,@last_name,@email,@room_type,@no_guests,@Arrival_Date,@Departure_Date)";

            SqlCommand com = new SqlCommand(sql, conn);
            com.Parameters.AddWithValue("@c_id", this.c_id.Text);
            com.Parameters.AddWithValue("@first_name", this.first_name.Text);
            com.Parameters.AddWithValue("@last_name", this.last_name.Text);
            com.Parameters.AddWithValue("@email", this.email.Text);
            com.Parameters.AddWithValue("@room_type", this.room_type.Text);
            com.Parameters.AddWithValue("@no_guests", this.no_guests.Text);
            com.Parameters.AddWithValue("@Arrival_Date", this.Arrival_Date.Text);
            com.Parameters.AddWithValue("@Departure_Date", this.Departure_Date.Text);

            //Execute Command to insert data
            int ret = com.ExecuteNonQuery();
            MessageBox.Show("No of records inserted: " + ret);

            //Disconnect from server
            conn.Close();
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
            }
            else
            {
                MessageBox.Show("No records found");
            }

            //Disconnect from Server
            con.Close();
        }

        private void update_Click(object sender, EventArgs e)
        {
            //Create a Connection
            string cs = @"Data Source=JANIRU_INDUWARA\SQLEXPRESS;initial Catalog=Hotel_Management_System;Integrated Security = True";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();

            //Command
            string sql = "UPDATE customer_table SET first_name=@first_name,last_name=@last_name,email=@email,room_type=@room_type,no_guests=@no_guests,Arrival_Date=@Arrival_Date,Departure_Date=@Departure_Date WHERE c_id=@c_id";
            SqlCommand com = new SqlCommand(sql, conn);
            com.Parameters.AddWithValue("@c_id", this.c_id.Text);
            com.Parameters.AddWithValue("@first_name", this.first_name.Text);
            com.Parameters.AddWithValue("@last_name", this.last_name.Text);
            com.Parameters.AddWithValue("@email", this.email.Text);
            com.Parameters.AddWithValue("@room_type", this.room_type.Text);
            com.Parameters.AddWithValue("@no_guests", this.no_guests.Text);
            com.Parameters.AddWithValue("@Arrival_Date", this.Arrival_Date.Text);
            com.Parameters.AddWithValue("@Departure_Date", this.Departure_Date.Text);

            //Execute Command to insert data
            int ret = com.ExecuteNonQuery();
            MessageBox.Show("No of records updated: " + ret);

            //Disconnect from server
            conn.Close();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            //Create a Connection
            string cs = @"Data Source=JANIRU_INDUWARA\SQLEXPRESS;initial Catalog=Hotel_Management_System;Integrated Security = True";
            SqlConnection conn = new SqlConnection(cs);
            conn.Open();

            //Command
            string sql = "DELETE FROM customer_table WHERE c_id=@c_id";
            SqlCommand com = new SqlCommand(sql, conn);
            com.Parameters.AddWithValue("@c_id", this.c_id.Text);

            //Execute Command to insert data
            int ret = com.ExecuteNonQuery();
            MessageBox.Show("No of records deleted: " + ret);

            //Disconnect from server
            conn.Close();
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
