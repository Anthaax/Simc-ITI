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
using ITI.Simc_ITI.Money.Lib;

namespace ITI.Simc_ITI.Rendering
{
    public partial class DemoWindow2 : Form
    {
        Map _map;
        InfrastructureManager _infManager;
        MoneyGestion _mg;
        Timer t;
        double scalefactor;
        int x;
        int y;
        int _xBox;
        int _yBox;

        public DemoWindow2()
        {
            _map = new Map( 100, 100 );
            _infManager = new InfrastructureManager();
            _mg = new MoneyGestion();
            InitializeComponent();
            _mainViewPortControl.SetMap( _map, 5 * 100 );
            scalefactor = _mainViewPortControl.ViewPort.ActualZoomFactor;
            InitiallizeTimer();
            AllButtonInvisible();
            InitializeAllEvents();
            BuildingEvent();
        }
        private void InitiallizeTimer()
        {
            t = new Timer();
            t.Interval = 30000;
            t.Enabled = true;
            t.Tick += UpdateGame;
            t.Start();
        }
        private void AllButtonInvisible()
        {
            Button_Destroy.Visible = false;
            School_Button.Visible = false;
            Build_Road.Visible = false;
            Kind_Building.Visible = false;
            HabitationBuild.Visible = false;
        }
        private void AllButtonVisible()
        {
            School_Button.Visible = true;
            Build_Road.Visible = true;
            HabitationBuild.Visible = true;
        }
        private void BuildingEvent()
        {
            IEnumerable<InfrastructureType> types = _infManager.AllTypes;
            foreach( var building in types )
            {
<<<<<<< HEAD
                building.BuildingHasBeenCreated += ( s, e ) => AfterBuildAInfrastructure();
                building.BuildingHasBeenCreated += (s, e) => AverageHappyness();
=======
                building.BuildingHasBeenCreated += ( s, e) => AfterBuildAInfrastructure();
                building.BuildingHasBeenCreated += ( s, e) => AverageHappyness();
>>>>>>> origin/Devellop
            }
        }

        private void InitializeAllEvents()
        {
            _map.Money.ActualMoneyChanged += label_MonArgent_text;
            _mainViewPortControl.MouseDown += new MouseEventHandler( MouseClickEvent );
            _mg.TaxationAsChanged += TaxationWasChanged;

        }
        private void UpdateGame( object sender, EventArgs e )
        {
            IEnumerable<IInfrastructureForBox> infra = _map.GetAllInfrastucture<IInfrastructureForBox>();
            foreach( var infrastructure in infra)
            {
                infrastructure.Update();
            }
        }

        private void buton_Grass_Click( object sender, EventArgs e )
        {
            CustomisationBuilding RoadCustom = new CustomisationBuilding( _map.Boxes[_xBox, _yBox], _infManager );
            RoadCustom.Show();
            AllButtonInvisible();
        }

        void CreateHabitation(object sender , EventArgs e )
        {
            _infManager.Find( "Habitation" ).CreateInfrastructure( _map.Boxes[_xBox, _yBox], 0 );
            _mainViewPortControl.Invalidate();
            AllButtonInvisible();
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
            }
            _mainViewPortControl.KeyMove(x, y);
        }
        private void MousePosition(MouseEventArgs e)
        {
            int _boxInPixel = (int)Math.Round( _map.BoxWidth * _mainViewPortControl.ViewPort.ClientScaleFactor );
            int _mouseX = e.X;
            int _mouseY = e.Y;
            _xBox = Math.Min( (_mainViewPortControl.ViewPort.Area.X / _map.BoxWidth) + _mouseX / _boxInPixel, _map.BoxCount );
            _yBox = Math.Min( (_mainViewPortControl.ViewPort.Area.Y / _map.BoxWidth) + _mouseY / _boxInPixel, _map.BoxCount );
        }
        private void MouseClickEvent(object sender, MouseEventArgs e)
        {
            MousePosition( e );
            if( _map.Boxes[_xBox, _yBox].Infrasructure == null)
            {
                AllButtonInvisible();
                if( _infManager.Find("Habitation").CanCreatedNormal(_map.Boxes[_xBox, _yBox]) == true ) AllButtonVisible();
                Build_Road.Visible = true;
            }
            else
            {
                AllButtonInvisible();
                Kind_Building.Visible = true;
                Kind_Building.Text = "Type du batiment : Une " + _map.Boxes[_xBox, _yBox].Infrasructure.Type.Name + ".";
                if( _infManager.Find( _map.Boxes[_xBox, _yBox].Infrasructure.Type.Name ).CanDestroy( _map.Boxes[_xBox, _yBox] ) == false ) Button_Destroy.Visible = true;
            }
            Coordonnées.Visible = true;
            Coordonnées.Text = "Coordonnées : " + _xBox + " , " + _yBox;
        }

        private void School_Button_Click( object sender, EventArgs e )
        {
            _infManager.Find( "Ecole" ).CreateInfrastructure( _map.Boxes[_xBox, _yBox], 0 );
            _mainViewPortControl.Invalidate();
            AllButtonInvisible();
        }

        private void Button_Destroy_Click( object sender, EventArgs e )
        {
            _map.Money.ActualMoney += _map.Boxes[_xBox, _yBox].Infrasructure.Type.BuildingCost / 2;
            _map.Boxes[_xBox, _yBox].Infrasructure.Destroy();
            AverageHappyness();
            AllButtonInvisible();
            _mainViewPortControl.Invalidate();
        }
        private void OpenMoneyGestion( object sender, EventArgs e )
        {
            TaxationModification Taxes = new TaxationModification(_mg);
            Taxes.Show();
        }
        private void TaxationWasChanged( object sender, EventArgs e )
        {
            IEnumerable<Habitation> habitation = _map.GetAllInfrastucture<Habitation>();
            foreach( var hab in habitation )
            {
                hab.Taxation = _mg.HabitationTaxation;
            }
            IEnumerable<Commerce> commerce = _map.GetAllInfrastucture<Commerce>();
            foreach( var co in commerce )
            {
                co.Taxation = _mg.CommerceTaxation;
            }
        }
<<<<<<< HEAD
=======

       
>>>>>>> origin/Devellop
        private void AverageHappyness()
        {
            int totalHappyness = 0;
            IEnumerable<IHappyness> happy = _map.GetAllInfrastucture<IHappyness>();
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
            Habitation taxe = _map.Boxes[_xBox, _yBox].Infrasructure as Habitation;
            if( taxe != null ) taxe.Taxation = _mg.HabitationTaxation;
            Commerce ctaxe = _map.Boxes[_xBox, _yBox].Infrasructure as Commerce;
            if( ctaxe != null ) ctaxe.Taxation = _mg.CommerceTaxation;
            _mainViewPortControl.Invalidate();
        }

        private void MoneyGestionOpen_Click( object sender, EventArgs e )
        {
            TaxationModification tx = new TaxationModification(_mg);
            tx.Show();
        }

        private void pause_button_Click(object sender, EventArgs e)
        {
            if (t.Enabled != false)
            {
                t.Enabled = false;
                pause_button.Text = "Play";
            }
            else
            {
                t.Enabled = true;
                pause_button.Text = "Pause";
            }
        }

        private void fastforward_button_Click(object sender, EventArgs e)
        {
            if (t.Interval == 30000)
            {
                t.Interval = t.Interval / 2;
                fastforward_button.Text = "annuler";
            }
            else if(t.Interval < 30000)
            {
                t.Interval = 30000;
                fastforward_button.Text = ">>";
            }
        }

        private void rewind_button_Click(object sender, EventArgs e)
        {
            if (t.Interval == 30000)
            {
                t.Interval = t.Interval * 2;
                rewind_button.Text = "annuler";
            }
            else if (t.Interval > 30000)
            {
                t.Interval = 30000;
                rewind_button.Text = "<<";
            }
        }
    }
}