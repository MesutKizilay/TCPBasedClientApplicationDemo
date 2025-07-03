namespace LeibingerControlCenterUI
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
            lblErrorStatus = new Label();
            lblMachineStatus = new Label();
            lblNozzleStatus = new Label();
            btnPrinterStatus = new Button();
            lblJobChange = new Label();
            lblCurrentSpeed = new Label();
            lblHeadCover = new Label();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label4 = new Label();
            panel1 = new Panel();
            txtDisplayType = new TextBox();
            txtSignalTone = new TextBox();
            txtShutdownBehavior = new TextBox();
            label5 = new Label();
            txtErrorSource = new TextBox();
            label6 = new Label();
            label10 = new Label();
            label11 = new Label();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtData
            // 
            txtData.Location = new Point(520, 340);
            txtData.Name = "txtData";
            txtData.Size = new Size(257, 27);
            txtData.TabIndex = 0;
            txtData.Visible = false;
            // 
            // btnSendData
            // 
            btnSendData.Location = new Point(662, 399);
            btnSendData.Name = "btnSendData";
            btnSendData.Size = new Size(115, 29);
            btnSendData.TabIndex = 1;
            btnSendData.Text = "Gönder";
            btnSendData.UseVisualStyleBackColor = true;
            btnSendData.Visible = false;
            btnSendData.Click += btnSendData_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(520, 399);
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
            label1.Location = new Point(18, 11);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 3;
            label1.Text = "Nozzle Durumu:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 44);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 4;
            label2.Text = "Makine Durumu:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 74);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 5;
            label3.Text = "Hata Durumu:";
            // 
            // lblErrorStatus
            // 
            lblErrorStatus.AutoSize = true;
            lblErrorStatus.Location = new Point(169, 74);
            lblErrorStatus.Name = "lblErrorStatus";
            lblErrorStatus.Size = new Size(0, 23);
            lblErrorStatus.TabIndex = 8;
            lblErrorStatus.UseCompatibleTextRendering = true;
            // 
            // lblMachineStatus
            // 
            lblMachineStatus.AutoSize = true;
            lblMachineStatus.Location = new Point(169, 44);
            lblMachineStatus.Name = "lblMachineStatus";
            lblMachineStatus.Size = new Size(0, 20);
            lblMachineStatus.TabIndex = 7;
            // 
            // lblNozzleStatus
            // 
            lblNozzleStatus.AutoSize = true;
            lblNozzleStatus.Location = new Point(169, 11);
            lblNozzleStatus.Name = "lblNozzleStatus";
            lblNozzleStatus.Size = new Size(0, 20);
            lblNozzleStatus.TabIndex = 6;
            // 
            // btnPrinterStatus
            // 
            btnPrinterStatus.Location = new Point(29, 12);
            btnPrinterStatus.Name = "btnPrinterStatus";
            btnPrinterStatus.Size = new Size(162, 29);
            btnPrinterStatus.TabIndex = 9;
            btnPrinterStatus.Text = "Yazıcı Durum Sorgula";
            btnPrinterStatus.UseVisualStyleBackColor = true;
            btnPrinterStatus.Click += btnPrinterStatus_Click;
            // 
            // lblJobChange
            // 
            lblJobChange.AutoSize = true;
            lblJobChange.Location = new Point(169, 169);
            lblJobChange.Name = "lblJobChange";
            lblJobChange.Size = new Size(0, 23);
            lblJobChange.TabIndex = 15;
            lblJobChange.UseCompatibleTextRendering = true;
            // 
            // lblCurrentSpeed
            // 
            lblCurrentSpeed.AutoSize = true;
            lblCurrentSpeed.Location = new Point(169, 139);
            lblCurrentSpeed.Name = "lblCurrentSpeed";
            lblCurrentSpeed.Size = new Size(0, 20);
            lblCurrentSpeed.TabIndex = 14;
            // 
            // lblHeadCover
            // 
            lblHeadCover.AutoSize = true;
            lblHeadCover.Location = new Point(169, 106);
            lblHeadCover.Name = "lblHeadCover";
            lblHeadCover.Size = new Size(0, 20);
            lblHeadCover.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(18, 169);
            label7.Name = "label7";
            label7.Size = new Size(140, 20);
            label7.TabIndex = 12;
            label7.Text = "İş Dosyası Değişimi:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 139);
            label8.Name = "label8";
            label8.Size = new Size(76, 20);
            label8.TabIndex = 11;
            label8.Text = "Band Hızı:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 106);
            label9.Name = "label9";
            label9.Size = new Size(99, 20);
            label9.TabIndex = 10;
            label9.Text = "Kafa Durumu:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label4.Location = new Point(100, 11);
            label4.Name = "label4";
            label4.Size = new Size(162, 28);
            label4.TabIndex = 16;
            label4.Text = "Hata Ayrıntıları";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtDisplayType);
            panel1.Controls.Add(txtSignalTone);
            panel1.Controls.Add(txtShutdownBehavior);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtErrorSource);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label11);
            panel1.Location = new Point(420, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(357, 213);
            panel1.TabIndex = 17;
            panel1.Visible = false;
            // 
            // txtDisplayType
            // 
            txtDisplayType.Location = new Point(154, 156);
            txtDisplayType.Name = "txtDisplayType";
            txtDisplayType.Size = new Size(200, 27);
            txtDisplayType.TabIndex = 24;
            // 
            // txtSignalTone
            // 
            txtSignalTone.Location = new Point(154, 123);
            txtSignalTone.Name = "txtSignalTone";
            txtSignalTone.Size = new Size(200, 27);
            txtSignalTone.TabIndex = 23;
            // 
            // txtShutdownBehavior
            // 
            txtShutdownBehavior.Location = new Point(154, 91);
            txtShutdownBehavior.Name = "txtShutdownBehavior";
            txtShutdownBehavior.Size = new Size(200, 27);
            txtShutdownBehavior.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 161);
            label5.Name = "label5";
            label5.Size = new Size(73, 20);
            label5.TabIndex = 21;
            label5.Text = "Hata Tipi:";
            // 
            // txtErrorSource
            // 
            txtErrorSource.Location = new Point(154, 58);
            txtErrorSource.Name = "txtErrorSource";
            txtErrorSource.Size = new Size(200, 27);
            txtErrorSource.TabIndex = 17;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 130);
            label6.Name = "label6";
            label6.Size = new Size(51, 20);
            label6.TabIndex = 20;
            label6.Text = "Sinyal:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(8, 98);
            label10.Name = "label10";
            label10.Size = new Size(132, 20);
            label10.TabIndex = 19;
            label10.Text = "Kapanma Durumu:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(8, 65);
            label11.Name = "label11";
            label11.Size = new Size(101, 20);
            label11.TabIndex = 18;
            label11.Text = "Hata Kaynağı:";
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(lblJobChange);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(lblCurrentSpeed);
            panel2.Controls.Add(lblNozzleStatus);
            panel2.Controls.Add(lblHeadCover);
            panel2.Controls.Add(lblMachineStatus);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(lblErrorStatus);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label9);
            panel2.Location = new Point(29, 57);
            panel2.Name = "panel2";
            panel2.Size = new Size(348, 213);
            panel2.TabIndex = 18;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnPrinterStatus);
            Controls.Add(btnConnect);
            Controls.Add(btnSendData);
            Controls.Add(txtData);
            Name = "Form1";
            Text = "Jet 2 Neo S";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Label lblErrorStatus;
        private Label lblMachineStatus;
        private Label lblNozzleStatus;
        private Button btnPrinterStatus;
        private Label lblJobChange;
        private Label lblCurrentSpeed;
        private Label lblHeadCover;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label4;
        private Panel panel1;
        private Label label5;
        private TextBox txtErrorSource;
        private Label label6;
        private Label label10;
        private Label label11;
        private TextBox txtDisplayType;
        private TextBox txtSignalTone;
        private TextBox txtShutdownBehavior;
        private Panel panel2;
    }
}
