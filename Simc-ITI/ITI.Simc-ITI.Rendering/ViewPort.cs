﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Rendering
{
    public class ViewPort
    {
        readonly Map _map;
        readonly int _minDisplayWidth;
        Rectangle _viewPort;
        double _userZoomFactor;
        int _maxClientSize;
        public float _clientScaleFactor;

        public ViewPort( Map m, int minDisplayMeters )
        {
            _map = m;
            _viewPort = m.Area;
            _userZoomFactor = 0.0;
            _minDisplayWidth = minDisplayMeters * 100;
        }

        public Map Map
        {
            get { return _map; }
        }

        public bool HScrollEnabled
        {
            get { return _viewPort.Width < _map.MapWidth; }
        }

        public bool VScrollEnabled
        {
            get { return _viewPort.Height < Map.Area.Height; }
        }

        public double MinActualZoomFactor
        {
            get { return (double)_minDisplayWidth / (double)_map.MapWidth; }
        }

        /// <summary>
        /// Gets the zoom factor between <see cref="MinActualZoomFactor"/> (closest) and 1.0 (seeing the whole map).
        /// </summary>
        public double ActualZoomFactor
        {
            get { return (double)Math.Max( _viewPort.Width, _viewPort.Height ) / (double)_map.MapWidth; }
        }

        public bool SetActualZoomFactor( double value )
        {
            Debug.Assert( _map.Area.Contains( _viewPort ) );
            if( value > 1.0 ) value = 1.0;
            else if( value < MinActualZoomFactor ) value = MinActualZoomFactor;
            if( Math.Abs( value - ActualZoomFactor ) <= Double.Epsilon ) return false;

            double grow = value / ActualZoomFactor;
            int newWidth = (int)Math.Round( _viewPort.Width * grow );
            if( newWidth < _minDisplayWidth ) newWidth = _minDisplayWidth;
            int newHeight = (int)Math.Round( _viewPort.Height * grow );
            if( newHeight < _minDisplayWidth ) newHeight = _minDisplayWidth;
            int deltaW = (newWidth - _viewPort.Width) / 2;
            int deltaH = (newHeight - _viewPort.Height) / 2;
            if( deltaW == 0 && deltaH == 0 ) return false;
            _viewPort.Width = newWidth;
            _viewPort.Height = newHeight;
            DoMove( ref _viewPort, -deltaW, -deltaW );
            Debug.Assert( _map.Area.Contains( _viewPort ) );
            _clientScaleFactor = (float)_maxClientSize / (float)Math.Max( _viewPort.Width, _viewPort.Height );
            var h = AreaChanged;
            if( h != null ) h( this, EventArgs.Empty );
            return true;
        }

        /// <summary>
        /// Gets the current area of this ViewPort (in centimeters).
        /// </summary>
        public Rectangle Area
        {
            get { return _viewPort; }
        }

        /// <summary>
        /// Fires whenever <see cref="Area"/> has changed.
        /// </summary>
        public event EventHandler AreaChanged;

        /// <summary>
        /// Gets or sets the zoom factor from 0.0 (seeing the whole map) to 1.0 (closest).
        /// This is the reverse of the <see cref="ActualZoomFactor"/> and in the range [0.0,1.0].
        /// </summary>
        public double UserZoomFactor
        {
            get { return _userZoomFactor; }
            set
            {
                if( value <= 0 )
                {
                    _userZoomFactor = 0.0;
                    SetActualZoomFactor( 1.0 );
                }
                else if( value >= 1.0 )
                {
                    _userZoomFactor = 1.0;
                    SetActualZoomFactor( MinActualZoomFactor );
                }
                else
                {
                    _userZoomFactor = value;
                    SetActualZoomFactor( (1.0 - value) * (1.0 - MinActualZoomFactor) + MinActualZoomFactor );
                }
            }
        }

        public float ClientScaleFactor
        {
            get { return _clientScaleFactor; }

        }

        public void Move( int deltaX, int deltaY )
        {
            if( DoMove( ref _viewPort, deltaX, deltaY ) )
            {
                var h = AreaChanged;
                if( h != null ) h( this, EventArgs.Empty );
            }
        }

        public void MoveTo( int x, int y )
        {
            Move( x - _viewPort.X, y - _viewPort.Y );
        }

        bool DoMove( ref Rectangle r, int deltaX, int deltaY )
        {
            int prevX = r.X;
            int prevY = r.Y;
            r.Offset( deltaX, deltaY );
            if( r.X < 0 ) r.X = 0;
            else
            {
                int overflow = r.Right - _map.MapWidth;
                if( overflow > 0 )
                {
                    r.X -= overflow;
                    if( r.X < 0 )
                    {
                        r.X = 0;
                        r.Width = _map.MapWidth;
                    }
                }
            }
            if( r.Y < 0 ) r.Y = 0;
            else
            {
                int overflow = r.Bottom - _map.MapWidth;
                if( overflow > 0 )
                {
                    r.Y -= overflow;
                    if( r.Y < 0 )
                    {
                        r.Y = 0;
                        r.Height = _map.MapWidth;
                    }
                }
            }
            Debug.Assert( _map.Area.Contains( r ) );
            return prevX != r.X || prevY != r.Y;
        }

        internal void SetClientSize( Size client )
        {
            Debug.Assert( _map.Area.Contains( _viewPort ) );
            _maxClientSize = Math.Max( client.Width, client.Height );
            Rectangle newViewPort = _viewPort;
            bool keepH = _viewPort.Height > _viewPort.Width || (_viewPort.Height == _viewPort.Width && client.Height > client.Width);
            if( keepH )
            {
                _clientScaleFactor = (float)_maxClientSize / (float)_viewPort.Height;
                newViewPort.Width = (int)Math.Ceiling( _viewPort.Height * client.Width / (double)_maxClientSize );
                if( newViewPort.Width < _minDisplayWidth ) newViewPort.Width = _minDisplayWidth;
                if( newViewPort.Right > _map.MapWidth )
                {
                    DoMove( ref newViewPort, _map.MapWidth - newViewPort.Right, 0 );
                }
            }
            else
            {
                _clientScaleFactor = (float)_maxClientSize / (float)_viewPort.Width;
                newViewPort.Height = (int)Math.Ceiling( _viewPort.Width * client.Height / (double)_maxClientSize );
                if( newViewPort.Height < _minDisplayWidth ) newViewPort.Height = _minDisplayWidth;
                if( newViewPort.Bottom > _map.Area.Height )
                {
                    DoMove( ref newViewPort, 0, _map.Area.Height - newViewPort.Bottom );
                }
            }
            Debug.Assert( _map.Area.Contains( newViewPort ) );
            _viewPort = newViewPort;
            _clientScaleFactor = (float)_maxClientSize / (float)Math.Max( _viewPort.Width, _viewPort.Height );
            var h = AreaChanged;
            if( h != null ) h( this, EventArgs.Empty );
        }

        internal void Draw( Graphics g )
        {
            Debug.Assert( _map.Area.Contains( _viewPort ) );
            Matrix origin = g.Transform;
            g.ResetTransform();
            g.ScaleTransform( _clientScaleFactor, _clientScaleFactor );
            Matrix local = g.Transform;
            foreach( var renderInfo in _map.GetOverlappedBoxes( _viewPort ) )
            {
                g.TranslateTransform( renderInfo.OffsetX, renderInfo.OffsetY );
                renderInfo.Box.Draw( g, renderInfo.RectSource, _clientScaleFactor );
                g.Transform = local;
            }
            g.Transform = origin;
        }

    }
}
