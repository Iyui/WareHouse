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
            this.dgv_Storehouse = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsb_LastPage = new System.Windows.Forms.ToolStripButton();
            this.tsb_NextPage = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.cbPageNum = new System.Windows.Forms.ToolStripComboBox();
            this.rbAllinventory = new System.Windows.Forms.RadioButton();
            this.rbinventory = new System.Windows.Forms.RadioButton();
            this.rbNoinventory = new System.Windows.Forms.RadioButton();
            this.tsb_Export = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Storehouse)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            this.splitContainer1.Panel1.Controls.Add(this.rbNoinventory);
            this.splitContainer1.Panel1.Controls.Add(this.rbinventory);
            this.splitContainer1.Panel1.Controls.Add(this.rbAllinventory);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgv_Storehouse);
            this.splitContainer1.Size = new System.Drawing.Size(930, 465);
            this.splitContainer1.SplitterDistance = 48;
            this.splitContainer1.TabIndex = 0;
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
            this.dgv_Storehouse.Size = new System.Drawing.Size(930, 413);
            this.dgv_Storehouse.TabIndex = 0;
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
            this.toolStrip1.Size = new System.Drawing.Size(930, 48);
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
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(96, 45);
            this.toolStripLabel2.Text = "toolStripLabel2";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(96, 45);
            this.toolStripLabel3.Text = "toolStripLabel3";
            // 
            // cbPageNum
            // 
            this.cbPageNum.Name = "cbPageNum";
            this.cbPageNum.Size = new System.Drawing.Size(121, 48);
            this.cbPageNum.TextChanged += new System.EventHandler(this.cbPageNum_TextChanged);
            // 
            // rbAllinventory
            // 
            this.rbAllinventory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbAllinventory.AutoSize = true;
            this.rbAllinventory.Location = new System.Drawing.Point(603, 15);
            this.rbAllinventory.Name = "rbAllinventory";
            this.rbAllinventory.Size = new System.Drawing.Size(71, 16);
            this.rbAllinventory.TabIndex = 1;
            this.rbAllinventory.TabStop = true;
            this.rbAllinventory.Text = "所有物资";
            this.rbAllinventory.UseVisualStyleBackColor = true;
            this.rbAllinventory.CheckedChanged += new System.EventHandler(this.rbAllinventory_CheckedChanged);
            // 
            // rbinventory
            // 
            this.rbinventory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbinventory.AutoSize = true;
            this.rbinventory.Location = new System.Drawing.Point(686, 15);
            this.rbinventory.Name = "rbinventory";
            this.rbinventory.Size = new System.Drawing.Size(59, 16);
            this.rbinventory.TabIndex = 2;
            this.rbinventory.TabStop = true;
            this.rbinventory.Text = "有库存";
            this.rbinventory.UseVisualStyleBackColor = true;
            this.rbinventory.CheckedChanged += new System.EventHandler(this.rbinventory_CheckedChanged);
            // 
            // rbNoinventory
            // 
            this.rbNoinventory.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.rbNoinventory.AutoSize = true;
            this.rbNoinventory.Location = new System.Drawing.Point(757, 15);
            this.rbNoinventory.Name = "rbNoinventory";
            this.rbNoinventory.Size = new System.Drawing.Size(59, 16);
            this.rbNoinventory.TabIndex = 3;
            this.rbNoinventory.TabStop = true;
            this.rbNoinventory.Text = "无库存";
            this.rbNoinventory.UseVisualStyleBackColor = true;
            this.rbNoinventory.CheckedChanged += new System.EventHandler(this.rbNoinventory_CheckedChanged);
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
            // Storehouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 465);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Storehouse";
            this.Text = "Storehouse";
            this.Load += new System.EventHandler(this.Storehouse_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Storehouse)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
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
    }
}