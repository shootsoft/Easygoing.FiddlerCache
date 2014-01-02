namespace Easygoing.FiddlerCache.View
{
    partial class CacheManagerView
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CacheManagerView));
            this.TreeListViewCache = new BrightIdeasSoftware.TreeListView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.ButtonClear = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListViewCache)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeListViewCache
            // 
            this.TreeListViewCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeListViewCache.Location = new System.Drawing.Point(0, 25);
            this.TreeListViewCache.Name = "TreeListViewCache";
            this.TreeListViewCache.OwnerDraw = true;
            this.TreeListViewCache.ShowGroups = false;
            this.TreeListViewCache.Size = new System.Drawing.Size(530, 336);
            this.TreeListViewCache.TabIndex = 3;
            this.TreeListViewCache.UseCompatibleStateImageBehavior = false;
            this.TreeListViewCache.View = System.Windows.Forms.View.Details;
            this.TreeListViewCache.VirtualMode = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonEdit,
            this.toolStripSeparator1,
            this.ButtonDelete,
            this.ButtonClear});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(530, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.Image = ((System.Drawing.Image)(resources.GetObject("ButtonEdit.Image")));
            this.ButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(49, 22);
            this.ButtonEdit.Text = "Edit";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("ButtonDelete.Image")));
            this.ButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(64, 22);
            this.ButtonDelete.Text = "Delete";
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonClear
            // 
            this.ButtonClear.Image = ((System.Drawing.Image)(resources.GetObject("ButtonClear.Image")));
            this.ButtonClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonClear.Name = "ButtonClear";
            this.ButtonClear.Size = new System.Drawing.Size(57, 22);
            this.ButtonClear.Text = "Clear";
            this.ButtonClear.Click += new System.EventHandler(this.ButtonClear_Click);
            // 
            // CacheManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TreeListViewCache);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CacheManagerView";
            this.Size = new System.Drawing.Size(530, 361);
            ((System.ComponentModel.ISupportInitialize)(this.TreeListViewCache)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ButtonEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ButtonDelete;
        private System.Windows.Forms.ToolStripButton ButtonClear;
        public BrightIdeasSoftware.TreeListView TreeListViewCache;
    }
}
