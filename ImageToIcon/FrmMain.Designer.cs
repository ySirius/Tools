namespace ImageToIcon
{
    partial class FrmMain
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
            this.btnCom = new System.Windows.Forms.Button();
            this.lbCount = new System.Windows.Forms.Label();
            this.tbSource = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbTarget = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCom
            // 
            this.btnCom.Location = new System.Drawing.Point(553, 178);
            this.btnCom.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCom.Name = "btnCom";
            this.btnCom.Size = new System.Drawing.Size(100, 90);
            this.btnCom.TabIndex = 0;
            this.btnCom.Text = "压缩";
            this.btnCom.UseVisualStyleBackColor = true;
            this.btnCom.Click += new System.EventHandler(this.BtnCom_Click);
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(14, 9);
            this.lbCount.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(161, 27);
            this.lbCount.TabIndex = 2;
            this.lbCount.Text = "本月用量 0 /500";
            // 
            // tbSource
            // 
            this.tbSource.Location = new System.Drawing.Point(114, 178);
            this.tbSource.Name = "tbSource";
            this.tbSource.Size = new System.Drawing.Size(350, 34);
            this.tbSource.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 181);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 27);
            this.label1.TabIndex = 4;
            this.label1.Text = "压缩目录";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 237);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 27);
            this.label2.TabIndex = 5;
            this.label2.Text = "输出目录";
            // 
            // tbTarget
            // 
            this.tbTarget.Location = new System.Drawing.Point(114, 234);
            this.tbTarget.Name = "tbTarget";
            this.tbTarget.Size = new System.Drawing.Size(350, 34);
            this.tbTarget.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(663, 178);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 90);
            this.button1.TabIndex = 7;
            this.button1.Text = "测试压缩";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(470, 178);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 34);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.Text = "打开文件";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.BtnOpen_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(970, 579);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbTarget);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbSource);
            this.Controls.Add(this.lbCount);
            this.Controls.Add(this.btnCom);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmMain";
            this.Text = "JPEG.PNG压缩";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCom;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.TextBox tbSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbTarget;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnOpen;
    }
}