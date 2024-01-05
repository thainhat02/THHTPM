using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Baitap2
{
    public partial class Form1 : Form
    {
        DataUtil data = new DataUtil();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            show();
        }
        private void Clear()
        {
            txtID.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtCity.Clear();
        }
        private void show()
        {
            dgv.DataSource = data.ShowList();
            lbCount.Text = dgv.RowCount.ToString();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            show();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Xác nhận yêu cầu thoát", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string error = "";
            string checkid = "^[S][0-9]{1,4}$";
            string checkname = "^[a-zA-Z ]+$";
            string checkage = "^[0-9]{2}$";
            string checkcity = "^[a-zA-Z ]+$";
            if(!Regex.IsMatch(txtID.Text, checkid))
            {
                error += "\nBạn cần nhập mã sinh viên";
            }
            if(!Regex.IsMatch(txtName.Text, checkname))
            {
                error += "\nBạn cần nhập tên";
            }
            if (!Regex.IsMatch(txtAge.Text, checkage))
            {
                error += "\nBạn cần nhập tuôit";
            }
            if (!Regex.IsMatch(txtCity.Text, checkcity))
            {
                error += "\nBạn cần nhập thành phố";
            }
            if(error!= "")
            {
                MessageBox.Show("Có lỗi: " + error);
            }
            else
            {
                student s = new student();
                s.id = txtID.Text;
                s.name = txtName.Text;
                s.age = txtAge.Text;
                s.city = txtCity.Text;
                bool k = data.AddStudent(s);
                if (!k)
                {
                    MessageBox.Show("Trùng mã");
                }
                else
                {
                    MessageBox.Show("Thêm thành công");
                    Clear();
                    show();
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string error = "";
            string checkid = "^[S][0-9]{1,4}$";
            string checkname = "^[a-zA-Z ]+$";
            string checkage = "^[0-9]{2}$";
            string checkcity = "^[a-zA-Z ]+$";
            if (!Regex.IsMatch(txtID.Text, checkid))
            {
                error += "\nBạn cần nhập mã sinh viên";
            }
            if (!Regex.IsMatch(txtName.Text, checkname))
            {
                error += "\nBạn cần nhập tên";
            }
            if (!Regex.IsMatch(txtAge.Text, checkage))
            {
                error += "\nBạn cần nhập tuôit";
            }
            if (!Regex.IsMatch(txtCity.Text, checkcity))
            {
                error += "\nBạn cần nhập thành phố";
            }
            if (error != "")
            {
                MessageBox.Show("Có lỗi: " + error);
            }
            else
            {
                student s = new student();
                s.id = txtID.Text;
                s.name = txtName.Text;
                s.age = txtAge.Text;
                s.city = txtCity.Text;
                bool k = data.UpdateStudent(s);
                if (!k)
                {
                    MessageBox.Show("Không tìm thấy sinh viên");
                }
                else
                {
                    MessageBox.Show("Sửa thành công");
                    Clear();
                    show();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            bool k = data.DeleteStudent(id);
            if (!k)
            {
                MessageBox.Show("Không tìm thấy sinh viên");
            }
            else
            {
                Clear();
                show();
            }
        }

        private void GetAStudent(object sender, DataGridViewCellEventArgs e)
        {
            student s = (student)dgv.CurrentRow.DataBoundItem;
            txtID.Text = s.id;
            txtName.Text = s.name;
            txtAge.Text = s.age;
            txtCity.Text = s.city;
        }

        private void btnFindID_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            List<student> li = new List<student>();
            student s = data.FindId(id);
            if (s != null)
            {
                li.Add(s);
                dgv.DataSource = li;
                Clear();
                lbCount.Text = dgv.RowCount.ToString();
               
            }
            else
            {
                dgv.DataSource = li;
                Clear();
                lbCount.Text = dgv.RowCount.ToString();
            }
        }
    }
}
