
namespace WorkLog
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.rtbIng = new System.Windows.Forms.RichTextBox();
            this.rtbFuture = new System.Windows.Forms.RichTextBox();
            this.rtbPre = new System.Windows.Forms.RichTextBox();
            this.rtbNext = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbAuto = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.plLogin = new System.Windows.Forms.Panel();
            this.plInfo = new System.Windows.Forms.Panel();
            this.lbName = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.plLogin.SuspendLayout();
            this.plInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(454, 424);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 27);
            this.btnSubmit.TabIndex = 0;
            this.btnSubmit.Text = "提交";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(70, 5);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(150, 25);
            this.tbName.TabIndex = 1;
            // 
            // tbPwd
            // 
            this.tbPwd.Location = new System.Drawing.Point(269, 5);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '*';
            this.tbPwd.Size = new System.Drawing.Size(150, 25);
            this.tbPwd.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(226, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "密码";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.White;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLogin.ForeColor = System.Drawing.Color.Black;
            this.btnLogin.Location = new System.Drawing.Point(425, 34);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 27);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "登录";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // rtbIng
            // 
            this.rtbIng.BackColor = System.Drawing.Color.White;
            this.rtbIng.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbIng.Location = new System.Drawing.Point(156, 89);
            this.rtbIng.Name = "rtbIng";
            this.rtbIng.Size = new System.Drawing.Size(345, 80);
            this.rtbIng.TabIndex = 6;
            this.rtbIng.Text = "";
            // 
            // rtbFuture
            // 
            this.rtbFuture.BackColor = System.Drawing.Color.White;
            this.rtbFuture.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbFuture.Location = new System.Drawing.Point(156, 261);
            this.rtbFuture.Name = "rtbFuture";
            this.rtbFuture.Size = new System.Drawing.Size(345, 80);
            this.rtbFuture.TabIndex = 7;
            this.rtbFuture.Text = "";
            // 
            // rtbPre
            // 
            this.rtbPre.BackColor = System.Drawing.Color.White;
            this.rtbPre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbPre.Location = new System.Drawing.Point(156, 3);
            this.rtbPre.Name = "rtbPre";
            this.rtbPre.Size = new System.Drawing.Size(345, 80);
            this.rtbPre.TabIndex = 8;
            this.rtbPre.Text = "";
            // 
            // rtbNext
            // 
            this.rtbNext.BackColor = System.Drawing.Color.White;
            this.rtbNext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbNext.Location = new System.Drawing.Point(156, 175);
            this.rtbNext.Name = "rtbNext";
            this.rtbNext.Size = new System.Drawing.Size(345, 80);
            this.rtbNext.TabIndex = 9;
            this.rtbNext.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "上周已完成";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "正在完成";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "下周计划";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 290);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "排在后面的活";
            // 
            // cbAuto
            // 
            this.cbAuto.AutoSize = true;
            this.cbAuto.Location = new System.Drawing.Point(425, 6);
            this.cbAuto.Name = "cbAuto";
            this.cbAuto.Size = new System.Drawing.Size(84, 24);
            this.cbAuto.TabIndex = 16;
            this.cbAuto.Text = "记住密码";
            this.cbAuto.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.rtbFuture);
            this.panel1.Controls.Add(this.rtbNext);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.rtbPre);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.rtbIng);
            this.panel1.Location = new System.Drawing.Point(20, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 347);
            this.panel1.TabIndex = 17;
            // 
            // plLogin
            // 
            this.plLogin.Controls.Add(this.cbAuto);
            this.plLogin.Controls.Add(this.tbName);
            this.plLogin.Controls.Add(this.btnLogin);
            this.plLogin.Controls.Add(this.tbPwd);
            this.plLogin.Controls.Add(this.label1);
            this.plLogin.Controls.Add(this.label2);
            this.plLogin.Dock = System.Windows.Forms.DockStyle.Top;
            this.plLogin.Location = new System.Drawing.Point(0, 0);
            this.plLogin.Name = "plLogin";
            this.plLogin.Size = new System.Drawing.Size(551, 65);
            this.plLogin.TabIndex = 18;
            // 
            // plInfo
            // 
            this.plInfo.Controls.Add(this.lbName);
            this.plInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.plInfo.Location = new System.Drawing.Point(0, 65);
            this.plInfo.Name = "plInfo";
            this.plInfo.Size = new System.Drawing.Size(551, 61);
            this.plInfo.TabIndex = 14;
            this.plInfo.Visible = false;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Location = new System.Drawing.Point(148, 23);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(0, 20);
            this.lbName.TabIndex = 0;
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(551, 460);
            this.Controls.Add(this.plInfo);
            this.Controls.Add(this.plLogin);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSubmit);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日志生成器";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.plLogin.ResumeLayout(false);
            this.plLogin.PerformLayout();
            this.plInfo.ResumeLayout(false);
            this.plInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.RichTextBox rtbIng;
        private System.Windows.Forms.RichTextBox rtbFuture;
        private System.Windows.Forms.RichTextBox rtbPre;
        private System.Windows.Forms.RichTextBox rtbNext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox cbAuto;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel plLogin;
        private System.Windows.Forms.Panel plInfo;
        private System.Windows.Forms.Label lbName;
    }
}

