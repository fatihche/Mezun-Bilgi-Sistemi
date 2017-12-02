using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class YazilimMuh : Bolumler
    {
        Heap yazilim;
        
        
        public YazilimMuh()
        {
            yazilim = new Heap(20);
            BolumId = 16;
            
        }
       
        public override void HeapOgrenciEkle(Ogrenci ogr)
        {
            yazilim.Insert(ogr);
        }
        public Heap Heapver()
        {
            return yazilim;
        }
        public override  HeapDugumu EnUygunMezun()
        {
           return yazilim.EnUygunEleman();
        }

        public override bool OgrenciVarMi(int ogrNo)
        {
            throw new NotImplementedException();
        }
    }
}
