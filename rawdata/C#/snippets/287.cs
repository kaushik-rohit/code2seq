private void InitializeComponent()
        {
            this.objectListView1 = new BrightIdeasSoftware.FastObjectListView();
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).BeginInit();
            this.SuspendLayout();
            // 
            // objectListView1
            // 
            this.objectListView1.Cursor = System.Windows.Forms.Cursors.Default;
            this.objectListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.objectListView1.Location = new System.Drawing.Point(0, 0);
            this.objectListView1.Name = "objectListView1";
            this.objectListView1.ShowGroups = false;
            this.objectListView1.Size = new System.Drawing.Size(884, 595);
            this.objectListView1.TabIndex = 0;
            this.objectListView1.UseCompatibleStateImageBehavior = false;
            this.objectListView1.View = System.Windows.Forms.View.Details;
            // 
            // StoreClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 595);
            this.Controls.Add(this.objectListView1);
            this.Name = "StoreClientForm";
            this.Text = "Store Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StoreClientForm_FormClosing);
            this.Load += new System.EventHandler(this.StoreClientForm_LoadAsync);
            ((System.ComponentModel.ISupportInitialize)(this.objectListView1)).EndInit();
            this.ResumeLayout(false);

        }