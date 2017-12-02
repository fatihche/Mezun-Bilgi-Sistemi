using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
   public class HeapDugumu
    {
        public Ogrenci ogrenci;
        public int BasariPuani;
        
        public HeapDugumu(Ogrenci ogr)
        {
            this.ogrenci = ogr;
            OgrenciBasariDereceHesapla();
            
        }
        private void OgrenciBasariDereceHesapla()
        {
            if(ogrenci.BolumBilgi.Basaribelgesi==true)
            {
                BasariPuani = ogrenci.BolumBilgi.notOrtalama + 10;
                
            }
            else
            {
                BasariPuani = ogrenci.BolumBilgi.notOrtalama;
            }
        }
        
    }
}
