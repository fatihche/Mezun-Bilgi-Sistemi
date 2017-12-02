using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
   public class EndustriMuh:Bolumler
    {
        Heap Endustri;
        
        public EndustriMuh()
        {
             Endustri = new Heap(20);
            BolumId = 11;
        }

        public override void HeapOgrenciEkle(Ogrenci ogr)
        {
            Endustri.Insert(ogr);
        }
        public Heap Heapver()
        {
            return Endustri;
        }
        public override HeapDugumu EnUygunMezun()
        {
            return Endustri.EnUygunEleman();
        }

        public override bool OgrenciVarMi(int ogrNo)
        {
            throw new NotImplementedException();
        }
    }
}
