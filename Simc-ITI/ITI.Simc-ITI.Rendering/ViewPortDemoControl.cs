using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.Simc_ITI.Rendering
{
    public partial class ViewPortDemoControl : UserControl
    {
        public ViewPortDemoControl()
        {
            InitializeComponent();
            _viewControl.ViewPort.AreaChanged += ViewPort_AreaChanged;
        }

        void ViewPort_AreaChanged( object sender, EventArgs e )
        {
            _viewPortLeft.Maximum = _viewControl.ViewPort.Map.Area.Width - _viewControl.ViewPort.Area.Width;
            _viewPortLeft.Value = _viewControl.ViewPort.Area.Left;
            _viewPortTop.Maximum = _viewControl.ViewPort.Map.Area.Height - _viewControl.ViewPort.Area.Height;
            _viewPortTop.Value = _viewControl.ViewPort.Area.Top;
            DisplayInfo();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad( e );
            DisplayInfo();
        }

        void _zoomer_Scroll( object sender, EventArgs e )
        {
            _viewControl.ViewPort.UserZoomFactor = (double)(_zoomer.Maximum - _zoomer.Value) / (double)_zoomer.Maximum;
        }

        void DisplayInfo()
        {
            StringBuilder b = new StringBuilder();
            b.Append( "ViewPort: " ).Append( _viewControl.ViewPort.Area ).AppendLine();
            b.Append( "Zoom: " ).Append( _viewControl.ViewPort.UserZoomFactor ).AppendLine();
            b.Append( "ClientScaleFactor: " ).Append( _viewControl.ViewPort.ClientScaleFactor ).AppendLine();
            b.Append( "ClientSize: " ).Append( _viewControl.ClientSize ).AppendLine();
            _displayInfo.Text = b.ToString();
        }

        void _viewPortLeft_ValueChanged( object sender, EventArgs e )
        {
            _viewControl.ViewPort.MoveTo( (int)_viewPortLeft.Value, _viewControl.ViewPort.Area.Top );
        }

        void _viewPortTop_ValueChanged( object sender, EventArgs e )
        {
            _viewControl.ViewPort.MoveTo( _viewControl.ViewPort.Area.Left, (int)_viewPortTop.Value );
        }
    }
}
