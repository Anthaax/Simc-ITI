﻿using System;
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
            : base( "Habitation", 0, 0, "C:/dev/Textures/Habitation.bmp" )
        {
            _happyness = 50;
        }
        protected override Infrastructure DoCreateInfrastructure( Box location )
        {
                return new Habitation( location, this );
        }
        public int Happyness { get { return _happyness; } }
    }
    public class Habitation : Infrastructure, IHappyness, ITaxation
    {
        int _hapyness;
        int _salary;
        int _taxation;
        Bitmap _bmp;
        HabitationType _info;
        Box _box;

        public Habitation(Box b, HabitationType info)
            : base(b, info)
        {
            _info = info;
            _box = b;
            _box.Infrasructure = this;
            _bmp = new Bitmap(info.TexturePath);
            _hapyness = info.Happyness;
        }

        public override void Draw( Graphics g, Rectangle rectSource, float scaleFactor )
        {
            Rectangle r = new Rectangle( 0, 0, _box.Map.BoxWidth, _box.Map.BoxWidth );
            g.DrawImage( _bmp, r );
            g.DrawRectangle( Pens.DarkGreen, r );
        }
        public override void Destroy()
        {
            _box.Infrasructure = null;
            _box = null;
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
            throw new NotImplementedException();
        }
        public int Happyness { get { return _hapyness; } set { _hapyness = value; } }
        public int Taxation { get { return _taxation; } set { _taxation = value; } }
        
    }
}
