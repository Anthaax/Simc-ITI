﻿namespace ITI.Simc_ITI.Rendering
{
    partial class DemoWindow2
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.Build_Road = new System.Windows.Forms.Button();
            this.HabitationBuild = new System.Windows.Forms.Button();
            this.School_Button = new System.Windows.Forms.Button();
            this._mainViewPortControl = new ITI.Simc_ITI.Rendering.ViewPortControl();
            this.fastforward_button = new System.Windows.Forms.Button();
            this.pause_button = new System.Windows.Forms.Button();
            this.rewind_button = new System.Windows.Forms.Button();
            this.MoneyGestionOpen = new System.Windows.Forms.Button();
            this.HumeurLabel = new System.Windows.Forms.Label();
            this.Button_Destroy = new System.Windows.Forms.Button();
            this.Kind_Building = new System.Windows.Forms.Label();
            this.Coordonnées = new System.Windows.Forms.Label();
            this.MonArgent = new System.Windows.Forms.Label();
            this.MyMoney = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.fastforward_button);
            this.splitContainer1.Panel2.Controls.Add(this.pause_button);
            this.splitContainer1.Panel2.Controls.Add(this.rewind_button);
            this.splitContainer1.Panel2.Controls.Add(this.MoneyGestionOpen);
            this.splitContainer1.Panel2.Controls.Add(this.HumeurLabel);
            this.splitContainer1.Panel2.Controls.Add(this.Button_Destroy);
            this.splitContainer1.Panel2.Controls.Add(this.Kind_Building);
            this.splitContainer1.Panel2.Controls.Add(this.Coordonnées);
            this.splitContainer1.Panel2.Controls.Add(this.MonArgent);
            this.splitContainer1.Panel2.Controls.Add(this.MyMoney);
            this.splitContainer1.Size = new System.Drawing.Size(944, 393);
            this.splitContainer1.SplitterDistance = 299;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.Build_Road);
            this.splitContainer2.Panel1.Controls.Add(this.HabitationBuild);
            this.splitContainer2.Panel1.Controls.Add(this.School_Button);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this._mainViewPortControl);
            this.splitContainer2.Size = new System.Drawing.Size(944, 299);
            this.splitContainer2.SplitterDistance = 71;
            this.splitContainer2.TabIndex = 0;
            // 
            // Build_Road
            // 
            this.Build_Road.Location = new System.Drawing.Point(2, 11);
            this.Build_Road.Margin = new System.Windows.Forms.Padding(2);
            this.Build_Road.Name = "Build_Road";
            this.Build_Road.Size = new System.Drawing.Size(68, 19);
            this.Build_Road.TabIndex = 3;
            this.Build_Road.Text = "Route";
            this.Build_Road.UseVisualStyleBackColor = true;
            this.Build_Road.Visible = false;
            this.Build_Road.Click += new System.EventHandler(this.buton_Grass_Click);
            // 
            // HabitationBuild
            // 
            this.HabitationBuild.Location = new System.Drawing.Point(2, 57);
            this.HabitationBuild.Margin = new System.Windows.Forms.Padding(2);
            this.HabitationBuild.Name = "HabitationBuild";
            this.HabitationBuild.Size = new System.Drawing.Size(68, 19);
            this.HabitationBuild.TabIndex = 8;
            this.HabitationBuild.Text = "Habitation";
            this.HabitationBuild.UseVisualStyleBackColor = true;
            this.HabitationBuild.Click += new System.EventHandler(this.CreateHabitation);
            // 
            // School_Button
            // 
            this.School_Button.Location = new System.Drawing.Point(2, 34);
            this.School_Button.Margin = new System.Windows.Forms.Padding(2);
            this.School_Button.Name = "School_Button";
            this.School_Button.Size = new System.Drawing.Size(68, 19);
            this.School_Button.TabIndex = 5;
            this.School_Button.Text = "Ecole";
            this.School_Button.UseVisualStyleBackColor = true;
            this.School_Button.Visible = false;
            this.School_Button.Click += new System.EventHandler(this.School_Button_Click);
            // 
            // _mainViewPortControl
            // 
            this._mainViewPortControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainViewPortControl.Location = new System.Drawing.Point(0, 0);
            this._mainViewPortControl.Name = "_mainViewPortControl";
            this._mainViewPortControl.Size = new System.Drawing.Size(869, 299);
            this._mainViewPortControl.TabIndex = 0;
            // 
            // fastforward_button
            // 
            this.fastforward_button.Location = new System.Drawing.Point(156, 8);
            this.fastforward_button.Name = "fastforward_button";
            this.fastforward_button.Size = new System.Drawing.Size(60, 23);
            this.fastforward_button.TabIndex = 12;
            this.fastforward_button.Text = ">>";
            this.fastforward_button.UseVisualStyleBackColor = true;
            this.fastforward_button.Click += new System.EventHandler(this.fastforward_button_Click);
            // 
            // pause_button
            // 
            this.pause_button.Location = new System.Drawing.Point(75, 8);
            this.pause_button.Name = "pause_button";
            this.pause_button.Size = new System.Drawing.Size(75, 23);
            this.pause_button.TabIndex = 11;
            this.pause_button.Text = "pause";
            this.pause_button.UseVisualStyleBackColor = true;
            this.pause_button.Click += new System.EventHandler(this.pause_button_Click);
            // 
            // rewind_button
            // 
            this.rewind_button.Location = new System.Drawing.Point(13, 8);
            this.rewind_button.Name = "rewind_button";
            this.rewind_button.Size = new System.Drawing.Size(57, 23);
            this.rewind_button.TabIndex = 10;
            this.rewind_button.Text = "<<";
            this.rewind_button.UseVisualStyleBackColor = true;
            this.rewind_button.Click += new System.EventHandler(this.rewind_button_Click);
            // 
            // MoneyGestionOpen
            // 
            this.MoneyGestionOpen.Location = new System.Drawing.Point(839, 56);
            this.MoneyGestionOpen.Margin = new System.Windows.Forms.Padding(2);
            this.MoneyGestionOpen.Name = "MoneyGestionOpen";
            this.MoneyGestionOpen.Size = new System.Drawing.Size(96, 19);
            this.MoneyGestionOpen.TabIndex = 9;
            this.MoneyGestionOpen.Text = "Gerer L\'argent";
            this.MoneyGestionOpen.UseVisualStyleBackColor = true;
            this.MoneyGestionOpen.Click += new System.EventHandler(this.MoneyGestionOpen_Click);
            // 
            // HumeurLabel
            // 
            this.HumeurLabel.AutoSize = true;
            this.HumeurLabel.Location = new System.Drawing.Point(837, 32);
            this.HumeurLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.HumeurLabel.Name = "HumeurLabel";
            this.HumeurLabel.Size = new System.Drawing.Size(50, 13);
            this.HumeurLabel.TabIndex = 7;
            this.HumeurLabel.Text = "Humeur :";
            // 
            // Button_Destroy
            // 
            this.Button_Destroy.Location = new System.Drawing.Point(569, 2);
            this.Button_Destroy.Margin = new System.Windows.Forms.Padding(2);
            this.Button_Destroy.Name = "Button_Destroy";
            this.Button_Destroy.Size = new System.Drawing.Size(56, 19);
            this.Button_Destroy.TabIndex = 6;
            this.Button_Destroy.Text = "Détruire";
            this.Button_Destroy.UseVisualStyleBackColor = true;
            this.Button_Destroy.Visible = false;
            this.Button_Destroy.Click += new System.EventHandler(this.Button_Destroy_Click);
            // 
            // Kind_Building
            // 
            this.Kind_Building.AutoSize = true;
            this.Kind_Building.Location = new System.Drawing.Point(449, 22);
            this.Kind_Building.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Kind_Building.Name = "Kind_Building";
            this.Kind_Building.Size = new System.Drawing.Size(37, 13);
            this.Kind_Building.TabIndex = 5;
            this.Kind_Building.Text = "Type :";
            this.Kind_Building.Visible = false;
            // 
            // Coordonnées
            // 
            this.Coordonnées.AutoSize = true;
            this.Coordonnées.Location = new System.Drawing.Point(449, 8);
            this.Coordonnées.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Coordonnées.Name = "Coordonnées";
            this.Coordonnées.Size = new System.Drawing.Size(97, 13);
            this.Coordonnées.TabIndex = 4;
            this.Coordonnées.Text = "Coordonnées : 0, 0";
            this.Coordonnées.Visible = false;
            // 
            // MonArgent
            // 
            this.MonArgent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MonArgent.AutoSize = true;
            this.MonArgent.Location = new System.Drawing.Point(905, 8);
            this.MonArgent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MonArgent.Name = "MonArgent";
            this.MonArgent.Size = new System.Drawing.Size(31, 13);
            this.MonArgent.TabIndex = 2;
            this.MonArgent.Text = "5000";
            // 
            // MyMoney
            // 
            this.MyMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyMoney.AutoSize = true;
            this.MyMoney.Location = new System.Drawing.Point(835, 8);
            this.MyMoney.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.MyMoney.Name = "MyMoney";
            this.MyMoney.Size = new System.Drawing.Size(67, 13);
            this.MyMoney.TabIndex = 1;
            this.MyMoney.Text = "Mon argent :";
            // 
            // DemoWindow2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 393);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Name = "DemoWindow2";
            this.Text = "Simc\'ITI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DemoWindow2_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private ViewPortControl _mainViewPortControl;
        private System.Windows.Forms.Label MonArgent;
        private System.Windows.Forms.Label MyMoney;
        private System.Windows.Forms.Button Build_Road;
        private System.Windows.Forms.Label Coordonnées;
        private System.Windows.Forms.Label Kind_Building;
        private System.Windows.Forms.Button School_Button;
        private System.Windows.Forms.Button Button_Destroy;
        private System.Windows.Forms.Label HumeurLabel;
        private System.Windows.Forms.Button HabitationBuild;
        private System.Windows.Forms.Button MoneyGestionOpen;
        private System.Windows.Forms.Button fastforward_button;
        private System.Windows.Forms.Button pause_button;
        private System.Windows.Forms.Button rewind_button;
    }
}