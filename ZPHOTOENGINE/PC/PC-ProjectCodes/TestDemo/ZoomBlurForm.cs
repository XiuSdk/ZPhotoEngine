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
    public partial class ZoomBlurForm : CCWin.Skin_Mac
    {
        public ZoomBlurForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)zPhoto.ZoomBlurProcess(curBitmap, radius, amount);
            }
        }
        private ZPhotoEngineDll zPhoto = null;
        private Bitmap curBitmap = null;
        private int radius = 10;
        private int amount = 10;
        public int getRadius
        {
            get { return radius; }
        }
        public int getAmount
        {
            get { return amount; }
        }
        //radius
        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                radius = skinHScrollBar1.Value;
                amount = skinHScrollBar2.Value;
                textBox1.Text = radius.ToString();
                textBox2.Text = amount.ToString();
                pictureBox1.Image = (Image)zPhoto.ZoomBlurProcess(curBitmap, radius, amount);
            }
        }
        //amount
        private void skinHScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                radius = skinHScrollBar1.Value;
                amount = skinHScrollBar2.Value;
                textBox1.Text = radius.ToString();
                textBox2.Text = amount.ToString();
                pictureBox1.Image = (Image)zPhoto.ZoomBlurProcess(curBitmap, radius, amount);
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            radius = skinHScrollBar1.Value;
            amount = skinHScrollBar2.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
