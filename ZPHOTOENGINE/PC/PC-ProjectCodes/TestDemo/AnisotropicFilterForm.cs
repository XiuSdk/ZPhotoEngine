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
    public partial class AnisotropicFilterForm : CCWin.Skin_Mac
    {
        public AnisotropicFilterForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)zPhoto.AnisotropicFilter(curBitmap, iter, k);
            }

        }
        private ZPhotoEngineDll zPhoto = null;
        private Bitmap curBitmap = null;
        private int iter = 7;
        private int k = 10;
        public int getIter
        {
            get { return iter; }
        }
        public int getK
        {
            get { return k; }
        }
        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                k = skinHScrollBar2.Value;
                iter = skinHScrollBar1.Value;
                textBox1.Text = iter.ToString();
                textBox2.Text = k.ToString();
                pictureBox1.Image = (Image)zPhoto.AnisotropicFilter(curBitmap, iter, k);
            }

        }

        private void skinHScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                k = skinHScrollBar2.Value;
                iter = skinHScrollBar1.Value;
                textBox1.Text = iter.ToString();
                textBox2.Text = k.ToString();
                pictureBox1.Image = (Image)zPhoto.AnisotropicFilter(curBitmap, iter, k);
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            k = skinHScrollBar2.Value;
            iter = skinHScrollBar1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
