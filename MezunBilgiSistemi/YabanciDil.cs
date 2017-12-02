using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
   public class YabanciDil
    {

        public DilSeviyesi Dil { get; set; }

      public   enum DilSeviyesi
        {
            preintermediate = 0,
            intermediate = 1,
            upperintermediate = 2,
            advanced = 3

        }





    }
}
