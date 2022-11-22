namespace TakeFood
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
            this.cbPerson = new System.Windows.Forms.CheckedListBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.tbResult = new System.Windows.Forms.RichTextBox();
            this.lbList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbPerson
            // 
            this.cbPerson.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.cbPerson.CheckOnClick = true;
            this.cbPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbPerson.Font = new System.Drawing.Font("Consolas", 10F);
            this.cbPerson.FormattingEnabled = true;
            this.cbPerson.Location = new System.Drawing.Point(3, 18);
            this.cbPerson.Margin = new System.Windows.Forms.Padding(4);
            this.cbPerson.Name = "cbPerson";
            this.cbPerson.Size = new System.Drawing.Size(185, 171);
            this.cbPerson.TabIndex = 0;
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.Gray;
            this.btnGo.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Font = new System.Drawing.Font("Consolas", 11F);
            this.btnGo.ForeColor = System.Drawing.Color.White;
            this.btnGo.Location = new System.Drawing.Point(120, 196);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(149, 30);
            this.btnGo.TabIndex = 8;
            this.btnGo.Text = "Good Luck~";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.BtnGo_Click);
            // 
            // tbResult
            // 
            this.tbResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbResult.Location = new System.Drawing.Point(0, 233);
            this.tbResult.Name = "tbResult";
            this.tbResult.Size = new System.Drawing.Size(384, 28);
            this.tbResult.TabIndex = 9;
            this.tbResult.Text = "";
            // 
            // lbList
            // 
            this.lbList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbList.Font = new System.Drawing.Font("Consolas", 11F);
            this.lbList.FormattingEnabled = true;
            this.lbList.ItemHeight = 18;
            this.lbList.Location = new System.Drawing.Point(3, 18);
            this.lbList.Name = "lbList";
            this.lbList.Size = new System.Drawing.Size(187, 171);
            this.lbList.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPerson);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(191, 192);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "All ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbList);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(191, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(193, 192);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Lucky Value";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(384, 192);
            this.panel1.TabIndex = 13;
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(384, 261);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.btnGo);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "取外卖";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox cbPerson;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.RichTextBox tbResult;
        private System.Windows.Forms.ListBox lbList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
    }
}

