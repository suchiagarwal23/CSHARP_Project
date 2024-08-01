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
    public partial class LogInForm : Form
    {
        string ConStr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;





        public LogInForm()
        {
            InitializeComponent();
        }

       

        private void btn_login_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(ConStr);

            string username, password;
            username =  txtusername.Text;
            password = txtpassword.Text;
            try
            {
                string query = "select * from LOGIN where USERNAME=@username and PASSWORD=@password";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("username", txtusername.Text);
                cmd.Parameters.AddWithValue("password" , txtpassword.Text);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    username = txtusername.Text;
                    password = txtpassword.Text;


                    MainPage secondpage = new MainPage();
                    secondpage.Show();
                   Visible = true;
                }
                else
                {
                    MessageBox.Show("INVALID LOG IN DETAILS","ERROR",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    txtusername.Clear();
                    txtpassword.Clear();

                }
            }
            catch
            {
                MessageBox.Show("ERROR");
            }
            finally
            {
                con.Close();
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Do you want to exit??", "exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }

        }
    }
}
