using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

       
        private void entry_Click(object sender, EventArgs e)
        {
            EntryForm f1 = new EntryForm();
            f1.Show();
            Visible = true;
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            dailyreport dr = new dailyreport();
            dr.Show();
            Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SelectedReport sr = new SelectedReport();
            sr.Show();
            Visible= true;
        }

       
    }
}
