using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    [Serializable]
    public class MoneyManager
    {

        int _myMoney = 0;
        TaxationManager _taxe;
        public MoneyManager()
        {
            ActualMoney = 4000;
            _taxe = new TaxationManager();
        }
        [field: NonSerialized]
        public event EventHandler ActualMoneyChanged;
        public int ActualMoney
        {
            get { return _myMoney; }
            set 
            {
                if( _myMoney != value )
                {
                    _myMoney = value;
                    var h = ActualMoneyChanged;
                    if( h != null ) h( this, EventArgs.Empty );
                }
            }
        }
        public TaxationManager TaxationManager { get { return _taxe; } }
    }
}
