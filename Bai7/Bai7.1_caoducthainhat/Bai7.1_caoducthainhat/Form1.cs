using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai7._1_caoducthainhat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataUtil data = new DataUtil();
        List<TaiKhoan> taiKhoans = new List<TaiKhoan>();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.sotaikhoan = txtSoTK.Text;
            tk.tentaikhoan = txtTenTK.Text;
            tk.diachi = txtDIaChi.Text;
            tk.dienthoai = txtDienThoai.Text;
            tk.sotien = txtSoTien.Text;
            bool k = data.AddTaiKhoan(tk);
            if (!k)
            {
                MessageBox.Show("Số tài khoản đã tồn tại");
                return;
            }
            else
            {
                data.AddTaiKhoan(tk);
                CLear();
                loadfile();
            }
            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            CLear();
        }
        private void CLear()
        {
            txtSoTK.Clear();
            txtTenTK.Clear();
            txtDIaChi.Clear();
            txtDienThoai.Clear();
            txtSoTien.Clear();

        }

        private void btnCLose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Xác nhận yêu cầu thoát", "Thông báo", MessageBoxButtons.YesNo) == DialogResult.Yes) 
            {
                this.Close();
            }
        }

        private void loadfile()
        {
            dgv.DataSource = data.ShowCount();
            lbCount.Text = dgv.Rows.Count.ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            loadfile();

        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            loadfile();
        }

        private void GetATaiKhoan(object sender, DataGridViewCellEventArgs e) // event cell click
        {
            TaiKhoan tk = (TaiKhoan)dgv.CurrentRow.DataBoundItem;
            txtSoTK.Text = tk.sotaikhoan;
            txtTenTK.Text = tk.tentaikhoan;
            txtDIaChi.Text = tk.diachi;
            txtDienThoai.Text = tk.dienthoai;
            txtSoTien.Text = tk.sotien;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            TaiKhoan tk = new TaiKhoan();
            tk.sotaikhoan = txtSoTK.Text;
            tk.tentaikhoan = txtTenTK.Text;
            tk.diachi = txtDIaChi.Text;
            tk.dienthoai = txtDienThoai.Text;
            tk.sotien = txtSoTien.Text;
            bool k = data.UpdateTaiKhoan(tk);
            if (!k)
            {
                MessageBox.Show("Không cập nhật được sinh viên có id = " + tk.sotaikhoan);
                return;
            }
            loadfile();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắc chắn muốn xóa không? ", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if(d== DialogResult.Yes)
            {
                bool kt = data.DeleteTaiKhoan(txtSoTK.Text);
                if (!kt)
                {
                    MessageBox.Show("Có lỗi khi xóa", "thông báo");
                    return;
                }
                loadfile();
                CLear();
            }
        }

        private void btnFindID_Click(object sender, EventArgs e)
        {
            string sotaikhoan = txtSoTK.Text;
            List<TaiKhoan> li = new List<TaiKhoan>();
            TaiKhoan taiKhoan = data.FindByID(sotaikhoan);
            if (taiKhoan != null)
            {
                li.Add(taiKhoan);
                dgv.DataSource = li;
                lbCount.Text = dgv.Rows.Count + "";
                txtSoTK.Text = taiKhoan.sotaikhoan;
                txtTenTK.Text = taiKhoan.tentaikhoan;
                txtDIaChi.Text = taiKhoan.diachi;
                txtDienThoai.Text = taiKhoan.dienthoai;
                txtSoTien.Text = taiKhoan.sotien;
            }
        }

        private void btnFindName_Click(object sender, EventArgs e)
        {
            string tentaikhoan = txtTenTK.Text;
            List<TaiKhoan> li = data.FindByName(tentaikhoan);
            if (li != null)
            {
                dgv.DataSource = li;
                lbCount.Text = dgv.Rows.Count + "";
                
            }
        }
    }
}
