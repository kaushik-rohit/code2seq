private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesktopForm));
            this._toolStripContainer = new System.Windows.Forms.ToolStripContainer();
            this._tabbedGroups = new Crownwood.DotNetMagic.Controls.TabbedGroups();
            this._toolbar = new System.Windows.Forms.ToolStrip();
            this._layoutTable = new System.Windows.Forms.TableLayoutPanel();
            this._mainMenu = new System.Windows.Forms.MenuStrip();
            this._toolStripContainer.ContentPanel.SuspendLayout();
            this._toolStripContainer.TopToolStripPanel.SuspendLayout();
            this._toolStripContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._tabbedGroups)).BeginInit();
            this._layoutTable.SuspendLayout();
            this.SuspendLayout();
            // 
            // _toolStripContainer
            // 
            // 
            // _toolStripContainer.ContentPanel
            // 
            this._toolStripContainer.ContentPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this._toolStripContainer.ContentPanel.Controls.Add(this._tabbedGroups);
            resources.ApplyResources(this._toolStripContainer.ContentPanel, "_toolStripContainer.ContentPanel");
            resources.ApplyResources(this._toolStripContainer, "_toolStripContainer");
            this._toolStripContainer.Name = "_toolStripContainer";
            // 
            // _toolStripContainer.TopToolStripPanel
            // 
            this._toolStripContainer.TopToolStripPanel.Controls.Add(this._toolbar);
            // 
            // _tabbedGroups
            // 
            this._tabbedGroups.AllowDrop = true;
            this._tabbedGroups.AtLeastOneLeaf = true;
            this._tabbedGroups.BackColor = System.Drawing.Color.Black;
            resources.ApplyResources(this._tabbedGroups, "_tabbedGroups");
            this._tabbedGroups.Name = "_tabbedGroups";
            this._tabbedGroups.OfficeStyleNormal = Crownwood.DotNetMagic.Controls.OfficeStyle.Light;
            this._tabbedGroups.OfficeStyleProminent = Crownwood.DotNetMagic.Controls.OfficeStyle.Light;
            this._tabbedGroups.OfficeStyleSelected = Crownwood.DotNetMagic.Controls.OfficeStyle.Light;
            this._tabbedGroups.ProminentLeaf = null;
            this._tabbedGroups.ResizeBarColor = System.Drawing.SystemColors.Control;
            this._tabbedGroups.Style = Crownwood.DotNetMagic.Common.VisualStyle.IDE2005;
            // 
            // _toolbar
            // 
            this._toolbar.AllowItemReorder = true;
            resources.ApplyResources(this._toolbar, "_toolbar");
            this._toolbar.ImageScalingSize = new System.Drawing.Size(48, 48);
            this._toolbar.Name = "_toolbar";
            this._toolbar.Stretch = true;
            // 
            // _layoutTable
            // 
            resources.ApplyResources(this._layoutTable, "_layoutTable");
            this._layoutTable.Controls.Add(this._mainMenu, 0, 0);
            this._layoutTable.Controls.Add(this._toolStripContainer, 0, 1);
            this._layoutTable.Name = "_layoutTable";
            // 
            // _mainMenu
            // 
            resources.ApplyResources(this._mainMenu, "_mainMenu");
            this._mainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this._mainMenu.Name = "_mainMenu";
            // 
            // DesktopForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._layoutTable);
            this.IsMdiContainer = true;
            this.Name = "DesktopForm";
            this.Style = Crownwood.DotNetMagic.Common.VisualStyle.IDE2005;
            this._toolStripContainer.ContentPanel.ResumeLayout(false);
            this._toolStripContainer.TopToolStripPanel.ResumeLayout(false);
            this._toolStripContainer.TopToolStripPanel.PerformLayout();
            this._toolStripContainer.ResumeLayout(false);
            this._toolStripContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._tabbedGroups)).EndInit();
            this._layoutTable.ResumeLayout(false);
            this._layoutTable.PerformLayout();
            this.ResumeLayout(false);

        }