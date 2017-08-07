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
    public partial class ThresholdForm : CCWin.Skin_Mac
    {
        public ThresholdForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)zPhoto.Threshold(curBitmap, threshold);
            }
        }
        private ZPhotoEngineDll zPhoto = null;
        private Bitmap curBitmap = null;
        private int threshold = 128;
        public int getThresold
        {
            get { return threshold; }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            threshold = skinHScrollBar1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                threshold = skinHScrollBar1.Value;
                textBox1.Text = threshold.ToString();
                pictureBox1.Image = (Image)zPhoto.Threshold(curBitmap, threshold);
            }
        }
    }
}
