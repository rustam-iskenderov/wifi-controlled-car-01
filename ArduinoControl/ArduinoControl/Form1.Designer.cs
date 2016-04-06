namespace ArduinoControl
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
            this.listBoxMsg = new System.Windows.Forms.ListBox();
            this.textBox_IP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_SendTimeout = new System.Windows.Forms.TextBox();
            this.textBox_ReceiveTimeout = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_Port = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label_Voltage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listBoxMsg
            // 
            this.listBoxMsg.FormattingEnabled = true;
            this.listBoxMsg.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.listBoxMsg.Location = new System.Drawing.Point(12, 116);
            this.listBoxMsg.Name = "listBoxMsg";
            this.listBoxMsg.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBoxMsg.Size = new System.Drawing.Size(410, 95);
            this.listBoxMsg.TabIndex = 2;
            // 
            // textBox_IP
            // 
            this.textBox_IP.Location = new System.Drawing.Point(94, 12);
            this.textBox_IP.Name = "textBox_IP";
            this.textBox_IP.Size = new System.Drawing.Size(100, 20);
            this.textBox_IP.TabIndex = 3;
            this.textBox_IP.Text = "192.168.1.177";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "IP:";
            // 
            // textBox_SendTimeout
            // 
            this.textBox_SendTimeout.Location = new System.Drawing.Point(94, 64);
            this.textBox_SendTimeout.Name = "textBox_SendTimeout";
            this.textBox_SendTimeout.Size = new System.Drawing.Size(45, 20);
            this.textBox_SendTimeout.TabIndex = 3;
            this.textBox_SendTimeout.Text = "500";
            this.textBox_SendTimeout.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // textBox_ReceiveTimeout
            // 
            this.textBox_ReceiveTimeout.Location = new System.Drawing.Point(94, 90);
            this.textBox_ReceiveTimeout.Name = "textBox_ReceiveTimeout";
            this.textBox_ReceiveTimeout.Size = new System.Drawing.Size(45, 20);
            this.textBox_ReceiveTimeout.TabIndex = 3;
            this.textBox_ReceiveTimeout.Text = "1000";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Send timout";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Receive timout";
            // 
            // textBox_Port
            // 
            this.textBox_Port.Location = new System.Drawing.Point(94, 38);
            this.textBox_Port.Name = "textBox_Port";
            this.textBox_Port.Size = new System.Drawing.Size(45, 20);
            this.textBox_Port.TabIndex = 3;
            this.textBox_Port.Text = "8890";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(59, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Port:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label_Voltage
            // 
            this.label_Voltage.AutoSize = true;
            this.label_Voltage.Location = new System.Drawing.Point(256, 12);
            this.label_Voltage.Name = "label_Voltage";
            this.label_Voltage.Size = new System.Drawing.Size(68, 13);
            this.label_Voltage.TabIndex = 5;
            this.label_Voltage.Text = "Voltage 0.0V";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 396);
            this.Controls.Add(this.label_Voltage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ReceiveTimeout);
            this.Controls.Add(this.textBox_SendTimeout);
            this.Controls.Add(this.textBox_Port);
            this.Controls.Add(this.textBox_IP);
            this.Controls.Add(this.listBoxMsg);
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxMsg;
        private System.Windows.Forms.TextBox textBox_IP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_SendTimeout;
        private System.Windows.Forms.TextBox textBox_ReceiveTimeout;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_Port;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label_Voltage;
    }
}

