namespace Schedule.Windows
{
    partial class AddCabinetWindow
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
            this.labelCabinet = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxCabinet = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelCabinet
            // 
            this.labelCabinet.AutoSize = true;
            this.labelCabinet.Font = new System.Drawing.Font("Georgia", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCabinet.Location = new System.Drawing.Point(0, 9);
            this.labelCabinet.Name = "labelCabinet";
            this.labelCabinet.Size = new System.Drawing.Size(166, 20);
            this.labelCabinet.TabIndex = 0;
            this.labelCabinet.Text = "Номер кабинета";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(84, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxCabinet
            // 
            this.textBoxCabinet.Location = new System.Drawing.Point(4, 32);
            this.textBoxCabinet.Name = "textBoxCabinet";
            this.textBoxCabinet.Size = new System.Drawing.Size(162, 22);
            this.textBoxCabinet.TabIndex = 2;
            // 
            // AddCabinetWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(174, 88);
            this.Controls.Add(this.textBoxCabinet);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelCabinet);
            this.Name = "AddCabinetWindow";
            this.Text = "AddCabinetWindow";
            this.Load += new System.EventHandler(this.AddCabinetWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelCabinet;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxCabinet;
    }
}