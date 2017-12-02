using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class MekatronikMuh : Bolumler
    {
        Heap Mekatronik;
        
        public MekatronikMuh()
        {
            Mekatronik = new Heap(20);
            BolumId = 14;
        }
        public override void HeapOgrenciEkle(Ogrenci ogr)
        {
            Mekatronik.Insert(ogr);
        }
        public Heap Heapver()
        {
            return Mekatronik;
        }
        public override HeapDugumu EnUygunMezun()
        {
            return Mekatronik.EnUygunEleman();
        }

        public override bool OgrenciVarMi(int ogrNo)
        {
            throw new NotImplementedException();
        }
    }
}
