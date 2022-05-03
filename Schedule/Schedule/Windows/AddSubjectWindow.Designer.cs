namespace Schedule.Windows
{
    partial class AddSubjectWindow
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
            this.textBoxSubjectName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelCabinet = new System.Windows.Forms.Label();
            this.textBoxSubjectPause = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxSubjectName
            // 
            this.textBoxSubjectName.Location = new System.Drawing.Point(10, 41);
            this.textBoxSubjectName.Name = "textBoxSubjectName";
            this.textBoxSubjectName.Size = new System.Drawing.Size(199, 22);
            this.textBoxSubjectName.TabIndex = 8;
            this.textBoxSubjectName.TextChanged += new System.EventHandler(this.textBoxSubjectName_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 125);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelCabinet
            // 
            this.labelCabinet.AutoSize = true;
            this.labelCabinet.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCabinet.Location = new System.Drawing.Point(6, 18);
            this.labelCabinet.Name = "labelCabinet";
            this.labelCabinet.Size = new System.Drawing.Size(197, 20);
            this.labelCabinet.TabIndex = 6;
            this.labelCabinet.Text = "Название предмета";
            this.labelCabinet.Click += new System.EventHandler(this.labelCabinet_Click);
            // 
            // textBoxSubjectPause
            // 
            this.textBoxSubjectPause.Location = new System.Drawing.Point(10, 97);
            this.textBoxSubjectPause.Name = "textBoxSubjectPause";
            this.textBoxSubjectPause.Size = new System.Drawing.Size(199, 22);
            this.textBoxSubjectPause.TabIndex = 8;
            this.textBoxSubjectPause.TextChanged += new System.EventHandler(this.textBoxSubjectPause_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Время для подготовки";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // AddSubjectWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 159);
            this.Controls.Add(this.textBoxSubjectPause);
            this.Controls.Add(this.textBoxSubjectName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCabinet);
            this.Name = "AddSubjectWindow";
            this.Text = "AddSubjectWindow";
            this.Load += new System.EventHandler(this.AddSubjectWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxSubjectName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelCabinet;
        private System.Windows.Forms.TextBox textBoxSubjectPause;
        private System.Windows.Forms.Label label1;
    }
}