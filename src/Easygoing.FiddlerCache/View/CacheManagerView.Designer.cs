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
            this.olvColumnUrl = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnLength = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnCreationTime = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumnPath = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItemSystemMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.ButtonClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonHideProperty = new System.Windows.Forms.ToolStripButton();
            this.ButtonEnabled = new System.Windows.Forms.ToolStripButton();
            this.ImageListIcon = new System.Windows.Forms.ImageList(this.components);
            this.SplitContainerMain = new System.Windows.Forms.SplitContainer();
            this.PropertyGrid = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.TreeListViewCache)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).BeginInit();
            this.SplitContainerMain.Panel1.SuspendLayout();
            this.SplitContainerMain.Panel2.SuspendLayout();
            this.SplitContainerMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeListViewCache
            // 
            this.TreeListViewCache.AllColumns.Add(this.olvColumnUrl);
            this.TreeListViewCache.AllColumns.Add(this.olvColumnLength);
            this.TreeListViewCache.AllColumns.Add(this.olvColumnCreationTime);
            this.TreeListViewCache.AllColumns.Add(this.olvColumnPath);
            this.TreeListViewCache.CheckBoxes = true;
            this.TreeListViewCache.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumnUrl,
            this.olvColumnLength,
            this.olvColumnCreationTime,
            this.olvColumnPath});
            this.TreeListViewCache.ContextMenuStrip = this.contextMenuStrip1;
            this.TreeListViewCache.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeListViewCache.Location = new System.Drawing.Point(0, 0);
            this.TreeListViewCache.Name = "TreeListViewCache";
            this.TreeListViewCache.OwnerDraw = true;
            this.TreeListViewCache.ShowGroups = false;
            this.TreeListViewCache.ShowImagesOnSubItems = true;
            this.TreeListViewCache.Size = new System.Drawing.Size(530, 205);
            this.TreeListViewCache.TabIndex = 3;
            this.TreeListViewCache.UseCompatibleStateImageBehavior = false;
            this.TreeListViewCache.View = System.Windows.Forms.View.Details;
            this.TreeListViewCache.VirtualMode = true;
            this.TreeListViewCache.SelectedIndexChanged += new System.EventHandler(this.TreeListViewCache_SelectedIndexChanged);
            // 
            // olvColumnUrl
            // 
            this.olvColumnUrl.CellPadding = null;
            this.olvColumnUrl.Text = "Url";
            this.olvColumnUrl.Width = 186;
            // 
            // olvColumnLength
            // 
            this.olvColumnLength.CellPadding = null;
            this.olvColumnLength.Text = "Length";
            // 
            // olvColumnCreationTime
            // 
            this.olvColumnCreationTime.CellPadding = null;
            this.olvColumnCreationTime.Text = "Creation";
            this.olvColumnCreationTime.Width = 101;
            // 
            // olvColumnPath
            // 
            this.olvColumnPath.CellPadding = null;
            this.olvColumnPath.Text = "Path";
            this.olvColumnPath.Width = 300;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.openToolStripMenuItem,
            this.openDirectoryToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.toolStripMenuItem2,
            this.ToolStripMenuItemSystemMenu});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 148);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openDirectoryToolStripMenuItem
            // 
            this.openDirectoryToolStripMenuItem.Name = "openDirectoryToolStripMenuItem";
            this.openDirectoryToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.openDirectoryToolStripMenuItem.Text = "Open Directory";
            this.openDirectoryToolStripMenuItem.Click += new System.EventHandler(this.openDirectoryToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(160, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(160, 6);
            // 
            // ToolStripMenuItemSystemMenu
            // 
            this.ToolStripMenuItemSystemMenu.Name = "ToolStripMenuItemSystemMenu";
            this.ToolStripMenuItemSystemMenu.Size = new System.Drawing.Size(163, 22);
            this.ToolStripMenuItemSystemMenu.Text = "System Menu";
            this.ToolStripMenuItemSystemMenu.Click += new System.EventHandler(this.ToolStripMenuItemSystemMenu_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonEdit,
            this.toolStripSeparator1,
            this.ButtonDelete,
            this.ButtonClear,
            this.toolStripSeparator2,
            this.ButtonHideProperty,
            this.ButtonEnabled});
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
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
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
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // ButtonHideProperty
            // 
            this.ButtonHideProperty.Image = ((System.Drawing.Image)(resources.GetObject("ButtonHideProperty.Image")));
            this.ButtonHideProperty.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonHideProperty.Name = "ButtonHideProperty";
            this.ButtonHideProperty.Size = new System.Drawing.Size(119, 22);
            this.ButtonHideProperty.Text = "Hide properties";
            this.ButtonHideProperty.Click += new System.EventHandler(this.ButtonHideProperty_Click);
            // 
            // ButtonEnabled
            // 
            this.ButtonEnabled.Image = ((System.Drawing.Image)(resources.GetObject("ButtonEnabled.Image")));
            this.ButtonEnabled.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonEnabled.Name = "ButtonEnabled";
            this.ButtonEnabled.Size = new System.Drawing.Size(74, 22);
            this.ButtonEnabled.Text = "Enabled";
            this.ButtonEnabled.Click += new System.EventHandler(this.ButtonEnabled_Click);
            // 
            // ImageListIcon
            // 
            this.ImageListIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageListIcon.ImageStream")));
            this.ImageListIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageListIcon.Images.SetKeyName(0, "book.png");
            this.ImageListIcon.Images.SetKeyName(1, "host");
            this.ImageListIcon.Images.SetKeyName(2, "cache");
            this.ImageListIcon.Images.SetKeyName(3, "pause");
            this.ImageListIcon.Images.SetKeyName(4, "start");
            this.ImageListIcon.Images.SetKeyName(5, "Hide properties");
            this.ImageListIcon.Images.SetKeyName(6, "Show properties");
            // 
            // SplitContainerMain
            // 
            this.SplitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SplitContainerMain.Location = new System.Drawing.Point(0, 25);
            this.SplitContainerMain.Name = "SplitContainerMain";
            this.SplitContainerMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // SplitContainerMain.Panel1
            // 
            this.SplitContainerMain.Panel1.Controls.Add(this.TreeListViewCache);
            // 
            // SplitContainerMain.Panel2
            // 
            this.SplitContainerMain.Panel2.Controls.Add(this.PropertyGrid);
            this.SplitContainerMain.Size = new System.Drawing.Size(530, 336);
            this.SplitContainerMain.SplitterDistance = 205;
            this.SplitContainerMain.TabIndex = 4;
            // 
            // PropertyGrid
            // 
            this.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.PropertyGrid.Name = "PropertyGrid";
            this.PropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.PropertyGrid.Size = new System.Drawing.Size(530, 127);
            this.PropertyGrid.TabIndex = 0;
            // 
            // CacheManagerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.SplitContainerMain);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CacheManagerView";
            this.Size = new System.Drawing.Size(530, 361);
            ((System.ComponentModel.ISupportInitialize)(this.TreeListViewCache)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.SplitContainerMain.Panel1.ResumeLayout(false);
            this.SplitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SplitContainerMain)).EndInit();
            this.SplitContainerMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        public BrightIdeasSoftware.TreeListView TreeListViewCache;
     
        private BrightIdeasSoftware.OLVColumn olvColumnUrl;
        private BrightIdeasSoftware.OLVColumn olvColumnCreationTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openDirectoryToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn olvColumnLength;
        private BrightIdeasSoftware.OLVColumn olvColumnPath;
        public System.Windows.Forms.ImageList ImageListIcon;
        public System.Windows.Forms.ToolStripButton ButtonEdit;
        public System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public System.Windows.Forms.ToolStripButton ButtonDelete;
        public System.Windows.Forms.ToolStripButton ButtonClear;
        public System.Windows.Forms.ToolStripButton ButtonEnabled;
        public System.Windows.Forms.PropertyGrid PropertyGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        public System.Windows.Forms.SplitContainer SplitContainerMain;
        public System.Windows.Forms.ToolStripButton ButtonHideProperty;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemSystemMenu;
    }
}
