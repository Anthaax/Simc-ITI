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
    public class PoliceStation : Infrastructure, IHappynessImpact, IPulicBuilding
    {
        Bitmap _bmp;
        int _costPerMonth; 
        bool _health = true;
        public PoliceStation(Box b, PoliceStationType info)
            : base(b, info)
        {
            _bmp = b.Map.BitmapCache.Get("PoliceStation.bmp");
            _costPerMonth = info.CostPerMonth;
            CheckAllNearBoxes();
        }
        public override void Draw(Graphics g, Rectangle rectSource, float scaleFactor, Pen penColor)
        {
            Rectangle r = new Rectangle(0, 0, Box.Map.BoxWidth, Box.Map.BoxWidth);
            g.DrawImage(_bmp, r);
            g.DrawRectangle(penColor, r);
        }
        public override void OnDestroy()
        {
            _bmp.Dispose();
        }
        public override void OnCreatedAround(Box b)
        {

        }
        public override void OnDestroyingAround(Box b)
        {

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
        public int HappynessImpact(Box b)
        {
            int happyness;
            int cDistance = Math.Abs(Box.Column - b.Column);
            int lDistance = Math.Abs(Box.Line - b.Line);
            if (_health == true)
            {
                if (cDistance < 5 && lDistance < 5) happyness = 5;
                else if (cDistance < 10 && lDistance < 10) happyness = 2;
                else happyness = 1;
            }
            else
            {
                happyness = 0;
            }
            return happyness;
        }
        public int CostPerMount { get { return _costPerMonth; } set { _costPerMonth = value; } }
    }
}
