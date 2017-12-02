using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
   public class BilisimSisMuh:Bolumler
    {
        Heap BilisimSistem;
        
        public BilisimSisMuh()
        {
      BilisimSistem = new Heap(20);
            BolumId = 10;
        }

        public override void HeapOgrenciEkle(Ogrenci ogr)
        {
            BilisimSistem.Insert(ogr);
            
        }
        public Heap Heapver()
        {
            return BilisimSistem;
        }
        public override HeapDugumu EnUygunMezun()
        {
            return BilisimSistem.EnUygunEleman();
        }

        public override bool OgrenciVarMi(int ogrNo)
        {
            throw new NotImplementedException();
        }
    }
}
