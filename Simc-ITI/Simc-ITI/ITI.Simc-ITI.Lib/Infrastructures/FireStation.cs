using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    [Serializable]
    public class FireStationType : InfrastructureType
    {
        int _costPerMonth;
        public FireStationType(GameContext ctx)
            : base(ctx, "Pompier", 1000, 10)
        {
            _costPerMonth = 1000;
        }
        public int CostPerMounth { get { return _costPerMonth; } set { _costPerMonth = value; } }
        protected override Infrastructure DoCreateInfrastructure( Box location, object creationConfig )
        {
            return new FireStation( location, this );
        }
    }
    [Serializable]
    public class FireStation : Infrastructure, IBurnImpact, IPulicBuilding
    {
        int _costPerMonth;
        [field: NonSerialized]
        Bitmap _bmp;
        public FireStation(Box b, FireStationType info)
            :base(b, info)
        {
            _bmp = b.Map.BitmapCache.Get( "Pompier.bmp" );
            _costPerMonth = info.CostPerMounth;
            CheckAllNearBoxes();
        }
        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle( 0, 0, Box.Map.BoxWidth, Box.Map.BoxWidth );
            g.DrawImage( _bmp, r );
            if( Box.Selected == true )
            {
                g.DrawRectangle( Pens.Red, new Rectangle( 0, 0, Box.Map.BoxWidth - 400, Box.Map.BoxWidth - 400 ) );
            }
        }
        public override void OnDestroy()
        {
            _bmp = null;
        }
        public override void OnCreatedAround( Box b )
        {

        }
        public override void OnDestroyingAround( Box b )
        {

        }
        public void CheckAllNearBoxes()
        {
            IEnumerable<Box> nearBox = Box.NearBoxes( Box.Map.BoxCount );
            foreach( var box in nearBox )
            {
                if( box.Infrasructure != null )
                {
                    if( box.Line - box.Infrasructure.Type.AreaEffect <= Box.Line || box.Line + box.Infrasructure.Type.AreaEffect >= Box.Line || box.Column - box.Infrasructure.Type.AreaEffect <= Box.Column || box.Column + box.Infrasructure.Type.AreaEffect >= Box.Column )
                    {
                        OnCreatedAround( box );
                    }
                }
            }
        }
        public int FireChanceImpact(Box b)
        {
            int _firerate;
            int cDistance = Math.Abs( Box.Column - b.Column );
            int lDistance = Math.Abs( Box.Line - b.Line );
            if( cDistance < 5 && lDistance < 5 ) _firerate = 70;
            else _firerate = 60;
            return _firerate;
        }
        public int CostPerMounth { get { return _costPerMonth; } set { _costPerMonth = value; } }
        public override void ChargeBitMap()
        {
            _bmp = Box.Map.BitmapCache.Get( "Pompier.bmp" );
        }
    }
}
