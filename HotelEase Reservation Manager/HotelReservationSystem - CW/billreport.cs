using CrystalDecisions.CrystalReports.Engine;
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
    public partial class billreport : Form
    {
        string billid;
        public billreport(string billid)
        {
            InitializeComponent();
            this.billid = billid;
        }

        private void billreport_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();

            DataTable dt = new DataTable();

            string cs = @"Data Source=JANIRU_INDUWARA\SQLEXPRESS;initial Catalog=Hotel_Management_System;Integrated Security = True";

            using (SqlConnection con = new SqlConnection(cs))
            {
                con.Open();
                string sql = "SELECT * FROM billtbl WHERE bill_no = @billno";
                using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                {
                    da.SelectCommand.Parameters.AddWithValue("@billno", billid);
                    // Fill the DataTable with the fetched data
                    da.Fill(dt);
                }
            }

            // Assign the DataTable to the DataSet (if you use a DataSet)
            ds.Tables.Add(dt);

            // Create a new ReportDocument instance
            ReportDocument reportDocument = new ReportDocument();

            // Load your Crystal Report
            reportDocument.Load(@"C:\Users\janir\OneDrive\Desktop\Academics\10-GUI Application Development\HotelReservationSystem - CW\HotelReservationSystem - CW\CrystalReport7.rpt");

            // Set the DataSource of the report to the DataTable or DataSet
            reportDocument.SetDataSource(dt); // Use dt if you have a single table
                                              // reportDocument.SetDataSource(ds); // Use ds if you have multiple tables in a DataSet

            // Set the ReportDocument as the source for the CrystalReportViewer
            crystalReportViewer1.ReportSource = reportDocument;

            // Refresh the viewer to show the report
            crystalReportViewer1.Refresh();
        }
    }
}
