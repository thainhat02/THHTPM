using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Student s = new Student();
            s.id = txtID.Text;
            s.name = txtName.Text;
            s.age = txtAge.Text;
            s.city = txtCity.Text;
            data.AddStudent(s);
            Cleartext();
        }
        private void Cleartext()
        {
            txtID.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtCity.Clear();
            ActiveControl = txtID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
