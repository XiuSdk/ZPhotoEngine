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
    public partial class ChannelMixForm : CCWin.Skin_Mac
    {
        public ChannelMixForm(string path)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            srcBitmap = new Bitmap (path);
            curBitmap = new Bitmap(srcBitmap);
            comboBox1.SelectedIndex = 0;
            pictureBox1.Image = (Image)curBitmap;
            zPhoto = new ZPhotoEngineDll();
        }
        private Bitmap curBitmap = null;
        private Bitmap srcBitmap = null;
        private int kr = 0, kg = 0, kb = 0, N = 0, channel = 0;
        private bool singleColor = false;
        private ZPhotoEngineDll zPhoto = null;
        public Bitmap getResImage
        {
            get { return curBitmap; }
        }
        //red
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                textBox1.Text = hScrollBar1.Value.ToString();
                kr = hScrollBar1.Value;
                kg = hScrollBar2.Value;
                kb = hScrollBar3.Value;
                channel = comboBox1.SelectedIndex;
                pictureBox1.Image = (Image)zPhoto.ChannelMixProcess(curBitmap, channel, kr, kg, kb, N, singleColor, false);
            }
        }
        //green
        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                textBox2.Text = hScrollBar2.Value.ToString();
                kr = hScrollBar1.Value;
                kg = hScrollBar2.Value;
                kb = hScrollBar3.Value;
                channel = comboBox1.SelectedIndex;
                pictureBox1.Image = (Image)zPhoto.ChannelMixProcess(curBitmap, channel, kr, kg, kb, N, singleColor, false);
            }
        }
        //blue
        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                textBox3.Text = hScrollBar3.Value.ToString();
                kr = hScrollBar1.Value;
                kg = hScrollBar2.Value;
                kb = hScrollBar3.Value;
                channel = comboBox1.SelectedIndex;
                pictureBox1.Image = (Image)zPhoto.ChannelMixProcess(curBitmap, channel, kr, kg, kb, N, singleColor, false);
            }
        }
        //N
        private void hScrollBar4_Scroll(object sender, ScrollEventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                N = hScrollBar4.Value;
                kr = hScrollBar1.Value;
                kg = hScrollBar2.Value;
                kb = hScrollBar3.Value;
                channel = comboBox1.SelectedIndex;
                textBox4.Text = hScrollBar4.Value.ToString();
                pictureBox1.Image = (Image)zPhoto.ChannelMixProcess(curBitmap, channel, kr, kg, kb, N, singleColor, true);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                singleColor = true;
                comboBox1.SelectedIndex = 3;
                kr = 40; 
                kg = 40;
                kb = 20;
                N = 0;
                textBox1.Text = kr.ToString();
                textBox2.Text = kg.ToString();
                textBox3.Text = kb.ToString();
                textBox4.Text = N.ToString();
                hScrollBar1.Value = 40;
                hScrollBar2.Value = 40;
                hScrollBar3.Value = 20;
                hScrollBar4.Value = 0;
                curBitmap = new Bitmap(srcBitmap);
                pictureBox1.Image = (Image)curBitmap;
            }
            else
            {
                singleColor = false;
                comboBox1.SelectedIndex = 0;
                kr = 100;
                kg = 0;
                kb = 0;
                N = 0;
                textBox1.Text = kr.ToString();
                textBox2.Text = kg.ToString();
                textBox3.Text = kb.ToString();
                textBox4.Text = N.ToString();
                hScrollBar1.Value = 100;
                hScrollBar2.Value = 0;
                hScrollBar3.Value = 0;
                hScrollBar4.Value = 0;
                curBitmap = new Bitmap(srcBitmap);
                pictureBox1.Image = (Image)curBitmap;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 3)
            {
                singleColor = true;
                checkBox1.Checked = true;
            }
            else
            {
                singleColor = false;
                checkBox1.Checked = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                curBitmap = new Bitmap((Bitmap)pictureBox1.Image);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
