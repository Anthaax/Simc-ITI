using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ITI.Simc_ITI;
using ITI.Simc_ITI.Lib;

namespace ITI.Simc_ITI.Test
{
    [TestFixture]
    public class BuildingTest
    {
        [Test]
        public void CreateTheGoodBuilding()
        {
            Map m = new Map( 10, 10 );
            Box[,] box;
            box = m.Boxes;
            Bitmap bmp;
            Bitmap BmpTest = new Bitmap( "C:/dev/Textures/RV2.bmp" );
            int _money = m.Money.ActualMoney;
            Assert.That( _money, Is.EqualTo( 5000 ) );
            box[0, 0].CreateInfrastructure( 50, 0, 5, true, true, true, true,"RV");
            bmp = box[0, 0].BitmapTexture;
            Assert.That( bmp.GetPixel( 0, 1 ), Is.EqualTo( BmpTest.GetPixel( 0, 1 ) ) );
            box[0, 1].CreateInfrastructure( 500, 3, 50, true, true, true, false,"Ecole" );
            Bitmap BmpTest2 = new Bitmap( "C:/dev/Textures/College.bmp" );
            bmp = box[0, 1].BitmapTexture;
            Assert.That( bmp.GetPixel( 0, 2 ), Is.EqualTo( BmpTest2.GetPixel( 0, 2 ) ) );
            box[0, 2].CreateInfrastructure( 500, 0, 0, true, true, true, false,"Habitation" );
            _money = m.Money.ActualMoney;
            Assert.That( _money, Is.EqualTo( 3950 ) );
            bool _isOk = box[0, 0].MyInfrasructure.MyRoad.MyVRoad.Electricity;
            int _areaEffect = box[0, 1].MyInfrasructure.MyBuilding.IsPublic.MySchool.AreaEffect;
            int _people = box[0, 2].MyInfrasructure.MyBuilding.IsPrivate.MyHabitation.People;
            Assert.That( _isOk, Is.EqualTo(true) );
            Assert.That( _areaEffect, Is.EqualTo( 3 ) );
            Assert.That( _people, Is.EqualTo( 3 ) );
        }
    }
}
