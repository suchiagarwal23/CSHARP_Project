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

namespace FinalProject
{
    public partial class RECORDS : Form
    {
        public RECORDS()
        {
            InitializeComponent();
            dataGridView1_CellContentClick();
        }

        private void dataGridView1_CellContentClick()
        {
            string ConStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                string getAllEmployeeSql = "select * from RECORDS";
                SqlDataAdapter da = new SqlDataAdapter(getAllEmployeeSql, ConStr);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}
