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
    public partial class MotionBlurForm : CCWin.Skin_Mac
    {
        public MotionBlurForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)zPhoto.MotionBlur(curBitmap, angle, distance);
            }
        }
        private ZPhotoEngineDll zPhoto = null;
        private Bitmap curBitmap = null;
        private int angle = 90;
        private int distance = 14;
        public int getAngle
        {
            get { return angle; }
        }
        public int getDistance
        {
            get { return distance; }
        }
        //angle
        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                angle = skinHScrollBar1.Value;
                distance = skinHScrollBar2.Value;
                textBox1.Text = angle.ToString();
                textBox2.Text = distance.ToString();
                pictureBox1.Image = (Image)zPhoto.MotionBlur(curBitmap, angle, distance);
            }
        }
        //distance
        private void skinHScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                angle = skinHScrollBar1.Value;
                distance = skinHScrollBar2.Value;
                textBox1.Text = angle.ToString();
                textBox2.Text = distance.ToString();
                pictureBox1.Image = (Image)zPhoto.MotionBlur(curBitmap, angle, distance);
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            angle = skinHScrollBar1.Value;
            distance = skinHScrollBar2.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
