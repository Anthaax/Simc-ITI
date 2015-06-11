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
            this.MonArgent = new System.Windows.Forms.Label();
            this.HumeurLabel = new System.Windows.Forms.Label();
            this.MoneyGestionOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rewind_button
            // 
            this.rewind_button.Location = new System.Drawing.Point(3, 69);
            this.rewind_button.Name = "rewind_button";
            this.rewind_button.Size = new System.Drawing.Size(57, 23);
            this.rewind_button.TabIndex = 11;
            this.rewind_button.Text = "<<";
            this.rewind_button.UseVisualStyleBackColor = true;
            // 
            // pause_button
            // 
            this.pause_button.Location = new System.Drawing.Point(66, 69);
            this.pause_button.Name = "pause_button";
            this.pause_button.Size = new System.Drawing.Size(75, 23);
            this.pause_button.TabIndex = 12;
            this.pause_button.Text = "pause";
            this.pause_button.UseVisualStyleBackColor = true;
            // 
            // fastforward_button
            // 
            this.fastforward_button.Location = new System.Drawing.Point(147, 69);
            this.fastforward_button.Name = "fastforward_button";
            this.fastforward_button.Size = new System.Drawing.Size(60, 23);
            this.fastforward_button.TabIndex = 13;
            this.fastforward_button.Text = ">>";
            this.fastforward_button.UseVisualStyleBackColor = true;
            // 
            // Coordonnées
            // 
            this.Coordonnées.AutoSize = true;
            this.Coordonnées.Location = new System.Drawing.Point(273, 13);
            this.Coordonnées.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Coordonnées.Name = "Coordonnées";
            this.Coordonnées.Size = new System.Drawing.Size(97, 13);
            this.Coordonnées.TabIndex = 14;
            this.Coordonnées.Text = "Coordonnées : 0, 0";
            this.Coordonnées.Visible = false;
            // 
            // Kind_Building
            // 
            this.Kind_Building.AutoSize = true;
            this.Kind_Building.Location = new System.Drawing.Point(273, 35);
            this.Kind_Building.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Kind_Building.Name = "Kind_Building";
            this.Kind_Building.Size = new System.Drawing.Size(37, 13);
            this.Kind_Building.TabIndex = 15;
            this.Kind_Building.Text = "Type :";
            this.Kind_Building.Visible = false;
            // 
            // Button_Destroy
            // 
            this.Button_Destroy.Location = new System.Drawing.Point(385, 10);
            this.Button_Destroy.Margin = new System.Windows.Forms.Padding(2);
            this.Button_Destroy.Name = "Button_Destroy";
            this.Button_Destroy.Size = new System.Drawing.Size(56, 19);
            this.Button_Destroy.TabIndex = 16;
            this.Button_Destroy.Text = "Détruire";
            this.Button_Destroy.UseVisualStyleBackColor = true;
            this.Button_Destroy.Visible = false;
            // 
            // MyMoney
            // 
            this.MyMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyMoney.AutoSize = true;
            this.MyMoney.Location = new System.Drawing.Point(478, 13);
            this.MyMoney.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MyMoney.Name = "MyMoney";
            this.MyMoney.Size = new System.Drawing.Size(67, 13);
            this.MyMoney.TabIndex = 17;
            this.MyMoney.Text = "Mon argent :";
            // 
            // MonArgent
            // 
            this.MonArgent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MonArgent.AutoSize = true;
            this.MonArgent.Location = new System.Drawing.Point(549, 13);
            this.MonArgent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MonArgent.Name = "MonArgent";
            this.MonArgent.Size = new System.Drawing.Size(31, 13);
            this.MonArgent.TabIndex = 18;
            this.MonArgent.Text = "5000";
            // 
            // HumeurLabel
            // 
            this.HumeurLabel.AutoSize = true;
            this.HumeurLabel.Location = new System.Drawing.Point(495, 35);
            this.HumeurLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HumeurLabel.Name = "HumeurLabel";
            this.HumeurLabel.Size = new System.Drawing.Size(50, 13);
            this.HumeurLabel.TabIndex = 19;
            this.HumeurLabel.Text = "Humeur :";
            // 
            // MoneyGestionOpen
            // 
            this.MoneyGestionOpen.Location = new System.Drawing.Point(484, 63);
            this.MoneyGestionOpen.Margin = new System.Windows.Forms.Padding(2);
            this.MoneyGestionOpen.Name = "MoneyGestionOpen";
            this.MoneyGestionOpen.Size = new System.Drawing.Size(96, 19);
            this.MoneyGestionOpen.TabIndex = 20;
            this.MoneyGestionOpen.Text = "Gerer L\'argent";
            this.MoneyGestionOpen.UseVisualStyleBackColor = true;
            // 
            // BottomPaneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.MoneyGestionOpen);
            this.Controls.Add(this.HumeurLabel);
            this.Controls.Add(this.MonArgent);
            this.Controls.Add(this.MyMoney);
            this.Controls.Add(this.Button_Destroy);
            this.Controls.Add(this.Kind_Building);
            this.Controls.Add(this.Coordonnées);
            this.Controls.Add(this.fastforward_button);
            this.Controls.Add(this.pause_button);
            this.Controls.Add(this.rewind_button);
            this.Name = "BottomPaneControl";
            this.Size = new System.Drawing.Size(630, 95);
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
        private System.Windows.Forms.Label MonArgent;
        private System.Windows.Forms.Label HumeurLabel;
        private System.Windows.Forms.Button MoneyGestionOpen;
    }
}
