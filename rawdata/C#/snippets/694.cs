private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this._dbBox = new System.Windows.Forms.ComboBox();
            this._searchBox = new System.Windows.Forms.TextBox();
            this._sequentialBox = new System.Windows.Forms.TextBox();
            this._programBox = new System.Windows.Forms.TextBox();
            this._console = new AM.Windows.Forms.ConsoleControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this._goButton = new System.Windows.Forms.Button();
            this._timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // _dbBox
            // 
            this._dbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._dbBox.FormattingEnabled = true;
            this._dbBox.Location = new System.Drawing.Point(12, 31);
            this._dbBox.Name = "_dbBox";
            this._dbBox.Size = new System.Drawing.Size(241, 21);
            this._dbBox.TabIndex = 0;
            // 
            // _searchBox
            // 
            this._searchBox.Location = new System.Drawing.Point(268, 31);
            this._searchBox.Name = "_searchBox";
            this._searchBox.Size = new System.Drawing.Size(384, 20);
            this._searchBox.TabIndex = 1;
            this._searchBox.Text = "\"K=бетон$\"";
            // 
            // _sequentialBox
            // 
            this._sequentialBox.Location = new System.Drawing.Point(12, 82);
            this._sequentialBox.Name = "_sequentialBox";
            this._sequentialBox.Size = new System.Drawing.Size(472, 20);
            this._sequentialBox.TabIndex = 2;
            // 
            // _programBox
            // 
            this._programBox.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this._programBox.Location = new System.Drawing.Point(12, 135);
            this._programBox.Multiline = true;
            this._programBox.Name = "_programBox";
            this._programBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this._programBox.Size = new System.Drawing.Size(640, 105);
            this._programBox.TabIndex = 3;
            this._programBox.Text = "\'[\', mfn, \'] \' v200^a, \" : \"v200^e, \" / \"v200^f, /";
            // 
            // _console
            // 
            this._console.BackColor = System.Drawing.Color.White;
            this._console.CursorLeft = 0;
            this._console.CursorTop = 0;
            this._console.ForeColor = System.Drawing.Color.Blue;
            this._console.Location = new System.Drawing.Point(12, 256);
            this._console.Name = "_console";
            this._console.Size = new System.Drawing.Size(640, 375);
            this._console.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "База данных";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(274, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Поисковое выражение";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Последовательный поиск (необязательно)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Текст программы";
            // 
            // _goButton
            // 
            this._goButton.Location = new System.Drawing.Point(490, 80);
            this._goButton.Name = "_goButton";
            this._goButton.Size = new System.Drawing.Size(162, 23);
            this._goButton.TabIndex = 9;
            this._goButton.Text = "Запуск!";
            this._goButton.UseVisualStyleBackColor = true;
            this._goButton.Click += new System.EventHandler(this._goButton_Click);
            // 
            // _timer
            // 
            this._timer.Interval = 10000;
            this._timer.Tick += new System.EventHandler(this._timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(665, 645);
            this.Controls.Add(this._goButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._programBox);
            this.Controls.Add(this._sequentialBox);
            this.Controls.Add(this._searchBox);
            this.Controls.Add(this._dbBox);
            this.Controls.Add(this._console);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "EasyGlobal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }