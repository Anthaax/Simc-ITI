using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITI.Simc_ITI.Build;

namespace ITI.Simc_ITI.Rendering
{
    public partial class LeftPaneControl : UserControl
    {
        ViewPortControl _mainViewportControl;
        GameContext _game;
        int _xBox;
        int _yBox;
        double scalefactor;
        int x;
        int y;
        public LeftPaneControl()
        {
            InitializeComponent();
            AllButtonInvisible();
        }
        public void SetGameandViewport(GameContext g, ViewPortControl v)
        {
            _game = g;
            _mainViewportControl = v;
        }
        private void AllButtonInvisible()
        {
            School_Button.Visible = false;
            Build_Road.Visible = false;
            HabitationBuild.Visible = false;
            Centrale_electrique.Visible = false;
            Water_Central.Visible = false;
            Commerce.Visible = false;
            Usine_Button.Visible = false;
            fireStation_button.Visible = false;
            Police.Visible = false;
        }
        private void BuildingConstructionVisible()
        {
            School_Button.Visible = true;
            Build_Road.Visible = true;
            HabitationBuild.Visible = true;
            Commerce.Visible = true;
            Usine_Button.Visible = true;
            fireStation_button.Visible = true;
            Police.Visible = true;
        }
        private void CentraleConstructionVisibile()
        {
            Centrale_electrique.Visible = true;
            Water_Central.Visible = true;
        }
        public void PositionOfTheMouse(int xbox, int ybox)
        {
            _xBox = xbox;
            _yBox = ybox;
            CanCreate();
        }
        private void BuildRoad( object sender, EventArgs e )
        {
            CustomisationBuilding RoadCustom = new CustomisationBuilding( _game.Map.Boxes[_xBox, _yBox], _game.InfrastructureManager );
            RoadCustom.Show();
            AllButtonInvisible();
            _mainViewportControl.Invalidate();
        }
        void CreateHabitation( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Habitation" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }
        private void School_Button_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Ecole" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }
        private void Centrale_electrique_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "CentraleElectrique" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }

        private void Water_Central_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "CentraleHydrolique" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }

        private void Police_Click(object sender, EventArgs e)
        {
            _game.InfrastructureManager.Find("PoliceStation").CreateInfrastructure(_game.Map.Boxes[_xBox, _yBox], 0);
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }

        private void Commerce_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Commerce" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }
        private void Usine_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Usine" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }
        private void FireStation_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Pompier" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }
        public void CanCreate()
        {
            if( _game.Map.Boxes[_xBox, _yBox].Infrasructure == null )
            {
                AllButtonInvisible();
                if( _game.InfrastructureManager.Find( "CentraleElectrique" ).CanCreatedNearRoad( _game.Map.Boxes[_xBox, _yBox] ) ) CentraleConstructionVisibile();
                if( CanCreate( "Habitation", _game.Map.Boxes[_xBox, _yBox] ) ) BuildingConstructionVisible();
                Build_Road.Visible = true;
            }
            else
            {
                AllButtonInvisible();
            }
        }
        private bool CanCreate( string building, Box b )
        {
            return _game.InfrastructureManager.Find( building ).CanCreatedNearRoad( b ) && _game.InfrastructureManager.Find( building ).CanCreated( b );
        }
        private void MoveOnTheMap( object sender, KeyEventArgs e )
        {
            switch( e.KeyCode )
            {
                case Keys.Add:
                    if( scalefactor >= 0.1 )
                    {
                        scalefactor -= 0.1;
                        _mainViewportControl.Zoom( scalefactor );
                        x = _mainViewportControl.ViewPort.Area.X;
                        y = _mainViewportControl.ViewPort.Area.Y;
                    }
                    break;
                case Keys.Subtract:
                    if( scalefactor < 1.0 )
                    {
                        scalefactor += 0.1;
                        _mainViewportControl.Zoom( scalefactor );
                        x = _mainViewportControl.ViewPort.Area.X;
                        y = _mainViewportControl.ViewPort.Area.Y;
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
            _mainViewportControl.KeyMove( x, y );
        }
    }
}
