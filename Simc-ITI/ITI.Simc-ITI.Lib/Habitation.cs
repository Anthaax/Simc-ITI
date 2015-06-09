using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ITI.Simc_ITI.Build
{
    public class HabitationType : InfrastructureType
    {
        int _happyness;
        public HabitationType()
            : base( "Habitation", 0, 0)
        {
            _happyness = 50;
        }
        protected override Infrastructure DoCreateInfrastructure( Box location, object creationConfig )
        {
                return new Habitation( location, this );
        }
        public int Happyness { get { return _happyness; } }
    }
    public class Habitation : Infrastructure, IHappyness, ITaxation
    {
        int _hapyness;
        int _salary = 15000;
        int _taxation = 10;
        Bitmap _bmp;


        public Habitation(Box b, HabitationType info)
            : base(b, info)
        {
            _bmp = b.Map.Texture.Get("Habitation.bmp");
            _hapyness = info.Happyness;
            CheckAllNearBoxes();
        }

        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle( 0, 0, Box.Map.BoxWidth, Box.Map.BoxWidth );
            g.DrawImage( _bmp, r );
            g.DrawRectangle( Pens.DarkGreen, r );
        }
        public override void OnDestroy()
        {
            _bmp.Dispose();
        }
        public override void OnCreatedAround( Box b )
        {
            IHappynessImpact impact = b.Infrasructure as IHappynessImpact;
            if( impact != null )
            {
                Happyness += impact.HappynessImpact;
            }
        }
        public override void OnDestroyingAround( Box b )
        {
            IHappynessImpact impact = b.Infrasructure as IHappynessImpact;
            if( impact != null )
            {
                Happyness -= impact.HappynessImpact;
            }
        }
        public int Happyness { get { return _hapyness; } set { _hapyness = value; } }
        public int Taxation { get { return _taxation; } set { _taxation = value; } }
        public int Salary { get { return _salary; } }
        public void CheckAllNearBoxes()
        {
            IEnumerable<Box> nearBox = Box.NearBoxes( 10 );
            foreach( var box in nearBox)
            {
                if( box.Infrasructure != null )
                {
                    OnCreatedAround( box );
                }
            }
        }
    }
}
