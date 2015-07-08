using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.Simc_ITI.Build
{
    public partial class TaxationModification : Form
    {
        TaxationManager _taxe;
        public TaxationModification( TaxationManager taxe )
        {
            InitializeComponent();
            _taxe = taxe;
            HabitationTrackBar.Value = taxe.HabitationTaxation;
            CommerceTrackBar.Value = taxe.CommerceTaxation;
            UsineTrackBar.Value = taxe.UsineTaxation;
            AjustLabel();
        }
        public void HabitationTrackBarScroll( object sender, EventArgs e )
        {
            _taxe.HabitationTaxation = HabitationTrackBar.Value;
            AjustLabel();
        }
        public void CommerceTrackBarScroll( object sender, EventArgs e )
        {
            _taxe.CommerceTaxation = CommerceTrackBar.Value;
            AjustLabel();
        }
        public void UsineTrackBarScroll( object sender, EventArgs e )
        {
            _taxe.UsineTaxation = UsineTrackBar.Value;
            AjustLabel();
        }
        public void AjustLabel()
        {
            HabitationPorcent.Text = HabitationTrackBar.Value + "%";
            CommercePorcent.Text = CommerceTrackBar.Value + "%";
            UsinePercent.Text = UsineTrackBar.Value + "%";
        }

        private void CloseButton_Click( object sender, EventArgs e )
        {
            Close();
        }
    }
}
