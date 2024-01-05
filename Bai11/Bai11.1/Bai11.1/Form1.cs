using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using static System.Net.WebRequestMethods;

namespace Bai11._1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Link gọi API
            string link = "http://localhost:8080/api/sanpham";
            // tạo ra một yêu cầu gửi tới website dùng HttpWebRequest
            HttpWebRequest request = WebRequest.CreateHttp(link);
            //lấy thông tin trả về từ Web server sử dụng webresponse
            WebResponse response = request.GetResponse();
            //đưa dữ liệu từ mảng sản phẩm về định dạng Json sử dụng thư viện DataContractJsonSerializer
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(TrieuGoiWebAPI[]));
            // lấy dữ liệu dạng json đưa về mô hình  đối tượng đã định nghĩa
            object data = js.ReadObject(response.GetResponseStream());
            //ép dữ liệu về mảng sanpham
            TrieuGoiWebAPI[] arr = data as TrieuGoiWebAPI[];
            dataGridView1.DataSource = arr;
        }
    }
}
