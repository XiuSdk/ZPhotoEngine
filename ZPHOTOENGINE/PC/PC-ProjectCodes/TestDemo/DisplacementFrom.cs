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
    public partial class DisplacementFrom : CCWin.Skin_Mac
    {
        public DisplacementFrom()
        {
            InitializeComponent();
        }
        private string mskPath = null;
        private int hRatio = 10;
        private int vRatio = 10;
        public string getMaskPath
        {
            get { return mskPath; }
        }
        public int getHRatio
        {
            get { return hRatio; }
        }
        public int getVRatio
        {
            get { return vRatio; }
        }
        private void skinButton1_Click(object sender, EventArgs e)
        {
            mskPath = textBox1.Text.ToString();
            hRatio = Convert.ToInt32(textBox2.Text);
            vRatio = Convert.ToInt32(textBox3.Text);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
