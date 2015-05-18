using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITI.Simc_ITI.Build;

namespace ITI.Simc_ITI.Rendering
{
    public partial class DemoWindow2 : Form
    {
        Map _map;
        InfrastructureManager _infManager;
        double scalefactor;
        int x;
        int y;

        public DemoWindow2()
        {
            _map = new Map( 100,100 );
            _infManager = new InfrastructureManager();
            InitializeComponent();
            _mainViewPortControl.SetMap( _map, 5 * 100 );
            _map.Money.ActualMoneyChanged += label_MonArgent_text;
            scalefactor = _mainViewPortControl.ViewPort.ActualZoomFactor;
            _mainViewPortControl.MouseDown += new MouseEventHandler( MouseClickEvent );
        }

        private void buton_Grass_Click( object sender, EventArgs e )
        {
            _infManager.Find( "Road" ).CreateInfrastructure( _map.Boxes[0, 1] );
            _mainViewPortControl.Invalidate();
        }
  
        private void label_MonArgent_text( object sender, EventArgs e)
        {
            MonArgent.Text = _map.Money.ActualMoney.ToString();
        }

        private void DemoWindow2_KeyDown( object sender, KeyEventArgs e )
        {
            switch( e.KeyCode )
            {
                case Keys.Add:
                    if (scalefactor >= 0.1)
                    {
                        scalefactor -= 0.1;
                        _mainViewPortControl.Zoom(scalefactor);
                        x = _mainViewPortControl.ViewPort.Area.X;
                        y = _mainViewPortControl.ViewPort.Area.Y;
                    }
                    break;
                case Keys.Subtract:
                    if (scalefactor < 1.0)
                    {
                        scalefactor += 0.1;
                        _mainViewPortControl.Zoom(scalefactor);
                        x = _mainViewPortControl.ViewPort.Area.X;
                        y = _mainViewPortControl.ViewPort.Area.Y;
                    }
                    break;
                case Keys.NumPad6:
                    x += 10000;
                    break;
                case Keys.NumPad4:
                    if( x > 0) x -= 10000;
                    break;
                case Keys.NumPad8:
                    if (y > 0) y -= 10000;
                    break;
                case Keys.NumPad2:
                    y += 10000;
                    break;

                //Keys.OemMinus
            }
            _mainViewPortControl.KeyMove(x, y);
        }

        private void MouseClickEvent(object sender, MouseEventArgs e)
        {
            int _mouseX = e.X;
            int _mouseY = e.Y;
            double _xMap = _mainViewPortControl.ViewPort.Area.X + (_mouseX * _mainViewPortControl.ViewPort.Area.Width * _mainViewPortControl.ViewPort.ActualZoomFactor) / _map.MapWidth;
            double _yMap = _mainViewPortControl.ViewPort.Area.Y + (_mouseY * _mainViewPortControl.ViewPort.Area.Width * _mainViewPortControl.ViewPort.ActualZoomFactor) / _map.MapWidth;
            MessageBox.Show("Position de la souris : "+_mouseX+" , "+_mouseY+"\n"+"Position sur la map : "+_xMap+" , "+_yMap );

        }
    }
}
