using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace TestDemo
{
    public partial class MessageForm : Skin_Mac
    {
        public MessageForm(string msg)
        {
            InitializeComponent();
            this.DoubleBuffered = true;  
            skinLabel1.Text = msg.ToString();
        }
        private void messageBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
