using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class Staj
    {
        public string sirketisim { get; set; }
        public string stajTarih { get; set; }
        public string departman { get; set; }
        public Staj next;


    }
}
