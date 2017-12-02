using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
   public class OgrenciAgacDugum
    {
        public Ogrenci ogrenciBilgi;
        public OgrenciAgacDugum sol;
        public OgrenciAgacDugum sag;
        public OgrenciAgacDugum()
        {
        }

        public OgrenciAgacDugum(Ogrenci veri)
        {
            this.ogrenciBilgi = veri;
            sol = null;
            sag = null;
        }
    }
}
