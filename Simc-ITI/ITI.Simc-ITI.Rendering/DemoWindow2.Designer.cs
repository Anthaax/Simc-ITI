namespace ITI.Simc_ITI.Rendering
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
            this.MonArgent = new System.Windows.Forms.Label();
            this.MyMoney = new System.Windows.Forms.Label();
            this.Build_Road = new System.Windows.Forms.Button();
            this._mainViewPortControl = new ITI.Simc_ITI.Rendering.ViewPortControl();
            this.Coordonnées = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Coordonnées);
            this.splitContainer1.Panel2.Controls.Add(this.Build_Road);
            this.splitContainer1.Panel2.Controls.Add(this.MonArgent);
            this.splitContainer1.Panel2.Controls.Add(this.MyMoney);
            this.splitContainer1.Size = new System.Drawing.Size(1259, 484);
            this.splitContainer1.SplitterDistance = 369;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this._mainViewPortControl);
            this.splitContainer2.Size = new System.Drawing.Size(1259, 369);
            this.splitContainer2.SplitterDistance = 70;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // MonArgent
            // 
            this.MonArgent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MonArgent.AutoSize = true;
            this.MonArgent.Location = new System.Drawing.Point(1207, 10);
            this.MonArgent.Name = "MonArgent";
            this.MonArgent.Size = new System.Drawing.Size(40, 17);
            this.MonArgent.TabIndex = 2;
            this.MonArgent.Text = "5000";
            // 
            // MyMoney
            // 
            this.MyMoney.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MyMoney.AutoSize = true;
            this.MyMoney.Location = new System.Drawing.Point(1121, 10);
            this.MyMoney.Name = "MyMoney";
            this.MyMoney.Size = new System.Drawing.Size(88, 17);
            this.MyMoney.TabIndex = 1;
            this.MyMoney.Text = "Mon argent :";
            // 
            // Build_Road
            // 
            this.Build_Road.Location = new System.Drawing.Point(13, 10);
            this.Build_Road.Name = "Build_Road";
            this.Build_Road.Size = new System.Drawing.Size(75, 23);
            this.Build_Road.TabIndex = 3;
            this.Build_Road.Text = "Road";
            this.Build_Road.UseVisualStyleBackColor = true;
            this.Build_Road.Visible = false;
            this.Build_Road.Click += new System.EventHandler(this.buton_Grass_Click);
            // 
            // _mainViewPortControl
            // 
            this._mainViewPortControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainViewPortControl.Location = new System.Drawing.Point(0, 0);
            this._mainViewPortControl.Margin = new System.Windows.Forms.Padding(4);
            this._mainViewPortControl.Name = "_mainViewPortControl";
            this._mainViewPortControl.Size = new System.Drawing.Size(1184, 369);
            this._mainViewPortControl.TabIndex = 0;
            // 
            // Coordonnées
            // 
            this.Coordonnées.AutoSize = true;
            this.Coordonnées.Location = new System.Drawing.Point(599, 10);
            this.Coordonnées.Name = "Coordonnées";
            this.Coordonnées.Size = new System.Drawing.Size(129, 17);
            this.Coordonnées.TabIndex = 4;
            this.Coordonnées.Text = "Coordonnées : 0, 0";
            this.Coordonnées.Visible = false;
            // 
            // DemoWindow2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 484);
            this.Controls.Add(this.splitContainer1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DemoWindow2";
            this.Text = "Simc\'ITI";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DemoWindow2_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
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
    }
}