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
    public partial class ReliefForm : CCWin.Skin_Mac
    {
        public ReliefForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            zPhoto = new ZPhotoEngineDll();
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                pictureBox1.Image = (Image)zPhoto.Relief(curBitmap, angle, amount);
            }
        }
        private ZPhotoEngineDll zPhoto = null;
        private Bitmap curBitmap = null;
        private int angle = 90;
        private int amount = 500;
        public int getAngle
        {
            get { return angle; }
        }
        public int getAmount
        {
            get { return amount; }
        }
        //角度
        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                angle = skinHScrollBar1.Value;
                amount = skinHScrollBar2.Value;
                textBox1.Text = angle.ToString();
                textBox2.Text = amount.ToString();
                pictureBox1.Image = (Image)zPhoto.Relief(curBitmap, angle, amount);
            }
        }
        //数量
        private void skinHScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (curBitmap != null)
            {
                angle = skinHScrollBar1.Value;
                amount = skinHScrollBar2.Value;
                textBox1.Text = angle.ToString();
                textBox2.Text = amount.ToString();
                pictureBox1.Image = (Image)zPhoto.Relief(curBitmap, angle, amount);
            }
        }

        private void skinButton1_Click(object sender, EventArgs e)
        {
            angle = skinHScrollBar1.Value;
            amount = skinHScrollBar2.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
