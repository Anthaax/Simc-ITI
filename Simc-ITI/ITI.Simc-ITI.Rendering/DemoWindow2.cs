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
        Timer _timer;
        GameContext _game;
        double scalefactor;
        int x;
        int y;
        static int _xBox;
        static int _yBox;

        public DemoWindow2()
        {
            _game = GameContext.CreateNewGame();
            InitializeComponent();
            _mainViewPortControl.SetMap( _game.Map , 5 * 100 );
            scalefactor = _mainViewPortControl.ViewPort.ActualZoomFactor;
            MonArgent.Text = _game.MoneyManager.ActualMoney.ToString();
            InitiallizeTimer();
            AllButtonInvisible();
            InitializeAllEvents();
            BuildingEvent();
        }
        private void InitiallizeTimer()
        {
            _timer = new Timer();
            _timer.Interval = 30000;
            _timer.Enabled = true;
            _timer.Tick += UpdateGame;
            _timer.Start();
        }
        private void AllButtonInvisible()
        {
            Button_Destroy.Visible = false;
            School_Button.Visible = false;
            Build_Road.Visible = false;
            Kind_Building.Visible = false;
            HabitationBuild.Visible = false;
            Centrale_electrique.Visible = false;
            Water_Central.Visible = false;
            Commerce.Visible = false;
        }
        private void BuildingConstructionVisible()
        {
            School_Button.Visible = true;
            Build_Road.Visible = true;
            HabitationBuild.Visible = true;
            Commerce.Visible = true;
            HumeurLabel.Visible = true;
        }
        private void CentraleConstructionVisibile()
        {
            Centrale_electrique.Visible = true;
            Water_Central.Visible = true;
        }
        private void BuildingEvent()
        {
            IEnumerable<InfrastructureType> types = _game.InfrastructureManager.AllTypes;
            foreach( var building in types )
            {
                building.BuildingHasBeenCreated += ( s, e) => AfterBuildAInfrastructure();
                building.BuildingHasBeenCreated += ( s, e) => AverageHappyness();
            }
        }

        private void InitializeAllEvents()
        {
            _game.MoneyManager.ActualMoneyChanged += label_MonArgent_text;
            _mainViewPortControl.MouseDown += new MouseEventHandler( MouseClickEvent );
            _game.MoneyManager.TaxationManager.TaxationAsChanged += TaxationWasChanged;

        }
        private void UpdateGame( object sender, EventArgs e )
        {
            IEnumerable<IInfrastructureForBox> infra = _game.Map.GetAllInfrastucture<IInfrastructureForBox>();
            foreach( var infrastructure in infra)
            {
                infrastructure.Update();
            }
        }

        private void buton_Grass_Click( object sender, EventArgs e )
        {
            CustomisationBuilding RoadCustom = new CustomisationBuilding( _game.Map.Boxes[_xBox, _yBox], _game.InfrastructureManager );
            RoadCustom.Show();
            AllButtonInvisible();
        }

        void CreateHabitation(object sender , EventArgs e )
        {
            _game.InfrastructureManager.Find( "Habitation" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewPortControl.Invalidate();
            AllButtonInvisible();
        }
  
        private void label_MonArgent_text( object sender, EventArgs e)
        {
            MonArgent.Text = _game.MoneyManager.ActualMoney.ToString();
        }

        //private void label_LastCost_text(object sender, EventArgs e)
        //{
        //    LastCost.Text = ;
        //}

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
            }
            _mainViewPortControl.KeyMove(x, y);
        }
        private void MousePosition(MouseEventArgs e)
        {
            int _boxInPixel = (int)Math.Round( _game.Map.BoxWidth * _mainViewPortControl.ViewPort.ClientScaleFactor );
            int _mouseX = e.X;
            int _mouseY = e.Y;
            _xBox = Math.Min( (_mainViewPortControl.ViewPort.Area.X / _game.Map.BoxWidth) + _mouseX / _boxInPixel, _game.Map.BoxCount );
            _yBox = Math.Min( (_mainViewPortControl.ViewPort.Area.Y / _game.Map.BoxWidth) + _mouseY / _boxInPixel, _game.Map.BoxCount );
        }
        private void MouseClickEvent(object sender, MouseEventArgs e)
        {
            MousePosition( e );
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
                Kind_Building.Visible = true;
                Kind_Building.Text = "Type du batiment : Une " + _game.Map.Boxes[_xBox, _yBox].Infrasructure.Type.Name + ".";
                if( _game.InfrastructureManager.Find( _game.Map.Boxes[_xBox, _yBox].Infrasructure.Type.Name ).CanDestroy( _game.Map.Boxes[_xBox, _yBox] ) == false ) Button_Destroy.Visible = true;
            }
            Coordonnées.Visible = true;
            Coordonnées.Text = "Coordonnées : " + _xBox + " , " + _yBox;
        }

        private void School_Button_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Ecole" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewPortControl.Invalidate();
            AllButtonInvisible();
        }
        
        private void Button_Destroy_Click( object sender, EventArgs e )
        {
            _game.MoneyManager.ActualMoney += _game.Map.Boxes[_xBox, _yBox].Infrasructure.Type.BuildingCost / 2;
            _game.Map.Boxes[_xBox, _yBox].Infrasructure.Destroy();
            AverageHappyness();
            AllButtonInvisible();
            _mainViewPortControl.Invalidate();
        }
        private void OpenMoneyGestion( object sender, EventArgs e )
        {
            TaxationModification Taxes = new TaxationModification( _game.MoneyManager.TaxationManager);
            Taxes.Show();
        }
        private void TaxationWasChanged( object sender, EventArgs e )
        {
            IEnumerable<Habitation> habitation = _game.Map.GetAllInfrastucture<Habitation>();
            foreach( var hab in habitation )
            {
                hab.Taxation = _game.MoneyManager.TaxationManager.HabitationTaxation;
            }
            IEnumerable<Retail> commerce = _game.Map.GetAllInfrastucture<Retail>();
            foreach( var co in commerce )
            {
                co.Taxation = _game.MoneyManager.TaxationManager.CommerceTaxation;
            }
        }
        private void AverageHappyness()
        {
            int totalHappyness = 0;
            IEnumerable<IHappyness> happy = _game.Map.GetAllInfrastucture<IHappyness>();
            if( happy.FirstOrDefault<IHappyness>() == null ) totalHappyness = 50;
            else
            {
                foreach( var happyness in happy )
                {
                    totalHappyness += happyness.Happyness;
                }
                totalHappyness = totalHappyness / happy.Count<IHappyness>();
                HumeurLabel.Text = "Humeur : " + totalHappyness + "%";
            }
        }
        private void AfterBuildAInfrastructure()
        {
            Habitation taxe = _game.Map.Boxes[_xBox, _yBox].Infrasructure as Habitation;
            if( taxe != null ) taxe.Taxation = _game.MoneyManager.TaxationManager.HabitationTaxation;
            Retail ctaxe = _game.Map.Boxes[_xBox, _yBox].Infrasructure as Retail;
            if( ctaxe != null ) ctaxe.Taxation = _game.MoneyManager.TaxationManager.CommerceTaxation;
            _mainViewPortControl.Invalidate();
        }

        private void pause_button_Click(object sender, EventArgs e)
        {
            if (_timer.Enabled != false)
            {
                _timer.Enabled = false;
                pause_button.Text = "Play";
            }
            else
            {
                _timer.Enabled = true;
                pause_button.Text = "Pause";
            }
        }

        private void fastforward_button_Click(object sender, EventArgs e)
        {
            if (_timer.Interval == 30000)
            {
                _timer.Interval = _timer.Interval / 2;
                fastforward_button.Text = "annuler";
            }
            else if(_timer.Interval < 30000)
            {
                _timer.Interval = 30000;
                fastforward_button.Text = ">>";
            }
        }

        private void rewind_button_Click(object sender, EventArgs e)
        {
            if (_timer.Interval == 30000)
            {
                _timer.Interval = _timer.Interval * 2;
                rewind_button.Text = "annuler";
            }
            else if (_timer.Interval > 30000)
            {
                _timer.Interval = 30000;
                rewind_button.Text = "<<";
            }
        }
        private bool CanCreate(string building, Box b)
        {
            return _game.InfrastructureManager.Find( building ).CanCreatedNearRoad( b ) && _game.InfrastructureManager.Find( building ).CanCreated( b );
        }

        private void Centrale_electrique_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "CentraleElectrique" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewPortControl.Invalidate();
            AllButtonInvisible();
        }

        private void Water_Central_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "CentraleHydrolique" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewPortControl.Invalidate();
            AllButtonInvisible();
        }

        private void Commerce_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Commerce" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewPortControl.Invalidate();
            AllButtonInvisible();
        }
    }
}
