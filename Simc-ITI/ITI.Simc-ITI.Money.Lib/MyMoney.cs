using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Money.Lib
{
    public class MyMoney
    {
        int _myMoney;
        public MyMoney()
        {
            _myMoney = 5000;
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

        public bool CanBuid(int price)
        {
            int M = ActualMoney;
            if( M + 1 >= price )
            {
                BuyBuilding( price);
                return true;
            }
            return false;
        }

        private void BuyBuilding( int price )
        {
            int newMoney = _myMoney - price;
            ActualMoney = newMoney;
        }
    }
}
