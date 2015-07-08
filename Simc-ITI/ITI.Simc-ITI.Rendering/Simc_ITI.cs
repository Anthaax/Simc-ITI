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
        /// <summary>
        /// Initialize game 
        /// Use this only if the game wasn't null
        /// </summary>
        private void InitializeGame()
        {
            _game = menuControl1.GameContext;
            InitializeUsersControls();
            scalefactor = _viewPortControl.ViewPort.ActualZoomFactor;
            
            MouseEvents();
            InitialiezBuildingEvent();
            InitiallizeTimer();
        }
        /// <summary>
        /// Initialize All User Controls
        /// </summary>
        private void InitializeUsersControls()
        {
            menuControl1.Visible = false;
            _bottomPaneControl.Visible = true;
            _leftPaneControl.Visible = true;
            _viewPortControl.Visible = true;
            _bottomPaneControl.SetGameandViewport( _game, _viewPortControl );
            _leftPaneControl.SetGameandViewport( _game, _viewPortControl );
            _viewPortControl.SetMap( _game.Map, 5 * 100 );
        }
        /// <summary>
        /// Initialize Timer for the game loop
        /// </summary>
        private void InitiallizeTimer()
        {
            _timer = new Timer();
            // Timer in milliseconds 
            _timer.Interval = 20000;
            _timer.Enabled = true;
            _timer.Tick += ( s, e ) => UpdateGame();
            _timer.Start();
            _bottomPaneControl.SetTimer( _timer );
        }
        /// <summary>
        /// Initialize all building events
        /// </summary>
        private void InitialiezBuildingEvent()
        {
            IEnumerable<InfrastructureType> types = _game.InfrastructureManager.AllTypes;
            foreach( var building in types )
            {
                building.BuildingHasBeenCreated += ( s, e ) => AfterBuildAInfrastructure();
                building.BuildingHasBeenCreated += ( s, e ) => _bottomPaneControl.AverageHappyness();
            }
            _game.IsGameOverChanged += GameOver;
            _game.MoneyManager.NoMoreMoney += GameOver;
        }
        /// <summary>
        /// Initialize all mouse events
        /// </summary>
        private void MouseEvents()
        {
            _viewPortControl.MouseDown += new MouseEventHandler( MouseClickEvent );
            _viewPortControl.MouseUp += new MouseEventHandler( MouseOneClickEvent );
            _leftPaneControl.MouseWheel += new MouseEventHandler( TrayIcon_MouseWheel );
            _bottomPaneControl.MouseWheel += new MouseEventHandler( TrayIcon_MouseWheel );
            _viewPortControl.MouseWheel += new MouseEventHandler( TrayIcon_MouseWheel );
            menuControl1.MouseWheel += new MouseEventHandler( TrayIcon_MouseWheel );
        }
        /// <summary>
        /// Update the game
        /// </summary>
        private void UpdateGame()
        {
            int update = 0;
            IEnumerable<IInfrastructureForBox> infra = _game.Map.GetAllInfrastucture<IInfrastructureForBox>();
            foreach( var infrastructure in infra )
            {
                update += infrastructure.Update();
            }
            _game.MoneyManager.LastPurchase = update;
            _bottomPaneControl.AverageHappyness();
            _viewPortControl.Invalidate();
        }
        /// <summary>
        /// Event use when the mouse click was realesed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"> You need a MouseEvent </param>
        private void MouseOneClickEvent(object sender, MouseEventArgs e)
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

        /// <summary>
        /// Move on the map with the keyboard
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    _viewPortControl.ViewPort.Move(-6000, 0);
                    return true;
                case Keys.Right:
                    _viewPortControl.ViewPort.Move(6000, 0);
                    return true;
                case Keys.Up:
                    _viewPortControl.ViewPort.Move(0, -6000);
                    return true;
                case Keys.Down:
                    _viewPortControl.ViewPort.Move(0, 6000);
                    return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Move on the map with the mouse release
        /// </summary>
        /// <param name="x1"> x position for the first box </param>
        /// <param name="y1"> y position for the first box </param>
        /// <param name="x2"> x position for the second box </param>
        /// <param name="y2"> y position for the second box </param>
        private void MouseMoveOnDrag(int x1, int y1, int x2, int y2)
        {
            int xMove = x1 - x2;
            int yMove = y1 - y2;
            int MoveX = xMove * 10000;
            int MoveY = yMove * 10000;
            if( MoveX > 10000 && MoveX < -10000 ) MoveX = 0;
            if( MoveY > 10000 && MoveY < -10000 ) MoveY = 0;
            if( MoveX != 0 && MoveY != 0 ) _viewPortControl.KeyMove(MoveX, MoveY);
        }
        /// <summary>
        /// Zoom with mouse wheel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Select the box with click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Color the box 
        /// </summary>
        private void ColorSelectedBox()
        {
            foreach( var box in _game.Map.Boxes )
            {
                box.Selected = false;
            }
            _game.Map.Boxes[_xBox, _yBox].Selected = true;
            _viewPortControl.Invalidate();
        }
        /// <summary>
        /// Set the taxation with all Building
        /// </summary>
        private void AfterBuildAInfrastructure()
        {
            Habitation taxe = _game.Map.Boxes[_xBox, _yBox].Infrasructure as Habitation;
            if( taxe != null ) taxe.Taxation = _game.MoneyManager.TaxationManager.HabitationTaxation;
            Retail ctaxe = _game.Map.Boxes[_xBox, _yBox].Infrasructure as Retail;
            if( ctaxe != null ) ctaxe.Taxation = _game.MoneyManager.TaxationManager.CommerceTaxation;
            _viewPortControl.Invalidate();
        }

        /// <summary>
        /// Show the game Over
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameOver( object sender, EventArgs e )
        {
            _bottomPaneControl.Visible = false;
            _leftPaneControl.Visible = false;
            _viewPortControl.Visible = false;
            _timer.Enabled = false;
            GameOver_Label.Visible = true;
        }
    }
}
