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
        public LeftPaneControl()
        {
            InitializeComponent();
            AllButtonInvisible();
        }
        public void SetGameandViewport(GameContext g, ViewPortControl v)
        {
            _game = g;
            _mainViewportControl = v;
            ChargeAllLabels();
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
            HospitalButton.Visible = false;
            CentralEPrice.Visible = false;
            CommercePrice.Visible = false;
            EauPrice.Visible = false;
            EcolePrice.Visible = false;
            HabitationPrice.Visible = false;
            HopitalPrice.Visible = false;
            PolicePrice.Visible = false;
            PompierPrice.Visible = false;
            RoadPrice.Visible = false;
            UsinePrice.Visible = false;
        }
<<<<<<< HEAD

        /// <summary>
        /// Affiche les buildings disponible
        /// </summary>
=======
>>>>>>> origin/Devellop
        private void BuildingConstructionVisible()
        {
            School_Button.Visible = true;
            Build_Road.Visible = true;
            HabitationBuild.Visible = true;
            Commerce.Visible = true;
            Usine_Button.Visible = true;
            fireStation_button.Visible = true;
            Police.Visible = true;
            HospitalButton.Visible = true;
            CommercePrice.Visible = true;
            EcolePrice.Visible = true;
            HabitationPrice.Visible = true;
            HopitalPrice.Visible = true;
            PolicePrice.Visible = true;
            PompierPrice.Visible = true;
            UsinePrice.Visible = true;
        }
        private void CentraleConstructionVisibile()
        {
            Centrale_electrique.Visible = true;
            CentralEPrice.Visible = true;
            Water_Central.Visible = true;
            EauPrice.Visible = true;
        }
<<<<<<< HEAD

        /// <summary>
        /// get the position of the mouse
        /// </summary>
        /// <param name="xbox"></param>
        /// <param name="ybox"></param>
=======
>>>>>>> origin/Devellop
        public void PositionOfTheMouse(int xbox, int ybox)
        {
            _xBox = xbox;
            _yBox = ybox;
            CanCreate();
        }
<<<<<<< HEAD

        /// <summary>
        /// Build a road
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
=======
>>>>>>> origin/Devellop
        private void BuildRoad( object sender, EventArgs e )
        {
            CustomisationBuilding RoadCustom = new CustomisationBuilding( _game.Map.Boxes[_xBox, _yBox], _game.InfrastructureManager );
            RoadCustom.Show();
            AllButtonInvisible();
            _mainViewportControl.Invalidate();
        }
<<<<<<< HEAD

        /// <summary>
        /// Build an habitation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
=======
>>>>>>> origin/Devellop
        void CreateHabitation( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Habitation" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }
<<<<<<< HEAD

        /// <summary>
        /// Build a school
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
=======
>>>>>>> origin/Devellop
        private void School_Button_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Ecole" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }
<<<<<<< HEAD

        /// <summary>
        /// Build a power station
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
=======
>>>>>>> origin/Devellop
        private void Centrale_electrique_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "CentraleElectrique" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }

<<<<<<< HEAD
        /// <summary>
        /// Build a water station
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
=======
>>>>>>> origin/Devellop
        private void Water_Central_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "CentraleHydrolique" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }

<<<<<<< HEAD
        /// <summary>
        /// Build a policestation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
=======
>>>>>>> origin/Devellop
        private void Police_Click(object sender, EventArgs e)
        {
            _game.InfrastructureManager.Find("PoliceStation").CreateInfrastructure(_game.Map.Boxes[_xBox, _yBox], 0);
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }

<<<<<<< HEAD
        /// <summary>
        /// Build a shop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
=======
>>>>>>> origin/Devellop
        private void Commerce_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Commerce" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }
<<<<<<< HEAD

        /// <summary>
        /// Build a factory
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
=======
>>>>>>> origin/Devellop
        private void Usine_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Usine" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }
<<<<<<< HEAD

        /// <summary>
        /// Build a firestation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
=======
>>>>>>> origin/Devellop
        private void FireStation_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Pompier" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }
<<<<<<< HEAD

        /// <summary>
        /// Build an hospital
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
=======
>>>>>>> origin/Devellop
        private void Hospital_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Hopital" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }
<<<<<<< HEAD

        /// <summary>
        /// Check if you can create some others building
        /// </summary>
=======
>>>>>>> origin/Devellop
        public void CanCreate()
        {
            if( _game.Map.Boxes[_xBox, _yBox].Infrasructure == null )
            {
                AllButtonInvisible();
                if( _game.InfrastructureManager.Find( "CentraleElectrique" ).CanCreatedNearRoad( _game.Map.Boxes[_xBox, _yBox] ) ) CentraleConstructionVisibile();
                if( CanCreate( "Habitation", _game.Map.Boxes[_xBox, _yBox] ) ) BuildingConstructionVisible();
                Build_Road.Visible = true;
                RoadPrice.Visible = true;
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
<<<<<<< HEAD

        /// <summary>
        /// Loading of the prices
        /// </summary>
=======
>>>>>>> origin/Devellop
        private void ChargeAllLabels()
        {
            CentralEPrice.Text = "Price : " + _game.InfrastructureManager.Find( "CentraleElectrique" ).BuildingCost;
            CommercePrice.Text = "Price : " + _game.InfrastructureManager.Find( "Commerce" ).BuildingCost;
            EauPrice.Text = "Price : " + _game.InfrastructureManager.Find( "CentraleHydrolique" ).BuildingCost;
            EcolePrice.Text = "Price : " + _game.InfrastructureManager.Find( "Ecole" ).BuildingCost;
            HabitationPrice.Text = "Price : " + _game.InfrastructureManager.Find( "Habitation" ).BuildingCost;
            HopitalPrice.Text = "Price : " + _game.InfrastructureManager.Find( "Hopital" ).BuildingCost;
            PolicePrice.Text = "Price : " + _game.InfrastructureManager.Find( "PoliceStation" ).BuildingCost;
            PompierPrice.Text = "Price : " + _game.InfrastructureManager.Find( "Pompier" ).BuildingCost;
            RoadPrice.Text = "Price : " + _game.InfrastructureManager.Find( "Route" ).BuildingCost;
            UsinePrice.Text = "Price : " + _game.InfrastructureManager.Find( "Usine" ).BuildingCost;
        }
    }
}
