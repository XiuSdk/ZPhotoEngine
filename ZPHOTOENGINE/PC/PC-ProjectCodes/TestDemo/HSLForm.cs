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
    public partial class HSLForm : CCWin.Skin_Mac
    {
        public HSLForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)curBitmap;
            }
            
        }
        private ZPhotoEngineDll zPhoto = null;
        private Bitmap curBitmap = null;
        private int hue = 0;
        private int satruation = 0;
        private int lightness = 0;
        private Bitmap tmp = null;
        public int getHue
        {
            get { return hue; }
        }
        public int getSaturation
        {
            get { return satruation; }
        }
        public int getLightness
        {
            get { return lightness; }
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            hue = hScrollBar1.Value;
            satruation = hScrollBar2.Value;
            lightness = hScrollBar3.Value; 
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        //hue
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                textBox1.Text = hScrollBar1.Value.ToString();
                hue = hScrollBar1.Value;
                satruation = hScrollBar2.Value;
                lightness = hScrollBar3.Value;
                tmp = zPhoto.HueSaturationAdjust(curBitmap, hue, satruation);
                pictureBox1.Image = (Image)zPhoto.LightnessAdjustProcess(tmp, lightness);
            }
        }
        //saturation
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                textBox2.Text = hScrollBar2.Value.ToString();
                hue = hScrollBar1.Value;
                satruation = hScrollBar2.Value;
                lightness = hScrollBar3.Value;
                tmp = zPhoto.HueSaturationAdjust(curBitmap, hue, satruation);
                pictureBox1.Image = (Image)zPhoto.LightnessAdjustProcess(tmp, lightness);
            }
        }
        //lightness
        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                textBox3.Text = hScrollBar3.Value.ToString();
                hue = hScrollBar1.Value;
                satruation = hScrollBar2.Value;
                lightness = hScrollBar3.Value;
                tmp = zPhoto.HueSaturationAdjust(curBitmap, hue, satruation);
                pictureBox1.Image = (Image)zPhoto.LightnessAdjustProcess(tmp, lightness);
            }
        }
    }
}
