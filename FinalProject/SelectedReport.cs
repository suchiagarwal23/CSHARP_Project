using FinalProject.datasets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace FinalProject
{
    public partial class SelectedReport : Form
    {
        string ConStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public SelectedReport()
        {
            InitializeComponent();
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "FinalProject.Reports.Report3.rdlc";
            PopulateAREA1();

            // Set event handlers for ComboBox selections
            cmbarea1.SelectedIndexChanged += SelectedIndexcmbarea1Changed;
            cmbarea2.SelectedIndexChanged += SelectedIndexcmbarea2Changed;
            cmbarea3.SelectedIndexChanged += SelectedIndexcmbarea3Changed;
        }

        public void PopulateAREA1()
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                List<string> listofarea1 = new List<string>();

                string getarea1 = "SELECT * FROM [dbo].[AREA1]";
                SqlCommand cmd = new SqlCommand(getarea1, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listofarea1.Add(reader.GetString(1));
                }
                cmbarea1.DataSource = listofarea1;
                cmbarea1.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void PopulateAREA2(string selectedarea)
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                List<string> listofarea2 = new List<string>();

                string getarea2 = "SELECT * FROM [dbo].[AREA2] WHERE CD1 = (SELECT CD1 FROM [dbo].[AREA1] WHERE AREA = @selected_area)";
                SqlCommand cmd = new SqlCommand(getarea2, con);
                cmd.Parameters.AddWithValue("@selected_area", selectedarea);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listofarea2.Add(reader.GetString(2));
                }
                cmbarea2.DataSource = listofarea2;
                cmbarea2.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void PopulateAREA3()
        {
            string selectedarea1 = cmbarea1.SelectedItem?.ToString();
            string selectedarea2 = cmbarea2.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedarea1) || string.IsNullOrEmpty(selectedarea2))
            {
                return;
            }

            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                List<string> listofarea3 = new List<string>();

                string getarea3 = "SELECT * FROM [dbo].[AREA3] WHERE CD1 = (SELECT CD1 FROM [dbo].[AREA1] WHERE AREA = @selected_area1) AND CD2 = (SELECT CD2 FROM [dbo].[AREA2] WHERE AREA = @selected_area2)";
                SqlCommand cmd = new SqlCommand(getarea3, con);
                cmd.Parameters.AddWithValue("@selected_area1", selectedarea1);
                cmd.Parameters.AddWithValue("@selected_area2", selectedarea2);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listofarea3.Add(reader.GetString(3));
                }
                cmbarea3.DataSource = listofarea3;
                cmbarea3.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void PopulateAREA4()
        {
            string selectedarea1 = cmbarea1.SelectedItem?.ToString();
            string selectedarea2 = cmbarea2.SelectedItem?.ToString();
            string selectedarea3 = cmbarea3.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedarea1) || string.IsNullOrEmpty(selectedarea2) || string.IsNullOrEmpty(selectedarea3))
            {
                return;
            }

            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                List<string> listofarea4 = new List<string>();

                string getarea4 = "SELECT * FROM [dbo].[AREA4] WHERE CD1 = (SELECT CD1 FROM [dbo].[AREA1] WHERE AREA = @selected_area1) AND CD2 = (SELECT CD2 FROM [dbo].[AREA2] WHERE AREA = @selected_area2) AND CD3 = (SELECT CD3 FROM [dbo].[AREA3] WHERE AREA = @selected_area3)";
                SqlCommand cmd = new SqlCommand(getarea4, con);
                cmd.Parameters.AddWithValue("@selected_area1", selectedarea1);
                cmd.Parameters.AddWithValue("@selected_area2", selectedarea2);
                cmd.Parameters.AddWithValue("@selected_area3", selectedarea3);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listofarea4.Add(reader.GetString(4));
                }
                cmbarea4.DataSource = listofarea4;
                cmbarea4.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void SelectedIndexcmbarea1Changed(object sender, EventArgs e)
        {
            string selectedarea = cmbarea1.SelectedItem?.ToString();
            PopulateAREA2(selectedarea);
        }

        private void SelectedIndexcmbarea2Changed(object sender, EventArgs e)
        {
            PopulateAREA3();
        }

        private void SelectedIndexcmbarea3Changed(object sender, EventArgs e)
        {
            PopulateAREA4();
        }
        private void btnshowreport_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(ConStr))
                {
                    // Base query
                    string query = "SELECT * FROM RECORDS WHERE 1=1";

                    // Parameters and conditions for non-empty selections
                    if (!string.IsNullOrEmpty(cmbarea1.Text))
                    {
                        query += " AND AREA1 = @area1";
                    }
                    if (!string.IsNullOrEmpty(cmbarea2.Text))
                    {
                        query += " AND AREA2 = @area2";
                    }
                    if (!string.IsNullOrEmpty(cmbarea3.Text))
                    {
                        query += " AND AREA3 = @area3";
                    }
                    if (!string.IsNullOrEmpty(cmbarea4.Text))
                    {
                        query += " AND AREA4 = @area4";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Adding parameters only for non-empty selections
                        if (!string.IsNullOrEmpty(cmbarea1.Text))
                        {
                            cmd.Parameters.AddWithValue("@area1", cmbarea1.Text);
                        }
                        if (!string.IsNullOrEmpty(cmbarea2.Text))
                        {
                            cmd.Parameters.AddWithValue("@area2", cmbarea2.Text);
                        }
                        if (!string.IsNullOrEmpty(cmbarea3.Text))
                        {
                            cmd.Parameters.AddWithValue("@area3", cmbarea3.Text);
                        }
                        if (!string.IsNullOrEmpty(cmbarea4.Text))
                        {
                            cmd.Parameters.AddWithValue("@area4", cmbarea4.Text);
                        }

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
                MessageBox.Show(ex.Message);
            }
        }
    }
}


       

