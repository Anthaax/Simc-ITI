using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.Simc_ITI.Build
{
    public partial class CustomisationBuilding : Form
    {
        Box _box;
        InfrastructureManager _infraManager;

        public CustomisationBuilding( Box b, InfrastructureManager inf )
        {
            InitializeComponent();
            _box = b;
            _infraManager = inf;
        }
        private void TypeValidation_Click( object sender, EventArgs e )
        {
            RoadCreationConfig cfg = new RoadCreationConfig();

            if (v1.Checked)
            {
                RoadOrientation type = (RoadOrientation)1;
                cfg.Orientation = type;
            }
            if (v2.Checked)
            {
                RoadOrientation type = (RoadOrientation)2;
                cfg.Orientation = type;
            }
            if (v3.Checked)
            {
                RoadOrientation type = (RoadOrientation)3;
                cfg.Orientation = type;
            }
            if (v4.Checked)
            {
                RoadOrientation type = (RoadOrientation)4;
                cfg.Orientation = type;
            }
            if (v5.Checked)
            {
                RoadOrientation type = (RoadOrientation)5;
                cfg.Orientation = type;
            }
            if (v6.Checked)
            {
                RoadOrientation type = (RoadOrientation)6;
                cfg.Orientation = type;
            }
            if (v7.Checked)
            {
                RoadOrientation type = (RoadOrientation)7;
                cfg.Orientation = type;
            }
            if (v8.Checked)
            {
                RoadOrientation type = (RoadOrientation)8;
                cfg.Orientation = type;
            }
            if (v9.Checked)
            {
                RoadOrientation type = (RoadOrientation)9;
                cfg.Orientation = type;
            }
            if (v10.Checked)
            {
                RoadOrientation type = (RoadOrientation)10;
                cfg.Orientation = type;
            }
            if (v11.Checked)
            {
                RoadOrientation type = (RoadOrientation)11;
                cfg.Orientation = type;
            }
            this.Close();
            _infraManager.Find( "Route" ).CreateInfrastructure( _box, cfg );
        }
    }
}
