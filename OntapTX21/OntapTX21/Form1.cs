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

namespace OntapTX21
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
            txtMasach.Clear();
            txtTensach.Clear();
            txtSotrang.Clear();
            txtHoten.Clear();
            txtDiachi.Clear();
        }
        private void show()
        {
            dgv.DataSource = data.ShowList();
            lbCount.Text = dgv.RowCount.ToString();
        }
        private void GetABook(object sender, DataGridViewCellEventArgs e)
        {
            Sach s = (Sach)dgv.CurrentRow.DataBoundItem;
            txtMasach.Text = s.masach;
            txtTensach.Text = s.tensach;
            txtSotrang.Text = s.sotrang;
            txtHoten.Text = s.hoten;
            txtDiachi.Text = s.diachi;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            show();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            show();
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
            string checkms = "^[s][0-9]{2}$";
            string checkts = "^[a-zA-Z ]+$";
            string checkst = "^[0-9]{1,4}$";
            string checkht = "^[a-zA-Z ]+$";
            string checkdc = "^[a-zA-Z ]+$";
            if(!Regex.IsMatch(txtMasach.Text, checkms))
            {
                error += "\nBạn cần nhập lại mã sách";
            }
            if (!Regex.IsMatch(txtTensach.Text, checkts))
            {
                error += "\nBạn cần nhập lại tên sách";
            }
            if (!Regex.IsMatch(txtSotrang.Text, checkst))
            {
                error += "\nBạn cần nhập lại số trang sách";
            }
            if (!Regex.IsMatch(txtHoten.Text, checkht))
            {
                error += "\nBạn cần nhập lại họ tên";
            }
            if (!Regex.IsMatch(txtDiachi.Text, checkdc))
            {
                error += "\nBạn cần nhập lại địa chỉ";
            }
            if (error != "")
            {
                MessageBox.Show("Có lỗi: " + error, "Thông báo");
            }
            else
            {
                Sach s = new Sach();
                s.masach = txtMasach.Text;
                s.tensach = txtTensach.Text;
                s.sotrang = txtSotrang.Text;
                s.hoten = txtHoten.Text;
                s.diachi = txtDiachi.Text;
                bool k = data.Add(s);
                if (!k)
                {
                    MessageBox.Show("Trùng mã");
                    return;
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
            string checkms = "^[s][0-9]{2}$";
            string checkts = "^[a-zA-Z ]+$";
            string checkst = "^[0-9]{1,4}$";
            string checkht = "^[a-zA-Z ]+$";
            string checkdc = "^[a-zA-Z ]+$";
            if (!Regex.IsMatch(txtMasach.Text, checkms))
            {
                error += "\nBạn cần nhập lại mã sách";
            }
            if (!Regex.IsMatch(txtTensach.Text, checkts))
            {
                error += "\nBạn cần nhập lại tên sách";
            }
            if (!Regex.IsMatch(txtSotrang.Text, checkst))
            {
                error += "\nBạn cần nhập lại số trang sách";
            }
            if (!Regex.IsMatch(txtHoten.Text, checkht))
            {
                error += "\nBạn cần nhập lại họ tên";
            }
            if (!Regex.IsMatch(txtDiachi.Text, checkdc))
            {
                error += "\nBạn cần nhập lại địa chỉ";
            }
            if (error != "")
            {
                MessageBox.Show("Có lỗi: " + error, "Thông báo");
            }
            else
            {
                Sach s = new Sach();
                s.masach = txtMasach.Text;
                s.tensach = txtTensach.Text;
                s.sotrang = txtSotrang.Text;
                s.hoten = txtHoten.Text;
                s.diachi = txtDiachi.Text;
                bool k = data.Update(s);
                if (!k)
                {
                    MessageBox.Show("Không tìm thấy sinh viên");
                    return;
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
            string error = "";
            string checkms = "^[s][0-9]{2}$";
            if (!Regex.IsMatch(txtMasach.Text, checkms))
            {
                error += "\nBạn cần nhập lại mã sách";
            }
            if (error != "")
            {
                MessageBox.Show("Có lỗi: " + error, "Thông báo");
            }
            else
            {
                string masach = txtMasach.Text;
                bool k = data.Delete(masach);
                if (!k)
                {
                    MessageBox.Show("Không tìm thấy sinh viên");
                    return;
                }
                else
                {
                    Clear();
                    show();
                }
            }
        }

        private void btnFindname_Click(object sender, EventArgs e)
        {
            string error = "";
            string checkht = "^[a-zA-Z ]+$";
            if (!Regex.IsMatch(txtHoten.Text, checkht))
            {
                error += "\nBạn cần nhập lại họ tên";
            }
            if (error != "")
            {
                MessageBox.Show("Có lỗi: " + error, "Thông báo");
            }
            else
            {
                string hoten = txtHoten.Text;
                List<Sach> li = data.FindName(hoten);
                if (li.Count>0)
                {
                    dgv.DataSource = li;
                    lbCount.Text = dgv.RowCount.ToString();
                    Clear();
                }
                else
                {
                    MessageBox.Show("Không có sinh viên nào");
                    Clear();
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
