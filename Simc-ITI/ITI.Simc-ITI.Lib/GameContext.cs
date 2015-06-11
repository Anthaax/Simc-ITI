using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI.Build
{
    public class GameContext
    {
        readonly Map _map;
        readonly InfrastructureManager _infraManager;
        readonly MyMoney _money;
        readonly MoneyGestion _moneygestion;
        bool _isGameOver;

        GameContext()
        {
            _map = new Map( 100, 100 );
            _infraManager = new InfrastructureManager( this );
            _money = new MyMoney();
            _moneygestion = new MoneyGestion();
        }

        public static GameContext CreateNewGame()
        {
            return new GameContext();
        }

        public void Save( string path )
        {

        }

        public class LoadResult
        {
            public GameContext LoadedGame { get; private set; }
            public string ErrorMessage { get; private set; }

            public LoadResult( GameContext c, string error )
            {
                Debug.Assert( c == null ^ error == null );
                LoadedGame = c;
                ErrorMessage = error;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Null on error.</returns>
        public static LoadResult LoadGame( string path )
        {
            return new LoadResult() new GameContext();
        }

        public bool IsGameOver
        {
            get { return _isGameOver; }
        }
        public event EventHandler IsGameOverChanged;

        internal void SetGameOver()
        {
            Debug.Assert( !_isGameOver );
            _isGameOver = true;
            var h = IsGameOverChanged;
            if( h != null ) h( this, EventArgs.Empty );
        }
    }
}
