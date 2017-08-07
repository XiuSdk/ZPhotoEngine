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
    public partial class RotateForm : CCWin.Skin_Mac
    {
        public RotateForm(string path)
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
        private int degree = 0;
        private Bitmap curBitmap = null;
        public int getDegree
        {
            get
            {
                return degree;
            }
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            degree = Convert.ToInt32(textBox1.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox1.Text = skinHScrollBar1.Value.ToString();
            pictureBox1.Image = (Image)zPhoto.TransformRotation(curBitmap, skinHScrollBar1.Value, 1, 0);
        }
    }
}
