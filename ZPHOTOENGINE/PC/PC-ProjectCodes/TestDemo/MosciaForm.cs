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
    public partial class MosciaForm : CCWin.Skin_Mac
    {
        public MosciaForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)zPhoto.MosaicProcess(curBitmap, blocksize);
            }
        }
        private ZPhotoEngineDll zPhoto = null;
        private Bitmap curBitmap = null;
        private int blocksize = 6;
        public int getBlocksize
        {
            get { return blocksize; }
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            blocksize = skinHScrollBar1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                blocksize = skinHScrollBar1.Value;
                textBox1.Text = blocksize.ToString();
                pictureBox1.Image = (Image)zPhoto.MosaicProcess(curBitmap, blocksize);
            }
        }
    }
}
