namespace ITI.Simc_ITI.Money.Lib
{
    partial class TaxationModification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if( disposing && (components != null) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HabitationTrackBar = new System.Windows.Forms.TrackBar();
            this.CommerceTrackBar = new System.Windows.Forms.TrackBar();
            this.UsineTrackBar = new System.Windows.Forms.TrackBar();
            this.HabitationLabel = new System.Windows.Forms.Label();
            this.CommerceLabel = new System.Windows.Forms.Label();
            this.UsineLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.HabitationPorcent = new System.Windows.Forms.Label();
            this.CommercePorcent = new System.Windows.Forms.Label();
            this.UsinePercent = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.HabitationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommerceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsineTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // HabitationTrackBar
            // 
            this.HabitationTrackBar.Location = new System.Drawing.Point(162, 85);
            this.HabitationTrackBar.Maximum = 100;
            this.HabitationTrackBar.Name = "HabitationTrackBar";
            this.HabitationTrackBar.Size = new System.Drawing.Size(937, 56);
            this.HabitationTrackBar.TabIndex = 0;
            this.HabitationTrackBar.Value = 10;
            this.HabitationTrackBar.Scroll += new System.EventHandler(this.HabitationTrackBarScroll);
            // 
            // CommerceTrackBar
            // 
            this.CommerceTrackBar.Location = new System.Drawing.Point(162, 222);
            this.CommerceTrackBar.Maximum = 100;
            this.CommerceTrackBar.Name = "CommerceTrackBar";
            this.CommerceTrackBar.Size = new System.Drawing.Size(937, 56);
            this.CommerceTrackBar.TabIndex = 1;
            this.CommerceTrackBar.Value = 10;
            this.CommerceTrackBar.Scroll += new System.EventHandler(this.CommerceTrackBarScroll);
            // 
            // UsineTrackBar
            // 
            this.UsineTrackBar.Location = new System.Drawing.Point(162, 351);
            this.UsineTrackBar.Maximum = 100;
            this.UsineTrackBar.Name = "UsineTrackBar";
            this.UsineTrackBar.Size = new System.Drawing.Size(937, 56);
            this.UsineTrackBar.TabIndex = 1;
            this.UsineTrackBar.Value = 10;
            this.UsineTrackBar.Scroll += new System.EventHandler(this.UsineTrackBarScroll);
            // 
            // HabitationLabel
            // 
            this.HabitationLabel.AutoSize = true;
            this.HabitationLabel.Location = new System.Drawing.Point(17, 85);
            this.HabitationLabel.Name = "HabitationLabel";
            this.HabitationLabel.Size = new System.Drawing.Size(79, 17);
            this.HabitationLabel.TabIndex = 3;
            this.HabitationLabel.Text = "Habitations";
            // 
            // CommerceLabel
            // 
            this.CommerceLabel.AutoSize = true;
            this.CommerceLabel.Location = new System.Drawing.Point(17, 222);
            this.CommerceLabel.Name = "CommerceLabel";
            this.CommerceLabel.Size = new System.Drawing.Size(82, 17);
            this.CommerceLabel.TabIndex = 4;
            this.CommerceLabel.Text = "Commerces";
            // 
            // UsineLabel
            // 
            this.UsineLabel.AutoSize = true;
            this.UsineLabel.Location = new System.Drawing.Point(17, 351);
            this.UsineLabel.Name = "UsineLabel";
            this.UsineLabel.Size = new System.Drawing.Size(51, 17);
            this.UsineLabel.TabIndex = 5;
            this.UsineLabel.Text = "Usines";
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(982, 410);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(124, 36);
            this.CloseButton.TabIndex = 6;
            this.CloseButton.Text = "Terminé";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // HabitationPorcent
            // 
            this.HabitationPorcent.AutoSize = true;
            this.HabitationPorcent.Location = new System.Drawing.Point(17, 114);
            this.HabitationPorcent.Name = "HabitationPorcent";
            this.HabitationPorcent.Size = new System.Drawing.Size(28, 17);
            this.HabitationPorcent.TabIndex = 7;
            this.HabitationPorcent.Text = "1%";
            // 
            // CommercePorcent
            // 
            this.CommercePorcent.AutoSize = true;
            this.CommercePorcent.Location = new System.Drawing.Point(17, 249);
            this.CommercePorcent.Name = "CommercePorcent";
            this.CommercePorcent.Size = new System.Drawing.Size(46, 17);
            this.CommercePorcent.TabIndex = 8;
            this.CommercePorcent.Text = "label2";
            // 
            // UsinePercent
            // 
            this.UsinePercent.AutoSize = true;
            this.UsinePercent.Location = new System.Drawing.Point(17, 380);
            this.UsinePercent.Name = "UsinePercent";
            this.UsinePercent.Size = new System.Drawing.Size(46, 17);
            this.UsinePercent.TabIndex = 9;
            this.UsinePercent.Text = "label3";
            // 
            // TaxationModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 458);
            this.Controls.Add(this.UsinePercent);
            this.Controls.Add(this.CommercePorcent);
            this.Controls.Add(this.HabitationPorcent);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.UsineLabel);
            this.Controls.Add(this.CommerceLabel);
            this.Controls.Add(this.HabitationLabel);
            this.Controls.Add(this.UsineTrackBar);
            this.Controls.Add(this.CommerceTrackBar);
            this.Controls.Add(this.HabitationTrackBar);
            this.Name = "TaxationModification";
            this.Text = "TaxationModification";
            ((System.ComponentModel.ISupportInitialize)(this.HabitationTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommerceTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsineTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar HabitationTrackBar;
        private System.Windows.Forms.TrackBar CommerceTrackBar;
        private System.Windows.Forms.TrackBar UsineTrackBar;
        private System.Windows.Forms.Label HabitationLabel;
        private System.Windows.Forms.Label CommerceLabel;
        private System.Windows.Forms.Label UsineLabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label HabitationPorcent;
        private System.Windows.Forms.Label CommercePorcent;
        private System.Windows.Forms.Label UsinePercent;
    }
}