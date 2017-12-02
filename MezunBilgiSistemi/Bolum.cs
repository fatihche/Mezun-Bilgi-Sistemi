using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
   public class Bolum
    {
        public string bolumadi { get; set; }
        public string baslangicTarihi { get; set; }
        public string bitisTarihi { get; set; }
        public int notOrtalama { get; set; }
        public Boolean Basaribelgesi { get; set; }
        public Bolum next;

    }
}
