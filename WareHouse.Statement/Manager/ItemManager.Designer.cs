namespace WareHouse.Statement.Manager
{
    partial class ItemManager
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label7 = new System.Windows.Forms.Label();
            this.cbIsCompleted = new System.Windows.Forms.ComboBox();
            this.tbRemark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbItemBatchNum = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbItemDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbItemName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbItemType = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbItemSerialNum = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bt_close = new System.Windows.Forms.Button();
            this.bt_Add = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.bt_Amend = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.bt_close);
            this.splitContainer1.Panel2.Controls.Add(this.bt_Add);
            this.splitContainer1.Panel2.Controls.Add(this.bt_Delete);
            this.splitContainer1.Panel2.Controls.Add(this.bt_Amend);
            this.splitContainer1.Size = new System.Drawing.Size(999, 623);
            this.splitContainer1.SplitterDistance = 553;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.cbIsCompleted);
            this.splitContainer2.Panel1.Controls.Add(this.tbRemark);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.tbItemBatchNum);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.tbItemDescription);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.tbItemName);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.tbItemType);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.tbItemSerialNum);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer2.Size = new System.Drawing.Size(999, 553);
            this.splitContainer2.SplitterDistance = 207;
            this.splitContainer2.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 14F);
            this.label7.Location = new System.Drawing.Point(478, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "是否完成";
            // 
            // cbIsCompleted
            // 
            this.cbIsCompleted.Font = new System.Drawing.Font("宋体", 14F);
            this.cbIsCompleted.FormattingEnabled = true;
            this.cbIsCompleted.Items.AddRange(new object[] {
            "是",
            "否"});
            this.cbIsCompleted.Location = new System.Drawing.Point(600, 130);
            this.cbIsCompleted.Name = "cbIsCompleted";
            this.cbIsCompleted.Size = new System.Drawing.Size(121, 27);
            this.cbIsCompleted.TabIndex = 12;
            // 
            // tbRemark
            // 
            this.tbRemark.Font = new System.Drawing.Font("宋体", 14F);
            this.tbRemark.Location = new System.Drawing.Point(218, 165);
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.Size = new System.Drawing.Size(158, 29);
            this.tbRemark.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 14F);
            this.label6.Location = new System.Drawing.Point(96, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 19);
            this.label6.TabIndex = 10;
            this.label6.Text = "备注";
            // 
            // tbItemBatchNum
            // 
            this.tbItemBatchNum.Font = new System.Drawing.Font("宋体", 14F);
            this.tbItemBatchNum.Location = new System.Drawing.Point(218, 123);
            this.tbItemBatchNum.Name = "tbItemBatchNum";
            this.tbItemBatchNum.Size = new System.Drawing.Size(158, 29);
            this.tbItemBatchNum.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 14F);
            this.label5.Location = new System.Drawing.Point(96, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "项目批号";
            // 
            // tbItemDescription
            // 
            this.tbItemDescription.Font = new System.Drawing.Font("宋体", 14F);
            this.tbItemDescription.Location = new System.Drawing.Point(600, 77);
            this.tbItemDescription.Name = "tbItemDescription";
            this.tbItemDescription.Size = new System.Drawing.Size(158, 29);
            this.tbItemDescription.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 14F);
            this.label4.Location = new System.Drawing.Point(478, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "项目说明";
            // 
            // tbItemName
            // 
            this.tbItemName.Font = new System.Drawing.Font("宋体", 14F);
            this.tbItemName.Location = new System.Drawing.Point(600, 22);
            this.tbItemName.Name = "tbItemName";
            this.tbItemName.Size = new System.Drawing.Size(158, 29);
            this.tbItemName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14F);
            this.label3.Location = new System.Drawing.Point(478, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "项目名称";
            // 
            // tbItemType
            // 
            this.tbItemType.Font = new System.Drawing.Font("宋体", 14F);
            this.tbItemType.Location = new System.Drawing.Point(218, 77);
            this.tbItemType.Name = "tbItemType";
            this.tbItemType.Size = new System.Drawing.Size(158, 29);
            this.tbItemType.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14F);
            this.label2.Location = new System.Drawing.Point(96, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "项目型号";
            // 
            // tbItemSerialNum
            // 
            this.tbItemSerialNum.Font = new System.Drawing.Font("宋体", 14F);
            this.tbItemSerialNum.Location = new System.Drawing.Point(218, 27);
            this.tbItemSerialNum.Name = "tbItemSerialNum";
            this.tbItemSerialNum.Size = new System.Drawing.Size(158, 29);
            this.tbItemSerialNum.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14F);
            this.label1.Location = new System.Drawing.Point(96, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目编号";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(999, 342);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // bt_close
            // 
            this.bt_close.Location = new System.Drawing.Point(728, 11);
            this.bt_close.Name = "bt_close";
            this.bt_close.Size = new System.Drawing.Size(110, 43);
            this.bt_close.TabIndex = 35;
            this.bt_close.Text = "退出";
            this.bt_close.UseVisualStyleBackColor = true;
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(160, 12);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(110, 43);
            this.bt_Add.TabIndex = 34;
            this.bt_Add.Text = "添加";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(538, 11);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(110, 43);
            this.bt_Delete.TabIndex = 33;
            this.bt_Delete.Text = "删除";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // bt_Amend
            // 
            this.bt_Amend.Location = new System.Drawing.Point(341, 11);
            this.bt_Amend.Name = "bt_Amend";
            this.bt_Amend.Size = new System.Drawing.Size(110, 43);
            this.bt_Amend.TabIndex = 32;
            this.bt_Amend.Text = "修改";
            this.bt_Amend.UseVisualStyleBackColor = true;
            this.bt_Amend.Click += new System.EventHandler(this.bt_Amend_Click);
            // 
            // ItemManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 623);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ItemManager";
            this.Text = "ItemManager";
            this.Load += new System.EventHandler(this.ItemManager_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button bt_close;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button bt_Amend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbItemSerialNum;
        private System.Windows.Forms.TextBox tbRemark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbItemBatchNum;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbItemDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbItemType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbIsCompleted;
    }
}