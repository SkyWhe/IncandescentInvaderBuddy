namespace IncandescentInvaderBuddy
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.emailbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.runBtn = new System.Windows.Forms.Button();
            this.scanTimer = new System.Windows.Forms.Timer(this.components);
            this.windowName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.running = new System.Windows.Forms.Label();
            this.emailcheckbox = new System.Windows.Forms.CheckBox();
            this.soundcheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // emailbox
            // 
            this.emailbox.Location = new System.Drawing.Point(95, 12);
            this.emailbox.Name = "emailbox";
            this.emailbox.Size = new System.Drawing.Size(260, 20);
            this.emailbox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email: ";
            // 
            // runBtn
            // 
            this.runBtn.Location = new System.Drawing.Point(9, 76);
            this.runBtn.Name = "runBtn";
            this.runBtn.Size = new System.Drawing.Size(260, 46);
            this.runBtn.TabIndex = 2;
            this.runBtn.Text = "Run/Pause";
            this.runBtn.UseVisualStyleBackColor = true;
            this.runBtn.Click += new System.EventHandler(this.runBtn_Click);
            // 
            // scanTimer
            // 
            this.scanTimer.Interval = 500;
            this.scanTimer.Tick += new System.EventHandler(this.scanTimer_Tick);
            // 
            // windowName
            // 
            this.windowName.Cursor = System.Windows.Forms.Cursors.Default;
            this.windowName.Location = new System.Drawing.Point(95, 38);
            this.windowName.Name = "windowName";
            this.windowName.Size = new System.Drawing.Size(260, 20);
            this.windowName.TabIndex = 3;
            this.windowName.Text = "DARK SOULS III";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Window Name: ";
            // 
            // running
            // 
            this.running.AutoSize = true;
            this.running.Location = new System.Drawing.Point(6, 125);
            this.running.Name = "running";
            this.running.Size = new System.Drawing.Size(67, 13);
            this.running.TabIndex = 5;
            this.running.Text = "Not Running";
            // 
            // emailcheckbox
            // 
            this.emailcheckbox.AutoSize = true;
            this.emailcheckbox.Location = new System.Drawing.Point(275, 76);
            this.emailcheckbox.Name = "emailcheckbox";
            this.emailcheckbox.Size = new System.Drawing.Size(79, 17);
            this.emailcheckbox.TabIndex = 6;
            this.emailcheckbox.Text = "Send Email";
            this.emailcheckbox.UseVisualStyleBackColor = true;
            // 
            // soundcheckbox
            // 
            this.soundcheckbox.AutoSize = true;
            this.soundcheckbox.Location = new System.Drawing.Point(274, 105);
            this.soundcheckbox.Name = "soundcheckbox";
            this.soundcheckbox.Size = new System.Drawing.Size(80, 17);
            this.soundcheckbox.TabIndex = 7;
            this.soundcheckbox.Text = "Play Sound";
            this.soundcheckbox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 144);
            this.Controls.Add(this.soundcheckbox);
            this.Controls.Add(this.emailcheckbox);
            this.Controls.Add(this.running);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.windowName);
            this.Controls.Add(this.runBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.emailbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Incandescent Invader Buddy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox emailbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button runBtn;
        private System.Windows.Forms.Timer scanTimer;
        private System.Windows.Forms.TextBox windowName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label running;
        private System.Windows.Forms.CheckBox emailcheckbox;
        private System.Windows.Forms.CheckBox soundcheckbox;
    }
}

