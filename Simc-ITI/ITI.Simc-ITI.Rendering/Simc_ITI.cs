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
    public partial class Simc_ITI : Form
    {
        Timer _timer;
        GameContext _game;
        double scalefactor;
        int x;
        int y;
        int _xBox;
        int _yBox;
        public Simc_ITI()
        {
            InitializeComponent();
            menuControl1.GameHasBeenCreated += ( s, e ) => InitializeGame();
        }
        private void InitializeGame()
        {
            _game = menuControl1.GameContext;
            menuControl1.Visible = false;
            _bottomPaneControl.Visible = true;
            _leftPaneControl.Visible = true;
            _viewPortControl.Visible = true;
            _bottomPaneControl.SetGameandViewport( _game, _viewPortControl );
            _leftPaneControl.SetGameandViewport( _game, _viewPortControl );
            _viewPortControl.SetMap( _game.Map, 5 * 100 );
            scalefactor = _viewPortControl.ViewPort.ActualZoomFactor;
            _viewPortControl.MouseDown += new MouseEventHandler( MouseClickEvent );
            _viewPortControl.MouseUp += new MouseEventHandler(MouseUnClickEvent);
            BuildingEvent();
            InitiallizeTimer();
            InitializeZoom();
        }

        private void InitializeZoom()
        {
            _leftPaneControl.MouseWheel += new MouseEventHandler(TrayIcon_MouseWheel);
            _bottomPaneControl.MouseWheel += new MouseEventHandler(TrayIcon_MouseWheel);
            _viewPortControl.MouseWheel += new MouseEventHandler(TrayIcon_MouseWheel);
            menuControl1.MouseWheel += new MouseEventHandler(TrayIcon_MouseWheel);
        }

        private void InitiallizeTimer()
        {
            _timer = new Timer();
            _timer.Interval = 10000;
            _timer.Enabled = true;
            _timer.Tick += UpdateGame;
            _timer.Start();
            _bottomPaneControl.SetTimer( _timer );
        }
        private void BuildingEvent()
        {
            IEnumerable<InfrastructureType> types = _game.InfrastructureManager.AllTypes;
            foreach( var building in types )
            {
                building.BuildingHasBeenCreated += ( s, e ) => AfterBuildAInfrastructure();
                building.BuildingHasBeenCreated += ( s, e ) => _bottomPaneControl.AverageHappyness();
            }
        }
        private void UpdateGame( object sender, EventArgs e )
        {
            int update = 0;
            IEnumerable<IInfrastructureForBox> infra = _game.Map.GetAllInfrastucture<IInfrastructureForBox>();
            foreach( var infrastructure in infra )
            {
                update += infrastructure.Update();
            }
            _game.MoneyManager.LastPurchase = update;
            _viewPortControl.Invalidate();
        }


        private void MouseUnClickEvent(object sender, MouseEventArgs e)
        {

            int _xBox2;
            int _yBox2;
            int _boxInPixel2 = (int)Math.Round(_game.Map.BoxWidth * _viewPortControl.ViewPort.ClientScaleFactor);
            int _mouseX2 = e.X;
            int _mouseY2 = e.Y;
            _xBox2 = Math.Min((_viewPortControl.ViewPort.Area.X / _game.Map.BoxWidth) + _mouseX2 / _boxInPixel2, _game.Map.BoxCount);
            _yBox2 = Math.Min((_viewPortControl.ViewPort.Area.Y / _game.Map.BoxWidth) + _mouseY2 / _boxInPixel2, _game.Map.BoxCount);
            if (_xBox2 >= 100) _xBox2 = 99;
            if (_yBox2 >= 100) _yBox2 = 99;
            MouseMoveOnDrag(_xBox, _yBox, _xBox2, _yBox2);
        }
        private void MouseMoveOnDrag(int x1, int y1, int x2, int y2)
        {
            int xMove = x1 - x2;
            int yMove = y1 - y2;
            int MoveX = xMove * 10000;
            int MoveY = yMove * 10000;
            _viewPortControl.KeyMove(MoveX, MoveY);
        }

        private void TrayIcon_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                if (scalefactor < 1.0)
                {
                    scalefactor += 0.1;
                    _viewPortControl.Zoom(scalefactor);
                    x = _viewPortControl.ViewPort.Area.X;
                    y = _viewPortControl.ViewPort.Area.Y;
                }
            }
            else if (e.Delta > 0)
            {
                if (scalefactor >= 0.1)
                {
                    scalefactor -= 0.1;
                    _viewPortControl.Zoom(scalefactor);
                    x = _viewPortControl.ViewPort.Area.X;
                    y = _viewPortControl.ViewPort.Area.Y;
                }
            }
        }

        private void MoveOnTheMap( object sender, KeyEventArgs e )
        {
            switch( e.KeyCode )
            {
                case Keys.Add:
                    break;
                case Keys.NumPad6:
                    x += 10000;
                    break;
                case Keys.NumPad4:
                    if( x > 0 ) x -= 10000;
                    break;
                case Keys.NumPad8:
                    if( y > 0 ) y -= 10000;
                    break;
                case Keys.NumPad2:
                    y += 10000;
                    break;
            }
            _viewPortControl.KeyMove( x, y );
        }
        private void MouseClickEvent(object sender, MouseEventArgs e)
        {
            int _boxInPixel = (int)Math.Round( _game.Map.BoxWidth *  _viewPortControl.ViewPort.ClientScaleFactor );
            int _mouseX = e.X;
            int _mouseY = e.Y;
            _xBox = Math.Min( (_viewPortControl.ViewPort.Area.X / _game.Map.BoxWidth) + _mouseX / _boxInPixel, _game.Map.BoxCount );
            _yBox = Math.Min( (_viewPortControl.ViewPort.Area.Y / _game.Map.BoxWidth) + _mouseY / _boxInPixel, _game.Map.BoxCount );
            if( _xBox >= 100 ) _xBox = 99;
            if( _yBox >= 100 ) _yBox = 99;
            _bottomPaneControl.RenderingWithClickEvent( _xBox, _yBox );
            _leftPaneControl.PositionOfTheMouse( _xBox, _yBox );
            ColorSelectedBox();
        }
        private void ColorSelectedBox()
        {
            foreach( var box in _game.Map.Boxes )
            {
                box.PenColor = new Pen( Color.DimGray );
            }
            _game.Map.Boxes[_xBox, _yBox].PenColor = new Pen( Color.Red );
            _viewPortControl.Invalidate();
        }
        private void AfterBuildAInfrastructure()
        {
            Habitation taxe = _game.Map.Boxes[_xBox, _yBox].Infrasructure as Habitation;
            if( taxe != null ) taxe.Taxation = _game.MoneyManager.TaxationManager.HabitationTaxation;
            Retail ctaxe = _game.Map.Boxes[_xBox, _yBox].Infrasructure as Retail;
            if( ctaxe != null ) ctaxe.Taxation = _game.MoneyManager.TaxationManager.CommerceTaxation;
            _viewPortControl.Invalidate();
        }
    }
}
