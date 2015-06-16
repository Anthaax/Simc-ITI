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
    }
}
