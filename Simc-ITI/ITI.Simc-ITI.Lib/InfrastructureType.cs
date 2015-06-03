﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public abstract class InfrastructureType : IInfrastructureType
    {
        readonly string _name;
        readonly int _areaEffect;
        readonly int _buildingCost;
        readonly string _texturePath;

        protected InfrastructureType( string name, int buildingCost, int areaEffect, string path)
        {
            _name = name;
            _buildingCost = buildingCost;
            _texturePath = path;
            _areaEffect = areaEffect;
        }

        public string Name { get { return _name; } }
        public int AreaEffect { get { return _areaEffect; } }
        public int BuildingCost { get { return _buildingCost; } }
        public string TexturePath { get { return _texturePath; } }

        public bool CanCreated( Box b )
        {
            bool _check = false;
            IEnumerable<Box> _nearBoxes = b.NearBoxes( 1 );
            foreach( var box in _nearBoxes )
            {
                if( box.Infrasructure != null )
                {
                    if( box.Infrasructure.Type.Name == "Route" ) _check = true;
                }
            }
            return _check;
        }
        public bool CanDestroy(Box b)
        {
            bool _check = false;
            IEnumerable<Box> _nearBoxes = b.NearBoxes( 1 );
            foreach( var box in _nearBoxes )
            {
                if( box.Infrasructure != null )
                {
                    if( box.Infrasructure.Type.Name != "Route" ) _check = true;
                }
            }
            return _check;
        }
        public Infrastructure CreateInfrastructure( Box b )
        {
            if( b.Infrasructure != null ) throw new InvalidOperationException( "The box alreay has an Infrastructure." );
            b.Map.Money.ActualMoney -= BuildingCost;
            Infrastructure infra = DoCreateInfrastructure( b );
            for( int c = Math.Max( 0, b.Column - infra.AreaEffect ); c < Math.Min( b.Map.BoxCount, b.Column + infra.AreaEffect ); c++ )
            {
                for( int l = Math.Max( 0, b.Line - infra.AreaEffect ); l < Math.Min( b.Map.BoxCount, b.Line + infra.AreaEffect ); l++ )
                {
                    if( c != b.Column || l != b.Line )
                    {
                        Box aroundBox = b.Map.Boxes[c, l];
                        if( aroundBox.Infrasructure != null )
                        {
                            aroundBox.Infrasructure.OnCreatedAround( b );
                        }
                    }
                }
            }
            return infra;
        }

        protected abstract Infrastructure DoCreateInfrastructure( Box location );
    }
}
