private void InitializeComponent()
        {
            this.m_btnCalculate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_tbAvgSpeed = new System.Windows.Forms.TextBox();
            this.m_tbHoursLeft = new System.Windows.Forms.TextBox();
            this.m_lblReachStep = new System.Windows.Forms.Label();
            this.m_lblReachTrip = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cbStage = new System.Windows.Forms.ComboBox();
            this.m_cbStep = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // m_btnCalculate
            // 
            this.m_btnCalculate.BackColor = System.Drawing.Color.LawnGreen;
            this.m_btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnCalculate.Location = new System.Drawing.Point(12, 9);
            this.m_btnCalculate.Name = "m_btnCalculate";
            this.m_btnCalculate.Size = new System.Drawing.Size(75, 49);
            this.m_btnCalculate.TabIndex = 5;
            this.m_btnCalculate.Text = "Calculate\r\nReachable Step";
            this.m_btnCalculate.UseVisualStyleBackColor = false;
            this.m_btnCalculate.Click += new System.EventHandler(this.Calculate);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Stage:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(123, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Step:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Average Speed:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Hours Left:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(68, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Reachable Step:";
            // 
            // m_tbAvgSpeed
            // 
            this.m_tbAvgSpeed.Location = new System.Drawing.Point(161, 64);
            this.m_tbAvgSpeed.Name = "m_tbAvgSpeed";
            this.m_tbAvgSpeed.Size = new System.Drawing.Size(118, 20);
            this.m_tbAvgSpeed.TabIndex = 3;
            // 
            // m_tbHoursLeft
            // 
            this.m_tbHoursLeft.Location = new System.Drawing.Point(161, 90);
            this.m_tbHoursLeft.Name = "m_tbHoursLeft";
            this.m_tbHoursLeft.Size = new System.Drawing.Size(118, 20);
            this.m_tbHoursLeft.TabIndex = 4;
            // 
            // m_lblReachStep
            // 
            this.m_lblReachStep.AutoSize = true;
            this.m_lblReachStep.Location = new System.Drawing.Point(158, 138);
            this.m_lblReachStep.Name = "m_lblReachStep";
            this.m_lblReachStep.Size = new System.Drawing.Size(112, 13);
            this.m_lblReachStep.TabIndex = 10;
            this.m_lblReachStep.Text = "Enter Info to Calculate";
            // 
            // m_lblReachTrip
            // 
            this.m_lblReachTrip.AutoSize = true;
            this.m_lblReachTrip.Location = new System.Drawing.Point(158, 116);
            this.m_lblReachTrip.Name = "m_lblReachTrip";
            this.m_lblReachTrip.Size = new System.Drawing.Size(112, 13);
            this.m_lblReachTrip.TabIndex = 12;
            this.m_lblReachTrip.Text = "Enter Info to Calculate";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(72, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "Reachable Trip:";
            // 
            // m_cbStage
            // 
            this.m_cbStage.FormattingEnabled = true;
            this.m_cbStage.Location = new System.Drawing.Point(161, 12);
            this.m_cbStage.Name = "m_cbStage";
            this.m_cbStage.Size = new System.Drawing.Size(118, 21);
            this.m_cbStage.TabIndex = 1;
            this.m_cbStage.SelectedValueChanged += new System.EventHandler(this.enableStepCB);
            // 
            // m_cbStep
            // 
            this.m_cbStep.Enabled = false;
            this.m_cbStep.FormattingEnabled = true;
            this.m_cbStep.Location = new System.Drawing.Point(161, 38);
            this.m_cbStep.Name = "m_cbStep";
            this.m_cbStep.Size = new System.Drawing.Size(118, 21);
            this.m_cbStep.TabIndex = 2;
            // 
            // EndOfDayDist
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 160);
            this.Controls.Add(this.m_cbStep);
            this.Controls.Add(this.m_cbStage);
            this.Controls.Add(this.m_lblReachTrip);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.m_lblReachStep);
            this.Controls.Add(this.m_tbHoursLeft);
            this.Controls.Add(this.m_tbAvgSpeed);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btnCalculate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "EndOfDayDist";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EndOfDayDist";
            this.ResumeLayout(false);
            this.PerformLayout();

        }