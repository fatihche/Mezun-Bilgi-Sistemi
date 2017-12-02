using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class Ogrenci:IMezunYetki
    {
        public string ad { get; set; }
        public string soyad { get; set; }
        public string adres { get; set; }
        public int telNo { get; set; }
        public string eposta { get; set; }
        public string uyruk { get; set; }
        public int ogrenciNo { get; set; }
        public YabanciDil Ingilizce = new YabanciDil();
        public IlgiAlanlari ilgialanlari = new IlgiAlanlari();
        public Bolum BolumBilgi = new Bolum();

        public Staj StajBilgi = new Staj();

        public void BilgileriGuncelle(OgrenciAgac ogrAgac, Ogrenci ogr,int ogrenciNo)
        {
            ogrAgac.Guncelle(ogr, ogrenciNo);
        }

        public void BilgileriSistemdenSil(OgrenciAgac ogrAgac, int ogrenciNo)
        {
            ogrAgac.Sil(ogrenciNo);
        }
    }
}
