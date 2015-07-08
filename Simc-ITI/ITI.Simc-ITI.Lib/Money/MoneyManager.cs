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

        int _myMoney;
        int _lastPourchase = 0;
        TaxationManager _taxe;
        GameContext _ctx;
        public MoneyManager(GameContext ctx)
        {
            ActualMoney = 5000;
            _taxe = new TaxationManager();
            _ctx = ctx;
        }
        [field: NonSerialized]
        public event EventHandler ActualMoneyChanged;
        [field: NonSerialized]
        public event EventHandler NoMoreMoney;
        public int ActualMoney
        {
            get { return _myMoney; }
            set 
            {
                if( _myMoney != value )
                {
                    _myMoney = value;
                    if( _myMoney <= -100 )
                    {
                        _ctx.SetGameOver();
                        var h = NoMoreMoney;
                        if( h != null ) h( this, EventArgs.Empty );
                    }
                    var j = ActualMoneyChanged;
                    if( j != null ) j( this, EventArgs.Empty );
                }  
            }
        }
        [field : NonSerialized]
        public event EventHandler LastPurchaseWasDone;
        public int LastPurchase {
            get { return _lastPourchase; } 
            set 
            {
                if( _lastPourchase != value )
                {
                    _lastPourchase = value;
                    var h = LastPurchaseWasDone;
                    if( h != null ) h( this, EventArgs.Empty );
                } 
            } 
        }
        public TaxationManager TaxationManager { get { return _taxe; } }
    }
}
