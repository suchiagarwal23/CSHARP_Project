using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinalProject.datasets;
using Microsoft.Reporting.WinForms;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

namespace FinalProject

{

    public partial class dailyreport : Form
    {
        string ConStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public dailyreport()
        {
            InitializeComponent();
            
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinalProject.Reports.Report2.rdlc";
        }

        private void btnselect_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConStr))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM RECORDS WHERE DATE = @Date", con))
                    {
                        cmd.Parameters.AddWithValue("@Date", date.Value.Date); 
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataSet1 ds = new DataSet1();
                        da.Fill(ds, "RECORDS");
                        ReportDataSource datasource = new ReportDataSource("DataSet1", ds.Tables[0]);
                        this.reportViewer1.LocalReport.DataSources.Clear();
                        this.reportViewer1.LocalReport.DataSources.Add(datasource);
                        this.reportViewer1.RefreshReport();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

       
    }
}
