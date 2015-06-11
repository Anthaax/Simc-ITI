using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public class MoneyManager
    {
<<<<<<< HEAD:Simc-ITI/ITI.Simc-ITI.Lib/Money/MoneyManager.cs
        int _myMoney = 0;
        TaxationManager _taxe;
        public MoneyManager()
=======
        int _myMoney;
        int _price;
        public MyMoney()
>>>>>>> origin/Devellop:Simc-ITI/ITI.Simc-ITI.Lib/MyMoney.cs
        {
            ActualMoney = 2000;
            _taxe = new TaxationManager();
        }
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
