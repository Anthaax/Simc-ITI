using System;
using System.Collections.Generic;
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
            Box [,] box;
            box = m.Boxes;
            box[0, 0].CreateInfrastructure( 0 );
            box[0, 1].CreateInfrastructure( 1 );
            box[0, 2].CreateInfrastructure( 2 );
            bool isOk = box[0, 0].MyInfrasructure.MyRoad.MyVRoad.Electricity;
            box[0,1].MyInfrasructure.MyBuilding.IsPublic.MySchool.
            Assert.That( isOk, Is.EqualTo(true) );
        }
    }
}
