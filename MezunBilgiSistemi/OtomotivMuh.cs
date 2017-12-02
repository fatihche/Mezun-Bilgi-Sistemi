using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class OtomotivMuh : Bolumler
    {
        Heap Otomotiv;
        
        public OtomotivMuh()
        {
            Otomotiv = new Heap(20);
            BolumId = 15;
        }
        public override void HeapOgrenciEkle(Ogrenci ogr)
        {
            Otomotiv.Insert(ogr);
        }
        public Heap Heapver()
        {
            return Otomotiv;
        }
        public override HeapDugumu EnUygunMezun()
        {
            return Otomotiv.EnUygunEleman();
        }

        public override bool OgrenciVarMi(int ogrNo)
        {
            throw new NotImplementedException();
        }
    }
}
