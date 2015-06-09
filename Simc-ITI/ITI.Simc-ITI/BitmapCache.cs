using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI
{
    public class BitmapCache
    {
        readonly Dictionary<string, Bitmap> _textures;
        readonly string _rootPath;

        public BitmapCache()
        {
            _textures = new Dictionary<string, Bitmap>();
            var uri = new Uri(Assembly.GetExecutingAssembly().CodeBase);
            string localPath = uri.LocalPath;
            _rootPath = Path.Combine( Path.GetDirectoryName(localPath), "Images");
        }

        public Bitmap Get( string name )
        {
            Bitmap image;
            if( !_textures.TryGetValue( name, out image ) )
            {
                string path = Path.Combine(_rootPath, name);
                
                image = new Bitmap(path);
                _textures.Add( name, image );
            }
            return image;
        }
    }
}
