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
    public partial class MinForm : CCWin.Skin_Mac
    {
        public MinForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)zPhoto.MinFilterProcess(curBitmap, radius);
            }
        }
        private ZPhotoEngineDll zPhoto = null;
        private Bitmap curBitmap = null;
        private int radius = 20;
        public int getRadius
        {
            get { return radius; }
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            radius = skinHScrollBar1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                radius = skinHScrollBar1.Value;
                textBox1.Text = radius.ToString();
                pictureBox1.Image = (Image)zPhoto.MinFilterProcess(curBitmap, radius);
            }
        }
    }
}
