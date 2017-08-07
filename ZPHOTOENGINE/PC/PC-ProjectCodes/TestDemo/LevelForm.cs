using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace TestDemo
{
    unsafe public partial class LevelForm : CCWin.Skin_Mac
    {
        public LevelForm(string path)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            this.DoubleBuffered = true;
            Bitmap tmp = new Bitmap(path);
            if (tmp != null)
            {
                curBitmap = new Bitmap(tmp, 150 * tmp.Width / Math.Max(tmp.Width, tmp.Height), 150 * tmp.Height / Math.Max(tmp.Width, tmp.Height));
                DrawHistogram(curBitmap, 0);
            }
        }
        private Bitmap curBitmap = null;
        private int leftInput = 0;
        private double midInput = 0;
        private int rightInput = 255;
        private int leftOutput = 0;
        private int rightOutput = 255;
        private int channel = 0;
        public int getChannel
        {
            get { return channel; }
        }
        public int getLeftInput
        {
            get { return leftInput; }
        }
        public double getMidInput
        {
            get { return midInput; }
        }
        public int getRightInput
        {
            get { return rightInput; }
        }
        public int getLeftOutput
        {
            get { return leftOutput; }
        }
        public int getRightOutput
        {
            get { return rightOutput; }
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            leftInput = Convert.ToInt32(textBox1.Text);
            midInput = Convert.ToDouble(textBox2.Text);
            rightInput = Convert.ToInt32(textBox3.Text);
            leftOutput = Convert.ToInt32(textBox4.Text);
            rightOutput = Convert.ToInt32(textBox5.Text);
            channel = comboBox1.SelectedIndex;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                leftInput = Convert.ToInt32(textBox1.Text);
                rightInput = Convert.ToInt32(textBox3.Text);
                rightInput = Math.Min(255, Math.Max(0, rightInput));
                leftInput = Math.Min(255, Math.Max(0, leftInput));
                if (leftInput > rightOutput - 2)
                    leftInput = rightOutput - 2;
                textBox1.Text = leftInput.ToString();
                textBox3.Text = rightInput.ToString();
            }
            catch { return; }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try{
            leftInput = Convert.ToInt32(textBox1.Text);
            rightInput = Convert.ToInt32(textBox3.Text);
            rightInput = Math.Min(255, Math.Max(0, rightInput));
            leftInput = Math.Min(255, Math.Max(0, leftInput));
            if (leftInput > rightOutput - 2)
                rightOutput = leftInput + 2;
            textBox1.Text = leftInput.ToString();
            textBox3.Text = rightInput.ToString();
            }
            catch { return; }
        }
        private void DrawHistogram(Bitmap tmp, int channel)
        {
            if (tmp != null)
            {
                int w = tmp.Width;
                int h = tmp.Height;
                int[] gray = new int[256];
                int[] r = new int[256];
                int[] g = new int[256];
                int[] b = new int[256];
                BitmapData srcData = tmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
                byte* p = (byte*)srcData.Scan0;
                int offset = srcData.Stride - w * 4;
                for (int j = 0; j < h; j++)
                {
                    for (int i = 0; i < w; i++)
                    {
                        gray[(int)((p[0] + p[1] + p[2]) / 3)]++;
                        b[p[0]]++;
                        g[p[1]]++;
                        r[p[2]]++;
                        p += 4;
                    }
                    p += offset;
                }
                tmp.UnlockBits(srcData);
                Bitmap grayHisBmp = new Bitmap(System.Windows.Forms.Application.StartupPath + "\\hisBmp.jpg");
                Graphics grayGra = Graphics.FromImage(grayHisBmp);
                Point start;
                Point end;
                Pen p0 = new Pen(Color.Black, 1);
                Pen p1 = new Pen(Color.Red, 1);
                Pen p2 = new Pen(Color.Green, 1);
                Pen p3 = new Pen(Color.Blue, 1);
                int grayMax = gray.Max();
                int rMax = r.Max();
                int gMax = g.Max();
                int bMax = b.Max();
                switch (channel)
                {
                    case 0:
                        for (int i = 0; i < 256; i++)
                        {
                            start = new Point(i, 0);
                            end = new Point(i, 150 - gray[i] * 150 / (grayMax));
                            grayGra.DrawLine(p0, start, end);
                        }
                        break;
                    case 1:
                        for (int i = 0; i < 256; i++)
                        {
                            start = new Point(i, 0);
                            end = new Point(i, 150 - r[i] * 150 / (rMax));
                            grayGra.DrawLine(p0, start, end);
                        }
                        break;
                    case 2:
                        for (int i = 0; i < 256; i++)
                        {
                            start = new Point(i, 0);
                            end = new Point(i, 150 - g[i] * 150 / (gMax));
                            grayGra.DrawLine(p0, start, end);
                        }
                        break;
                    case 3:
                        for (int i = 0; i < 256; i++)
                        {
                            start = new Point(i, 0);
                            end = new Point(i, 150 - b[i] * 150 / (bMax));
                            grayGra.DrawLine(p0, start, end);
                        }
                        break;
                }
                grayGra.Dispose();
                pictureBox1.Image = (Image)grayHisBmp;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawHistogram(curBitmap, comboBox1.SelectedIndex);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //string t = textBox2.Text.ToString();
            //try{
            //    midInput = Convert.ToDouble(t);
            //midInput = Math.Min(9.99, Math .Max(midInput,0));
            //textBox2.Text = midInput.ToString();
            //}
            //catch { return; }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try{
            leftOutput = Convert.ToInt32(textBox4.Text);
            leftOutput = Math.Min(255, Math.Max(leftOutput, 0));
            textBox4.Text = leftOutput.ToString();
            }
            catch { return; }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                rightOutput = Convert.ToInt32(textBox5.Text);
                rightOutput = Math.Min(255, Math.Max(rightOutput, 0));
                textBox5.Text = rightOutput.ToString();
            }
            catch { return; }
        }
    }
}
