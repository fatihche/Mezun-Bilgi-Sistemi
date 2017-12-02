using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
   public class OgrenciAgac
    {
        private OgrenciAgacDugum kok;
        private string dugumler;
        public  OgrenciAgac()
        {
        }
        public OgrenciAgac(OgrenciAgacDugum kok)
        {
            this.kok = kok;
        }
        public int DugumSayisi()
        {
            return DugumSayisi(kok);
        }
        public int DugumSayisi(OgrenciAgacDugum dugum)
        {
            int count = 0;
            if (dugum != null)
            {
                count = 1;
                count += DugumSayisi(dugum.sol);
                count += DugumSayisi(dugum.sag);
            }
            return count;
        }
        public int YaprakSayisi()
        {
            return YaprakSayisi(kok);
        }
        public int YaprakSayisi(OgrenciAgacDugum dugum)
        {
            int count = 0;
            if (dugum != null)
            {
                if ((dugum.sol == null) && (dugum.sag == null))
                    count = 1;
                else
                    count = count + YaprakSayisi(dugum.sol) + YaprakSayisi(dugum.sag);
            }
            return count;
        }
        public string DugumleriYazdir()
        {
            return dugumler;
        }
        public void PreOrder()
        {
            dugumler = "";
            PreOrderInt(kok);
        }
        private void PreOrderInt(OgrenciAgacDugum dugum)
        {
            if (dugum == null)
                return;
            Ziyaret(dugum);
            PreOrderInt(dugum.sol);
            PreOrderInt(dugum.sag);
        }
        public void InOrder()
        {
            dugumler = "";
            InOrderInt(kok);
        }
        private void InOrderInt(OgrenciAgacDugum dugum)
        {
            if (dugum == null)
                return;
            InOrderInt(dugum.sol);
            Ziyaret(dugum);
            InOrderInt(dugum.sag);
        }
        private void Ziyaret(OgrenciAgacDugum dugum)
        {
            dugumler += dugum.ogrenciBilgi + " ";
        }
        public void PostOrder()
        {
            dugumler = "";
            PostOrderInt(kok);
        }
        private void PostOrderInt(OgrenciAgacDugum dugum)
        {
            if (dugum == null)
                return;
            PostOrderInt(dugum.sol);
            PostOrderInt(dugum.sag);
            Ziyaret(dugum);
        }
        public void Ekle(Ogrenci ogr)
        {
            //Yeni eklenecek düğümün parent'ı
            OgrenciAgacDugum tempParent = new OgrenciAgacDugum();
            //Kökten başla ve ilerle
            OgrenciAgacDugum tempSearch = kok;

            while (tempSearch != null)
            {
                tempParent = tempSearch;
                //Deger zaten var, çık.
                if (ogr.ogrenciNo == (int)tempSearch.ogrenciBilgi.ogrenciNo)
                    return;
                else if (ogr.ogrenciNo < (int)tempSearch.ogrenciBilgi.ogrenciNo)
                    tempSearch = tempSearch.sol;
                else
                    tempSearch = tempSearch.sag;
            }
            OgrenciAgacDugum eklenecek = new OgrenciAgacDugum(ogr);
            //Ağaç boş, köke ekle
            if (kok == null)
                kok = eklenecek;
            else if (ogr.ogrenciNo < (int)tempParent.ogrenciBilgi.ogrenciNo)
                tempParent.sol = eklenecek;
            else
                tempParent.sag = eklenecek;
        }
      
        public void Guncelle(Ogrenci ogr, int anahtar)
        {
            OgrenciAgacDugum aranandeger = AraInt(kok, anahtar);
            aranandeger.ogrenciBilgi = ogr;
        }
        
       
        public bool VarMi(int anahar)
        {
            OgrenciAgacDugum deger = AraInt(kok, anahar);
            if (deger == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
       
        
        public OgrenciAgacDugum Ara(int anahtar)
        {
            return AraInt(kok, anahtar);
        }
        private OgrenciAgacDugum AraInt(OgrenciAgacDugum dugum,
                                            int anahtar)
        {
            if (dugum == null)
                return null;
            else if ((int)dugum.ogrenciBilgi.ogrenciNo == anahtar)
                return dugum;
            else if ((int)dugum.ogrenciBilgi.ogrenciNo > anahtar)
                
                return (AraInt(dugum.sol, anahtar));
            else
                return (AraInt(dugum.sag, anahtar));
        }

        public OgrenciAgacDugum MinDeger()
        {
            OgrenciAgacDugum tempSol = kok;
            while (tempSol.sol != null)
                tempSol = tempSol.sol;
            return tempSol;
        }

        public OgrenciAgacDugum MaksDeger()
        {
            OgrenciAgacDugum tempSag = kok;
            while (tempSag.sag != null)
                tempSag = tempSag.sag;
            return tempSag;
        }

        private OgrenciAgacDugum Successor(OgrenciAgacDugum silDugum)
        {
            OgrenciAgacDugum successorParent = silDugum;
            OgrenciAgacDugum successor = silDugum;
            OgrenciAgacDugum current = silDugum.sag;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.sol;
            }
            if (successor != silDugum.sag)
            {
                successorParent.sol = successor.sag;
                successor.sag = silDugum.sag;
            }
            return successor;
        }
        public bool Sil(int deger)
        {
            OgrenciAgacDugum current = kok;
            OgrenciAgacDugum parent = kok;
            bool issol = true;
            //DÜĞÜMÜ BUL
            while ((int)current.ogrenciBilgi.ogrenciNo != deger)
            {
                parent = current;
                if (deger < (int)current.ogrenciBilgi.ogrenciNo)
                {
                    issol = true;
                    current = current.sol;
                }
                else
                {
                    issol = false;
                    current = current.sag;
                }
                if (current == null)
                    return false;
            }
            //DURUM 1: YAPRAK DÜĞÜM
            if (current.sol == null && current.sag == null)
            {
                if (current == kok)
                    kok = null;
                else if (issol)
                    parent.sol = null;
                else
                    parent.sag = null;
            }
            //DURUM 2: TEK ÇOCUKLU DÜĞÜM
            else if (current.sag == null)
            {
                if (current == kok)
                    kok = current.sol;
                else if (issol)
                    parent.sol = current.sol;
                else
                    parent.sag = current.sol;
            }
            else if (current.sol == null)
            {
                if (current == kok)
                    kok = current.sag;
                else if (issol)
                    parent.sol = current.sag;
                else
                    parent.sag = current.sag;
            }
            //DURUM 3: İKİ ÇOCUKLU DÜĞÜM
            else
            {
                OgrenciAgacDugum successor = Successor(current);
                if (current == kok)
                    kok = successor;
                else if (issol)
                    parent.sol = successor;
                else
                    parent.sag = successor;
                successor.sol = current.sol;
            }
            return true;
        }

    }
}
