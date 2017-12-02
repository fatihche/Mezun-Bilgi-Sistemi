using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
   public class HashEntry
    {
        private int anahtar;


        private Heap deger;

        public Heap Deger
        {
            get { return deger; }
            set { deger = value; }
        }
        public int Anahtar
        {
            get { return anahtar; }
            set { anahtar = value; }
        }
        public HashEntry(int anahtar, Heap deger)
        {
            this.anahtar = anahtar;
            this.deger = deger;
        }
    }
}
