using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.Simc_ITI.Rendering
{
    public partial class LeftPaneControl : UserControl
    {
        ViewPortControl _mainViewportControl;
        static int _xBox;
        static int _yBox;
        public LeftPaneControl(ViewPortControl v)
        {
            InitializeComponent();
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

        private void Commerce_Click( object sender, EventArgs e )
        {
            _game.InfrastructureManager.Find( "Commerce" ).CreateInfrastructure( _game.Map.Boxes[_xBox, _yBox], 0 );
            _mainViewportControl.Invalidate();
            AllButtonInvisible();
        }
    }
}
