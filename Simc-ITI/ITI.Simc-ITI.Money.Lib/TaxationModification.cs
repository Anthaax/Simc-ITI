﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.Simc_ITI.Money.Lib
{
    public partial class TaxationModification : Form
    {
        MoneyGestion _mg;
        public TaxationModification(MoneyGestion mg)
        {
            InitializeComponent();
            _mg = mg;
            HabitationTrackBar.Value = mg.HabitationTaxation;
            CommerceTrackBar.Value = mg.CommerceTaxation;
            UsineTrackBar.Value =mg.UsineTaxation;
        }
        public void HabitationTrackBarScroll(object sender, EventArgs e)
        {
            _mg.HabitationTaxation = HabitationTrackBar.Value;
        }
        public void CommerceTrackBarScroll(object sender, EventArgs e)
        {
            _mg.CommerceTaxation = CommerceTrackBar.Value;
        }
        public void UsineTrackBarScroll( object sender, EventArgs e )
        {
            _mg.UsineTaxation = UsineTrackBar.Value;
        }
    }
}
