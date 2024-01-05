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

namespace Baitap3
{
    public partial class Form1 : Form
    {
        DataUtil data = new DataUtil();
        public Form1()
        {
            InitializeComponent();
        }

        private void Clear()
        {
            txtId.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtCity.Clear();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Xác nhận yêu cầu xóa", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void Show()
        {
            dgv.DataSource = data.ShowList();
            lbCount.Text = dgv.RowCount.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string error = "";
            string checkid = "^[S][0-9]{1,4}$";
            string checkname = "^[a-zA-Z ]+$";
            string checkage = "^[0-9]{2}$";
            string checkcity = "^[a-zA-Z ]+$";
            if(!Regex.IsMatch(txtId.Text, checkid))
            {
                error += "\nBạn cần nhập Id";
            }
            if (!Regex.IsMatch(txtName.Text, checkname))
            {
                error += "\nBạn cần nhập tên";
            }
            if (!Regex.IsMatch(txtAge.Text, checkage))
            {
                error += "\nBạn cần nhập tuổi";
            }
            if (!Regex.IsMatch(txtCity.Text, checkcity))
            {
                error += "\nBạn cần nhập thành phố";
            }
            if(error != "")
            {
                MessageBox.Show("Có lỗi:" + error, "Thông báo");
            }
            else
            {
                Student s = new Student();
                s.id = txtId.Text;
                s.name = txtName.Text;
                s.age = txtAge.Text;
                s.city = txtCity.Text;
                bool k = data.AddStudent(s);
                if (!k)
                {
                    MessageBox.Show("Trùng mã");
                    return;
                }
                else
                {
                    MessageBox.Show("Thêm thành công");
                    Clear();
                    Show();
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string error = "";
            string checkid = "^[S][0-9]{1,4}$";
            string checkname = "^[a-zA-Z ]+$";
            string checkage = "^[0-9]{2}$";
            string checkcity = "^[a-zA-Z ]+$";
            if (!Regex.IsMatch(txtId.Text, checkid))
            {
                error += "\nBạn cần nhập Id";
            }
            if (!Regex.IsMatch(txtName.Text, checkname))
            {
                error += "\nBạn cần nhập tên";
            }
            if (!Regex.IsMatch(txtAge.Text, checkage))
            {
                error += "\nBạn cần nhập tuổi";
            }
            if (!Regex.IsMatch(txtCity.Text, checkcity))
            {
                error += "\nBạn cần nhập thành phố";
            }
            if (error != "")
            {
                MessageBox.Show("Có lỗi:" + error, "Thông báo");
            }
            else
            {
                Student s = new Student();
                s.id = txtId.Text;
                s.name = txtName.Text;
                s.age = txtAge.Text;
                s.city = txtCity.Text;
                bool k = data.UpdateStudent(s);
                if (!k)
                {
                    MessageBox.Show("Không tìm thấy sinh viên");
                    return;
                }
                else
                {
                    MessageBox.Show("Sửa thành công");
                    Clear();
                    Show();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            bool k = data.DeleteStudent(id);
            if (!k)
            {
                MessageBox.Show("Không tìm thấy sinh viên");
                return;
            }
            else
            {
                Clear();
                Show();
            }
        }

        private void btnFindId_Click(object sender, EventArgs e)
        {
            string id = txtId.Text;
            List<Student> li = new List<Student>();
            Student s = data.FindId(id);
            if (s!=null)
            {
                li.Add(s);
                dgv.DataSource = li;
                lbCount.Text = dgv.RowCount.ToString();
                Clear();
            }
            else
            {
                dgv.DataSource = li;
                lbCount.Text = dgv.RowCount.ToString();
                Clear();
            }
        }

        private void GetAStudent(object sender, DataGridViewCellEventArgs e)
        {
            Student s = (Student)dgv.CurrentRow.DataBoundItem;
            txtId.Text = s.id;
            txtName.Text = s.name;
            txtAge.Text = s.age;
            txtCity.Text = s.city;
        }

        private void btnFindName_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            List<Student> li = data.FindName(name);
            if(li != null)
            {
                dgv.DataSource = li;
                lbCount.Text = dgv.RowCount.ToString();
                Clear();
            }
            else
            {

                dgv.DataSource = li;
                lbCount.Text = dgv.RowCount.ToString();
                Clear();
            }
        }
    }
}
