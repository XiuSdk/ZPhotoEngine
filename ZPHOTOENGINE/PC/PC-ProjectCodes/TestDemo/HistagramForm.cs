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
    unsafe public partial class HistagramForm : CCWin.Skin_Mac
    {
        public HistagramForm(string path)
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            this.DoubleBuffered = true;
            curBitmap = new Bitmap(path);
            DrawHistogram(curBitmap, 0);
        }
        private Bitmap curBitmap = null;
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
                            grayGra.DrawLine(p1, start, end);
                        }
                        break;
                    case 2:
                        for (int i = 0; i < 256; i++)
                        {
                            start = new Point(i, 0);
                            end = new Point(i, 150 - g[i] * 150 / (gMax));
                            grayGra.DrawLine(p2, start, end);
                        }
                        break;
                    case 3:
                        for (int i = 0; i < 256; i++)
                        {
                            start = new Point(i, 0);
                            end = new Point(i, 150 - b[i] * 150 / (bMax));
                            grayGra.DrawLine(p3, start, end);
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
    }
}
