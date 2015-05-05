using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.Map2D.Rendering
{
    public partial class DemoWindow2 : Form
    {
        Map _map;
      

        public DemoWindow2()
        {
            _map = new Map(100, 100);
            InitializeComponent();
            _mainViewPortControl.SetMap(_map, 5 * 100);
            
        }      
    }
}