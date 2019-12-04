private void InitializeComponent()
        {
            this.btn_lockWatchDog = new System.Windows.Forms.Button();
            this.btn_Terminate = new System.Windows.Forms.Button();
            this.btn_KillWatchDog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_lockWatchDog
            // 
            this.btn_lockWatchDog.Location = new System.Drawing.Point(12, 12);
            this.btn_lockWatchDog.Name = "btn_lockWatchDog";
            this.btn_lockWatchDog.Size = new System.Drawing.Size(108, 23);
            this.btn_lockWatchDog.TabIndex = 0;
            this.btn_lockWatchDog.Text = "Lock WatchDog";
            this.btn_lockWatchDog.UseVisualStyleBackColor = true;
            this.btn_lockWatchDog.Click += new System.EventHandler(this.btn_lockWatchDog_Click);
            // 
            // btn_Terminate
            // 
            this.btn_Terminate.Location = new System.Drawing.Point(215, 12);
            this.btn_Terminate.Name = "btn_Terminate";
            this.btn_Terminate.Size = new System.Drawing.Size(75, 23);
            this.btn_Terminate.TabIndex = 1;
            this.btn_Terminate.Text = "Terminate";
            this.btn_Terminate.UseVisualStyleBackColor = true;
            this.btn_Terminate.Click += new System.EventHandler(this.btn_Terminate_Click);
            // 
            // btn_KillWatchDog
            // 
            this.btn_KillWatchDog.Location = new System.Drawing.Point(126, 12);
            this.btn_KillWatchDog.Name = "btn_KillWatchDog";
            this.btn_KillWatchDog.Size = new System.Drawing.Size(83, 23);
            this.btn_KillWatchDog.TabIndex = 2;
            this.btn_KillWatchDog.Text = "Kill WatchDog";
            this.btn_KillWatchDog.UseVisualStyleBackColor = true;
            this.btn_KillWatchDog.Click += new System.EventHandler(this.btn_KillWatchDog_Click);
            // 
            // MonitoredApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 46);
            this.Controls.Add(this.btn_KillWatchDog);
            this.Controls.Add(this.btn_Terminate);
            this.Controls.Add(this.btn_lockWatchDog);
            this.Name = "MonitoredApplicationForm";
            this.Text = "Monitored Application";
            this.ResumeLayout(false);

        }