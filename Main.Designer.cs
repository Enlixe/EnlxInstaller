
namespace EnlxInstaller
{
    partial class EnlxInstaller
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EnlxInstaller));
            this.downloadButton = new System.Windows.Forms.Button();
            this.warningLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressLabel = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.info = new System.Windows.Forms.Label();
            this.optifine = new System.Windows.Forms.CheckBox();
            this.addonsLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(12, 339);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(776, 80);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButton_Click);
            // 
            // warningLabel
            // 
            this.warningLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.warningLabel.Location = new System.Drawing.Point(0, 422);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(800, 28);
            this.warningLabel.TabIndex = 1;
            this.warningLabel.Text = "Please don\'t close if the download is not completed yet";
            this.warningLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 315);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(776, 18);
            this.progressBar.TabIndex = 2;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(375, 295);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(0, 17);
            this.progressLabel.TabIndex = 3;
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.ErrorImage")));
            this.pictureBox.ImageLocation = "./assets/icon.png";
            this.pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.InitialImage")));
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(776, 69);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F);
            this.info.Location = new System.Drawing.Point(222, 247);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(348, 48);
            this.info.TabIndex = 5;
            this.info.Text = "Modpack Installer";
            // 
            // optifine
            // 
            this.optifine.AutoSize = true;
            this.optifine.Checked = true;
            this.optifine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.optifine.Enabled = false;
            this.optifine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.optifine.Location = new System.Drawing.Point(12, 141);
            this.optifine.Name = "optifine";
            this.optifine.Size = new System.Drawing.Size(306, 24);
            this.optifine.TabIndex = 6;
            this.optifine.Text = "OptiFine (currently bugged, disabled)";
            this.optifine.UseVisualStyleBackColor = true;
            // 
            // addonsLabel
            // 
            this.addonsLabel.AutoSize = true;
            this.addonsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.addonsLabel.Location = new System.Drawing.Point(7, 99);
            this.addonsLabel.Name = "addonsLabel";
            this.addonsLabel.Size = new System.Drawing.Size(107, 29);
            this.addonsLabel.TabIndex = 7;
            this.addonsLabel.Text = "Add-ons";
            // 
            // EnlxInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addonsLabel);
            this.Controls.Add(this.optifine);
            this.Controls.Add(this.info);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.downloadButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EnlxInstaller";
            this.Text = "EnlX Installer";
            this.Load += new System.EventHandler(this.EnlxInstaller_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.CheckBox optifine;
        private System.Windows.Forms.Label addonsLabel;
    }
}

