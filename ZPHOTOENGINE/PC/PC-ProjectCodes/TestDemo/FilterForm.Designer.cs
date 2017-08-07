namespace TestDemo
{
    partial class FilterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.skinButton1 = new CCWin.SkinControl.SkinButton();
            this.skinComboBox1 = new CCWin.SkinControl.SkinComboBox();
            this.skinPictureBox1 = new CCWin.SkinControl.SkinPictureBox();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.skinGroupBox1 = new CCWin.SkinControl.SkinGroupBox();
            this.skinButton2 = new CCWin.SkinControl.SkinButton();
            this.skinButton3 = new CCWin.SkinControl.SkinButton();
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).BeginInit();
            this.skinGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // skinButton1
            // 
            this.skinButton1.BackColor = System.Drawing.Color.Transparent;
            this.skinButton1.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton1.DownBack = null;
            this.skinButton1.Location = new System.Drawing.Point(6, 31);
            this.skinButton1.MouseBack = null;
            this.skinButton1.Name = "skinButton1";
            this.skinButton1.NormlBack = null;
            this.skinButton1.Size = new System.Drawing.Size(75, 23);
            this.skinButton1.TabIndex = 0;
            this.skinButton1.Text = "选择模板";
            this.skinButton1.UseVisualStyleBackColor = false;
            this.skinButton1.Click += new System.EventHandler(this.skinButton1_Click);
            // 
            // skinComboBox1
            // 
            this.skinComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.skinComboBox1.FormattingEnabled = true;
            this.skinComboBox1.Items.AddRange(new object[] {
            "变暗",
            "正片叠底",
            "颜色加深",
            "线性渐变",
            "深色",
            "变亮",
            "滤色",
            "颜色减淡  ",
            "颜色线性减淡",
            "浅色",
            "叠加",
            "柔光",
            "强光",
            "亮光",
            "线性",
            "点光",
            "实色",
            "差值",
            "排除",
            "减去",
            "划分"});
            this.skinComboBox1.Location = new System.Drawing.Point(197, 31);
            this.skinComboBox1.Name = "skinComboBox1";
            this.skinComboBox1.Size = new System.Drawing.Size(121, 22);
            this.skinComboBox1.TabIndex = 1;
            this.skinComboBox1.WaterText = "";
            // 
            // skinPictureBox1
            // 
            this.skinPictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinPictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.skinPictureBox1.Location = new System.Drawing.Point(19, 114);
            this.skinPictureBox1.Name = "skinPictureBox1";
            this.skinPictureBox1.Size = new System.Drawing.Size(324, 205);
            this.skinPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.skinPictureBox1.TabIndex = 2;
            this.skinPictureBox1.TabStop = false;
            // 
            // skinLabel1
            // 
            this.skinLabel1.AutoSize = true;
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(102, 33);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(92, 17);
            this.skinLabel1.TabIndex = 3;
            this.skinLabel1.Text = "图层混合模式：";
            // 
            // skinGroupBox1
            // 
            this.skinGroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.BorderColor = System.Drawing.Color.DarkGray;
            this.skinGroupBox1.Controls.Add(this.skinButton1);
            this.skinGroupBox1.Controls.Add(this.skinLabel1);
            this.skinGroupBox1.Controls.Add(this.skinComboBox1);
            this.skinGroupBox1.ForeColor = System.Drawing.Color.Blue;
            this.skinGroupBox1.Location = new System.Drawing.Point(19, 31);
            this.skinGroupBox1.Name = "skinGroupBox1";
            this.skinGroupBox1.RectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.RoundStyle = CCWin.SkinClass.RoundStyle.All;
            this.skinGroupBox1.Size = new System.Drawing.Size(324, 79);
            this.skinGroupBox1.TabIndex = 4;
            this.skinGroupBox1.TabStop = false;
            this.skinGroupBox1.TitleBorderColor = System.Drawing.Color.Red;
            this.skinGroupBox1.TitleRectBackColor = System.Drawing.Color.Transparent;
            this.skinGroupBox1.TitleRoundStyle = CCWin.SkinClass.RoundStyle.All;
            // 
            // skinButton2
            // 
            this.skinButton2.BackColor = System.Drawing.Color.Transparent;
            this.skinButton2.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton2.DownBack = null;
            this.skinButton2.Location = new System.Drawing.Point(25, 331);
            this.skinButton2.MouseBack = null;
            this.skinButton2.Name = "skinButton2";
            this.skinButton2.NormlBack = null;
            this.skinButton2.Size = new System.Drawing.Size(120, 23);
            this.skinButton2.TabIndex = 5;
            this.skinButton2.Text = "确定";
            this.skinButton2.UseVisualStyleBackColor = false;
            this.skinButton2.Click += new System.EventHandler(this.skinButton2_Click);
            // 
            // skinButton3
            // 
            this.skinButton3.BackColor = System.Drawing.Color.Transparent;
            this.skinButton3.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.skinButton3.DownBack = null;
            this.skinButton3.Location = new System.Drawing.Point(216, 331);
            this.skinButton3.MouseBack = null;
            this.skinButton3.Name = "skinButton3";
            this.skinButton3.NormlBack = null;
            this.skinButton3.Size = new System.Drawing.Size(120, 23);
            this.skinButton3.TabIndex = 6;
            this.skinButton3.Text = "取消";
            this.skinButton3.UseVisualStyleBackColor = false;
            this.skinButton3.Click += new System.EventHandler(this.skinButton3_Click);
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 367);
            this.Controls.Add(this.skinButton3);
            this.Controls.Add(this.skinButton2);
            this.Controls.Add(this.skinGroupBox1);
            this.Controls.Add(this.skinPictureBox1);
            this.MaximumSize = new System.Drawing.Size(362, 367);
            this.MinimumSize = new System.Drawing.Size(362, 367);
            this.Name = "FilterForm";
            this.Text = "自定义滤镜";
            this.TitleCenter = false;
            this.Load += new System.EventHandler(this.FilterForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.skinPictureBox1)).EndInit();
            this.skinGroupBox1.ResumeLayout(false);
            this.skinGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton skinButton1;
        private CCWin.SkinControl.SkinComboBox skinComboBox1;
        private CCWin.SkinControl.SkinPictureBox skinPictureBox1;
        private CCWin.SkinControl.SkinLabel skinLabel1;
        private CCWin.SkinControl.SkinGroupBox skinGroupBox1;
        private CCWin.SkinControl.SkinButton skinButton2;
        private CCWin.SkinControl.SkinButton skinButton3;
    }
}