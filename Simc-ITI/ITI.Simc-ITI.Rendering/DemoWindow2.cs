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


        public DemoWindow2()
        {
            _map = new Map( 100, 25 );
            InitializeComponent();
            _mainViewPortControl.SetMap( _map, 5 * 100 );
            MonArgent.Text += _map.MyMoney().ToString();
        }

        private void buton_Grass_Click( object sender, EventArgs e )
        {
            _map.Boxes[0, 0].CreateInfrastructure( 50, 0, 5, true, true, true, true, "RC" );
            _mainViewPortControl.SetMap( _map, 5 * 100 );
            MonArgent.Text = _map.MyMoney().ToString();
        }
  
        private void label_MonArgent_text( object sender, EventArgs e)
        {
            MonArgent.Text = _map.MyMoney().ToString();
        }
    }
}
