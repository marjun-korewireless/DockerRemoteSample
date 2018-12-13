namespace RemoteDockerUsingBatch
{
    partial class OperationsUI
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
            this.btnPull = new System.Windows.Forms.Button();
            this.txtImageName = new System.Windows.Forms.TextBox();
            this.lblOutput = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtImageToRun = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHostPort = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContPort = new System.Windows.Forms.TextBox();
            this.btnRunImage = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStartContainerId = new System.Windows.Forms.TextBox();
            this.btnStartContainer = new System.Windows.Forms.Button();
            this.btnStopContainer = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtStopContainerId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnListImages = new System.Windows.Forms.Button();
            this.btnListContainers = new System.Windows.Forms.Button();
            this.lblOutputHeader = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnRemoveContainer = new System.Windows.Forms.Button();
            this.txtRemoveContainerId = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRemoveImage = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.rdBtnPs = new System.Windows.Forms.RadioButton();
            this.rdBtnBatch = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnPull
            // 
            this.btnPull.Location = new System.Drawing.Point(312, 37);
            this.btnPull.Name = "btnPull";
            this.btnPull.Size = new System.Drawing.Size(75, 30);
            this.btnPull.TabIndex = 0;
            this.btnPull.Text = "Pull";
            this.btnPull.UseVisualStyleBackColor = true;
            this.btnPull.Click += new System.EventHandler(this.btnPull_Click);
            // 
            // txtImageName
            // 
            this.txtImageName.Location = new System.Drawing.Point(96, 37);
            this.txtImageName.Name = "txtImageName";
            this.txtImageName.Size = new System.Drawing.Size(210, 20);
            this.txtImageName.TabIndex = 1;
            // 
            // lblOutput
            // 
            this.lblOutput.AutoSize = true;
            this.lblOutput.Location = new System.Drawing.Point(414, 94);
            this.lblOutput.Name = "lblOutput";
            this.lblOutput.Size = new System.Drawing.Size(9, 13);
            this.lblOutput.TabIndex = 2;
            this.lblOutput.Text = "|";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Pull an image";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Run an image as container";
            // 
            // txtImageToRun
            // 
            this.txtImageToRun.Location = new System.Drawing.Point(96, 94);
            this.txtImageToRun.Name = "txtImageToRun";
            this.txtImageToRun.Size = new System.Drawing.Size(93, 20);
            this.txtImageToRun.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Image name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Image name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(195, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Host Port:";
            // 
            // txtHostPort
            // 
            this.txtHostPort.Location = new System.Drawing.Point(246, 94);
            this.txtHostPort.Name = "txtHostPort";
            this.txtHostPort.Size = new System.Drawing.Size(60, 20);
            this.txtHostPort.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(172, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Container Port:";
            // 
            // txtContPort
            // 
            this.txtContPort.Location = new System.Drawing.Point(246, 124);
            this.txtContPort.Name = "txtContPort";
            this.txtContPort.Size = new System.Drawing.Size(60, 20);
            this.txtContPort.TabIndex = 12;
            // 
            // btnRunImage
            // 
            this.btnRunImage.Location = new System.Drawing.Point(312, 94);
            this.btnRunImage.Name = "btnRunImage";
            this.btnRunImage.Size = new System.Drawing.Size(75, 29);
            this.btnRunImage.TabIndex = 13;
            this.btnRunImage.Text = "Run";
            this.btnRunImage.UseVisualStyleBackColor = true;
            this.btnRunImage.Click += new System.EventHandler(this.btnRunImage_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Start a container";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "Container ID:";
            // 
            // txtStartContainerId
            // 
            this.txtStartContainerId.Location = new System.Drawing.Point(96, 184);
            this.txtStartContainerId.Name = "txtStartContainerId";
            this.txtStartContainerId.Size = new System.Drawing.Size(210, 20);
            this.txtStartContainerId.TabIndex = 15;
            // 
            // btnStartContainer
            // 
            this.btnStartContainer.Location = new System.Drawing.Point(312, 184);
            this.btnStartContainer.Name = "btnStartContainer";
            this.btnStartContainer.Size = new System.Drawing.Size(75, 29);
            this.btnStartContainer.TabIndex = 17;
            this.btnStartContainer.Text = "Start";
            this.btnStartContainer.UseVisualStyleBackColor = true;
            this.btnStartContainer.Click += new System.EventHandler(this.btnStartContainer_Click);
            // 
            // btnStopContainer
            // 
            this.btnStopContainer.Location = new System.Drawing.Point(312, 238);
            this.btnStopContainer.Name = "btnStopContainer";
            this.btnStopContainer.Size = new System.Drawing.Size(75, 29);
            this.btnStopContainer.TabIndex = 20;
            this.btnStopContainer.Text = "Stop";
            this.btnStopContainer.UseVisualStyleBackColor = true;
            this.btnStopContainer.Click += new System.EventHandler(this.btnStopContainer_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(22, 241);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Container ID:";
            // 
            // txtStopContainerId
            // 
            this.txtStopContainerId.Location = new System.Drawing.Point(96, 238);
            this.txtStopContainerId.Name = "txtStopContainerId";
            this.txtStopContainerId.Size = new System.Drawing.Size(210, 20);
            this.txtStopContainerId.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 13);
            this.label10.TabIndex = 21;
            this.label10.Text = "Stop a container";
            // 
            // btnListImages
            // 
            this.btnListImages.Location = new System.Drawing.Point(767, 31);
            this.btnListImages.Name = "btnListImages";
            this.btnListImages.Size = new System.Drawing.Size(75, 30);
            this.btnListImages.TabIndex = 24;
            this.btnListImages.Text = "Images";
            this.btnListImages.UseVisualStyleBackColor = true;
            this.btnListImages.Click += new System.EventHandler(this.btnListImages_Click);
            // 
            // btnListContainers
            // 
            this.btnListContainers.Location = new System.Drawing.Point(848, 31);
            this.btnListContainers.Name = "btnListContainers";
            this.btnListContainers.Size = new System.Drawing.Size(75, 30);
            this.btnListContainers.TabIndex = 25;
            this.btnListContainers.Text = "Containers";
            this.btnListContainers.UseVisualStyleBackColor = true;
            this.btnListContainers.Click += new System.EventHandler(this.btnListContainers_Click);
            // 
            // lblOutputHeader
            // 
            this.lblOutputHeader.AutoSize = true;
            this.lblOutputHeader.Location = new System.Drawing.Point(405, 53);
            this.lblOutputHeader.Name = "lblOutputHeader";
            this.lblOutputHeader.Size = new System.Drawing.Size(39, 26);
            this.lblOutputHeader.TabIndex = 26;
            this.lblOutputHeader.Text = "\r\nOutput";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(20, 289);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(111, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Remove Container";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 312);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(69, 13);
            this.label12.TabIndex = 28;
            this.label12.Text = "Container ID:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // btnRemoveContainer
            // 
            this.btnRemoveContainer.Location = new System.Drawing.Point(313, 312);
            this.btnRemoveContainer.Name = "btnRemoveContainer";
            this.btnRemoveContainer.Size = new System.Drawing.Size(75, 29);
            this.btnRemoveContainer.TabIndex = 30;
            this.btnRemoveContainer.Text = "Remove";
            this.btnRemoveContainer.UseVisualStyleBackColor = true;
            this.btnRemoveContainer.Click += new System.EventHandler(this.btnRemoveContainer_Click);
            // 
            // txtRemoveContainerId
            // 
            this.txtRemoveContainerId.Location = new System.Drawing.Point(97, 312);
            this.txtRemoveContainerId.Name = "txtRemoveContainerId";
            this.txtRemoveContainerId.Size = new System.Drawing.Size(210, 20);
            this.txtRemoveContainerId.TabIndex = 29;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(313, 374);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 29);
            this.button1.TabIndex = 34;
            this.button1.Text = "Remove";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtRemoveImage
            // 
            this.txtRemoveImage.Location = new System.Drawing.Point(109, 374);
            this.txtRemoveImage.Name = "txtRemoveImage";
            this.txtRemoveImage.Size = new System.Drawing.Size(198, 20);
            this.txtRemoveImage.TabIndex = 33;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(22, 374);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 13);
            this.label13.TabIndex = 32;
            this.label13.Text = "Image Id/Name:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(20, 351);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Remove an Image";
            // 
            // rdBtnPs
            // 
            this.rdBtnPs.AutoSize = true;
            this.rdBtnPs.Checked = true;
            this.rdBtnPs.Location = new System.Drawing.Point(618, 31);
            this.rdBtnPs.Name = "rdBtnPs";
            this.rdBtnPs.Size = new System.Drawing.Size(89, 17);
            this.rdBtnPs.TabIndex = 35;
            this.rdBtnPs.TabStop = true;
            this.rdBtnPs.Text = "Use Ps Script";
            this.rdBtnPs.UseVisualStyleBackColor = true;
            // 
            // rdBtnBatch
            // 
            this.rdBtnBatch.AutoSize = true;
            this.rdBtnBatch.Location = new System.Drawing.Point(618, 50);
            this.rdBtnBatch.Name = "rdBtnBatch";
            this.rdBtnBatch.Size = new System.Drawing.Size(105, 17);
            this.rdBtnBatch.TabIndex = 36;
            this.rdBtnBatch.TabStop = true;
            this.rdBtnBatch.Text = "Use Batch Script";
            this.rdBtnBatch.UseVisualStyleBackColor = true;
            // 
            // OperationsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 496);
            this.Controls.Add(this.rdBtnBatch);
            this.Controls.Add(this.rdBtnPs);
            this.Controls.Add(this.lblOutput);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtRemoveImage);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btnRemoveContainer);
            this.Controls.Add(this.txtRemoveContainerId);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblOutputHeader);
            this.Controls.Add(this.btnListContainers);
            this.Controls.Add(this.btnListImages);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnStopContainer);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStopContainerId);
            this.Controls.Add(this.btnStartContainer);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtStartContainerId);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnRunImage);
            this.Controls.Add(this.txtContPort);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtHostPort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtImageToRun);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtImageName);
            this.Controls.Add(this.btnPull);
            this.Name = "OperationsUI";
            this.Text = "test";
            this.Load += new System.EventHandler(this.test_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPull;
        private System.Windows.Forms.TextBox txtImageName;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtImageToRun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHostPort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtContPort;
        private System.Windows.Forms.Button btnRunImage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStartContainerId;
        private System.Windows.Forms.Button btnStartContainer;
        private System.Windows.Forms.Button btnStopContainer;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtStopContainerId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnListImages;
        private System.Windows.Forms.Button btnListContainers;
        private System.Windows.Forms.Label lblOutputHeader;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnRemoveContainer;
        private System.Windows.Forms.TextBox txtRemoveContainerId;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtRemoveImage;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton rdBtnPs;
        private System.Windows.Forms.RadioButton rdBtnBatch;
    }
}

