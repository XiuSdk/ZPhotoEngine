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
    public partial class USMForm : CCWin.Skin_Mac
    {
        public USMForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 300 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 300 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)zPhoto.USMProcess(curBitmap, (float)radius, amount, threshold);
            }
        }
        private ZPhotoEngineDll zPhoto = null;
        private Bitmap curBitmap = null;
        private double radius = 1.5;
        private int amount = 200;
        private int threshold = 10;
        public double getRadius
        {
            get { return radius; }
        }
        public int getAmount
        {
            get { return amount; }
        }
        public int getThreshold
        {
            get { return threshold; }
        }
        //amount
        private void skinHScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                amount = skinHScrollBar2.Value;
                radius = (double)skinHScrollBar1.Value / 10.0;
                threshold = skinHScrollBar3.Value;
                textBox2.Text = amount.ToString();
                textBox1.Text = radius.ToString();
                textBox3.Text = threshold.ToString();
                pictureBox1.Image = (Image)zPhoto.USMProcess(curBitmap, (float)radius, amount, threshold);
            }
        }
        //radius
        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                amount = skinHScrollBar2.Value;
                radius = (double)skinHScrollBar1.Value / 10.0;
                threshold = skinHScrollBar3.Value;
                textBox2.Text = amount.ToString();
                textBox1.Text = radius.ToString();
                textBox3.Text = threshold.ToString();
                pictureBox1.Image = (Image)zPhoto.USMProcess(curBitmap, (float)radius, amount, threshold);
            }
        }
        //threshold
        private void skinHScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                amount = skinHScrollBar2.Value;
                radius = (double)skinHScrollBar1.Value / 10.0;
                threshold = skinHScrollBar3.Value;
                textBox2.Text = amount.ToString();
                textBox1.Text = radius.ToString();
                textBox3.Text = threshold.ToString();
                pictureBox1.Image = (Image)zPhoto.USMProcess(curBitmap, (float)radius, amount, threshold);
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            amount = skinHScrollBar2.Value;
            radius = (double)skinHScrollBar1.Value / 10.0;
            threshold = skinHScrollBar3.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
