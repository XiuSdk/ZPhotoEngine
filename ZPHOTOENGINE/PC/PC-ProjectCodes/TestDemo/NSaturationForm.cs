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
    public partial class NSaturationForm :  CCWin.Skin_Mac
    {
        public NSaturationForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)zPhoto.NaturalSaturationProcess(curBitmap, saturation);
            }
        }
        private ZPhotoEngineDll zPhoto = null;
        private Bitmap curBitmap = null;
        private int saturation = 0;
        public int getSaturation
        {
            get { return saturation; }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            saturation = skinHScrollBar1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                saturation = skinHScrollBar1.Value;
                textBox1.Text = saturation.ToString();
                pictureBox1.Image = (Image)zPhoto.NaturalSaturationProcess(curBitmap, saturation);
            }
        }
    }
}
