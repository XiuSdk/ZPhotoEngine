using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestDemo
{
    public partial class BlackWhiteForm : CCWin.Skin_Mac
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        public BlackWhiteForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            comboBox1.SelectedIndex = 0;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 200 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 200 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)curBitmap;
                BlackWhite(0);
            }
        }
        private ZPhotoEngineDll zPhoto = null;
        private Bitmap curBitmap = null;
        private int kRed = 0, kYellow = 0, kGreen = 0, kCyan = 0, kBlue = 0, kMagenta = 0;
        private void skinButton1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                BlackWhite(comboBox1.SelectedIndex);
            }
        }
        public int getKRed
        {
            get { return kRed; }
        }
        public int getKGreen
        {
            get { return kGreen; }
        }
        public int getKBlue
        {
            get { return kBlue; }
        }
        public int getKYellow
        {
            get { return kYellow; }
        }
        public int getKCyan
        {
            get { return kCyan; }
        }
        public int getKMagenta
        {
            get { return kMagenta; }
        }
        private void BlackWhite(int mode)
        {
            switch (mode)
            {
                case 0://default
                    kRed = 40;
                    kYellow = 60;
                    kGreen = 40;
                    kCyan = 60;
                    kBlue = 20;
                    kMagenta = 80;
                    break;
                case 1://蓝色滤镜
                    kRed = 0;
                    kYellow = 0;
                    kGreen = 0;
                    kCyan = 110;
                    kBlue = 110;
                    kMagenta = 110;
                    break;
                case 2://较暗
                    kRed = 30;
                    kYellow = 50;
                    kGreen = 30;
                    kCyan = 50;
                    kBlue = 10;
                    kMagenta = 70;
                    break;
                case 3://绿色滤镜
                    kRed = 50;
                    kYellow = 120;
                    kGreen = 90;
                    kCyan = 50;
                    kBlue = 0;
                    kMagenta = 0;
                    break;
                case 4://高对比度蓝色滤镜
                    kRed = -50;
                    kYellow = -50;
                    kGreen = -50;
                    kCyan = 150;
                    kBlue = 150;
                    kMagenta = 150;
                    break;
                case 5://高对比度红色滤镜
                    kRed = 120;
                    kYellow = 120;
                    kGreen = -10;
                    kCyan = -50;
                    kBlue = -50;
                    kMagenta = 120;
                    break;
                case 6://红外线
                    kRed = -40;
                    kYellow = 235;
                    kGreen = 144;
                    kCyan = -68;
                    kBlue = -3;
                    kMagenta = -107;
                    break;
                case 7://较亮
                    kRed = 50;
                    kYellow = 70;
                    kGreen = 50;
                    kCyan = 70;
                    kBlue = 30;
                    kMagenta = 90;
                    break;
                case 8://最黑
                    kRed = 0;
                    kYellow = 0;
                    kGreen = 0;
                    kCyan = 0;
                    kBlue = 0;
                    kMagenta = 0;
                    break;
                case 9://最白
                    kRed = 100;
                    kYellow = 100;
                    kGreen = 100;
                    kCyan = 100;
                    kBlue = 100;
                    kMagenta = 100;
                    break;
                case 10://中灰密度
                    kRed = 128;
                    kYellow = 128;
                    kGreen = 100;
                    kCyan = 100;
                    kBlue = 128;
                    kMagenta = 100;
                    break;
                case 11://红色滤镜
                    kRed = 120;
                    kYellow = 110;
                    kGreen = -10;
                    kCyan = -50;
                    kBlue = 0;
                    kMagenta = 120;
                    break;
                case 12://黄色滤镜
                    kRed = 120;
                    kYellow = 110;
                    kGreen = 40;
                    kCyan = -30;
                    kBlue = 0;
                    kMagenta = 70;
                    break;
                default:
                    kRed = 40;
                    kYellow = 60;
                    kGreen = 40;
                    kCyan = 60;
                    kBlue = 20;
                    kMagenta = 80;
                    break;
            }
            hScrollBar1.Value = kRed;
            hScrollBar2.Value = kYellow;
            hScrollBar3.Value = kGreen;
            hScrollBar4.Value = kCyan;
            hScrollBar5.Value = kBlue;
            hScrollBar6.Value = kMagenta;
            textBox1.Text = kRed.ToString();
            textBox2.Text = kYellow.ToString();
            textBox3.Text = kGreen.ToString();
            textBox4.Text = kCyan.ToString();
            textBox5.Text = kBlue.ToString();
            textBox6.Text = kMagenta.ToString();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = (Image)zPhoto.BlackwhiteProcess(curBitmap, kRed, kGreen, kBlue, kYellow, kCyan, kMagenta);
            }
        }
        //red
        private void hScrollBar1_Scroll_1(object sender, ScrollEventArgs e)
        {
            kRed = hScrollBar1.Value;
            kYellow = hScrollBar2.Value;
            kGreen = hScrollBar3.Value;
            kCyan = hScrollBar4.Value;
            kBlue = hScrollBar5.Value;
            kMagenta = hScrollBar6.Value;
            textBox1.Text = kRed.ToString();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = (Image)zPhoto.BlackwhiteProcess(curBitmap, kRed, kGreen, kBlue, kYellow, kCyan, kMagenta);
            }
        }
        //yellow
        private void hScrollBar2_Scroll_1(object sender, ScrollEventArgs e)
        {
            kRed = hScrollBar1.Value;
            kYellow = hScrollBar2.Value;
            kGreen = hScrollBar3.Value;
            kCyan = hScrollBar4.Value;
            kBlue = hScrollBar5.Value;
            kMagenta = hScrollBar6.Value;
            textBox2.Text = kYellow.ToString();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = (Image)zPhoto.BlackwhiteProcess(curBitmap, kRed, kGreen, kBlue, kYellow, kCyan, kMagenta);
            }
        }
        ///////////////
        //green
        private void hScrollBar3_Scroll_1(object sender, ScrollEventArgs e)
        {
            kRed = hScrollBar1.Value;
            kYellow = hScrollBar2.Value;
            kGreen = hScrollBar3.Value;
            kCyan = hScrollBar4.Value;
            kBlue = hScrollBar5.Value;
            kMagenta = hScrollBar6.Value;
            textBox3.Text = kGreen.ToString();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = (Image)zPhoto.BlackwhiteProcess(curBitmap, kRed, kGreen, kBlue, kYellow, kCyan, kMagenta);
            }
        }
        //cyan
        private void hScrollBar4_Scroll_1(object sender, ScrollEventArgs e)
        {
            kRed = hScrollBar1.Value;
            kYellow = hScrollBar2.Value;
            kGreen = hScrollBar3.Value;
            kCyan = hScrollBar4.Value;
            kBlue = hScrollBar5.Value;
            kMagenta = hScrollBar6.Value;
            textBox4.Text = kCyan.ToString();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = (Image)zPhoto.BlackwhiteProcess(curBitmap, kRed, kGreen, kBlue, kYellow, kCyan, kMagenta);
            }
        }
        //blue
        private void hScrollBar5_Scroll_1(object sender, ScrollEventArgs e)
        {
            kRed = hScrollBar1.Value;
            kYellow = hScrollBar2.Value;
            kGreen = hScrollBar3.Value;
            kCyan = hScrollBar4.Value;
            kBlue = hScrollBar5.Value;
            kMagenta = hScrollBar6.Value;
            textBox5.Text = kBlue.ToString();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = (Image)zPhoto.BlackwhiteProcess(curBitmap, kRed, kGreen, kBlue, kYellow, kCyan, kMagenta);
            }
        }
        //magenta
        private void hScrollBar6_Scroll_1(object sender, ScrollEventArgs e)
        {
            kRed = hScrollBar1.Value;
            kYellow = hScrollBar2.Value;
            kGreen = hScrollBar3.Value;
            kCyan = hScrollBar4.Value;
            kBlue = hScrollBar5.Value;
            kMagenta = hScrollBar6.Value;
            textBox6.Text = kMagenta.ToString();
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = (Image)zPhoto.BlackwhiteProcess(curBitmap, kRed, kGreen, kBlue, kYellow, kCyan, kMagenta);
            }
        }
    }
}
