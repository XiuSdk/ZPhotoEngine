namespace TestDemo
{
    partial class MessageForm
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
            this.messageBtn = new CCWin.SkinControl.SkinButton();
            this.skinLabel1 = new CCWin.SkinControl.SkinLabel();
            this.SuspendLayout();
            // 
            // messageBtn
            // 
            this.messageBtn.BackColor = System.Drawing.Color.Transparent;
            this.messageBtn.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.messageBtn.DownBack = null;
            this.messageBtn.Location = new System.Drawing.Point(115, 99);
            this.messageBtn.MouseBack = null;
            this.messageBtn.Name = "messageBtn";
            this.messageBtn.NormlBack = null;
            this.messageBtn.Size = new System.Drawing.Size(75, 23);
            this.messageBtn.TabIndex = 0;
            this.messageBtn.Text = "确定";
            this.messageBtn.UseVisualStyleBackColor = false;
            this.messageBtn.Click += new System.EventHandler(this.messageBtn_Click);
            // 
            // skinLabel1
            // 
            this.skinLabel1.BackColor = System.Drawing.Color.Transparent;
            this.skinLabel1.BorderColor = System.Drawing.Color.White;
            this.skinLabel1.Font = new System.Drawing.Font("Microsoft YaHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.skinLabel1.Location = new System.Drawing.Point(19, 60);
            this.skinLabel1.Name = "skinLabel1";
            this.skinLabel1.Size = new System.Drawing.Size(261, 23);
            this.skinLabel1.TabIndex = 1;
            this.skinLabel1.Text = "Error";
            this.skinLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MessageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(295, 142);
            this.Controls.Add(this.skinLabel1);
            this.Controls.Add(this.messageBtn);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(295, 142);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(295, 142);
            this.Name = "MessageForm";
            this.Text = "Message";
            this.TitleCenter = false;
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinButton messageBtn;
        private CCWin.SkinControl.SkinLabel skinLabel1;
    }
}