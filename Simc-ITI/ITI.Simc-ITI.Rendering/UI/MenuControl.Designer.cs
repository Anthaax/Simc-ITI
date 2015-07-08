namespace ITI.Simc_ITI.Rendering
{
    partial class MenuControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuControl));
            this.NewGame_button = new System.Windows.Forms.Button();
            this.LoadGame_button = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // NewGame_button
            // 
            this.NewGame_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.NewGame_button.Location = new System.Drawing.Point(212, 560);
            this.NewGame_button.Margin = new System.Windows.Forms.Padding(4);
            this.NewGame_button.Name = "NewGame_button";
            this.NewGame_button.Size = new System.Drawing.Size(335, 28);
            this.NewGame_button.TabIndex = 0;
            this.NewGame_button.Text = "Nouvelle Partie";
            this.NewGame_button.UseVisualStyleBackColor = true;
            this.NewGame_button.Click += new System.EventHandler(this.NewGame_button_Click);
            // 
            // LoadGame_button
            // 
            this.LoadGame_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadGame_button.Location = new System.Drawing.Point(891, 560);
            this.LoadGame_button.Margin = new System.Windows.Forms.Padding(4);
            this.LoadGame_button.Name = "LoadGame_button";
            this.LoadGame_button.Size = new System.Drawing.Size(335, 28);
            this.LoadGame_button.TabIndex = 1;
            this.LoadGame_button.Text = "Charger une partie";
            this.LoadGame_button.UseVisualStyleBackColor = true;
            this.LoadGame_button.Click += new System.EventHandler(this.LoadGame_button_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(212, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1014, 539);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LoadGame_button);
            this.Controls.Add(this.NewGame_button);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(1400, 751);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewGame_button;
        private System.Windows.Forms.Button LoadGame_button;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
