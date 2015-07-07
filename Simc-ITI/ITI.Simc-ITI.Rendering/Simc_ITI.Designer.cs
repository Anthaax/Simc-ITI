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
            this.GameOver_Label = new System.Windows.Forms.Label();
            this.menuControl1 = new ITI.Simc_ITI.Rendering.MenuControl();
            this._leftPaneControl = new ITI.Simc_ITI.Rendering.LeftPaneControl();
            this._bottomPaneControl = new ITI.Simc_ITI.Rendering.BottomPaneControl();
            this._viewPortControl = new ITI.Simc_ITI.Rendering.ViewPortControl();
            this.SuspendLayout();
            // 
            // GameOver_Label
            // 
            this.GameOver_Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameOver_Label.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GameOver_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 150F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GameOver_Label.ForeColor = System.Drawing.Color.Red;
            this.GameOver_Label.Location = new System.Drawing.Point(12, 9);
            this.GameOver_Label.Margin = new System.Windows.Forms.Padding(10);
            this.GameOver_Label.Name = "GameOver_Label";
            this.GameOver_Label.Size = new System.Drawing.Size(1340, 283);
            this.GameOver_Label.TabIndex = 4;
            this.GameOver_Label.Text = "GameOver";
            this.GameOver_Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.GameOver_Label.Visible = false;
            // 
            // menuControl1
            // 
            this.menuControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuControl1.Location = new System.Drawing.Point(115, 0);
            this.menuControl1.Margin = new System.Windows.Forms.Padding(4);
            this.menuControl1.Name = "menuControl1";
            this.menuControl1.Size = new System.Drawing.Size(1063, 252);
            this.menuControl1.TabIndex = 3;
            // 
            // _leftPaneControl
            // 
            this._leftPaneControl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._leftPaneControl.Dock = System.Windows.Forms.DockStyle.Left;
            this._leftPaneControl.Location = new System.Drawing.Point(0, 0);
            this._leftPaneControl.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._leftPaneControl.Name = "_leftPaneControl";
            this._leftPaneControl.Size = new System.Drawing.Size(115, 252);
            this._leftPaneControl.TabIndex = 2;
            this._leftPaneControl.Visible = false;
            // 
            // _bottomPaneControl
            // 
            this._bottomPaneControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._bottomPaneControl.Location = new System.Drawing.Point(0, 252);
            this._bottomPaneControl.Margin = new System.Windows.Forms.Padding(4);
            this._bottomPaneControl.Name = "_bottomPaneControl";
            this._bottomPaneControl.Size = new System.Drawing.Size(1178, 126);
            this._bottomPaneControl.TabIndex = 1;
            this._bottomPaneControl.Visible = false;
            // 
            // _viewPortControl
            // 
            this._viewPortControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._viewPortControl.Location = new System.Drawing.Point(121, 0);
            this._viewPortControl.Name = "_viewPortControl";
            this._viewPortControl.Size = new System.Drawing.Size(1063, 252);
            this._viewPortControl.TabIndex = 0;
            this._viewPortControl.Text = "viewPortControl1";
            this._viewPortControl.Visible = false;
            // 
            // Simc_ITI
            // 
            this.ClientSize = new System.Drawing.Size(1178, 378);
            this.Controls.Add(this.GameOver_Label);
            this.Controls.Add(this.menuControl1);
            this.Controls.Add(this._leftPaneControl);
            this.Controls.Add(this._bottomPaneControl);
            this.Controls.Add(this._viewPortControl);
            this.Name = "Simc_ITI";
            this.Text = "Simc\'ITI";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private ViewPortControl _viewPortControl;
        private BottomPaneControl _bottomPaneControl;
        private LeftPaneControl _leftPaneControl;
        private MenuControl menuControl1;
        private System.Windows.Forms.Label GameOver_Label;


    }
}