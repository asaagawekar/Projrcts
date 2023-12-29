using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeManagementSystem
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void lblemp_Click(object sender, EventArgs e)
        {
            employee emp = new employee();
            emp.Show();
            this.Hide();
        }

        private void lblview_Click(object sender, EventArgs e)
        {
            viewemployee view = new viewemployee();
            view.Show();
            this.Hide();
        }

        private void lblsalary_Click(object sender, EventArgs e)
        {
            salary sal = new salary();
            sal.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            login log = new login();
            log.Show();
            this.Hide();
        }

        private void pbemployee_Click(object sender, EventArgs e)
        {
            employee emp = new employee();
            emp.Show();
            this.Hide();
        }

        private void pbview_Click(object sender, EventArgs e)
        {
            viewemployee view = new viewemployee();
            view.Show();
            this.Hide();
        }

        private void pbsalary_Click(object sender, EventArgs e)
        {
            salary sal = new salary();
            sal.Show();
            this.Hide();
        }
    }
}
