namespace WareHouse.Administrator
{
    partial class AdminManager
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvAdmin = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rbBasicAdmin = new System.Windows.Forms.RadioButton();
            this.rbSystemAdmin = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btDel = new System.Windows.Forms.Button();
            this.btModify = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvAdmin);
            this.groupBox1.Location = new System.Drawing.Point(67, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 384);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "操作员信息";
            // 
            // dgvAdmin
            // 
            this.dgvAdmin.AllowUserToAddRows = false;
            this.dgvAdmin.AllowUserToResizeColumns = false;
            this.dgvAdmin.AllowUserToResizeRows = false;
            this.dgvAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAdmin.Location = new System.Drawing.Point(3, 17);
            this.dgvAdmin.MultiSelect = false;
            this.dgvAdmin.Name = "dgvAdmin";
            this.dgvAdmin.RowHeadersVisible = false;
            this.dgvAdmin.RowTemplate.Height = 23;
            this.dgvAdmin.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdmin.Size = new System.Drawing.Size(317, 364);
            this.dgvAdmin.TabIndex = 0;
            this.dgvAdmin.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAdmin_CellClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox5);
            this.groupBox3.Controls.Add(this.btModify);
            this.groupBox3.Controls.Add(this.checkBox4);
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.rbBasicAdmin);
            this.groupBox3.Controls.Add(this.rbSystemAdmin);
            this.groupBox3.Location = new System.Drawing.Point(459, 41);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(234, 231);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "操作权限";
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(135, 134);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(72, 16);
            this.checkBox5.TabIndex = 6;
            this.checkBox5.Text = "数据管理";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(135, 112);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(72, 16);
            this.checkBox4.TabIndex = 5;
            this.checkBox4.Text = "系统维护";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(135, 90);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(48, 16);
            this.checkBox3.TabIndex = 4;
            this.checkBox3.Text = "报表";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(135, 68);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(48, 16);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "查询";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(135, 46);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(96, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "仓库基本操作";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // rbBasicAdmin
            // 
            this.rbBasicAdmin.AutoSize = true;
            this.rbBasicAdmin.Location = new System.Drawing.Point(16, 111);
            this.rbBasicAdmin.Name = "rbBasicAdmin";
            this.rbBasicAdmin.Size = new System.Drawing.Size(83, 16);
            this.rbBasicAdmin.TabIndex = 1;
            this.rbBasicAdmin.TabStop = true;
            this.rbBasicAdmin.Text = "基本管理员";
            this.rbBasicAdmin.UseVisualStyleBackColor = true;
            this.rbBasicAdmin.CheckedChanged += new System.EventHandler(this.rbBasicAdmin_CheckedChanged);
            // 
            // rbSystemAdmin
            // 
            this.rbSystemAdmin.AutoSize = true;
            this.rbSystemAdmin.Location = new System.Drawing.Point(16, 68);
            this.rbSystemAdmin.Name = "rbSystemAdmin";
            this.rbSystemAdmin.Size = new System.Drawing.Size(83, 16);
            this.rbSystemAdmin.TabIndex = 0;
            this.rbSystemAdmin.TabStop = true;
            this.rbSystemAdmin.Text = "系统管理员";
            this.rbSystemAdmin.UseVisualStyleBackColor = true;
            this.rbSystemAdmin.CheckedChanged += new System.EventHandler(this.rbSystemAdmin_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btDel);
            this.groupBox4.Controls.Add(this.btAdd);
            this.groupBox4.Location = new System.Drawing.Point(459, 291);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(234, 134);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "操作员管理";
            // 
            // btDel
            // 
            this.btDel.Location = new System.Drawing.Point(62, 77);
            this.btDel.Name = "btDel";
            this.btDel.Size = new System.Drawing.Size(121, 30);
            this.btDel.TabIndex = 2;
            this.btDel.Text = "删除操作员";
            this.btDel.UseVisualStyleBackColor = true;
            this.btDel.Click += new System.EventHandler(this.btDel_Click);
            // 
            // btModify
            // 
            this.btModify.Location = new System.Drawing.Point(60, 175);
            this.btModify.Name = "btModify";
            this.btModify.Size = new System.Drawing.Size(121, 30);
            this.btModify.TabIndex = 1;
            this.btModify.Text = "修改操作员权限";
            this.btModify.UseVisualStyleBackColor = true;
            this.btModify.Click += new System.EventHandler(this.btModify_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(60, 24);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(121, 30);
            this.btAdd.TabIndex = 0;
            this.btAdd.Text = "添加新操作员";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // AdminManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 459);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminManager";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.AdminManager_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdmin)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvAdmin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox5;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.RadioButton rbBasicAdmin;
        private System.Windows.Forms.RadioButton rbSystemAdmin;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btDel;
        private System.Windows.Forms.Button btModify;
        private System.Windows.Forms.Button btAdd;
    }
}

