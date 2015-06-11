using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public class TaxationManager
    {
        int _habitationTaxation;
        int _commerceTaxation;
        int _usineTaxation;
        public TaxationManager()
        {
            _habitationTaxation = 10;
            _commerceTaxation = 10;
            _usineTaxation = 10;
        }
        public event EventHandler TaxationAsChanged;
        public int HabitationTaxation
        {
            get { return _habitationTaxation; }
            set
            {
                if( _habitationTaxation != value )
                {
                    _habitationTaxation = value;
                    var h = TaxationAsChanged;
                    if( h != null ) h( this, EventArgs.Empty );
                }
            }
        }
        public int CommerceTaxation
        {
            get { return _commerceTaxation; }
            set
            {
                if( _commerceTaxation != value )
                {
                    _commerceTaxation = value;
                    var h = TaxationAsChanged;
                    if( h != null ) h( this, EventArgs.Empty );
                }
            }
        }
        public int UsineTaxation
        {
            get { return _usineTaxation; }
            set
            {
                if( _usineTaxation != value )
                {
                    _usineTaxation = value;
                    var h = TaxationAsChanged;
                    if( h != null ) h( this, EventArgs.Empty );
                }
            }
        }
    }
}
