using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class EnerjiSisMuh : Bolumler
    {
        Heap Enerjisis;
        
        public EnerjiSisMuh()
        {
            Enerjisis = new Heap(20);
            BolumId = 12;
        }
        public override void HeapOgrenciEkle(Ogrenci ogr)
        {
            Enerjisis.Insert(ogr);   
        }
        public Heap Heapver()
        {
            return Enerjisis;
        }
        public override HeapDugumu EnUygunMezun()
        {
            return Enerjisis.EnUygunEleman();
        }

        public override bool OgrenciVarMi(int ogrNo)
        {
            throw new NotImplementedException();
        }
    }
}
