using FinalProject.datasets;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class overallreport : Form
    {
       // string ConStr = "Data Source=LAPTOP-01QG2D1I\\SQLEXPRESS;Initial Catalog=Problem;Integrated Security=SSPI";

        public overallreport()
        {
            InitializeComponent();
            //populatearea1();
        }

        public string ReportName { get; set; }
        public DataTable ReportData { get; set; }

        private void Form2_Load(object sender, EventArgs e)
        {
            try
            {
                ReportDataSource rds = new ReportDataSource("DataSet1", ReportData);
                reportViewer1.LocalReport.ReportPath = ReportName;
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading report: {ex.Message}");
            }
        }

       
        //private void populatearea1()
        //{
        //    SqlConnection con = new SqlConnection(ConStr);
        //    try
        //    {
        //        List<string> listofarea1 = new List<string>();

        //        string getarea1 = "select * from [dbo].[AREA1]";
        //        SqlCommand cmd = new SqlCommand(getarea1, con);
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            listofarea1.Add(reader.GetString(1));
        //        }
        //        cmbarea1.DataSource = listofarea1;
        //        cmbarea1.SelectedIndex = -1;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    finally
        //    {
        //        con.Close();
        //    }

        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if(cmbarea1.Text==null)
        //    {
        //        MessageBox.Show("SELECT AREA");
        //    }
        //    else
        //    {
        //        string query = "select * from [dbo].[RECORDS] WHERE AREA1=@area";
        //        var cmd = new SqlCommand(query);
        //        cmd.Parameters.AddWithValue("@area",this.cmbarea1.Text);
        //        using (var con = new SqlConnection(ConStr))
        //        {
        //          using(var da =new SqlDataAdapter())
        //            {
        //                cmd.Connection = con;
        //                da.SelectCommand = cmd;

        //            }
        //        }
        //    }
        //}

    }
}



