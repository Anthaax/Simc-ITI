using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Money.Lib
{
    public class Money
    {
        int _myMoney;
        public Money()
        {
            _myMoney = 5000;
        }

        public int MyMoney
        {
            get { return _myMoney; }
            set { _myMoney = value;}
        }

        public bool CanBuid(int price)
        {
            int M = MyMoney;
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
            MyMoney = newMoney;
        }
    }
}
