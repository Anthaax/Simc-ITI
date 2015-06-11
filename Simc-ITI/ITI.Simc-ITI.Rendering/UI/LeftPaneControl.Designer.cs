namespace ITI.Simc_ITI.Rendering
{
    partial class LeftPaneControl
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
            this.Build_Road = new System.Windows.Forms.Button();
            this.Centrale_electrique = new System.Windows.Forms.Button();
            this.School_Button = new System.Windows.Forms.Button();
            this.HabitationBuild = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Build_Road
            // 
            this.Build_Road.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Build_Road.Location = new System.Drawing.Point(2, 105);
            this.Build_Road.Margin = new System.Windows.Forms.Padding(2);
            this.Build_Road.Name = "Build_Road";
            this.Build_Road.Size = new System.Drawing.Size(81, 19);
            this.Build_Road.TabIndex = 4;
            this.Build_Road.Text = "Route";
            this.Build_Road.UseVisualStyleBackColor = true;
            this.Build_Road.Visible = false;
            // 
            // Centrale_electrique
            // 
            this.Centrale_electrique.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Centrale_electrique.Location = new System.Drawing.Point(2, 128);
            this.Centrale_electrique.Margin = new System.Windows.Forms.Padding(2);
            this.Centrale_electrique.Name = "Centrale_electrique";
            this.Centrale_electrique.Size = new System.Drawing.Size(81, 19);
            this.Centrale_electrique.TabIndex = 10;
            this.Centrale_electrique.Text = "CentraleE";
            this.Centrale_electrique.UseVisualStyleBackColor = true;
            this.Centrale_electrique.Visible = false;
            // 
            // School_Button
            // 
            this.School_Button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.School_Button.Location = new System.Drawing.Point(2, 151);
            this.School_Button.Margin = new System.Windows.Forms.Padding(2);
            this.School_Button.Name = "School_Button";
            this.School_Button.Size = new System.Drawing.Size(81, 19);
            this.School_Button.TabIndex = 11;
            this.School_Button.Text = "Ecole";
            this.School_Button.UseVisualStyleBackColor = true;
            this.School_Button.Visible = false;
            // 
            // HabitationBuild
            // 
            this.HabitationBuild.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HabitationBuild.Location = new System.Drawing.Point(2, 174);
            this.HabitationBuild.Margin = new System.Windows.Forms.Padding(2);
            this.HabitationBuild.Name = "HabitationBuild";
            this.HabitationBuild.Size = new System.Drawing.Size(81, 19);
            this.HabitationBuild.TabIndex = 12;
            this.HabitationBuild.Text = "Habitation";
            this.HabitationBuild.UseVisualStyleBackColor = true;
            this.HabitationBuild.Visible = false;
            // 
            // LeftPaneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.HabitationBuild);
            this.Controls.Add(this.School_Button);
            this.Controls.Add(this.Centrale_electrique);
            this.Controls.Add(this.Build_Road);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LeftPaneControl";
            this.Size = new System.Drawing.Size(86, 322);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Build_Road;
        private System.Windows.Forms.Button Centrale_electrique;
        private System.Windows.Forms.Button School_Button;
        private System.Windows.Forms.Button HabitationBuild;
    }
}
