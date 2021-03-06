﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI
{
    [Serializable]
    public class BitmapCache
    {
        readonly Dictionary<string, Bitmap> _textures;
        string _rootPath;

        public BitmapCache()
        {
            _textures = new Dictionary<string, Bitmap>();
        }

        public Bitmap Get( string name )
        {
            
            Bitmap image;
            if( !_textures.TryGetValue( name, out image ) )
            {
                var uri = new Uri(Assembly.GetExecutingAssembly().CodeBase);
                string localPath = uri.LocalPath;
                _rootPath = Path.Combine(Path.GetDirectoryName(localPath), "Images");
                string path = Path.Combine(_rootPath, name);
                
                image = new Bitmap(path);
                _textures.Add( name, image );
            }
            return image;
        }
    }
}
