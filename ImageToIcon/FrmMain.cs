using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TinifyAPI;
using System.IO;

namespace ImageToIcon
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private readonly string API_KEY = "L3LlYyp4gsytVz8jktX24VNQy7csC4f0";
        private void FrmMain_Load(object sender, EventArgs e)
        {
            ShowCount();
        }

        private async void ShowCount()
        {
            try
            {
                Tinify.Key = API_KEY;
                await Tinify.Validate();
                var compressionsThisMonth = Tinify.CompressionCount;
                lbCount.Text = String.Format("本月用量 {0} /500" , compressionsThisMonth.ToString());
            }
            catch (System.Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void BtnCom_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(tbSource.Text) ||
                !Directory.Exists(tbSource.Text) ||
                String.IsNullOrEmpty(tbTarget.Text) ||
                !Directory.Exists(tbTarget.Text))
            {
                MessageBox.Show("目录不存在!");
                return;
            }
            Tinify.Key = API_KEY;

            var files = Directory.GetFiles(tbSource.Text);

            foreach (var file in files)
            {
                string ext = Path.GetExtension(file);
                if (ext.Contains("png") || ext.Contains("jpeg") || ext.Contains("jpg"))
                {
                    string outPath = Path.Combine(tbTarget.Text, Path.GetFileNameWithoutExtension(file) + ".png");
                    Tinify.FromFile(file).ToFile(outPath).Wait();
                }
            }

            var compressionsThisMonth = Tinify.CompressionCount;
            lbCount.Text = String.Format("本月用量 {0} /500", compressionsThisMonth.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = @"C:\Users\Yin\Desktop\2.jpg";
            Bitmap bt = new Bitmap(path);

            //Graphics g = Graphics.FromImage(bt);

            bt.Save(@"C:\Users\Yin\Desktop\3.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);


            //Bitmap bt2 = new Bitmap((@"C:\Users\Yin\Desktop\2.jpg");

        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                tbSource.Text = dlg.SelectedPath;
            }
        }
    }
}
