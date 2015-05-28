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
        int _xBox;
        int _yBox;

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
            _infManager.Find( "Route" ).CreateInfrastructure( _map.Boxes[_xBox, _yBox] );
            _mainViewPortControl.Invalidate();
            Build_Road.Visible = false;
            Button_Destroy.Visible = false;
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
            int _boxInPixel = (int)Math.Round( _map.BoxWidth * _mainViewPortControl.ViewPort.ClientScaleFactor);
            int _mouseX = e.X;
            int _mouseY = e.Y;
            _xBox = (_mainViewPortControl.ViewPort.Area.X / _map.BoxWidth) + _mouseX / _boxInPixel ;
            _yBox = (_mainViewPortControl.ViewPort.Area.Y / _map.BoxWidth) + _mouseY / _boxInPixel ;

            if( _xBox == 100 ) _xBox = 99;
            else if( _yBox == 100 ) _yBox = 99;

            if( _map.Boxes[_xBox, _yBox].Infrasructure == null)
            {
                if( _map.Boxes[_xBox, _yBox].CheckTheNearBoxesRoad() == true ) School_Button.Visible = true;
                else if( _map.Boxes[_xBox, _yBox].CheckTheNearBoxesRoad() != true ) School_Button.Visible = false;
                Build_Road.Visible = true;
                Kind_Building.Visible = false;
                Button_Destroy.Visible = false;
            }
            else
            {
                Build_Road.Visible = false;
                School_Button.Visible = false;
                Kind_Building.Visible = true;
                Kind_Building.Text = "Type du batiment : Une " + _map.Boxes[_xBox, _yBox].Infrasructure.Name() + ".";
                if( _map.Boxes[_xBox, _yBox].CheckTheNearBoxesBuilding() == false )Button_Destroy.Visible = true;
            }
            Coordonnées.Visible = true;
            Coordonnées.Text = "Coordonnées : " + _xBox + " , " + _yBox;
        }

        private void School_Button_Click( object sender, EventArgs e )
        {
            _infManager.Find( "Ecole" ).CreateInfrastructure( _map.Boxes[_xBox, _yBox] );
            _mainViewPortControl.Invalidate();
            Build_Road.Visible = false;
            School_Button.Visible = false;
            Button_Destroy.Visible = false;
        }

        private void Button_Destroy_Click( object sender, EventArgs e )
        {
            _map.Money.ActualMoney += _infManager.Find( _map.Boxes[_xBox, _yBox].Infrasructure.Name() ).BuildingCost / 2;
            _map.Boxes[_xBox, _yBox].Infrasructure.Destroy();
            Button_Destroy.Visible = false;
            _mainViewPortControl.Invalidate();
        }
    }
}
