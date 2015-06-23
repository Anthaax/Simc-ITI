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
            this._leftPaneControl = new ITI.Simc_ITI.Rendering.LeftPaneControl();
            this._bottomPaneControl = new ITI.Simc_ITI.Rendering.BottomPaneControl();
            this._viewPortControl = new ITI.Simc_ITI.Rendering.ViewPortControl();
            this.SuspendLayout();
            // 
            // _leftPaneControl
            // 
            this._leftPaneControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._leftPaneControl.Dock = System.Windows.Forms.DockStyle.Left;
            this._leftPaneControl.Location = new System.Drawing.Point(0, 0);
            this._leftPaneControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._leftPaneControl.Name = "_leftPaneControl";
            this._leftPaneControl.Size = new System.Drawing.Size(115, 261);
            this._leftPaneControl.TabIndex = 2;
            this._leftPaneControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveOnTheMap);
            // 
            // _bottomPaneControl
            // 
            this._bottomPaneControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._bottomPaneControl.Location = new System.Drawing.Point(0, 261);
            this._bottomPaneControl.Margin = new System.Windows.Forms.Padding(4);
            this._bottomPaneControl.Name = "_bottomPaneControl";
            this._bottomPaneControl.Size = new System.Drawing.Size(1139, 117);
            this._bottomPaneControl.TabIndex = 1;
            this._bottomPaneControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveOnTheMap);
            // 
            // _viewPortControl
            // 
            this._viewPortControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._viewPortControl.Location = new System.Drawing.Point(0, 0);
            this._viewPortControl.Name = "_viewPortControl";
            this._viewPortControl.Size = new System.Drawing.Size(1139, 378);
            this._viewPortControl.TabIndex = 0;
            this._viewPortControl.Text = "viewPortControl1";
            this._viewPortControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveOnTheMap);
            // 
            // Simc_ITI
            // 
            this.ClientSize = new System.Drawing.Size(1139, 378);
            this.Controls.Add(this._leftPaneControl);
            this.Controls.Add(this._bottomPaneControl);
            this.Controls.Add(this._viewPortControl);
            this.Name = "Simc_ITI";
            this.Text = "Simc\'ITI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MoveOnTheMap);
            this.ResumeLayout(false);

        }

        #endregion

        private ViewPortControl _viewPortControl;
        private BottomPaneControl _bottomPaneControl;
        private LeftPaneControl _leftPaneControl;


    }
}