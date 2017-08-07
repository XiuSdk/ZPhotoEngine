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
    public partial class GaussBlurForm : CCWin.Skin_Mac
    {
        public GaussBlurForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 300 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 300 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)zPhoto.GaussFilterProcess(curBitmap, (float)radius);
            }
        }
        private Bitmap curBitmap = null;
        private double radius = 15.0;
        private ZPhotoEngineDll zPhoto = null;
        public double getRadius
        {
            get { return radius; }
        }

        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                radius = (double)skinHScrollBar1.Value / 10.0;
                textBox1.Text = radius.ToString();
                pictureBox1.Image = (Image)zPhoto.GaussFilterProcess(curBitmap, (float)radius);
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            radius = (double)skinHScrollBar1.Value / 10.0;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
