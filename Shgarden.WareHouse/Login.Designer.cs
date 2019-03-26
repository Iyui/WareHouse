namespace Shgarden.WareHouse
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            this.cbUserName = new System.Windows.Forms.ComboBox();
            this.storemanageDataSet = new Shgarden.WareHouse.storemanageDataSet();
            this.purviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.purviewTableAdapter = new Shgarden.WareHouse.storemanageDataSetTableAdapters.purviewTableAdapter();
            this.label1 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.bt_Login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.storemanageDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.purviewBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cbUserName
            // 
            this.cbUserName.DataSource = this.purviewBindingSource;
            this.cbUserName.DisplayMember = "操作员姓名";
            this.cbUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUserName.Font = new System.Drawing.Font("宋体", 12F);
            this.cbUserName.FormattingEnabled = true;
            this.cbUserName.Location = new System.Drawing.Point(123, 117);
            this.cbUserName.Name = "cbUserName";
            this.cbUserName.Size = new System.Drawing.Size(190, 24);
            this.cbUserName.TabIndex = 0;
            this.cbUserName.ValueMember = "操作员姓名";
            // 
            // storemanageDataSet
            // 
            this.storemanageDataSet.DataSetName = "storemanageDataSet";
            this.storemanageDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // purviewBindingSource
            // 
            this.purviewBindingSource.DataMember = "purview";
            this.purviewBindingSource.DataSource = this.storemanageDataSet;
            // 
            // purviewTableAdapter
            // 
            this.purviewTableAdapter.ClearBeforeFill = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 17F);
            this.label1.Location = new System.Drawing.Point(119, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "嘉地仓库管理系统";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("宋体", 12F);
            this.tbPassword.Location = new System.Drawing.Point(123, 169);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(190, 26);
            this.tbPassword.TabIndex = 2;
            // 
            // bt_Login
            // 
            this.bt_Login.Location = new System.Drawing.Point(123, 228);
            this.bt_Login.Name = "bt_Login";
            this.bt_Login.Size = new System.Drawing.Size(190, 35);
            this.bt_Login.TabIndex = 3;
            this.bt_Login.Text = "登陆";
            this.bt_Login.UseVisualStyleBackColor = true;
            this.bt_Login.Click += new System.EventHandler(this.bt_Login_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 124);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "用户名";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "密  码";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 292);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bt_Login);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbUserName);
            this.Name = "Form1";
            this.Text = "登陆";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.storemanageDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.purviewBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbUserName;
        private storemanageDataSet storemanageDataSet;
        private System.Windows.Forms.BindingSource purviewBindingSource;
        private storemanageDataSetTableAdapters.purviewTableAdapter purviewTableAdapter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button bt_Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}

