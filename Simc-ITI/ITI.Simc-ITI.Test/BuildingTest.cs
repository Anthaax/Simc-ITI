using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ITI.Simc_ITI;
using ITI.Simc_ITI.Build;

namespace ITI.Simc_ITI.Test
{
    [TestFixture]
    public class BuildingTest
    {
        [Test]
        public void CreateTheGoodBuilding()
        {
            Map m = new Map( 10, 10 );
            InfrastructureManager i = new InfrastructureManager();
            Assert.That( m.Boxes[0, 0].Infrasructure, Is.EqualTo( null ) );
            Assert.That( m.Money.ActualMoney, Is.EqualTo( 5000 ) );
            Assert.That( i.Find( "Route" ).BuildingCost, Is.EqualTo( 5 ) );
            Assert.That( i.Find( "Ecole" ).TexturePath, Is.EqualTo( "C:/dev/Textures/Ecole.bmp" ) );
            i.Find( "Route" ).CreateInfrastructure( m.Boxes[0, 0] );
            Assert.That( m.Money.ActualMoney, Is.EqualTo(4995) );
            Assert.That( m.Boxes[0, 0].Infrasructure.GetType(), Is.Not.Null );
            Assert.That( m.Boxes[0, 0].Infrasructure.Type.Name, Is.EqualTo( "Route" ) );
        }
        [Test]
        public void HappynessChangedWhenPublicBuildingWasCreate()
        {
            Map m = new Map( 10, 10 );
            InfrastructureManager i = new InfrastructureManager();
            i.Find( "Route" ).CreateInfrastructure( m.Boxes[0, 4] );
            bool canCreateHabitation = i.Find( "Habitation" ).CanCreated( m.Boxes[0, 5] );
            bool canCreateEcole = i.Find( "Ecole" ).CanCreated( m.Boxes[0, 3] );
            Assert.That( canCreateEcole, Is.EqualTo( true ) );
            Assert.That( canCreateHabitation, Is.EqualTo( true ) );
            i.Find( "Habitation" ).CreateInfrastructure( m.Boxes[0, 5] );
            i.Find( "Ecole" ).CreateInfrastructure( m.Boxes[0, 3] );
            IHappyness happy = m.GetAllInfrastucture<IHappyness>().Single();
            Assert.That( happy.Happyness, Is.EqualTo( 55 ) );
        }
        [Test]
        public void UpdateGame()
        {
            Map m = new Map( 10, 10 );
            InfrastructureManager i = new InfrastructureManager();
            i.Find( "Route" ).CreateInfrastructure( m.Boxes[0, 5] );
            i.Find( "Habitation" ).CreateInfrastructure( m.Boxes[0, 4] );
            i.Find( "Ecole" ).CreateInfrastructure( m.Boxes[0, 6] );
            
        }
    }
}
