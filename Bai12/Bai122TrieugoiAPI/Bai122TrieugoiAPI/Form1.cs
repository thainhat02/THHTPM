using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Bai122TrieugoiAPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string postString = string.Format("?ma={0}&ten={1}", txtMa.Text, txtTen.Text);
            string link = "http://localhost/Bai12/api/donvi/" + postString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "POST";
            request.ContentType = "application/json; charset=UTF-8";
            byte[] byteArr = Encoding.UTF8.GetBytes(postString);
            request.ContentLength = byteArr.Length;
            Stream datastream = request.GetRequestStream();
            datastream.Write(byteArr, 0, byteArr.Length);
            datastream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
               
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string putString = string.Format("?ma={0}&ten={1}", txtMa.Text, txtTen.Text);
            string link = "http://localhost/Bai12/api/donvi/" + putString;
            HttpWebRequest request = HttpWebRequest.CreateHttp(link);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=UTF-8";
            byte[] bytearr = Encoding.UTF8.GetBytes(putString);
            request.ContentLength = bytearr.Length;
            Stream stream = request.GetRequestStream();
            stream.Write(bytearr, 0, bytearr.Length);
            stream.Close();
            DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(bool));
            object data = js.ReadObject(request.GetResponse().GetResponseStream());
            bool kq = (bool)data;
            if (kq)
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Sửa thất bại");
            }
        }
    }
}
