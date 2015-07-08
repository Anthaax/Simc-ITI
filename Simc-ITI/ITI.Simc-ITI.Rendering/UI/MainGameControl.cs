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
    public partial class MainGameControl : UserControl
    {
        GameContext _game;
        public MainGameControl()
        {
            InitializeComponent();
        }
        public void SetGame( GameContext g )
        {
            _game = g;
        }
    }
}
