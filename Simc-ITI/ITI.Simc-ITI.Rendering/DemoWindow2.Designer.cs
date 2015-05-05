namespace ITI.Map2D.Rendering
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
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
            this._mainViewPortControl = new ITI.Map2D.ViewPortControl();
            this.buton_Grass = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(944, 393);
            this.splitContainer1.SplitterDistance = 240;
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
            this.splitContainer2.Panel1.Controls.Add(this.buton_Grass);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this._mainViewPortControl);
            this.splitContainer2.Size = new System.Drawing.Size(944, 240);
            this.splitContainer2.SplitterDistance = 53;
            this.splitContainer2.TabIndex = 0;
            // 
            // _mainViewPortControl
            // 
            this._mainViewPortControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._mainViewPortControl.Location = new System.Drawing.Point(0, 0);
            this._mainViewPortControl.Name = "_mainViewPortControl";
            this._mainViewPortControl.Size = new System.Drawing.Size(887, 240);
            this._mainViewPortControl.TabIndex = 0;
            // 
            // buton_Grass
            // 
            this.buton_Grass.Location = new System.Drawing.Point(4, 13);
            this.buton_Grass.Name = "buton_Grass";
            this.buton_Grass.Size = new System.Drawing.Size(46, 23);
            this.buton_Grass.TabIndex = 0;
            this.buton_Grass.Text = "Grass";
            this.buton_Grass.UseVisualStyleBackColor = true;
           
            // 
            // DemoWindow2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 393);
            this.Controls.Add(this.splitContainer1);
            this.Name = "DemoWindow2";
            this.Text = "DemoWindow2";
            this.splitContainer1.Panel1.ResumeLayout(false);
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
        private System.Windows.Forms.Button buton_Grass;
    }
}