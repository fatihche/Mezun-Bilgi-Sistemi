using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class MakinaMuh : Bolumler
    {
        Heap Makina;
        
        public MakinaMuh()
        {
            Makina = new Heap(20);
            BolumId = 13;
        }
        public override void HeapOgrenciEkle(Ogrenci ogr)
        {
            Makina.Insert(ogr);
        }
        public Heap Heapver()
        {
            return Makina;
        }
        public override HeapDugumu EnUygunMezun()
        {
            return Makina.EnUygunEleman();
        }

        public override bool OgrenciVarMi(int ogrNo)
        {
            throw new NotImplementedException();
        }
    }
}
