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
    public partial class salary : Form
    {
        public salary()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=AKSHAYPC\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True;Integrated Security=True;MultipleActiveResultSets=True");
        private void btnhome_Click(object sender, EventArgs e)
        {
            home home = new home();
            home.Show();
            this.Hide();
        }
        private void fetchempdata()
        {
            if (txtempid.Text == "")
            {
                MessageBox.Show("Please Enter Employee Id to Fetch Data");
            }
            else
            {
                Con.Open();
                string query = "select * from EmployeeTbl where EmpId='" + txtempid.Text + "'";
                SqlCommand cmd = new SqlCommand(query, Con);
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    txtempname.Text = dr["EmpName"].ToString();
                    txtemppos.Text = dr["EmpPos"].ToString();

                }
                Con.Close();
            }
        }

        private void btnfetchdata_Click(object sender, EventArgs e)
        {
            fetchempdata();
        }

        

        private void lblexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        int dailybase, Total;

        private void btnprint_Click(object sender, EventArgs e)
        {
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawString("*********SALARY DETAILS*********", new Font("Times New Roman", 20, FontStyle.Bold), Brushes.Maroon, new Point(150));
            e.Graphics.DrawString("Employee ID: " + txtempid.Text, new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50, 70));
            e.Graphics.DrawString("Employee Name: " + txtempname.Text, new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50, 100));
            e.Graphics.DrawString("Employee Position: " + txtemppos.Text, new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50, 130));
            e.Graphics.DrawString("Worked Days: " + txtworkdays.Text, new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50, 160));
            e.Graphics.DrawString("Dailybase Salary: " + dailybase, new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50, 190));
            e.Graphics.DrawString("Total Salary: " + Total, new Font("Times New Roman", 18, FontStyle.Regular), Brushes.Black, new Point(50, 220));
        }

        private void btnview_Click(object sender, EventArgs e)
        {
            if(txtemppos.Text == "")
            {
                MessageBox.Show("Please Select Position of an Employee");
            }
            else if(txtworkdays.Text == ""|| Convert.ToInt32(txtworkdays.Text) > 28)
            {
                MessageBox.Show("Please Enter Valid Number of Days");
            }else
            {
                if(txtemppos.Text == "Senior Developer")
                {
                    dailybase = 1500;
                }else if(txtemppos.Text == "Junior Developer")
                {
                    dailybase = 1100;
                }else if(txtemppos.Text == "Tester")
                {
                    dailybase = 1000;
                }else if(txtemppos.Text == "Accountant")
                {
                    dailybase = 800;
                }else if(txtemppos.Text == "Receptionist")
                {
                    dailybase = 600;
                }
                Total = dailybase * Convert.ToInt32(txtworkdays.Text);
                salaryslip.Text ="PAYMET SLIP "+ "\n\n" +"Employee Id: " + txtempid.Text + "\n" + "Employee Name: " + txtempname.Text + "\n" + "Employee Position: " + txtemppos.Text + "\n" + "Worked Days: " + txtworkdays.Text + "\n" + "Dailybase Salary: " + dailybase + "₹" + "\n" + "Total Salary: " + Total + "₹";                                          
            }
        }
    }
}
