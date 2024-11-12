using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelReservationSystem___CW
{
    public partial class mainform : Form
    {
        public mainform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 addnewcustomer = new Form1();
            addnewcustomer.Show();
        }

        private void database_Click(object sender, EventArgs e)
        {
            Database Database = new Database();
            Database.Show();
        }

        private void billsection_Click(object sender, EventArgs e)
        {
            billsection billsection = new billsection();
            billsection.Show();
        }
    }
}
