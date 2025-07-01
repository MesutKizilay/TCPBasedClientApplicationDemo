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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblNoozleStatus = new Label();
            lblErrorStatus = new Label();
            lblPrinterStatus = new Label();
            SuspendLayout();
            // 
            // txtData
            // 
            txtData.Location = new Point(376, 44);
            txtData.Name = "txtData";
            txtData.Size = new Size(257, 27);
            txtData.TabIndex = 0;
            // 
            // btnSendData
            // 
            btnSendData.Location = new Point(518, 103);
            btnSendData.Name = "btnSendData";
            btnSendData.Size = new Size(115, 29);
            btnSendData.TabIndex = 1;
            btnSendData.Text = "Gönder";
            btnSendData.UseVisualStyleBackColor = true;
            btnSendData.Click += btnSendData_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(376, 103);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(136, 29);
            btnConnect.TabIndex = 2;
            btnConnect.Text = "Bağlan";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Visible = false;
            btnConnect.Click += btnConnect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 44);
            label1.Name = "label1";
            label1.Size = new Size(106, 20);
            label1.TabIndex = 3;
            label1.Text = "Yazıcı Durumu:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 77);
            label2.Name = "label2";
            label2.Size = new Size(101, 20);
            label2.TabIndex = 4;
            label2.Text = "Hata Durumu:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 107);
            label3.Name = "label3";
            label3.Size = new Size(117, 20);
            label3.TabIndex = 5;
            label3.Text = "Noozle Durumu:";
            // 
            // lblNoozleStatus
            // 
            lblNoozleStatus.AutoSize = true;
            lblNoozleStatus.Location = new Point(165, 107);
            lblNoozleStatus.Name = "lblNoozleStatus";
            lblNoozleStatus.Size = new Size(0, 23);
            lblNoozleStatus.TabIndex = 8;
            lblNoozleStatus.UseCompatibleTextRendering = true;
            // 
            // lblErrorStatus
            // 
            lblErrorStatus.AutoSize = true;
            lblErrorStatus.Location = new Point(165, 77);
            lblErrorStatus.Name = "lblErrorStatus";
            lblErrorStatus.Size = new Size(0, 20);
            lblErrorStatus.TabIndex = 7;
            // 
            // lblPrinterStatus
            // 
            lblPrinterStatus.AutoSize = true;
            lblPrinterStatus.Location = new Point(165, 44);
            lblPrinterStatus.Name = "lblPrinterStatus";
            lblPrinterStatus.Size = new Size(0, 20);
            lblPrinterStatus.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblNoozleStatus);
            Controls.Add(lblErrorStatus);
            Controls.Add(lblPrinterStatus);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
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
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblNoozleStatus;
        private Label lblErrorStatus;
        private Label lblPrinterStatus;
    }
}
