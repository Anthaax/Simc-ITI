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
            ((System.ComponentModel.ISupportInitialize)(this.HabitationTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CommerceTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UsineTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // HabitationTrackBar
            // 
            this.HabitationTrackBar.Location = new System.Drawing.Point(199, 112);
            this.HabitationTrackBar.Maximum = 100;
            this.HabitationTrackBar.Name = "HabitationTrackBar";
            this.HabitationTrackBar.Size = new System.Drawing.Size(937, 56);
            this.HabitationTrackBar.TabIndex = 0;
            this.HabitationTrackBar.Value = 10;
            // 
            // CommerceTrackBar
            // 
            this.CommerceTrackBar.Location = new System.Drawing.Point(199, 249);
            this.CommerceTrackBar.Maximum = 100;
            this.CommerceTrackBar.Name = "CommerceTrackBar";
            this.CommerceTrackBar.Size = new System.Drawing.Size(937, 56);
            this.CommerceTrackBar.TabIndex = 1;
            this.CommerceTrackBar.Value = 10;
            // 
            // UsineTrackBar
            // 
            this.UsineTrackBar.Location = new System.Drawing.Point(199, 378);
            this.UsineTrackBar.Maximum = 100;
            this.UsineTrackBar.Name = "UsineTrackBar";
            this.UsineTrackBar.Size = new System.Drawing.Size(937, 56);
            this.UsineTrackBar.TabIndex = 1;
            this.UsineTrackBar.Value = 10;
            // 
            // HabitationLabel
            // 
            this.HabitationLabel.AutoSize = true;
            this.HabitationLabel.Location = new System.Drawing.Point(54, 112);
            this.HabitationLabel.Name = "HabitationLabel";
            this.HabitationLabel.Size = new System.Drawing.Size(79, 17);
            this.HabitationLabel.TabIndex = 3;
            this.HabitationLabel.Text = "Habitations";
            // 
            // CommerceLabel
            // 
            this.CommerceLabel.AutoSize = true;
            this.CommerceLabel.Location = new System.Drawing.Point(54, 249);
            this.CommerceLabel.Name = "CommerceLabel";
            this.CommerceLabel.Size = new System.Drawing.Size(82, 17);
            this.CommerceLabel.TabIndex = 4;
            this.CommerceLabel.Text = "Commerces";
            // 
            // UsineLabel
            // 
            this.UsineLabel.AutoSize = true;
            this.UsineLabel.Location = new System.Drawing.Point(54, 378);
            this.UsineLabel.Name = "UsineLabel";
            this.UsineLabel.Size = new System.Drawing.Size(51, 17);
            this.UsineLabel.TabIndex = 5;
            this.UsineLabel.Text = "Usines";
            // 
            // TaxationModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 524);
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
    }
}