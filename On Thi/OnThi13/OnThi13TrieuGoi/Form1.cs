using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnThi13TrieuGoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<NhanVien> nhanViens;
        private NhanVien nv;
        private List<NhanVien> HienThi()
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:8080/api/")
            };
            var response = client.GetAsync("nhanvien").Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<NhanVien>>().Result;
            }
            else
            {
                return null;
            }
        }

        private bool Add(NhanVien nv)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:8080/api/")
            };
            var response = client.PostAsJsonAsync("nhanvien", nv).Result;
            return response.IsSuccessStatusCode;
        }
        private bool Updat (NhanVien nv)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:8080/api/")
            };
            var response = client.PutAsJsonAsync("nhanvien", nv).Result;
            return response.IsSuccessStatusCode;
        }

        private List<NhanVien> Find(string ma)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:8080/api/")
            };
            var response = client.GetAsync($"nhanvien?ma={ma}").Result;

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<List<NhanVien>>().Result;
            }
            else
            {
                return null;
            }
        }
        private bool Delete(string ma)
        {
            HttpClient client = new HttpClient()
            {
                BaseAddress = new Uri("http://localhost:8080/api/")
            };
            var response = client.DeleteAsync($"nhanvien?ma={ma}").Result;
            return response.IsSuccessStatusCode;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            nhanViens = HienThi();
            dataGridView1.DataSource = nhanViens;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Add(new NhanVien()
            {
                Ma = txtMa.Text,
                Ten = txtTen.Text,
                NgaySinh = dateTimePicker1.Value,
                GioiTinh = rbtNam.Checked ? "Nam" : "Nữ",
                HeSoLuong = Convert.ToInt32(txtHSL.Text)
            }))
                dataGridView1.DataSource = HienThi();
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = nhanViens.FirstOrDefault(x => x.Ma == txtMa.Text);

            nhanVien.Ten = txtTen.Text;
            nhanVien.NgaySinh = dateTimePicker1.Value;
            nhanVien.GioiTinh = rbtNam.Checked ? "Nam" : "Nữ";
            nhanVien.HeSoLuong = Convert.ToInt32(txtHSL.Text);
            if (Updat(nhanVien))
            {
                dataGridView1.DataSource = HienThi();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
            
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Xác nhận yêu cầu xóa", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (Delete(txtMa.Text))
                {
                    dataGridView1.DataSource = HienThi();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại");
                }
            }
            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (Find(txtMa.Text) != null)
            {
                nhanViens = Find(txtMa.Text);
                dataGridView1.DataSource = nhanViens;
            }
            else
            {
                MessageBox.Show("Không có sinh viên nào");
            }

        }

        private void GetANV(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;
            txtMa.Text = row.Cells["Ma"].Value.ToString();
            txtTen.Text = row.Cells["Ten"].Value.ToString();
            dateTimePicker1.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
            rbtNam.Checked = row.Cells["GioiTinh"].Value.ToString() == "Nam";
            rbtNu.Checked = !(row.Cells["GioiTinh"].Value.ToString() == "Nam");
            txtHSL.Text = row.Cells["HeSoLuong"].Value.ToString();
        }
    }
}
