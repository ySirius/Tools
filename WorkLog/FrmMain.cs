using EV.Utility.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkLog
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private static readonly string folder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "evinf");
        private static readonly string iniFile = Path.Combine(folder, "worklog.ini");

        private CookieCollection _cookie = new CookieCollection();


        private string _week = "";          //上周日期
        private string _preWeek = "";       //上上周日期

        private void FrmMain_Load(object sender, EventArgs e)
        {
            InitTime();
            ReadIni();
        }

        private void InitTime()
        {
            DateTime dt = DateTime.Now;
            DateTime thisWeek = dt.AddDays(-2 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));
            DateTime preWeek = thisWeek.AddDays(-7);
            _week = thisWeek.ToString("yyyy-MM-dd");
            _preWeek = preWeek.ToString("yyyy-MM-dd");
        }

        private void ReadIni()
        {
            tbName.Text = FileHelper.ReadIni("user", "name", "", iniFile);
            tbPwd.Text = FileHelper.ReadIni("user", "pwd", "", iniFile);
            cbAuto.Checked = FileHelper.ReadIni("user", "auto", "False", iniFile) == "True";
        }

        private void WriteIni()
        {
            FileHelper.WriteIni("user", "name", tbName.Text, iniFile);
            FileHelper.WriteIni("user", "pwd", tbPwd.Text, iniFile);
            FileHelper.WriteIni("user", "auto", cbAuto.Checked.ToString(), iniFile);
        }


        private bool Login(string name, string pwd)
        {
            //没有引用dll方法是为了获取Cookies 利用Cookies获取用户登录名称
            Dictionary<string, string> keyValues = new Dictionary<string, string>()
            {
                { "account", name },
                { "password", pwd }
            };

            HttpPostRequestClient httpPost = new HttpPostRequestClient();
            foreach (var key in keyValues)
            {
                httpPost.SetField(key.Key, key.Value);
            }
            HttpWebResponse webRespon;
            webRespon = httpPost.Post("https://evinf.cn/bbs/web/login/login", "");

            _cookie = webRespon.Cookies;

            Stream s = webRespon.GetResponseStream();
            //读取服务器端返回的消息
            StreamReader sr = new StreamReader(s);
            string re = sr.ReadToEnd();

            s.Close();
            webRespon.Close();

            string result = JsonHelper.GetValueByTag(re, "msg");
            if (result.Equals("登录成功"))
            {
                WriteIni();
                return true;
            }
            else
                return false;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            bool a = Login(tbName.Text, tbPwd.Text);
            if (a)
            {
                //登录成功
                plLogin.Visible = false;
                plInfo.Visible = true;
                if (GetLastRecord(_week))
                {
                    SetText(_md_content);
                    lbName.Text = "登录账号: " + _username + " 上周工作记录已填写";
                }
                else
                {
                    GetLastRecord(_preWeek);
                    AISetText(_md_content);
                    lbName.Text = "登录账号: " + _username + " 上周工作记录已生成(待提交)";
                }
            }
        }

        /// <summary>
        /// 默认拉取上周的日志
        /// </summary>
        private bool GetLastRecord(string time)
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://evinf.cn/bbs/web/record/getRecord?time=" + time);
                request.Method = "GET";
                request.ContentType = "application/json;charset=UTF-8";
                request.CookieContainer = new CookieContainer();
                for (int i = 0; i < _cookie.Count; i++)
                {
                    request.CookieContainer.Add(_cookie[i]);
                }
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream();

                StreamReader sr = new StreamReader(s, Encoding.GetEncoding("utf-8"));

                string retString = sr.ReadToEnd();
                string data = JsonHelper.GetValueByTag(retString, "data");
                if (string.IsNullOrEmpty(data)) return false;
                _md_content = JsonHelper.GetValueByTag(data, "md_content");
                if (string.IsNullOrEmpty(_md_content)) return false;
                sr.Close();
                s.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        private string _username = "";

        private string _md_content = "";

        /// <summary>
        /// 显示已经完成的日志
        /// </summary>
        /// <param name="md_content"></param>
        private void SetText(string md_content)
        {
            if (string.IsNullOrEmpty(md_content)) return;
            string[] contents = md_content.Split('|');
            if (contents.Length == 0) return;
            for (int i = 0; i < contents.Length; i++)
            {
                if (contents[i].Contains("姓名"))
                {
                    _username = contents[i + 1].Replace("**", "").Trim();
                }
                if (contents[i].Contains("上周已完成"))
                {
                    rtbPre.Text = contents[i + 1].Replace("<br />", "\n").Trim();
                }
                else if (contents[i].Contains("正在完成中"))
                {
                    rtbIng.Text = contents[i + 1].Replace("<br />", "\n").Trim();
                }
                else if (contents[i].Contains("下周计划"))
                {
                    rtbNext.Text = contents[i + 1].Replace("<br />", "\n").Trim();
                }
                else if (contents[i].Contains("排在后面的活"))
                {
                    rtbFuture.Text = contents[i + 1].Replace("<br />", "\n").Trim();
                }
            }
        }

        /// <summary>
        /// 自动填充日志
        /// </summary>
        /// <param name="md_content"></param>
        private void AISetText(string md_content)
        {
            string[] contents = md_content.Split('|');
            if (contents.Length == 0) return;
            for (int i = 0; i < contents.Length; i++)
            {
                if (contents[i].Contains("姓名"))
                {
                    _username = contents[i + 1].Replace("**", "").Trim();
                }
                else if (contents[i].Contains("正在完成中"))
                {
                    rtbPre.Text = contents[i + 1].Replace("<br />", "\n").Trim();
                }
                else if (contents[i].Contains("下周计划"))
                {
                    rtbPre.Text += contents[i + 1].Replace("<br />", "\n").Trim();
                }
                else if (contents[i].Contains("排在后面的活"))
                {
                    rtbFuture.Text = contents[i + 1].Replace("<br />", "\n").Trim();
                }
            }
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            string mdText = CreateMdText();
            Dictionary<string, string> keyValues = new Dictionary<string, string>()
            {
                { "md_content", mdText },
                { "content" , CreateHtmlText() },
                { "time", _week }
            };
            string json = JsonConvert.SerializeObject(keyValues);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://evinf.cn/bbs/web/record/setRecord");
                request.Method = "POST";
                request.ContentType = "application/json;charset=UTF-8";
                byte[] byteData = Encoding.UTF8.GetBytes(json);
                int length = byteData.Length;
                request.ContentLength = length;
                request.CookieContainer = new CookieContainer();
                for (int i = 0; i < _cookie.Count; i++)
                {
                    request.CookieContainer.Add(_cookie[i]);
                }

                //request.CookieContainer.Add()
                Stream writer = request.GetRequestStream();
                writer.Write(byteData, 0, length);
                writer.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream s = response.GetResponseStream();
                //读取服务器端返回的消息
                StreamReader sr = new StreamReader(s);
                string retString = sr.ReadToEnd();

                string data = JsonHelper.GetValueByTag(retString, "msg");
                if (data.Equals("执行成功"))
                {
                    MessageBox.Show("提交成功!");
                    lbName.Text = "登录账号: " + _username + " 上周工作记录已生成(已提交)";
                }
                else
                    MessageBox.Show(data);

                s.Close();
                response.Close();
                //return retString;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                //return e.Message;
            }
        }

        private string CreateMdText()
        {
            string content = string.Format(@"| **姓名** | {0} |
| ---------------- | -------------------------------------------------- |
| **上周已完成**   |{1}|
| **正在完成中**   |{2}|
| **下周计划**     |{3}|
| **排在后面的活** |{4}|
------", _username,
ReText(rtbPre.Text),
ReText(rtbIng.Text),
ReText(rtbNext.Text),
ReText(rtbFuture.Text));
            return content.Replace("\r\n", "\n");
        }

        private string CreateHtmlText()
        {
            string content = string.Format(@"<table>
<thead>
<tr>
<th><strong>姓名</strong></th>
<th>{0}</th>
</tr>
</thead>
<tbody>
<tr>
<td><strong>上周已完成</strong></td>
<td>{1}</td>
</tr>
<tr>
<td><strong>正在完成中</strong></td>
<td>{2}
</td></tr>
<tr>
<td><strong>下周计划</strong></td>
<td>{3}
</td></tr>
<tr>
<td><strong>排在后面的活</strong></td>
<td>{4}
</td></tr>
</tbody>
</table>
<hr>", _username,
ReText2(rtbPre.Text),
ReText2(rtbIng.Text),
ReText2(rtbNext.Text),
ReText2(rtbFuture.Text)
);
            return content.Replace("\r\n", "\n");
        }

        private string ReText(string text)
        {
            return text.Replace("\n", "<br />");
        }
        private string ReText2(string text)
        {
            return text.Replace("\n", "<br>");
        }
    }
}
