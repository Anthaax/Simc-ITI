using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using NUnit.Framework;
using ITI.Simc_ITI.Build;
using ITI.Simc_ITI;
using System.IO;

namespace ITI.Simc_ITI.Test
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void CanSaveAGame()
        {
            GameContext _game = GameContext.CreateNewGame();
            _game.InfrastructureManager.Find( "Habitation" ).CreateInfrastructure( _game.Map.Boxes[5, 5], 123 );
            string path = @"D:\Documents\Simc_ITI Sauvergardes\Sav1.txt";
            _game.Save( path );
        }
        [Test]
        public void LoadAGame()
        {
            string path = @"D:\Documents\Simc_ITI Sauvergardes\Sav1.txt";
            GameContext.LoadResult _load = GameContext.LoadGame( path );
            Assert.That( _load.ErrorMessage, Is.EqualTo( null ) );
            GameContext _game = _load.LoadedGame;
            Assert.That( _game.Map.Boxes[5, 5].Infrasructure.Type.Name, Is.EqualTo( "Habitation" ) );
        }
        [Test]
        public void CheckFire()
        {
            GameContext _game = GameContext.CreateNewGame();
            _game.InfrastructureManager.Find( "Usine" ).CreateInfrastructure( _game.Map.Boxes[1, 1] , 0);
            IBurn BurningBuilding = _game.Map.Boxes[1, 1].Infrasructure as IBurn;
            Assert.That( BurningBuilding.BurningChance, Is.EqualTo( 75 ) );
            _game.InfrastructureManager.Find( "Pompier" ).CreateInfrastructure( _game.Map.Boxes[1, 2], 0 );
            IBurnImpact FireStation = _game.Map.Boxes[1, 2].Infrasructure as IBurnImpact;
            Assert.That( BurningBuilding.BurningChance, Is.EqualTo( 5 ) );

            _game = GameContext.CreateNewGame();
            _game.InfrastructureManager.Find( "Pompier" ).CreateInfrastructure( _game.Map.Boxes[1, 2], 0 );
            _game.InfrastructureManager.Find( "Usine" ).CreateInfrastructure( _game.Map.Boxes[1, 1], 0 );
            Assert.That( BurningBuilding.BurningChance, Is.EqualTo( 5 ) );
            
        }
        [Test]
        public void TaxationGoDownHappyness()
        {
            GameContext _game = GameContext.CreateNewGame();
            _game.InfrastructureManager.Find( "Habitation" ).CreateInfrastructure( _game.Map.Boxes[1, 1], 0 );
            ITaxation privateBuilding = _game.Map.Boxes[1, 1].Infrasructure as ITaxation;
            Assert.That( privateBuilding.Taxation, Is.EqualTo( _game.MoneyManager.TaxationManager.HabitationTaxation ) );
            _game.MoneyManager.TaxationManager.HabitationTaxation = 21;
            IEnumerable<Habitation> habitation = _game.Map.GetAllInfrastucture<Habitation>();
            foreach( var hab in habitation )
            {
                hab.Taxation = _game.MoneyManager.TaxationManager.HabitationTaxation;
            }
            _game.Map.Boxes[1, 1].Infrasructure.Update();
            Assert.That( privateBuilding.Taxation, Is.EqualTo( 16 ) );
            Assert.That( privateBuilding.Salary, Is.EqualTo( 7000 / 2 ) );


        }
    }
}
