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
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=AKSHAYPC\SQLEXPRESS;Initial Catalog=EMS;Integrated Security=True;MultipleActiveResultSets=True");
        private void btnadd_Click(object sender, EventArgs e)
        {
            if(txtEmpId.Text == "" || txtEmpName.Text == "" || txtEmpPhone.Text == "" || txtEmpAdd.Text == "")
            {
                MessageBox.Show("Please Fill All Mandatory Fields");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "insert into EmployeeTbl values('"+txtEmpId.Text+ "','" + txtEmpName.Text + "','" + txtEmpAdd.Text + "','" + cbEmpPos.SelectedItem.ToString() + "','" + dtEmpDOB.Value.Date + "','" + txtEmpPhone.Text + "','" + cbEmpEdu.SelectedItem.ToString() + "','" + cbEmpGen.SelectedItem.ToString() + "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Successfully Added");
                    Con.Close();
                    populate();

                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void lblexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void populate()
        {
            Con.Open();
            string query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            DGVEmp.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void employee_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if(txtEmpId.Text == "")
            {
                MessageBox.Show("Please Enter Employee Id");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from EmployeeTbl where EmpId='" + txtEmpId.Text +"';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Deleted Successfully");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DGVEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEmpId.Text = DGVEmp.SelectedRows[0].Cells[0].Value.ToString();
            txtEmpName.Text = DGVEmp.SelectedRows[0].Cells[1].Value.ToString();
            txtEmpAdd.Text = DGVEmp.SelectedRows[0].Cells[2].Value.ToString();
            cbEmpEdu.Text = DGVEmp.SelectedRows[0].Cells[6].Value.ToString();
            cbEmpPos.Text = DGVEmp.SelectedRows[0].Cells[3].Value.ToString();
            txtEmpPhone.Text = DGVEmp.SelectedRows[0].Cells[5].Value.ToString();
            cbEmpGen.Text = DGVEmp.SelectedRows[0].Cells[7].Value.ToString();
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (txtEmpId.Text == "" || txtEmpName.Text == "" || txtEmpPhone.Text == "" || txtEmpAdd.Text == "")
            {
                MessageBox.Show("Please Enter Information to Edit");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update EmployeeTbl set EmpName ='"+ txtEmpName.Text +"',EmpAdd ='" + txtEmpAdd.Text +"',EmpPos='"+ cbEmpPos.SelectedItem.ToString() +"',EmpDOB='"+ dtEmpDOB.Value.Date +"',EmpPhone='"+ txtEmpPhone.Text +"',EmpEdu='"+ cbEmpEdu.SelectedItem.ToString() + "',EmpGen='" + cbEmpGen.SelectedItem.ToString() + "' where EmpId='"+ txtEmpId.Text +"';";                               
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.BeginExecuteNonQuery();
                    MessageBox.Show("Employee Information Updated Successfully");
                    Con.Close();
                    populate();
                }catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void btnhome_Click(object sender, EventArgs e)
        {
            home home = new home();
            home.Show();
            this.Hide();
        }
    }
}
