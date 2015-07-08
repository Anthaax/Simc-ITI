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
using System.IO;
using System.Reflection;

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
            var uri = new Uri( Assembly.GetExecutingAssembly().CodeBase );
            string localPath = uri.LocalPath;
            string rootPath = Path.Combine( Path.GetDirectoryName( localPath ), "Save" );
            string truePath = Path.Combine( rootPath, "NewGame.txt" );
            GameContext.LoadResult _load = GameContext.LoadGame( truePath );
            if( _load.LoadedGame != null )
            {
                _game = _load.LoadedGame;
            }
            var j = GameHasBeenCreated;
            if( j != null ) j( this, EventArgs.Empty );
        }

        private void LoadGame_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog LoadGame = new OpenFileDialog();
            LoadGame.InitialDirectory = "c:\\";
            LoadGame.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*" ;
            LoadGame.FilterIndex = 2;
            LoadGame.RestoreDirectory = true;
            if( LoadGame.ShowDialog() == DialogResult.OK )
            {
                GameContext.LoadResult _load = GameContext.LoadGame( LoadGame.FileName );
                if( _load.LoadedGame != null )
                {
                    _game = _load.LoadedGame;
                    var h = GameHasBeenCreated;
                    if( h != null ) h( this, EventArgs.Empty );
                }
            }
        }

        private void DropGame_button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
        public GameContext GameContext { get { return _game; } }
    }
}
