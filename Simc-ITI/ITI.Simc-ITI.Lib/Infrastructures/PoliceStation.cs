using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    [Serializable]
    public class PoliceStationType : InfrastructureType
    {
        int _costPerMonth;
        public PoliceStationType(GameContext ctx)
            : base(ctx, "PoliceStation", 1000, 10)
        {
            _costPerMonth = 600;
        }
        protected override Infrastructure DoCreateInfrastructure(Box location, object creationConfig)
        {
            return new PoliceStation(location, this);
        }
        public int CostPerMonth { get { return _costPerMonth; } }
    }
    [Serializable]
    public class PoliceStation : Infrastructure, IPulicBuilding, IStealImpact
    {
        [field: NonSerialized]
        Bitmap _bmp;
        int _costPerMonth; 
        public PoliceStation(Box b, PoliceStationType info)
            : base(b, info)
        {
            _bmp = b.Map.BitmapCache.Get("PoliceStation.bmp");
            _costPerMonth = info.CostPerMonth;
            CheckAllNearBoxes();

        }
        public override void Draw(Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle(0, 0, Box.Map.BoxWidth + 400, Box.Map.BoxWidth + 400);
            g.DrawImage(_bmp, r);
            if( Box.Selected == true )
            {
                g.DrawRectangle( Pens.Red, new Rectangle( 0, 0, Box.Map.BoxWidth - 400, Box.Map.BoxWidth - 400 ) );
            }
        }
        public override void OnDestroy()
        {
            _bmp = null;
        }
        public override void OnCreatedAround(Box b)
        {

        }
        public override void OnDestroyingAround(Box b)
        {

        }
        public override void ChargeBitMap()
        {
            _bmp = Box.Map.BitmapCache.Get( "PoliceStation.bmp" );
        }
        public void CheckAllNearBoxes()
        {
            IEnumerable<Box> nearBox = Box.NearBoxes(Box.Map.BoxCount);
            foreach (var box in nearBox)
            {
                if (box.Infrasructure != null)
                {
                    if (box.Line - box.Infrasructure.Type.AreaEffect <= Box.Line || box.Line + box.Infrasructure.Type.AreaEffect >= Box.Line || box.Column - box.Infrasructure.Type.AreaEffect <= Box.Column || box.Column + box.Infrasructure.Type.AreaEffect >= Box.Column)
                    {
                        OnCreatedAround(box);
                    }
                }
            }
        }
        public int StealChanceImpact(Box b)
        {
            int _stealrate;
            int cDistance = Math.Abs(Box.Column - b.Column);
            int lDistance = Math.Abs(Box.Line - b.Line);
            if (cDistance < 5 && lDistance < 5) _stealrate = 70;
            else _stealrate = 60;
            return _stealrate;
        }
        public int CostPerMounth { get { return _costPerMonth; } set { _costPerMonth = value; } }
    }
}
