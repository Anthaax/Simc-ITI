using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.Simc_ITI.Rendering
{
    public partial class DemoWindow2 : Form
    {
        Map _map;
        double scalefactor = 1.0;

        public DemoWindow2()
        {
            _map = new Map( 100,100 );
            InitializeComponent();
            _mainViewPortControl.SetMap( _map, 5 * 100 );
            _map.Money.ActualMoneyChanged += label_MonArgent_text;
        }

        private void buton_Grass_Click( object sender, EventArgs e )
        {
            _map.Boxes[25, 25].CreateInfrastructure( 50, 0, 5, true, true, true, true, "RC" );
            _mainViewPortControl.SetMap( _map, 5 * 100 );
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
                    if( scalefactor >= 0.1 ) scalefactor -= 0.1;
                    break;
                case Keys.Subtract:
                    if( scalefactor < 1.0 ) scalefactor += 0.1;
                    break;

                //Keys.OemMinus
            }
            _mainViewPortControl.Zoom( scalefactor );
        }
    }
}
