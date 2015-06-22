namespace ITI.Simc_ITI.Rendering
{
    partial class Simc_ITI
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
            this._viewPortControl = new ITI.Simc_ITI.Rendering.ViewPortControl();
            this._bottomPaneControl = new ITI.Simc_ITI.Rendering.BottomPaneControl();
            this._leftPaneControl = new ITI.Simc_ITI.Rendering.LeftPaneControl();
            this.SuspendLayout();
            // 
            // _bottomPaneControl
            // 
            this._bottomPaneControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._bottomPaneControl.Location = new System.Drawing.Point(0, 245);
            this._bottomPaneControl.Margin = new System.Windows.Forms.Padding(4);
            this._bottomPaneControl.Name = "_bottomPaneControl";
            this._bottomPaneControl.Size = new System.Drawing.Size(809, 117);
            this._bottomPaneControl.TabIndex = 0;
            // 
            // _leftPaneControl
            // 
            this._leftPaneControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._leftPaneControl.Dock = System.Windows.Forms.DockStyle.Left;
            this._leftPaneControl.Location = new System.Drawing.Point(0, 0);
            this._leftPaneControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._leftPaneControl.Name = "_leftPaneControl";
            this._leftPaneControl.Size = new System.Drawing.Size(115, 245);
            this._leftPaneControl.TabIndex = 1;
            // 
            // _viewPortControl
            // 
            this._viewPortControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._viewPortControl.Location = new System.Drawing.Point(115, 0);
            this._viewPortControl.Name = "_viewPortControl";
            this._viewPortControl.Size = new System.Drawing.Size(694, 245);
            this._viewPortControl.TabIndex = 2;
            this._viewPortControl.Text = "viewPortControl1";
            // 
            // Simc_ITI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(809, 362);
            this.Controls.Add(this._viewPortControl);
            this.Controls.Add(this._leftPaneControl);
            this.Controls.Add(this._bottomPaneControl);
            this.Name = "Simc_ITI";
            this.Text = "Simc_ITI";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler( this.MoveOnTheMap );
            this.ResumeLayout(false);

        }

        #endregion

        private BottomPaneControl _bottomPaneControl;
        private LeftPaneControl _leftPaneControl;
        private ViewPortControl _viewPortControl;


    }
}