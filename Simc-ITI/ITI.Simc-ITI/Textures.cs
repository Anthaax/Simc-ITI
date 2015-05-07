using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.Simc_ITI
{
    class Textures
    {
        string _path;
        public Textures( string name )
        {
            ChangePath( name );
        }

        public string Path
        {
            get { return _path; }
        }

        private void ChangePath( string name )
        {
            if( name == "Habitation" ) _path = "C:/dev/Textures/Habitation.bmp";
            else if( name == "Ecole" ) _path = "C:/dev/Textures/College.bmp";
            else if( name == "RV" ) _path = "C:/dev/Textures/RV.bmp";
            else if( name == "RH" ) _path = "C:/dev/Textures/RH.bmp";
            else if( name == "RC" ) _path = "C:/dev/Textures/Careffour.bmp";
        }
    }
}
