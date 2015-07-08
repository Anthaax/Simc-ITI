using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ITI.Simc_ITI;

namespace ITI.Simc_ITI.Build
{ 
    [Serializable]
    public abstract class Infrastructure : IInfrastructureForBox
    {
        Box _box;
        InfrastructureType _type;
        protected Infrastructure(Box b, InfrastructureType i)
        {
            _box = b;
            _type = i;
            b.Infrasructure = this;
        }
        public Box Box
        {
            get { return _box; }
        }
        public GameContext GameContext
        { 
            get { return _type.GameContext; } 
        }

        public abstract void Draw( Graphics g, Rectangle rectSource, float scaleFactor, Pen penColor );
        IInfrastructureType IInfrastructureForBox.Type { get { return _type; } }
        public InfrastructureType Type { get { return _type; } }
        public abstract void OnCreatedAround( Box b );
        public abstract void OnDestroyingAround( Box b );
        public int AreaEffect { get; protected set; }
        [field: NonSerialized]
        public event EventHandler Destoyed;
        public void Destroy()
        {
            IEnumerable<Box> nearBox =  _box.NearBoxes( _box.Infrasructure.Type.AreaEffect );
            foreach( var box in nearBox)
            {
                if( box.Infrasructure != null )
                {
                    box.Infrasructure.OnDestroyingAround( _box );
                }
            }
            OnDestroy();
            _box.Infrasructure = null;
            var h = Destoyed;
            if( h != null ) h( this, EventArgs.Empty );
            _box = null;
        }
        public int Update()
        {
            int UpdateMoney = 0;
            IPulicBuilding publicBuilding = this as IPulicBuilding;
            if( publicBuilding != null )
            {
                _type.GameContext.MoneyManager.ActualMoney -= publicBuilding.CostPerMounth / 30;
                UpdateMoney = -publicBuilding.CostPerMounth / 30;
            }

            IHappyness HappynessBuilding = this as IHappyness;
            if( HappynessBuilding != null )
            {
                if( HappynessBuilding.Happyness <= 10 ) Destroy();
            }

            ITaxation privateBuilding = this as ITaxation;
            if( privateBuilding != null )
            {
                if( privateBuilding.Taxation > 15 )
                {
                    if( HappynessBuilding != null && HappynessBuilding.Happyness <= 20 )
                    {
                        HappynessBuilding.Happyness -= 2;
                    }
                    else if (HappynessBuilding != null )
                    {
                        HappynessBuilding.Happyness = 20;
                        privateBuilding.Taxation = 16;
                        privateBuilding.Salary /= 2;
                    }
                    else
                    {
                        privateBuilding.Taxation = 20;
                        privateBuilding.Salary /= 2;
                    }
                    if( _box != null )
                    {
                        ChargeBitMap();
                    }
                }
                _type.GameContext.MoneyManager.ActualMoney = _type.GameContext.MoneyManager.ActualMoney + privateBuilding.Salary * privateBuilding.Taxation / 100 / 30;
                UpdateMoney = privateBuilding.Salary * privateBuilding.Taxation / 100 / 30;
            }

            IBurn BurningBuilding = this as IBurn;
            if( BurningBuilding != null )
            {
                Random r = new Random();
                if( BurningBuilding.IsBurning == true ) this.Destroy();
                else if( r.Next( 100 ) <= BurningBuilding.BurningChance )
                {
                    BurningBuilding.IsBurning = true;
                }
            }
<<<<<<< HEAD
             return UpdateMoney;
=======
            IStolen StealingBuilding = this as IStolen;
            if(StealingBuilding != null)
            {
                Random r = new Random();
                if (StealingBuilding.IsSteal == true && StealingBuilding.IndicatorSteal == 0) StealingBuilding.IsSteal = false;
                else if (StealingBuilding.IsSteal == true) StealingBuilding.IndicatorSteal--;
                else if (r.Next(100) <= StealingBuilding.StealChance) StealingBuilding.IsSteal = true;
            }
            return UpdateMoney;
>>>>>>> origin/develop
        }
        public abstract void ChargeBitMap();
        public abstract void OnDestroy();
    }
}
