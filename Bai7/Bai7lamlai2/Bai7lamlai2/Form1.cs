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

namespace Bai7lamlai2
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string error = "";
            string checkid = "^[S][0-9]{1,4}$";
            string checkname = "^[a-zA-Z ]+$"; // tên phải bao gồm các chữ từ a-z tu A - Z và có thể xuất hiện 1 hoặc nhiều lần(+)
            string checkage = "^[0-9]{2}$";
            string checkcity = "^[a-zA-Z ]+$";
            if(!Regex.IsMatch(txtID.Text, checkid)) // kiểm tra txtID có thỏa mã checkid không
            {
                error += "\nBạn phải nhập mã sv bắt đầu bằng S và theo sau là từ 1 đến 4 số";
            }
            if(!Regex.IsMatch(txtName.Text, checkname))
            {
                error += "\nBạn phải nhập họ tên";
            }
            if(!Regex.IsMatch(txtAge.Text, checkage))
            {
                error += "\nBạn phải nhập tuổi có 2 chữ số";
            }

            if(!Regex.IsMatch(txtCity.Text, checkcity))
            {
                error += "\nBạn phải nhập thành phố";
            }
            if (error != null)
            {
                MessageBox.Show("Có lỗi: " + error);
            }
            else
            {
                Student student = new Student();
                student.id = txtID.Text;
                student.name = txtName.Text;
                student.age = txtAge.Text;
                student.city = txtCity.Text;
                bool check = data.AddStudent(student);
                if (!check)
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại");
                    return;
                }
                else
                {
                    data.AddStudent(student);
                    MessageBox.Show("Thêm thành công");
                    clear();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Xác nhận thoát", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
