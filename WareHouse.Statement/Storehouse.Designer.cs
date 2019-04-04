namespace WareHouse.Statement
{
    partial class Storehouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Storehouse));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.rbNoinventory = new System.Windows.Forms.RadioButton();
            this.rbinventory = new System.Windows.Forms.RadioButton();
            this.rbAllinventory = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_LastPage = new System.Windows.Forms.ToolStripButton();
            this.tsb_NextPage = new System.Windows.Forms.ToolStripButton();
            this.cbPageNum = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tsb_Export = new System.Windows.Forms.ToolStripButton();
            this.dgv_Storehouse = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Storehouse)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label13);
            this.splitContainer1.Panel1.Controls.Add(this.label14);
            this.splitContainer1.Panel1.Controls.Add(this.label15);
            this.splitContainer1.Panel1.Controls.Add(this.label16);
            this.splitContainer1.Panel1.Controls.Add(this.label17);
            this.splitContainer1.Panel1.Controls.Add(this.label18);
            this.splitContainer1.Panel1.Controls.Add(this.rbNoinventory);
            this.splitContainer1.Panel1.Controls.Add(this.rbinventory);
            this.splitContainer1.Panel1.Controls.Add(this.rbAllinventory);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_Storehouse);
            this.splitContainer1.Size = new System.Drawing.Size(960, 465);
            this.splitContainer1.SplitterDistance = 48;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(545, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 19;
            this.label1.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(481, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "未标价:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(545, 30);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(11, 12);
            this.label13.TabIndex = 17;
            this.label13.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(481, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(47, 12);
            this.label14.TabIndex = 16;
            this.label14.Text = "总金额:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(397, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(11, 12);
            this.label15.TabIndex = 15;
            this.label15.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(333, 29);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(47, 12);
            this.label16.TabIndex = 14;
            this.label16.Text = "总数量:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(397, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(11, 12);
            this.label17.TabIndex = 13;
            this.label17.Text = "0";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(333, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 12);
            this.label18.TabIndex = 12;
            this.label18.Text = "物资种类:";
            // 
            // rbNoinventory
            // 
            this.rbNoinventory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbNoinventory.AutoSize = true;
            this.rbNoinventory.Location = new System.Drawing.Point(787, 15);
            this.rbNoinventory.Name = "rbNoinventory";
            this.rbNoinventory.Size = new System.Drawing.Size(59, 16);
            this.rbNoinventory.TabIndex = 3;
            this.rbNoinventory.TabStop = true;
            this.rbNoinventory.Text = "无库存";
            this.rbNoinventory.UseVisualStyleBackColor = true;
            this.rbNoinventory.CheckedChanged += new System.EventHandler(this.rbNoinventory_CheckedChanged);
            // 
            // rbinventory
            // 
            this.rbinventory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbinventory.AutoSize = true;
            this.rbinventory.Location = new System.Drawing.Point(716, 15);
            this.rbinventory.Name = "rbinventory";
            this.rbinventory.Size = new System.Drawing.Size(59, 16);
            this.rbinventory.TabIndex = 2;
            this.rbinventory.TabStop = true;
            this.rbinventory.Text = "有库存";
            this.rbinventory.UseVisualStyleBackColor = true;
            this.rbinventory.CheckedChanged += new System.EventHandler(this.rbinventory_CheckedChanged);
            // 
            // rbAllinventory
            // 
            this.rbAllinventory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbAllinventory.AutoSize = true;
            this.rbAllinventory.Location = new System.Drawing.Point(633, 15);
            this.rbAllinventory.Name = "rbAllinventory";
            this.rbAllinventory.Size = new System.Drawing.Size(71, 16);
            this.rbAllinventory.TabIndex = 1;
            this.rbAllinventory.TabStop = true;
            this.rbAllinventory.Text = "所有物资";
            this.rbAllinventory.UseVisualStyleBackColor = true;
            this.rbAllinventory.CheckedChanged += new System.EventHandler(this.rbAllinventory_CheckedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_LastPage,
            this.tsb_NextPage,
            this.cbPageNum,
            this.toolStripLabel2,
            this.toolStripLabel3,
            this.tsb_Export});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(960, 48);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsb_LastPage
            // 
            this.tsb_LastPage.Image = ((System.Drawing.Image)(resources.GetObject("tsb_LastPage.Image")));
            this.tsb_LastPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_LastPage.Name = "tsb_LastPage";
            this.tsb_LastPage.Size = new System.Drawing.Size(48, 45);
            this.tsb_LastPage.Text = "上一页";
            this.tsb_LastPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_LastPage.Click += new System.EventHandler(this.tsb_LastPage_Click);
            // 
            // tsb_NextPage
            // 
            this.tsb_NextPage.Image = ((System.Drawing.Image)(resources.GetObject("tsb_NextPage.Image")));
            this.tsb_NextPage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_NextPage.Name = "tsb_NextPage";
            this.tsb_NextPage.Size = new System.Drawing.Size(48, 45);
            this.tsb_NextPage.Text = "下一页";
            this.tsb_NextPage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_NextPage.Click += new System.EventHandler(this.tsb_NextPage_Click);
            // 
            // cbPageNum
            // 
            this.cbPageNum.Name = "cbPageNum";
            this.cbPageNum.Size = new System.Drawing.Size(121, 48);
            this.cbPageNum.TextChanged += new System.EventHandler(this.cbPageNum_TextChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(36, 45);
            this.toolStripLabel2.Text = "1000";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(96, 45);
            this.toolStripLabel3.Text = "toolStripLabel3";
            // 
            // tsb_Export
            // 
            this.tsb_Export.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Export.Image")));
            this.tsb_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Export.Name = "tsb_Export";
            this.tsb_Export.Size = new System.Drawing.Size(36, 45);
            this.tsb_Export.Text = "导出";
            this.tsb_Export.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Export.Click += new System.EventHandler(this.tsb_Export_Click);
            // 
            // dgv_Storehouse
            // 
            this.dgv_Storehouse.AllowUserToAddRows = false;
            this.dgv_Storehouse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Storehouse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_Storehouse.Location = new System.Drawing.Point(0, 0);
            this.dgv_Storehouse.Name = "dgv_Storehouse";
            this.dgv_Storehouse.ReadOnly = true;
            this.dgv_Storehouse.RowTemplate.Height = 23;
            this.dgv_Storehouse.Size = new System.Drawing.Size(960, 413);
            this.dgv_Storehouse.TabIndex = 0;
            // 
            // Storehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 465);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Storehouse";
            this.Text = "Storehouse";
            this.Load += new System.EventHandler(this.Storehouse_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Storehouse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_Storehouse;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsb_LastPage;
        private System.Windows.Forms.ToolStripButton tsb_NextPage;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox cbPageNum;
        private System.Windows.Forms.RadioButton rbNoinventory;
        private System.Windows.Forms.RadioButton rbinventory;
        private System.Windows.Forms.RadioButton rbAllinventory;
        private System.Windows.Forms.ToolStripButton tsb_Export;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}