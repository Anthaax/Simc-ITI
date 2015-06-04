﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ITI.Simc_ITI.Money.Lib;
using ITI.Simc_ITI;

namespace ITI.Simc_ITI.Build
{
    public abstract class Infrastructure : IInfrastructureForBox
    {
        Box _box;
        InfrastructureType _info;
        protected Infrastructure(Box b, InfrastructureType i)
        {
            _box = b;
            _info = i;
            b.Infrasructure = this;
        }
        public Box Box
        {
            get { return _box; }
        }
        public abstract void Draw( Graphics g, Rectangle rectSource, float scaleFactor );
        IInfrastructureType IInfrastructureForBox.Type { get { return _info; } }
        public InfrastructureType Type { get { return _info; } }
        public abstract void OnCreatedAround( Box b );
        public abstract void OnDestroyingAround( Box b );
        public int AreaEffect { get; protected set; }
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
            _box.Infrasructure = null;
            _box = null;
        }

    }
}
