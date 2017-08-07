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
    public partial class ZoomForm : CCWin.Skin_Mac
    {
        public ZoomForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;  
        }
        private float scale = 0;
        public float getScale
        {
            get
            {
                return scale;
            }
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            scale = (float)skinHScrollBar1.Value / 10.0f;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void skinHScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            textBox1.Text = ((double)skinHScrollBar1.Value / 10.0).ToString();
        }
    }
}
