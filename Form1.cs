using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HttpRequestDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // GET 方法
            //string url = "https://www.baidu.com";
            // string pararm = "";
            // string result = HttpRequest.get(url);
            // string result = HttpRequest.get(url, pararm);

            // POST 方法
            // string url = "http://192.168.200.166:9080/login";
            // string param = "username=admin&password=123456";
            // string result = HttpRequest.post(url);
            // string result = HttpRequest.post(url, param);


            string url = this.textUrl.Text.Trim();
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = "http://" + url;
            }
            
            string method = this.rButtonGET.Checked ? "GET" : "POST";
            string data = this.textData.Text.Trim();
            string result = HttpRequest.submitHttpRequest(url, method, data);
            // 显示返回值
            this.textResult.Text = result;
        }
    }
}
