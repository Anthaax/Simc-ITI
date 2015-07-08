namespace ITI.Simc_ITI.Rendering
{
    partial class MainGameControl
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
            this.bottomPaneControl1 = new ITI.Simc_ITI.Rendering.BottomPaneControl();
            this.leftPaneControl1 = new ITI.Simc_ITI.Rendering.LeftPaneControl();
            this.viewPortControl1 = new ITI.Simc_ITI.Rendering.ViewPortControl();
            this.SuspendLayout();
            // 
            // bottomPaneControl1
            // 
            this.bottomPaneControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPaneControl1.Location = new System.Drawing.Point(0, 406);
            this.bottomPaneControl1.Margin = new System.Windows.Forms.Padding(4);
            this.bottomPaneControl1.Name = "bottomPaneControl1";
            this.bottomPaneControl1.Size = new System.Drawing.Size(1037, 117);
            this.bottomPaneControl1.TabIndex = 0;
            // 
            // leftPaneControl1
            // 
            this.leftPaneControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.leftPaneControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftPaneControl1.Location = new System.Drawing.Point(0, 0);
            this.leftPaneControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.leftPaneControl1.Name = "leftPaneControl1";
            this.leftPaneControl1.Size = new System.Drawing.Size(115, 406);
            this.leftPaneControl1.TabIndex = 1;
            // 
            // viewPortControl1
            // 
            this.viewPortControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewPortControl1.Location = new System.Drawing.Point(115, 0);
            this.viewPortControl1.Name = "viewPortControl1";
            this.viewPortControl1.Size = new System.Drawing.Size(922, 406);
            this.viewPortControl1.TabIndex = 2;
            this.viewPortControl1.Text = "viewPortControl1";
            // 
            // MainGameControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.viewPortControl1);
            this.Controls.Add(this.leftPaneControl1);
            this.Controls.Add(this.bottomPaneControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainGameControl";
            this.Size = new System.Drawing.Size(1037, 523);
            this.ResumeLayout(false);

        }

        #endregion

        private BottomPaneControl bottomPaneControl1;
        private LeftPaneControl leftPaneControl1;
        private ViewPortControl viewPortControl1;


    }
}
