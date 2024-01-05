using System.Net;
using System.Runtime.Serialization.Json;
using System.IO;
using System.Text;

namespace OnThi7TrieuGoi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void HienThi()
        {
            string link = "http://localhost/OnThi7/api/sanpham";
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = data as SanPham[];
            dataGridView1.DataSource = arr;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            HienThi();
        }

        private void GetASP(object sender, DataGridViewCellEventArgs e)
        {
            SanPham sp = (SanPham)dataGridView1.CurrentRow.DataBoundItem;
            txtMa.Text = sp.MaSP.ToString();
            txtTen.Text = sp.TenSP;
            txtDonGia.Text = sp.DonGia.ToString();
            txtSoLuong.Text = sp.SoLuong.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string post = string.Format("?ma={0}&ten={1}&dongia={2}&soluong={3}",
                txtMa.Text, txtTen.Text, txtDonGia.Text, txtSoLuong.Text);
            string link = "http://localhost/OnThi7/api/sanpham/" + post;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            request.Method = "POST";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(post);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                MessageBox.Show("Thêm thành công");
                HienThi();
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string put = string.Format("?ma={0}&ten={1}&dongia={2}&soluong={3}",
                txtMa.Text, txtTen.Text, txtDonGia.Text, txtSoLuong.Text);
            string link = "http://localhost/OnThi7/api/sanpham/" + put;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(put);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                MessageBox.Show("Sửa thành công");
                HienThi();
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string del = string.Format("?ma={0}", txtMa.Text);
            string link = "http://localhost/OnThi7/api/sanpham/" + del;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            request.Method = "DELETE";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytes = Encoding.UTF8.GetBytes(del);
            request.ContentLength = bytes.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                MessageBox.Show("Xóa thành công");
                HienThi();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string find = string.Format("?ten={0}", txtTen.Text);
            string link = "http://localhost/OnThi7/api/sanpham/" + find;
            HttpWebRequest request = WebRequest.CreateHttp(link);
            WebResponse response = request.GetResponse();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(SanPham[]));
            object data = js.ReadObject(response.GetResponseStream());
            SanPham[] arr = data as SanPham[];
            dataGridView1.DataSource = arr;
        }
    }
}