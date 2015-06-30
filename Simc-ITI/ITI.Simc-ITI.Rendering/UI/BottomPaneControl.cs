﻿using System;
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
    public partial class BottomPaneControl : UserControl
    {
        Timer _timer;
        GameContext _game;
        ViewPortControl _mainViewportControl;
        int _xBox;
        int _yBox;
        public BottomPaneControl()
        {
            InitializeComponent();
        }
        public void SetGameandViewport( GameContext g, ViewPortControl v )
        {
            _game = g;
            _mainViewportControl = v;
            AllEvent();
        }
        public void AllEvent()
        {
            MyMoney.Text = " Mon Argent : " + _game.MoneyManager.ActualMoney.ToString();
            _game.MoneyManager.ActualMoneyChanged += label_MonArgent_text;
        }
        public void SetTimer(Timer t)
        {
            _timer = t;
        }
        public void AllTextOrButtonInvisible()
        {
            Button_Destroy.Visible = false;
            Kind_Building.Visible = false;
            Burn_button.Visible = false;
            SaveLabel.Visible = false;
        }
        public void pause_button_Click( object sender, EventArgs e )
        {
            if( _timer.Enabled != false )
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
        public void fastforward_button_Click( object sender, EventArgs e )
        {
            if( _timer.Interval == 30000 )
            {
                _timer.Interval = _timer.Interval / 2;
                fastforward_button.Text = "annuler";
            }
            else if( _timer.Interval < 30000 )
            {
                _timer.Interval = 30000;
                fastforward_button.Text = ">>";
            }
        }
        public void rewind_button_Click( object sender, EventArgs e )
        {
            if( _timer.Interval == 30000 )
            {
                _timer.Interval = _timer.Interval * 2;
                rewind_button.Text = "annuler";
            }
            else if( _timer.Interval > 30000 )
            {
                _timer.Interval = 30000;
                rewind_button.Text = "<<";
            }
        }
        public void RenderingWithClickEvent(int xbox, int ybox)
        {
            _xBox = xbox;
            _yBox = ybox;
            AllTextOrButtonInvisible();
            if( _game.Map.Boxes[_xBox, _yBox].Infrasructure != null)
            {
                Kind_Building.Visible = true;
                Kind_Building.Text = "Type du batiment : Une " + _game.Map.Boxes[_xBox, _yBox].Infrasructure.Type.Name + ".";
                if( _game.Map.Boxes[_xBox, _yBox].Infrasructure.Type.Name == "CentraleHydrolique" || _game.Map.Boxes[_xBox, _yBox].Infrasructure.Type.Name == "CentraleElectrique" )
                {
                    Button_Destroy.Visible = false;
                }
                else if( _game.InfrastructureManager.Find( _game.Map.Boxes[_xBox, _yBox].Infrasructure.Type.Name ).CanDestroy( _game.Map.Boxes[_xBox, _yBox] ) == true ) Button_Destroy.Visible = true;
                IBurn BurningBuilding = _game.Map.Boxes[_xBox, _yBox].Infrasructure as IBurn;
                if( BurningBuilding != null )
                {
                    if( BurningBuilding.IsBurning == true )
                    {
                        IEnumerable<Box> nearBox = _game.Map.Boxes[_xBox, _yBox].NearBoxes( _game.InfrastructureManager.Find( "Pompier" ).AreaEffect );
                        foreach( var box in nearBox )
                        {
                            if( box.Infrasructure != null )
                            {
                                if( box.Infrasructure.Type.Name == "Pompier" )
                                {
                                    Burn_button.Visible = true;
                                }
                            }
                        }
                    }
                }
            }
            Coordonnées.Visible = true;
            Coordonnées.Text = "Coordonnées : " + _xBox + " , " + _yBox;
        }
        private void OpenMoneyGestion( object sender, EventArgs e)
        {
            TaxationModification Taxes = new TaxationModification( _game.MoneyManager.TaxationManager );
            Taxes.Show();
        }
        private void label_MonArgent_text( object sender, EventArgs e )
        {
            MyMoney.Text =" Mon Argent :" + _game.MoneyManager.ActualMoney.ToString();
        }
        private void Button_Destroy_Click( object sender, EventArgs e )
        {
            _game.MoneyManager.ActualMoney += _game.Map.Boxes[_xBox, _yBox].Infrasructure.Type.BuildingCost / 2;
            _game.Map.Boxes[_xBox, _yBox].Infrasructure.Destroy();
            AverageHappyness();
            AllTextOrButtonInvisible();
            _mainViewportControl.Invalidate();
        }
        private void Burn_Off( object sender, EventArgs e )
        {
            IBurn BurningBuilding = _game.Map.Boxes[_xBox, _yBox].Infrasructure as IBurn;
            if( BurningBuilding != null )
            {
                BurningBuilding.IsBurning = false;
            }
            _mainViewportControl.Invalidate();
            AllTextOrButtonInvisible();
        }
        public void AverageHappyness()
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
        public void TaxationWasChanged()
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
        private void SaveTheGame( object sender, EventArgs e )
        {
            string path = @"D:\Documents\Simc_ITI Sauvergardes\Sav1.txt";
            _game.Save( path );
            SaveLabel.Visible = true;
        }
    }
}
