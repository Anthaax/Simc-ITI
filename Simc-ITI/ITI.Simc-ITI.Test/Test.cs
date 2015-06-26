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
    }
}
