
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
            this.addonsOptifine = new System.Windows.Forms.CheckBox();
            this.addonsLabel = new System.Windows.Forms.Label();
            this.reinstallButton = new System.Windows.Forms.Button();
            this.addonsButton = new System.Windows.Forms.Button();
            this.addonsJourneymap = new System.Windows.Forms.CheckBox();
            this.addonsMousetweaks = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(12, 322);
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
            this.warningLabel.Location = new System.Drawing.Point(0, 408);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(800, 42);
            this.warningLabel.TabIndex = 1;
            this.warningLabel.Text = "Please don\'t close if the download is not completed yet";
            this.warningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 298);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(776, 18);
            this.progressBar.TabIndex = 2;
            // 
            // progressLabel
            // 
            this.progressLabel.AutoSize = true;
            this.progressLabel.Location = new System.Drawing.Point(344, 278);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(122, 17);
            this.progressLabel.TabIndex = 3;
            this.progressLabel.Text = "Downloading - 0%";
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
            // addonsOptifine
            // 
            this.addonsOptifine.AutoSize = true;
            this.addonsOptifine.Checked = true;
            this.addonsOptifine.CheckState = System.Windows.Forms.CheckState.Checked;
            this.addonsOptifine.Enabled = false;
            this.addonsOptifine.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addonsOptifine.Location = new System.Drawing.Point(12, 141);
            this.addonsOptifine.Name = "addonsOptifine";
            this.addonsOptifine.Size = new System.Drawing.Size(174, 24);
            this.addonsOptifine.TabIndex = 6;
            this.addonsOptifine.Text = "OptiFine (unstable)";
            this.addonsOptifine.UseVisualStyleBackColor = true;
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
            // reinstallButton
            // 
            this.reinstallButton.Location = new System.Drawing.Point(655, 408);
            this.reinstallButton.Name = "reinstallButton";
            this.reinstallButton.Size = new System.Drawing.Size(133, 39);
            this.reinstallButton.TabIndex = 8;
            this.reinstallButton.Text = "Re-install";
            this.reinstallButton.UseVisualStyleBackColor = true;
            this.reinstallButton.Click += new System.EventHandler(this.reinstallButton_Click);
            // 
            // addonsButton
            // 
            this.addonsButton.Location = new System.Drawing.Point(655, 99);
            this.addonsButton.Name = "addonsButton";
            this.addonsButton.Size = new System.Drawing.Size(133, 29);
            this.addonsButton.TabIndex = 9;
            this.addonsButton.Text = "Download Addons";
            this.addonsButton.UseVisualStyleBackColor = true;
            this.addonsButton.Click += new System.EventHandler(this.addonsButton_Click);
            // 
            // addonsJourneymap
            // 
            this.addonsJourneymap.AutoSize = true;
            this.addonsJourneymap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addonsJourneymap.Location = new System.Drawing.Point(12, 171);
            this.addonsJourneymap.Name = "addonsJourneymap";
            this.addonsJourneymap.Size = new System.Drawing.Size(122, 24);
            this.addonsJourneymap.TabIndex = 10;
            this.addonsJourneymap.Text = "JourneyMap";
            this.addonsJourneymap.UseVisualStyleBackColor = true;
            // 
            // addonsMousetweaks
            // 
            this.addonsMousetweaks.AutoSize = true;
            this.addonsMousetweaks.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.addonsMousetweaks.Location = new System.Drawing.Point(12, 201);
            this.addonsMousetweaks.Name = "addonsMousetweaks";
            this.addonsMousetweaks.Size = new System.Drawing.Size(138, 24);
            this.addonsMousetweaks.TabIndex = 11;
            this.addonsMousetweaks.Text = "MouseTweaks";
            this.addonsMousetweaks.UseVisualStyleBackColor = true;
            // 
            // EnlxInstaller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.addonsMousetweaks);
            this.Controls.Add(this.addonsJourneymap);
            this.Controls.Add(this.addonsButton);
            this.Controls.Add(this.reinstallButton);
            this.Controls.Add(this.addonsLabel);
            this.Controls.Add(this.addonsOptifine);
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
        private System.Windows.Forms.CheckBox addonsOptifine;
        private System.Windows.Forms.Label addonsLabel;
        private System.Windows.Forms.Button reinstallButton;
        private System.Windows.Forms.Button addonsButton;
        private System.Windows.Forms.CheckBox addonsJourneymap;
        private System.Windows.Forms.CheckBox addonsMousetweaks;
    }
}

