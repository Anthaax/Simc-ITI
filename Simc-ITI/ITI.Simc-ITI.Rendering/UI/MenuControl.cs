using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ITI.Simc_ITI.Build;

namespace ITI.Simc_ITI.Rendering
{
    public partial class MenuControl : UserControl
    {
        GameContext _game;
        public MenuControl()
        {
            InitializeComponent();
        }
        public event EventHandler GameHasBeenCreated;
        private void NewGame_button_Click(object sender, EventArgs e)
        {
            string path = @"D:\Documents\Simc_ITI Sauvergardes\NewGame.txt";
            GameContext.LoadResult _load = GameContext.LoadGame( path );
            if( _load.LoadedGame != null )
            {
                _game = _load.LoadedGame;
                _game.MoneyManager.ActualMoney = 4000;
;                foreach( var boxes in _game.Map.Boxes )
                {
                    boxes.PenColor = new Pen( Color.DimGray );
                }
            }
            var j = GameHasBeenCreated;
            if( j != null ) j( this, EventArgs.Empty );
        }

        private void LoadGame_button_Click(object sender, EventArgs e)
        {
            string path = @"D:\Documents\Simc_ITI Sauvergardes\Sav1.txt";
            GameContext.LoadResult _load = GameContext.LoadGame( path );
            if( _load.LoadedGame != null )
            {
                _game = _load.LoadedGame;
                foreach( var boxes in _game.Map.Boxes)
                {
                    boxes.PenColor = new Pen( Color.DimGray );
                }
                var h = GameHasBeenCreated;
                if( h != null ) h( this, EventArgs.Empty );
            }
        }

        private void DropGame_button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public GameContext GameContext { get { return _game; } }
    }
}
