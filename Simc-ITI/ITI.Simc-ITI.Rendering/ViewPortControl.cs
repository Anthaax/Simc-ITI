using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.Simc_ITI.Rendering
{
    public partial class ViewPortControl : Control
    {
        Map _map;
        ViewPort _viewPort;

        public ViewPortControl()
        {
            DoubleBuffered = true;
        }

        public void SetMap( Map m, int minDisplayWidth )
        {
            if( _map != null )
            {
                Debug.Assert( _viewPort != null && _viewPort.Map == _map );
                _viewPort.AreaChanged -= _viewPort_AreaChanged;
                _map = null;
                _viewPort = null;
            }
            if( m != null )
            {
                _map = m;
                _viewPort = new ViewPort( m, minDisplayWidth );
                _viewPort.AreaChanged += _viewPort_AreaChanged;
                _viewPort.SetClientSize( ClientSize );
            }
            Invalidate();
        }

        void _viewPort_AreaChanged( object sender, EventArgs e )
        {
            Invalidate();
        }

        /// <summary>
        /// Gets the <see cref="ViewPort"/> object. Null if no map has been set.
        /// </summary>
        public ViewPort ViewPort
        {
            get { return _viewPort; }
        }

        protected override void OnResize( EventArgs e )
        {
            if( _viewPort != null ) _viewPort.SetClientSize( ClientSize );
            base.OnResize( e );
        }

        public void ScrollTo( int x, int y )
        {
            if( _viewPort != null ) _viewPort.MoveTo( x, y );
        }

        protected override void OnPaint( PaintEventArgs e )
        {
            if( _viewPort == null || this.IsInDesignMode() )
            {
                e.Graphics.FillRectangle( Brushes.Yellow, e.ClipRectangle );
            }
            else
            {
                _viewPort.Draw( e.Graphics );
            }
            base.OnPaint( e );
        }

    }
}