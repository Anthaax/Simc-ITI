using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Money.Lib
{
    public class MoneyGestion
    {
        int _habitationTaxation;
        int _commerceTaxation;
        int _usineTaxation;
        public MoneyGestion()
        {
            _habitationTaxation = 10;
            _commerceTaxation = 10;
            _usineTaxation = 10;
        }
        public int HabitationTaxation { get { return _habitationTaxation; } set { _habitationTaxation = value; } }
        public int CommerceTaxation { get { return _commerceTaxation; } set { _commerceTaxation = value; } }
        public int UsineTaxation { get { return _usineTaxation; } set { _usineTaxation = value; } }
    }
}
