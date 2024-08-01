using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace FinalProject
{
    public partial class EntryForm : Form
    {

        //connection string 
        string ConStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public EntryForm()
        {
            InitializeComponent();
            PopulateAREA1();
            cmbarea1.SelectedIndex = 0;
            string SelectedValue = cmbarea1.SelectedValue?.ToString();
            PopulateAREA2(SelectedValue);

            // to  SelectedIndexChanged event
            cmbarea1.SelectedIndexChanged += SelectedIndexcmbarea1Changed;
            cmbarea2.SelectedIndexChanged += SelectedIndexcmbarea2Changed;
            cmbarea3.SelectedIndexChanged += SelectedIndexcmbarea3Changed;

            PopulateAREA3();
            PopulateAREA4();
            PopulateEMP1();
            PopulateEMP2();
            PopulateACT1();
            PopulateACT2();
            PopulateACT3();
            PopulateACT4();

        }


        //combobox area 1
        public void PopulateAREA1()
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                List<string> listofarea1 = new List<string>();

                string getarea1 = "select * from [dbo].[AREA1]";
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

        //combo box area 2
        private void PopulateAREA2(string selectedarea)
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                List<string> listofarea2 = new List<string>();

                string getarea2 = "select * from [dbo].[AREA2] where CD1 = (select CD1 from [dbo].[AREA1] where AREA = @selected_area)";
                SqlCommand cmd = new SqlCommand(getarea2, con);
                con.Open();
                cmd.Parameters.AddWithValue("@selected_area", selectedarea);
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

        private void SelectedIndexcmbarea1Changed(object sender, EventArgs e)
        {
            string selectedarea = cmbarea1.SelectedItem?.ToString();
            PopulateAREA2(selectedarea);
            PopulateAREA3();
            PopulateAREA4();
        }

        private void SelectedIndexcmbarea2Changed(object sender, EventArgs e)
        {
            PopulateAREA3();
            PopulateAREA4();
        }

        private void SelectedIndexcmbarea3Changed(object sender, EventArgs e)
        {
            PopulateAREA4();
        }

        //combo box area 3
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

                string getarea3 = "select * from [dbo].[AREA3] where CD1 = (select CD1 from [dbo].[AREA1] where AREA = @selected_area1) and CD2 = (select CD2 from [dbo].[AREA2] where AREA = @selected_area2)";
                SqlCommand cmd = new SqlCommand(getarea3, con);
                con.Open();
                cmd.Parameters.AddWithValue("@selected_area1", selectedarea1);
                cmd.Parameters.AddWithValue("@selected_area2", selectedarea2);
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

        //combo box area 4
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

                string getarea4 = "select * from [dbo].[AREA4] where CD1 = (select CD1 from [dbo].[AREA1] where AREA = @selected_area1) and CD2 = (select CD2 from [dbo].[AREA2] where AREA = @selected_area2) and CD3 = (select CD3 from [dbo].[AREA3] where AREA = @selected_area3)";
                SqlCommand cmd = new SqlCommand(getarea4, con);
                con.Open();
                cmd.Parameters.AddWithValue("@selected_area1", selectedarea1);
                cmd.Parameters.AddWithValue("@selected_area2", selectedarea2);
                cmd.Parameters.AddWithValue("@selected_area3", selectedarea3);
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

        //combo box employee 1
        private void PopulateEMP1()
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                List<string> listofemp1 = new List<string>();

                string getemp1 = "select * from [dbo].[MECH]";
                SqlCommand cmd = new SqlCommand(getemp1, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listofemp1.Add(reader.GetString(1));
                }
                cmbemp1.DataSource = listofemp1;
                cmbemp1.SelectedIndex = -1;
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

        //combo box employee 2
        private void PopulateEMP2()
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                List<string> listofemp2 = new List<string>();

                string getemp2 = "select * from [dbo].[MECH]";
                SqlCommand cmd = new SqlCommand(getemp2, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listofemp2.Add(reader.GetString(1));
                }
                cmbemp2.DataSource = listofemp2;
                cmbemp2.SelectedIndex = -1;
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


        //combo box activity 1
        private void PopulateACT1()
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                List<string> listofact1 = new List<string>();

                string getact1 = "select * from [dbo].[ACTIVITY]";
                SqlCommand cmd = new SqlCommand(getact1, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listofact1.Add(reader.GetString(1));
                }
                act1.DataSource = listofact1;
                act1.SelectedIndex = -1;
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


        //activity 2
        private void PopulateACT2()
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                List<string> listofact2 = new List<string>();

                string getact2 = "select * from [dbo].[ACTIVITY]";
                SqlCommand cmd = new SqlCommand(getact2, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listofact2.Add(reader.GetString(1));
                }
                act2.DataSource = listofact2;
                act2.SelectedIndex = -1;
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



        //activity 3
        private void PopulateACT3()
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                List<string> listofact3 = new List<string>();

                string getact3 = "select * from [dbo].[ACTIVITY]";
                SqlCommand cmd = new SqlCommand(getact3, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listofact3.Add(reader.GetString(1));
                }
                act3.DataSource = listofact3;
                act3.SelectedIndex = -1;
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



        //activity 4
        private void PopulateACT4()
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                List<string> listofact4 = new List<string>();

                string getact4 = "select * from [dbo].[ACTIVITY]";
                SqlCommand cmd = new SqlCommand(getact4, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    listofact4.Add(reader.GetString(1));
                }
                act4.DataSource = listofact4;
                act4.SelectedIndex = -1;
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

        //to add records in database 
        private void btnadd_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                string addrecord = @"insert into [dbo].[RECORDS] values (@area1,@area2,@area3,@area4,@date,@emp1,@emp2,@desc,@act1,@act2,@act3,@act4,@starttime,@endtime,@num2,@num3,@num4)";
                SqlCommand cmd = new SqlCommand(addrecord, con);

                //area1
                if (cmbarea1.SelectedIndex >= 0)
                {
                    cmd.Parameters.AddWithValue("@area1", cmbarea1.SelectedValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@area1", DBNull.Value);
                }

                //area2
                if (cmbarea2.SelectedIndex >= 0)
                {
                    cmd.Parameters.AddWithValue("@area2", cmbarea2.SelectedValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@area2", DBNull.Value);
                }

                //area3
                if (cmbarea3.SelectedIndex >= 0)
                {
                    cmd.Parameters.AddWithValue("@area3", cmbarea3.SelectedValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@area3", DBNull.Value);
                }

                //area4
                if (cmbarea4.SelectedIndex >= 0)
                {
                    cmd.Parameters.AddWithValue("@area4", cmbarea4.SelectedValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@area4", DBNull.Value);
                }

                cmd.Parameters.AddWithValue("@date", date.Value);
                cmd.Parameters.AddWithValue("@starttime", starttime.Value);
                cmd.Parameters.AddWithValue("@endtime", endtime.Value);
                //employee 1
                if (cmbemp1.SelectedIndex >= 0)
                {
                    cmd.Parameters.AddWithValue("@emp1", cmbemp1.SelectedValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@emp1", DBNull.Value);
                }

                //employee 2
                if (cmbemp2.SelectedIndex >= 0)
                {
                    cmd.Parameters.AddWithValue("@emp2", cmbemp2.SelectedValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@emp2", DBNull.Value);
                }

                //activity 1
                if (act1.SelectedIndex >= 0)
                {
                    cmd.Parameters.AddWithValue("@act1", act1.SelectedValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@act1", DBNull.Value);
                }
                //activity 2
                if (act2.SelectedIndex >= 0)
                {
                    cmd.Parameters.AddWithValue("@act2", act2.SelectedValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@act2", DBNull.Value);
                }

                //activity 3
                if (act3.SelectedIndex >= 0)
                {
                    cmd.Parameters.AddWithValue("@act3", act3.SelectedValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@act3", DBNull.Value);
                }

                //activity 2
                if (act4.SelectedIndex >= 0)
                {
                    cmd.Parameters.AddWithValue("@act4", act4.SelectedValue);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@act4", DBNull.Value);
                }
                cmd.Parameters.AddWithValue("@num2", numarea2.Text);
                cmd.Parameters.AddWithValue("@num3", numarea3.Text);
                cmd.Parameters.AddWithValue("@num4", numarea4.Text);
                //description
                cmd.Parameters.AddWithValue("@desc", txtdesc.Text);
                con.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    MessageBox.Show("RECORD ADDED SUCCESSFULLY");
                }
                else
                {
                    MessageBox.Show("RECORD WAS NOT ADDED");
                }
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

        //to select the record from database according to the record id
        private void btnselect_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                if (!string.IsNullOrEmpty(txtid.Text))
                {
                    string selectquery = "select * from [dbo].[RECORDS] where [RECORDID]=@ID";

                    SqlCommand cmd = new SqlCommand(selectquery, con);
                    cmd.Parameters.AddWithValue("@ID", txtid.Text);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbarea1.Text = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        cmbarea2.Text = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        cmbarea3.Text = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        cmbarea4.Text = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        date.Value = reader.IsDBNull(5) ? DateTime.Now : reader.GetDateTime(5);                       
                        cmbemp1.Text = reader.IsDBNull(6) ? string.Empty : reader.GetString(6);
                        cmbemp2.Text = reader.IsDBNull(7) ? string.Empty : reader.GetString(7);
                        txtdesc.Text = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
                        act1.Text = reader.IsDBNull(9) ? string.Empty : reader.GetString(9);
                        act2.Text = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        act3.Text = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        act4.Text = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                        numarea2.Text = reader.IsDBNull(15) ? null : reader.GetInt32(15).ToString();
                        numarea3.Text = reader.IsDBNull(16) ? null : reader.GetInt32(16).ToString();
                        numarea4.Text = reader.IsDBNull(17) ? null : reader.GetInt32(17).ToString();
                        
                        if (reader.IsDBNull(13))
                        {
                            starttime.Value = DateTime.Now;
                        }
                        else
                        {
                            TimeSpan startTimeSpan = reader.GetTimeSpan(13);
                            starttime.Value = DateTime.Today.Add(startTimeSpan); 
                        }

                        if (reader.IsDBNull(14))
                        {
                            endtime.Value = DateTime.Now;
                        }
                        else
                        {
                            TimeSpan endTimeSpan = reader.GetTimeSpan(14);
                            endtime.Value = DateTime.Today.Add(endTimeSpan);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Enter record ID first");
                }
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

        //to update the record for selected record id       
        private void btnupdate_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                string update = @"update [dbo].[RECORDS]
                                    set [AREA1]=@area1
                                       ,[AREA2]=@area2
                                       ,[AREA3]=@area3
                                       ,[AREA4]=@area4
                                       ,[DATE]=@date                      
                                       ,[EMPLOYEE1]=@emp1
                                       ,[EMPLOYEE2]=@emp2
                                       ,[ACTIVITY1]=@act1
                                       ,[ACTIVITY2]=@act2
                                       ,[ACTIVITY3]=@act3
                                       ,[ACTIVITY4]=@act4
                                       ,[DESCRIPTION]=@desc 
                                       ,[STARTTIME]=@start
                                       ,[ENDTIME]=@end
                                       ,[AREA2NUM]=@num2 
                                       ,[AREA3NUM]=@num3
                                       ,[AREA4NUM]=@num4 where [RECORDID]=@id";
                SqlCommand cmd = new SqlCommand(update, con);
                cmd.Parameters.AddWithValue("@id", txtid.Text);
                cmd.Parameters.AddWithValue("@area1", cmbarea1.Text);
                cmd.Parameters.AddWithValue("@area2", cmbarea2.Text);
                cmd.Parameters.AddWithValue("@area3", cmbarea3.Text);
                cmd.Parameters.AddWithValue("@area4", cmbarea4.Text);
                cmd.Parameters.AddWithValue("@date", date.Value);
                cmd.Parameters.AddWithValue("@act1", act1.Text);
                cmd.Parameters.AddWithValue("@act2", act2.Text);
                cmd.Parameters.AddWithValue("@act3", act3.Text);
                cmd.Parameters.AddWithValue("@act4", act4.Text);
                cmd.Parameters.AddWithValue("@start",starttime.Value);
                cmd.Parameters.AddWithValue("@end", endtime.Value);
                cmd.Parameters.AddWithValue("@emp1", cmbemp1.Text);
                cmd.Parameters.AddWithValue("@emp2", cmbemp2.Text);
                cmd.Parameters.AddWithValue("@desc", txtdesc.Text);
                cmd.Parameters.AddWithValue("@num2", numarea2.Text);
                cmd.Parameters.AddWithValue("@num3", numarea3.Text);
                cmd.Parameters.AddWithValue("@num4", numarea4.Text);
                con.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    MessageBox.Show("record updated successfully");
                }
                else
                {
                    MessageBox.Show("record not updated ");
                }

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



        //to delete the selected record
        private void btndelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConStr);
            try
            {
                string delete = @"delete from  [dbo].[RECORDS] where [RECORDID]=@id";
                SqlCommand cmd = new SqlCommand(delete, con);
                cmd.Parameters.AddWithValue("@id", txtid.Text);
                con.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    MessageBox.Show("record deleted successfully");
                }
                else
                {
                    MessageBox.Show("record not deleted ");
                }
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



        //to go to previous
        private void button1_Click(object sender, EventArgs e)
        {
            RECORDS r = new RECORDS();
            r.Show();
            Visible = true;
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(ConStr))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT  * FROM RECORDS"; 
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        string apppath = Application.StartupPath;
                        string reportpath = @"Reports/Report1.rdlc";
                        string fullpath = Path.Combine(apppath, reportpath);

                        overallreport rv = new overallreport
                        {
                            ReportName = fullpath,
                            ReportData = dt
                        };
                        rv.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No record found");
                    }
                }
                
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }
        }

    }
}
