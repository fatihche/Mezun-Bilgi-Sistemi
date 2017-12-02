using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
   public abstract class Bolumler
    {
        public abstract void HeapOgrenciEkle(Ogrenci ogr);
        public abstract HeapDugumu EnUygunMezun();
        public abstract bool OgrenciVarMi(int ogrNo);
        public int BolumId { get; set; }

    }
}
