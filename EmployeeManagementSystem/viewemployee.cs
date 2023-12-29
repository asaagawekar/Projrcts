using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EmployeeManagementSystem
{
    public partial class viewemployee : Form
    {
        public viewemployee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=AKSHAYPC\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True;Integrated Security=True;MultipleActiveResultSets=True");
        
        private void fetchempdata()
        {
            Con.Open();
            string query = "select * from EmployeeTbl where EmpId='" + txtempidsearch.Text + "'";
            SqlCommand cmd = new SqlCommand(query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            { 
                lblempid.Text = dr["EmpId"].ToString();
                lblempname.Text = dr["EmpName"].ToString();
                lblempadd.Text = dr["EmpAdd"].ToString();
                lblemppos.Text = dr["EmpPos"].ToString();
                lblempphn.Text = dr["EmpPhone"].ToString();
                lblempDOB.Text = dr["EmpDOB"].ToString();
                lblempgen.Text = dr["EmpGen"].ToString();
                lblempedu.Text = dr["EmpEdu"].ToString();
                lblempid.Visible = true;
                lblempname.Visible = true;
                lblempadd.Visible = true;
                lblemppos.Visible = true;
                lblempphn.Visible = true;
                lblempDOB.Visible = true;
                lblempgen.Visible = true;
                lblempedu.Visible = true;

            }
            Con.Close();
        }
        private void viewemployee_Load(object sender, EventArgs e)
        {

        }

        private void btnref_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        private void btnhomev_Click(object sender, EventArgs e)
        {
            home home = new home();
            home.Show();
            this.Hide();
        }

        private void lblexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            if(printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("*********EMPLOYEE DETAILS*********",new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Maroon, new Point(150));
            e.Graphics.DrawString("Employee ID: " + lblempid.Text,new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50,80));
            e.Graphics.DrawString("Employee Name: " + lblempname.Text,new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50, 110));
            e.Graphics.DrawString("Employee Address: " + lblempadd.Text, new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50, 140));
            e.Graphics.DrawString("Employee Gender: " + lblempgen.Text, new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50, 170));
            e.Graphics.DrawString("Employee Position: " + lblemppos.Text, new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50, 200));
            e.Graphics.DrawString("Employee DOB: " + lblempDOB.Text, new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50, 230));
            e.Graphics.DrawString("Employee Phone: " + lblempphn.Text, new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50, 260));
            e.Graphics.DrawString("Employee Education: " + lblempedu.Text, new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50, 290));
        }
    }
}
