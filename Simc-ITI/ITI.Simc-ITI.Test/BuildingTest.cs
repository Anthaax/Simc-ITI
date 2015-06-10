using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ITI.Simc_ITI;
using ITI.Simc_ITI.Build;
using ITI.Simc_ITI.Money.Lib;

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
            Assert.That( i.Find( "Ecole" ).BuildingCost, Is.EqualTo( 500 ) );
            i.Find( "Ecole" ).CreateInfrastructure( m.Boxes[0, 0], 1);
            i.Find( "CentraleElectrique" ).CreateInfrastructure( m.Boxes[0, 1], 0 );
            Assert.That( m.Money.ActualMoney, Is.EqualTo(4500-900) );
            Assert.That( m.Boxes[0, 0].Infrasructure.GetType(), Is.Not.Null );
            Assert.That( m.Boxes[0, 0].Infrasructure.Type.Name, Is.EqualTo( "Ecole" ) );
        }
        [Test]
        public void HappynessChangedWhenPublicBuildingWasCreate()
        {
            Map m = new Map( 10, 10 );
            InfrastructureManager i = new InfrastructureManager();
            i.Find( "Habitation" ).CreateInfrastructure( m.Boxes[0, 5],0 );
            i.Find( "Ecole" ).CreateInfrastructure( m.Boxes[0, 3],0 );
            IHappyness happy = m.GetAllInfrastucture<IHappyness>().Single();
            Assert.That( happy.Happyness, Is.EqualTo( 55 ) );
        }
        [Test]
        public void HabitationHaveTheTaxationWithUpdate()
        {
            Map m = new Map( 10, 10 );
            InfrastructureManager i = new InfrastructureManager();
            MoneyGestion mg = new MoneyGestion();                       
            i.Find( "Habitation" ).CreateInfrastructure( m.Boxes[0, 4],0 );
            i.Find( "Ecole" ).CreateInfrastructure( m.Boxes[0, 5], 0 );
            Habitation taxe = m.Boxes[0, 4].Infrasructure as Habitation;
            if( taxe != null ) taxe.Taxation = mg.HabitationTaxation;
            Assert.That( taxe.Taxation, Is.EqualTo( 10 ) );
            m.Boxes[0, 4].Infrasructure.Update();
            Assert.That( m.Money.ActualMoney, Is.EqualTo( 4550 ) );
            m.Boxes[0, 5].Infrasructure.Update();
            Assert.That( m.Money.ActualMoney, Is.EqualTo( 4540 ) );
            mg.HabitationTaxation = 15;
            if( taxe != null ) taxe.Taxation = mg.HabitationTaxation;
            Assert.That( taxe.Taxation, Is.EqualTo( 15 ) );
        }
        [Test]
        public void CanCreatedInfrastructure()
        {
            Map m = new Map( 10, 10 );
            InfrastructureManager i = new InfrastructureManager();
            RoadCreationConfig cfg = new RoadCreationConfig();
            RoadOrientation type = (RoadOrientation)1;
            cfg.Orientation = type;
            i.Find( "Route" ).CreateInfrastructure( m.Boxes[5, 5], cfg );
            Assert.That( i.Find( "CentraleElectrique" ).CanCreatedNearRoad( m.Boxes[5, 4] ), Is.EqualTo( true ) );
            i.Find( "CentraleElectrique" ).CreateInfrastructure( m.Boxes[5, 4], 0 );
            Assert.That( i.Find( "Habitation" ).CanCreatedNearRoad( m.Boxes[5, 6] ), Is.EqualTo( true ) );
            Assert.That( i.Find( "Habitation" ).CanCreated( m.Boxes[5, 6] ), Is.EqualTo( true ) );
        }
    }
}
