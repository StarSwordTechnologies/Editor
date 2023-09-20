namespace StarSwordEditor
{
    partial class editor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(editor));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileOpenMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenuSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.fileExitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editCutMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editCopyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editPasteMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.editMenuSeperator = new System.Windows.Forms.ToolStripSeparator();
            this.editDuplicateMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.assetMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.customMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.mainHorizontalSplit = new System.Windows.Forms.SplitContainer();
            this.assetTreeView = new System.Windows.Forms.TreeView();
            this.assetIcons = new System.Windows.Forms.ImageList(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.editorTab = new System.Windows.Forms.TabPage();
            this.jsonTab = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainHorizontalSplit)).BeginInit();
            this.mainHorizontalSplit.Panel1.SuspendLayout();
            this.mainHorizontalSplit.Panel2.SuspendLayout();
            this.mainHorizontalSplit.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.jsonTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.editMenu,
            this.assetMenu,
            this.customMenu});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 24);
            this.menu.TabIndex = 1;
            this.menu.Text = "menuStrip1";
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileOpenMenu,
            this.fileMenuSeperator,
            this.fileExitMenu});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(37, 20);
            this.fileMenu.Text = "File";
            // 
            // fileOpenMenu
            // 
            this.fileOpenMenu.Name = "fileOpenMenu";
            this.fileOpenMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.fileOpenMenu.Size = new System.Drawing.Size(182, 22);
            this.fileOpenMenu.Text = "&Open Folder";
            this.fileOpenMenu.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // fileMenuSeperator
            // 
            this.fileMenuSeperator.Name = "fileMenuSeperator";
            this.fileMenuSeperator.Size = new System.Drawing.Size(179, 6);
            // 
            // fileExitMenu
            // 
            this.fileExitMenu.Name = "fileExitMenu";
            this.fileExitMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.fileExitMenu.Size = new System.Drawing.Size(182, 22);
            this.fileExitMenu.Text = "E&xit";
            this.fileExitMenu.Click += new System.EventHandler(this.fileExitMenu_Click);
            // 
            // editMenu
            // 
            this.editMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editCutMenu,
            this.editCopyMenu,
            this.editPasteMenu,
            this.editMenuSeperator,
            this.editDuplicateMenu});
            this.editMenu.Name = "editMenu";
            this.editMenu.Size = new System.Drawing.Size(39, 20);
            this.editMenu.Text = "Edit";
            // 
            // editCutMenu
            // 
            this.editCutMenu.Name = "editCutMenu";
            this.editCutMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.editCutMenu.Size = new System.Drawing.Size(166, 22);
            this.editCutMenu.Text = "Cut";
            // 
            // editCopyMenu
            // 
            this.editCopyMenu.Name = "editCopyMenu";
            this.editCopyMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.editCopyMenu.Size = new System.Drawing.Size(166, 22);
            this.editCopyMenu.Text = "Copy";
            // 
            // editPasteMenu
            // 
            this.editPasteMenu.Name = "editPasteMenu";
            this.editPasteMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.editPasteMenu.Size = new System.Drawing.Size(166, 22);
            this.editPasteMenu.Text = "Paste";
            // 
            // editMenuSeperator
            // 
            this.editMenuSeperator.Name = "editMenuSeperator";
            this.editMenuSeperator.Size = new System.Drawing.Size(163, 6);
            // 
            // editDuplicateMenu
            // 
            this.editDuplicateMenu.Name = "editDuplicateMenu";
            this.editDuplicateMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this.editDuplicateMenu.Size = new System.Drawing.Size(166, 22);
            this.editDuplicateMenu.Text = "Duplicate";
            // 
            // assetMenu
            // 
            this.assetMenu.Name = "assetMenu";
            this.assetMenu.Size = new System.Drawing.Size(47, 20);
            this.assetMenu.Text = "Asset";
            // 
            // customMenu
            // 
            this.customMenu.Name = "customMenu";
            this.customMenu.Size = new System.Drawing.Size(12, 20);
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(0, 428);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(800, 22);
            this.status.TabIndex = 2;
            this.status.Text = "statusStrip1";
            // 
            // mainHorizontalSplit
            // 
            this.mainHorizontalSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainHorizontalSplit.Location = new System.Drawing.Point(0, 24);
            this.mainHorizontalSplit.Name = "mainHorizontalSplit";
            // 
            // mainHorizontalSplit.Panel1
            // 
            this.mainHorizontalSplit.Panel1.Controls.Add(this.assetTreeView);
            // 
            // mainHorizontalSplit.Panel2
            // 
            this.mainHorizontalSplit.Panel2.Controls.Add(this.tabControl);
            this.mainHorizontalSplit.Size = new System.Drawing.Size(800, 404);
            this.mainHorizontalSplit.SplitterDistance = 266;
            this.mainHorizontalSplit.TabIndex = 3;
            // 
            // assetTreeView
            // 
            this.assetTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assetTreeView.ImageIndex = 0;
            this.assetTreeView.ImageList = this.assetIcons;
            this.assetTreeView.Location = new System.Drawing.Point(0, 0);
            this.assetTreeView.Name = "assetTreeView";
            this.assetTreeView.SelectedImageIndex = 2;
            this.assetTreeView.Size = new System.Drawing.Size(266, 404);
            this.assetTreeView.TabIndex = 0;
            this.assetTreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.assetTreeView_BeforeSelect);
            // 
            // assetIcons
            // 
            this.assetIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("assetIcons.ImageStream")));
            this.assetIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.assetIcons.Images.SetKeyName(0, "folder.png");
            this.assetIcons.Images.SetKeyName(1, "star-sword.ico");
            this.assetIcons.Images.SetKeyName(2, "nothing.ico");
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.editorTab);
            this.tabControl.Controls.Add(this.jsonTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(530, 404);
            this.tabControl.TabIndex = 0;
            // 
            // editorTab
            // 
            this.editorTab.Location = new System.Drawing.Point(4, 22);
            this.editorTab.Name = "editorTab";
            this.editorTab.Padding = new System.Windows.Forms.Padding(3);
            this.editorTab.Size = new System.Drawing.Size(522, 378);
            this.editorTab.TabIndex = 0;
            this.editorTab.Text = "Editor";
            this.editorTab.UseVisualStyleBackColor = true;
            // 
            // jsonTab
            // 
            this.jsonTab.Controls.Add(this.textBox1);
            this.jsonTab.Location = new System.Drawing.Point(4, 22);
            this.jsonTab.Name = "jsonTab";
            this.jsonTab.Padding = new System.Windows.Forms.Padding(3);
            this.jsonTab.Size = new System.Drawing.Size(522, 378);
            this.jsonTab.TabIndex = 1;
            this.jsonTab.Text = "JSON";
            this.jsonTab.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(516, 372);
            this.textBox1.TabIndex = 0;
            // 
            // editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainHorizontalSplit);
            this.Controls.Add(this.status);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "editor";
            this.Text = "Star Sword Editor";
            this.Load += new System.EventHandler(this.editor_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.mainHorizontalSplit.Panel1.ResumeLayout(false);
            this.mainHorizontalSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainHorizontalSplit)).EndInit();
            this.mainHorizontalSplit.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.jsonTab.ResumeLayout(false);
            this.jsonTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.StatusStrip status;

        private System.Windows.Forms.ToolStripMenuItem fileMenu;
        private System.Windows.Forms.ToolStripMenuItem editMenu;
        private System.Windows.Forms.ToolStripMenuItem assetMenu;
        private System.Windows.Forms.ToolStripMenuItem customMenu;
        private System.Windows.Forms.SplitContainer mainHorizontalSplit;
        private System.Windows.Forms.TreeView assetTreeView;
        private System.Windows.Forms.ToolStripMenuItem fileOpenMenu;
        private System.Windows.Forms.ToolStripSeparator fileMenuSeperator;
        private System.Windows.Forms.ToolStripMenuItem fileExitMenu;
        private System.Windows.Forms.ToolStripMenuItem editCutMenu;
        private System.Windows.Forms.ToolStripMenuItem editCopyMenu;
        private System.Windows.Forms.ToolStripMenuItem editPasteMenu;
        private System.Windows.Forms.ToolStripSeparator editMenuSeperator;
        private System.Windows.Forms.ToolStripMenuItem editDuplicateMenu;
        private System.Windows.Forms.ImageList assetIcons;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage editorTab;
        private System.Windows.Forms.TabPage jsonTab;
        private System.Windows.Forms.TextBox textBox1;
    }
}

