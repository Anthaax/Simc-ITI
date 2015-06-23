﻿using System;
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
            _game = GameContext.CreateNewGame();
            InitializeComponent();
            _bottomPaneControl.SetGameandViewport( _game, _viewPortControl );
            _leftPaneControl.SetGameandViewport( _game, _viewPortControl );
            _viewPortControl.SetMap( _game.Map, 5 * 100 );
            scalefactor = _viewPortControl.ViewPort.ActualZoomFactor;
            _viewPortControl.MouseDown += new MouseEventHandler( MouseClickEvent );
            BuildingEvent();
            InitiallizeTimer();
        }
        private void InitiallizeTimer()
        {
            _timer = new Timer();
            _timer.Interval = 30000;
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
            IEnumerable<IInfrastructureForBox> infra = _game.Map.GetAllInfrastucture<IInfrastructureForBox>();
            foreach( var infrastructure in infra )
            {
                infrastructure.Update();
            }
            _viewPortControl.Invalidate();
        }
        private void MoveOnTheMap( object sender, KeyEventArgs e )
        {
            switch( e.KeyCode )
            {
                case Keys.Add:
                    if( scalefactor >= 0.1 )
                    {
                        scalefactor -= 0.1;
                        _viewPortControl.Zoom( scalefactor );
                        x = _viewPortControl.ViewPort.Area.X;
                        y = _viewPortControl.ViewPort.Area.Y;
                    }
                    break;
                case Keys.Subtract:
                    if( scalefactor < 1.0 )
                    {
                        scalefactor += 0.1;
                        _viewPortControl.Zoom( scalefactor );
                        x = _viewPortControl.ViewPort.Area.X;
                        y = _viewPortControl.ViewPort.Area.Y;
                    }
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