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
    public partial class HighlightShadowForm : CCWin.Skin_Mac
    {
        public HighlightShadowForm(string path)
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
        private int shadow = 0;
        private int highlight = 0;
        public int getShadow
        {
            get { return shadow; }
        }
        public int getHighlight
        {
            get { return highlight; }
        }
        private Bitmap tmp = null;
        //阴影
        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                shadow = skinHScrollBar1.Value;
                highlight = skinHScrollBar2.Value;
                textBox1.Text = shadow.ToString();
                textBox2.Text = highlight.ToString();
                tmp = zPhoto.ShadowAdjust(curBitmap, shadow, 100);
                pictureBox1.Image = (Image)zPhoto.HighlightAdjust(tmp, highlight, 100);
            }
        }
        //高光
        private void skinHScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                shadow = skinHScrollBar1.Value;
                highlight = skinHScrollBar2.Value;
                textBox1.Text = shadow.ToString();
                textBox2.Text = highlight.ToString();
                pictureBox1.Image = (Image)zPhoto.HighlightShadowPreciseAdjustProcess(curBitmap, highlight, shadow);
                //tmp = zPhoto.ShadowAdjust(curBitmap, shadow, 100);
                //pictureBox1.Image = (Image)zPhoto.HighlightAdjust(tmp, highlight, 100);
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            shadow = skinHScrollBar1.Value;
            highlight = skinHScrollBar2.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
