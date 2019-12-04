private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DicomServerConfigurationComponentControl));
            this._aeTitle = new Macro.Desktop.View.WinForms.TextField();
            this._port = new Macro.Desktop.View.WinForms.TextField();
            this.SuspendLayout();
            // 
            // _aeTitle
            // 
            resources.ApplyResources(this._aeTitle, "_aeTitle");
            this._aeTitle.Name = "_aeTitle";
            this._aeTitle.Value = null;
            // 
            // _port
            // 
            resources.ApplyResources(this._port, "_port");
            this._port.Name = "_port";
            this._port.Value = null;
            // 
            // DicomServerConfigurationComponentControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._port);
            this.Controls.Add(this._aeTitle);
            this.Name = "DicomServerConfigurationComponentControl";
            this.ResumeLayout(false);

        }