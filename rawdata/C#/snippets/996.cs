private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoryRowLabel));
            this.linkShowAll = new System.Windows.Forms.LinkLabel();
            this.linkHide = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // linkShowAll
            // 
            resources.ApplyResources(this.linkShowAll, "linkShowAll");
            this.linkShowAll.Name = "linkShowAll";
            this.linkShowAll.TabStop = true;
            this.linkShowAll.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkShowAll.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkShowAll_LinkClicked);
            // 
            // linkHide
            // 
            resources.ApplyResources(this.linkHide, "linkHide");
            this.linkHide.Name = "linkHide";
            this.linkHide.TabStop = true;
            this.linkHide.VisitedLinkColor = System.Drawing.Color.Blue;
            this.linkHide.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHide_LinkClicked);
            // 
            // MemoryRowLabel
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.linkHide);
            this.Controls.Add(this.linkShowAll);
            this.DoubleBuffered = true;
            this.Name = "MemoryRowLabel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }