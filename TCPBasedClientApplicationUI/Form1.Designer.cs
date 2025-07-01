namespace TCPBasedClientApplicationUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtData = new TextBox();
            btnSendData = new Button();
            btnConnect = new Button();
            SuspendLayout();
            // 
            // txtData
            // 
            txtData.Location = new Point(134, 44);
            txtData.Name = "txtData";
            txtData.Size = new Size(257, 27);
            txtData.TabIndex = 0;
            // 
            // btnSendData
            // 
            btnSendData.Location = new Point(276, 107);
            btnSendData.Name = "btnSendData";
            btnSendData.Size = new Size(115, 29);
            btnSendData.TabIndex = 1;
            btnSendData.Text = "Gönder";
            btnSendData.UseVisualStyleBackColor = true;
            btnSendData.Click += btnSendData_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(134, 107);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(136, 29);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Bağlan";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnConnect);
            Controls.Add(btnSendData);
            Controls.Add(txtData);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtData;
        private Button btnSendData;
        private Button btnConnect;
    }
}
