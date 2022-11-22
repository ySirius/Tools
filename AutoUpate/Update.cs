using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EV.Utility.Helper;

namespace AutoUpate
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private readonly string _yggUrl = "https://ygg.evinf.cn/ota/";

        private readonly string _sportUrl = "http://ota.sportguider.com:8899/ota/";

        private void Update_Load(object sender, EventArgs e)
        {
            JudgeVersion();
            if (true)
                this.Close();
        }

        private void JudgeVersion()
        {
            //只判断是否有新版本
            var result = Http.GetForm(_yggUrl + "update/fcbce34ff66b69db6591d90cbc469d47/latest", "");
            var code = JsonHelper.GetValueByTag(result, "code");

            if (code == "1")
            {
                string data = JsonHelper.GetValueByTag(result, "data");
                //正确返回结果
                string version  = JsonHelper.GetValueByTag(data, "version");
            }
        }

        private void DownNewFile()
        {
            
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            DownNewFile();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
