namespace ITI.Simc_ITI.Rendering.UI
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
            this.NewGame_button = new System.Windows.Forms.Button();
            this.LoadGame_button = new System.Windows.Forms.Button();
            this.DropGame_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewGame_button
            // 
            this.NewGame_button.Location = new System.Drawing.Point(257, 98);
            this.NewGame_button.Name = "NewGame_button";
            this.NewGame_button.Size = new System.Drawing.Size(151, 23);
            this.NewGame_button.TabIndex = 0;
            this.NewGame_button.Text = "Nouvelle Partie";
            this.NewGame_button.UseVisualStyleBackColor = true;
            this.NewGame_button.Click += new System.EventHandler(this.NewGame_button_Click);
            // 
            // LoadGame_button
            // 
            this.LoadGame_button.Location = new System.Drawing.Point(257, 161);
            this.LoadGame_button.Name = "LoadGame_button";
            this.LoadGame_button.Size = new System.Drawing.Size(151, 23);
            this.LoadGame_button.TabIndex = 1;
            this.LoadGame_button.Text = "Charger une partie";
            this.LoadGame_button.UseVisualStyleBackColor = true;
            this.LoadGame_button.Click += new System.EventHandler(this.LoadGame_button_Click);
            // 
            // DropGame_button
            // 
            this.DropGame_button.Location = new System.Drawing.Point(257, 225);
            this.DropGame_button.Name = "DropGame_button";
            this.DropGame_button.Size = new System.Drawing.Size(151, 23);
            this.DropGame_button.TabIndex = 2;
            this.DropGame_button.Text = "Supprimer une sauvegarde";
            this.DropGame_button.UseVisualStyleBackColor = true;
            this.DropGame_button.Click += new System.EventHandler(this.DropGame_button_Click);
            // 
            // MenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DropGame_button);
            this.Controls.Add(this.LoadGame_button);
            this.Controls.Add(this.NewGame_button);
            this.Name = "MenuControl";
            this.Size = new System.Drawing.Size(692, 350);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewGame_button;
        private System.Windows.Forms.Button LoadGame_button;
        private System.Windows.Forms.Button DropGame_button;
    }
}
