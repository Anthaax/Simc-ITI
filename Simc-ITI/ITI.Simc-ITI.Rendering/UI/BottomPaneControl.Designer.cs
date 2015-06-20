namespace ITI.Simc_ITI.Rendering
{
    partial class BottomPaneControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rewind_button = new System.Windows.Forms.Button();
            this.pause_button = new System.Windows.Forms.Button();
            this.fastforward_button = new System.Windows.Forms.Button();
            this.Coordonnées = new System.Windows.Forms.Label();
            this.Kind_Building = new System.Windows.Forms.Label();
            this.Button_Destroy = new System.Windows.Forms.Button();
            this.MyMoney = new System.Windows.Forms.Label();
            this.HumeurLabel = new System.Windows.Forms.Label();
            this.MoneyGestionOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rewind_button
            // 
            this.rewind_button.Location = new System.Drawing.Point(4, 85);
            this.rewind_button.Margin = new System.Windows.Forms.Padding(4);
            this.rewind_button.Name = "rewind_button";
            this.rewind_button.Size = new System.Drawing.Size(76, 28);
            this.rewind_button.TabIndex = 11;
            this.rewind_button.Text = "<<";
            this.rewind_button.UseVisualStyleBackColor = true;
            this.rewind_button.Click += new System.EventHandler(this.rewind_button_Click);
            // 
            // pause_button
            // 
            this.pause_button.Location = new System.Drawing.Point(88, 85);
            this.pause_button.Margin = new System.Windows.Forms.Padding(4);
            this.pause_button.Name = "pause_button";
            this.pause_button.Size = new System.Drawing.Size(100, 28);
            this.pause_button.TabIndex = 12;
            this.pause_button.Text = "pause";
            this.pause_button.UseVisualStyleBackColor = true;
            this.pause_button.Click += new System.EventHandler(this.pause_button_Click);
            // 
            // fastforward_button
            // 
            this.fastforward_button.Location = new System.Drawing.Point(196, 85);
            this.fastforward_button.Margin = new System.Windows.Forms.Padding(4);
            this.fastforward_button.Name = "fastforward_button";
            this.fastforward_button.Size = new System.Drawing.Size(80, 28);
            this.fastforward_button.TabIndex = 13;
            this.fastforward_button.Text = ">>";
            this.fastforward_button.UseVisualStyleBackColor = true;
            this.fastforward_button.Click += new System.EventHandler(this.fastforward_button_Click);
            // 
            // Coordonnées
            // 
            this.Coordonnées.AutoSize = true;
            this.Coordonnées.Location = new System.Drawing.Point(364, 16);
            this.Coordonnées.Name = "Coordonnées";
            this.Coordonnées.Size = new System.Drawing.Size(129, 17);
            this.Coordonnées.TabIndex = 14;
            this.Coordonnées.Text = "Coordonnées : 0, 0";
            this.Coordonnées.Visible = false;
            // 
            // Kind_Building
            // 
            this.Kind_Building.AutoSize = true;
            this.Kind_Building.Location = new System.Drawing.Point(364, 43);
            this.Kind_Building.Name = "Kind_Building";
            this.Kind_Building.Size = new System.Drawing.Size(48, 17);
            this.Kind_Building.TabIndex = 15;
            this.Kind_Building.Text = "Type :";
            this.Kind_Building.Visible = false;
            // 
            // Button_Destroy
            // 
            this.Button_Destroy.Location = new System.Drawing.Point(513, 12);
            this.Button_Destroy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Button_Destroy.Name = "Button_Destroy";
            this.Button_Destroy.Size = new System.Drawing.Size(75, 23);
            this.Button_Destroy.TabIndex = 16;
            this.Button_Destroy.Text = "Détruire";
            this.Button_Destroy.UseVisualStyleBackColor = true;
            this.Button_Destroy.Visible = false;
            this.Button_Destroy.Click += new System.EventHandler(this.Button_Destroy_Click);
            // 
            // MyMoney
            // 
            this.MyMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyMoney.AutoSize = true;
            this.MyMoney.Location = new System.Drawing.Point(696, 18);
            this.MyMoney.Name = "MyMoney";
            this.MyMoney.Size = new System.Drawing.Size(88, 17);
            this.MyMoney.TabIndex = 17;
            this.MyMoney.Text = "Mon argent :";
            // 
            // HumeurLabel
            // 
            this.HumeurLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HumeurLabel.AutoSize = true;
            this.HumeurLabel.Location = new System.Drawing.Point(696, 55);
            this.HumeurLabel.Name = "HumeurLabel";
            this.HumeurLabel.Size = new System.Drawing.Size(66, 17);
            this.HumeurLabel.TabIndex = 19;
            this.HumeurLabel.Text = "Humeur :";
            // 
            // MoneyGestionOpen
            // 
            this.MoneyGestionOpen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MoneyGestionOpen.Location = new System.Drawing.Point(699, 85);
            this.MoneyGestionOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MoneyGestionOpen.Name = "MoneyGestionOpen";
            this.MoneyGestionOpen.Size = new System.Drawing.Size(128, 23);
            this.MoneyGestionOpen.TabIndex = 20;
            this.MoneyGestionOpen.Text = "Gerer L\'argent";
            this.MoneyGestionOpen.UseVisualStyleBackColor = true;
            this.MoneyGestionOpen.Click += new System.EventHandler(this.OpenMoneyGestion);
            // 
            // BottomPaneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MoneyGestionOpen);
            this.Controls.Add(this.HumeurLabel);
            this.Controls.Add(this.MyMoney);
            this.Controls.Add(this.Button_Destroy);
            this.Controls.Add(this.Kind_Building);
            this.Controls.Add(this.Coordonnées);
            this.Controls.Add(this.fastforward_button);
            this.Controls.Add(this.pause_button);
            this.Controls.Add(this.rewind_button);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BottomPaneControl";
            this.Size = new System.Drawing.Size(840, 117);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button rewind_button;
        private System.Windows.Forms.Button pause_button;
        private System.Windows.Forms.Button fastforward_button;
        private System.Windows.Forms.Label Coordonnées;
        private System.Windows.Forms.Label Kind_Building;
        private System.Windows.Forms.Button Button_Destroy;
        private System.Windows.Forms.Label MyMoney;
        private System.Windows.Forms.Label HumeurLabel;
        private System.Windows.Forms.Button MoneyGestionOpen;
    }
}
