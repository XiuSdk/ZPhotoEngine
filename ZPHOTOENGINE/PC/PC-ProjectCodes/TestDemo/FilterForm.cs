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
    public partial class FilterForm : Skin_Mac
    {
        private Bitmap curBitmap = null;
        private string curFileName;

        private int filterId = 0;


        public int getMode
        {
           get
            {
                 return filterId;
            }
        }
        public string getMaskPath
        {
            get { return curFileName; }
        }
        public FilterForm( )
        {
            InitializeComponent();

        }

        //打开图像函数
        public void OpenFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "所有图像文件 | *.bmp; *.pcx; *.png; *.jpg; *.gif;" +
                   "*.tif; *.ico; *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf|" +
                   "位图( *.bmp; *.jpg; *.png;...) | *.bmp; *.pcx; *.png; *.jpg; *.gif; *.tif; *.ico|" +
                   "矢量图( *.wmf; *.eps; *.emf;...) | *.dxf; *.cgm; *.cdr; *.wmf; *.eps; *.emf";
            ofd.ShowHelp = true;
            ofd.Title = "打开图像文件";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                curFileName = ofd.FileName;
                try
                {
                    curBitmap = (Bitmap)System.Drawing.Image.FromFile(curFileName);
                    //srcBitmap = new Bitmap(curBitmap);
                }
                catch (Exception exp)
                { MessageBox.Show(exp.Message); }
            }
        }


        private void skinButton1_Click(object sender, EventArgs e)
        {
            OpenFile();

            if(curBitmap != null)
            {
                skinPictureBox1.Image = (Image)curBitmap;
            }

        }

        private void FilterForm_Load(object sender, EventArgs e)
        {
            skinComboBox1.SelectedIndex = 11;
        }

        private void skinButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void skinButton2_Click(object sender, EventArgs e)
        {
            filterId = Convert.ToInt32(skinComboBox1.SelectedIndex)+1;

            if (curBitmap != null)
            {
                this.DialogResult = DialogResult.OK; 
                this.Close();     
            }
            else
            {
                MessageForm msgForm = new MessageForm("请选择模板！");
                msgForm.Show();                       
            }
        }
    }
}
