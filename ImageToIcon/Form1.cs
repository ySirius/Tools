using Svg;  
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToIcon
{
    public partial class Form1 : Form
    {
        private string _PicPath = "";

        public Form1()
        {
            InitializeComponent();
            cbFormat.SelectedIndex = 0;
        }

        private void PicBox_DragEnter(object sender, DragEventArgs e)   
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private Image ReadSvg(string path)
        {
            SvgDocument svgDocument = SvgDocument.Open(path);

            int wid = (int)svgDocument.Bounds.Width;
            int hig = (int)svgDocument.Bounds.Height;

            Bitmap bitmap = new Bitmap(wid, hig);
            Graphics graphics = Graphics.FromImage(bitmap);
            ISvgRenderer renderer = SvgRenderer.FromGraphics(graphics);
            svgDocument.Width = wid;
            svgDocument.Height = hig;
            svgDocument.Draw(renderer);
            return bitmap;
        }

        private void PicBox_DragDrop(object sender, DragEventArgs e)
        {
            _PicPath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string ext = Path.GetExtension(_PicPath);
            if (File.Exists(_PicPath))
            {
                if (ext == ".svg")
                {
                    picBox.Image = ReadSvg(_PicPath);
                    cbFormat.SelectedIndex = 0;

                }
                else if (ext == ".png")
                {
                    picBox.Image = Image.FromFile(_PicPath);
                    cbFormat.SelectedIndex = 1;
                }
            }
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            if (picBox.Image == null)
            {
                Graphics g = e.Graphics;
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                g.DrawString("请把图片拖到此处", Font, Brushes.Black, e.ClipRectangle, sf);
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            if (picBox.Image == null) return;
            
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            string path = "";
            switch (cbFormat.SelectedIndex)
            {
                case 0:
                    path = Path.Combine(desktop, "1.png");
                    picBox.Image.Save(path, ImageFormat.Png);
                    break;
                case 1:
                    path = Path.Combine(desktop, "1.ico");
                    var icon = ConvertToIcon(picBox.Image);
                    using (Stream stream = new System.IO.FileStream(path, System.IO.FileMode.Create))
                    {
                        icon.Save(stream);
                    }
                    break;
            }

        }

        public static Icon ConvertToIcon(Image image)
        {
            if (image == null)
            {
                return null;
            }

            using (MemoryStream msImg = new MemoryStream()
                              , msIco = new MemoryStream())
            {
                image.Save(msImg, ImageFormat.Png);

                using (var bin = new BinaryWriter(msIco))
                {
                    //写图标头部
                    bin.Write((short)0);           //0-1保留
                    bin.Write((short)1);           //2-3文件类型。1=图标, 2=光标
                    bin.Write((short)1);           //4-5图像数量（图标可以包含多个图像）

                    bin.Write((byte)image.Width);  //6图标宽度
                    bin.Write((byte)image.Height); //7图标高度
                    bin.Write((byte)0);            //8颜色数（若像素位深>=8，填0。这是显然的，达到8bpp的颜色数最少是256，byte不够表示）
                    bin.Write((byte)0);            //9保留。必须为0
                    bin.Write((short)0);           //10-11调色板
                    bin.Write((short)32);          //12-13位深
                    bin.Write((int)msImg.Length);  //14-17位图数据大小
                    bin.Write(22);                 //18-21位图数据起始字节

                    //写图像数据
                    bin.Write(msImg.ToArray());

                    bin.Flush();
                    bin.Seek(0, SeekOrigin.Begin);
                    return new Icon(msIco);
                }
            }
        }
    }
}
