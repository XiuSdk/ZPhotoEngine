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
    public partial class TempreatureForm : CCWin.Skin_Mac
    {
        public TempreatureForm(string path)
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
        private Bitmap curBitmap = null;
        private int tempeature = 0;
        private ZPhotoEngineDll zPhoto = null;
        public int getTempeature
        {
            get { return tempeature; }
        }

        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                tempeature = skinHScrollBar1.Value;
                textBox1.Text = tempeature.ToString();
                pictureBox1.Image = (Image)zPhoto.ColorTemperatureProcess(curBitmap, tempeature);
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            tempeature = skinHScrollBar1.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
