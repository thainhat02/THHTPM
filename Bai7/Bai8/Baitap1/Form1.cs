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

namespace Baitap1
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
        private void show()
        {
            dgv.DataSource = data.ShowList();
            lbCount.Text = dgv.RowCount.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            string error ="";
            string checkid = "^[S][0-9]{1,4}$";
            string checkname = "^[a-zA-Z ]+$";
            string checkage = "^[0-9]{2}$";
            string checkcity = "^[a-zA-Z ]+$";
            if (!Regex.IsMatch(txtID.Text, checkid))
            {
                error += "\nBạn phải nhập mã sv bắt đầu bằng S và theo sau là từ 1 đến 4 sô\n";
            }
            if(!Regex.IsMatch(txtName.Text, checkname))
            {
                error += "Ban phải nhập họ tên\n";
            }
            if(!Regex.IsMatch(txtAge.Text, checkage))
            {
                error += "Ban phải nhập tuổi có 2 chữ số\n";
            }
            if(!Regex.IsMatch(txtCity.Text, checkcity))
            {
                error += "Ban phải nhập thành phố\n";
            }
            if(error!= "")
            {
                MessageBox.Show("Có lỗi:" + error);
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
                    MessageBox.Show("Mã sinh viên đã tồn tại");
                    return;
                }
                else{
                    MessageBox.Show("Thêm sinh viên thành công");
                    clear();
                    show();
                }
                
            }
            
        }

        private void clear()
        {
            txtID.Clear();
            txtName.Clear();
            txtAge.Clear();
            txtCity.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
            
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            show();
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
                error += "\nBạn phải nhập mã sv bắt đầu bằng S và theo sau là từ 1 đến 4 sô\n";
            }
            if (!Regex.IsMatch(txtName.Text, checkname))
            {
                error += "Ban phải nhập họ tên\n";
            }
            if (!Regex.IsMatch(txtAge.Text, checkage))
            {
                error += "Ban phải nhập tuổi có 2 chữ số\n";
            }
            if (!Regex.IsMatch(txtCity.Text, checkcity))
            {
                error += "Ban phải nhập thành phố\n";
            }
            if (error != "")
            {
                MessageBox.Show("Có lỗi:" + error);
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
                    return;
                }
                else
                {
                    MessageBox.Show("Cập nhật thông tin sinh viên thành công");
                    clear();
                    show();
                }

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
                clear();
                show();
            }
        }

        private void btnFindID_Click(object sender, EventArgs e)
        {
            string id = txtID.Text;
            List<student> li = data.FindByID(id);
            if(li == null)
            {
                MessageBox.Show("Không tìm thấy sinh viên");
                clear();
                show();
            }
            else
            {
                dgv.DataSource = data.FindByID(id);
                clear();
                lbCount.Text = dgv.RowCount.ToString();
               \


            }
        }

        private void btnFindCity_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;

            dgv.DataSource = data.FindByName(name);
            clear();
            lbCount.Text = dgv.RowCount.ToString();
        }
    }
}
