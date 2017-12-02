using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MezunBilgiSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        HashMap hash = new HashMap();
        
        MakinaMuh makina = new MakinaMuh();
        BilisimSisMuh bilisim = new BilisimSisMuh();
        EndustriMuh endustri = new EndustriMuh();
        EnerjiSisMuh enerji = new EnerjiSisMuh();
        MekatronikMuh mekatronik = new MekatronikMuh();
        OtomotivMuh otomotiv = new OtomotivMuh();
        YazilimMuh yazilim = new YazilimMuh();
        
       OgrenciAgac aramaAgaci = new OgrenciAgac();
        public void HashTabloHazirla()
        {
            Heap tmpyazilim = yazilim.Heapver();
            hash.AddHeap(yazilim.BolumId, tmpyazilim);
            Heap tmpmakina = makina.Heapver();
            hash.AddHeap(makina.BolumId, tmpmakina);
             Heap tmpmekatronik = mekatronik.Heapver();
            hash.AddHeap(mekatronik.BolumId, tmpmekatronik);
            Heap tmpenerji = enerji.Heapver();
             hash.AddHeap(enerji.BolumId, tmpenerji);
            Heap tmpendustri = endustri.Heapver();
            hash.AddHeap(endustri.BolumId, tmpendustri);
            Heap tmpotomotiv = otomotiv.Heapver();
            hash.AddHeap(otomotiv.BolumId, tmpotomotiv);
           Heap tmpbilisim = bilisim.Heapver();
            hash.AddHeap(bilisim.BolumId, tmpbilisim);
        }
        /*
        public HeapDugumu EnUygunAday(Bolumler b)
        {
            return b.EnUygunMezun();
        }
        */
        public ListBox BolumTumMmezunListele(Bolumler b,int dilTuru)
        {
           Heap tmpheap= hash.GetHeap(b.BolumId);
            int i = 0;
            
            for(i=0;i<20;i++)
            {
                HeapDugumu dugum = tmpheap.DugumVer(i);
                if (dugum == null)
                {
                    break;
                }
               
                else if((int)dugum.ogrenci.Ingilizce.Dil==dilTuru)
                {
                    lstbxMezunlar.Items.Add(dugum.BasariPuani.ToString()+""+ dugum.ogrenci.ad + " " + dugum.ogrenci.ogrenciNo.ToString() + " " + dugum.ogrenci.BolumBilgi.bolumadi + " " + dugum.ogrenci.Ingilizce.Dil.ToString() + Environment.NewLine);
                }
                else if(dilTuru==4)
                {
                    lstbxMezunlar.Items.Add(dugum.BasariPuani.ToString() + "" + dugum.ogrenci.ad + " " + dugum.ogrenci.ogrenciNo.ToString() + " " + dugum.ogrenci.BolumBilgi.bolumadi + " " + dugum.ogrenci.Ingilizce.Dil.ToString() + Environment.NewLine);

                }
            }

            return lstbxMezunlar;

        }
        public void OgrenciBilgileriAta(Ogrenci ogr)
        {
            ogr.ad = txtAd.Text;
            //ogr.soyad = txtSoyad.Text;
            //ogr.adres = txtAdres.Text;
            //ogr.telNo = Convert.ToInt32(txtTelefon.Text);
            //ogr.eposta = txtEposta.Text;
           
            ogr.ogrenciNo = Convert.ToInt32(txtOgrenciNo.Text);

            if (cmbBoxDil.SelectedIndex == 0)
            {
                ogr.Ingilizce.Dil = YabanciDil.DilSeviyesi.preintermediate;
            }
            else if (cmbBoxDil.SelectedIndex == 1)
            {
                ogr.Ingilizce.Dil = YabanciDil.DilSeviyesi.intermediate;
            }
            else if (cmbBoxDil.SelectedIndex == 2)
            {

                ogr.Ingilizce.Dil = YabanciDil.DilSeviyesi.upperintermediate;
            }
            else if (cmbBoxDil.SelectedIndex == 3)
            {
                ogr.Ingilizce.Dil= YabanciDil.DilSeviyesi.advanced;
            }
            else
            {
                MessageBox.Show("Hatalı Dil Girişi");
            }
           

            //ilgi alanlari
            // ogr.adres = txtAdres.Text;

            //  ogr.StajBilgi.sirketisim = txtSirketisim.Text;
            // ogr.StajBilgi.departman = txtDepartman.Text;
            //ogr.StajBilgi.stajTarih = txtStajTarh.Text;
            //bölüm bilgileri
            //ogr.BolumBilgi.baslangicTarihi = txtBasTarh.Text;
            // ogr.BolumBilgi.bitisTarihi = txtBitisTarh.Text;
            ogr.BolumBilgi.notOrtalama = Convert.ToInt32(txtNotOrt.Text);
            if (rdoBtnBasariVar.Checked)
            {
                ogr.BolumBilgi.Basaribelgesi = true;
                
            }
            else
            {
                ogr.BolumBilgi.Basaribelgesi = false;
            }
            if (cmbBoxBolum.SelectedIndex == 0)
            {

                BolumeGoreHeapAta(yazilim, ogr);
              
               

            }
            else if (cmbBoxBolum.SelectedIndex == 1)
            {
                BolumeGoreHeapAta(makina, ogr);
                

            }
            else if (cmbBoxBolum.SelectedIndex == 2)
            {
                BolumeGoreHeapAta(mekatronik, ogr);
                
               

            }
            else if (cmbBoxBolum.SelectedIndex == 3)
            {
                BolumeGoreHeapAta(enerji, ogr);
             

            }
            else if (cmbBoxBolum.SelectedIndex == 4)
            {
                BolumeGoreHeapAta(endustri, ogr);

               
                

            }
            else if (cmbBoxBolum.SelectedIndex == 5)
            {
                BolumeGoreHeapAta(otomotiv, ogr);
               
                

            }
            else if (cmbBoxBolum.SelectedIndex == 6)
            {
                BolumeGoreHeapAta(bilisim, ogr);
             
                
            }
            else
            {
                MessageBox.Show("Hatali bölüm girisi");
            }
            ogr.BolumBilgi.bolumadi = cmbBoxBolum.Text;
        }
        public void BolumeGoreHeapAta(Bolumler b,Ogrenci ogr)
        {
            
            b.HeapOgrenciEkle(ogr);
        }
        public void temizle()
        {
            txtAd.Clear();
            txtAdres.Clear();
            txtBasTarh.Clear();
            txtBitisTarh.Clear();
            txtDepartman.Clear();
            txtEposta.Clear();
            txtNotOrt.Clear();
            txtOgrenciNo.Clear();
            txtSirketisim.Clear();
            txtSoyad.Clear();
            txtStajTarh.Clear();
            txtTelefon.Clear();
            cmbBoxBolum.Text = " ";
            cmbBoxDil.Text = " ";
            chckBoxDans.Checked = false;
            chckBoxMuzik.Checked = false;
            chckBoxResim.Checked = false;
            chckBoxSpor.Checked = false;
        }


        private void girişYapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grpbxgrsyap.Visible = true;
            
            grpbxgrsyap.Location = new Point(12, 27);
            grpbxgrsyap.Size = new Size(284, 281);
            pictureBox1.Visible = false;
            txtGrsAd.Clear();
            txtGrsPswd.Clear();

            
        }

        private void btnGrs_Click(object sender, EventArgs e)
        {
            if (rdobtngrsmzn.Checked)
            {

                    uyeMezunToolStripMenuItem.Text = txtGrsAd.Text;
                    uyeMezunToolStripMenuItem.Visible = true;
                    
                    
                    girişYapToolStripMenuItem.Visible = false;
                    grpbxgrsyap.Visible = false;
                grpbxMznBilgi.Visible = true;
                grpbxMznBilgi.Location = new Point(12, 27);
                grpbxMznBilgi.Size = new Size(927, 424);
                

            }
            if (rdobtngrssrkt.Checked)
            {
                uyeSirketToolStripMenuItem.Text = txtGrsAd.Text;
                  uyeSirketToolStripMenuItem.Visible = true;
                çıkışYapToolStripMenuItem.Visible = true;
                    
                    girişYapToolStripMenuItem.Visible = false;
                    grpbxgrsyap.Visible = false;
                
            }
            temizle();
        }

       

        private void bilgileriniDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grpbxMznBilgi.Visible = true;
            grpbxMznBilgi.Location = new Point(12, 27);
            grpbxMznBilgi.Size = new Size(927, 424);
            btnGuncelle.Visible = true;
            btnBilgiKaydet.Visible = false;
            btnGuncelle.Location = new Point(615, 376);
            btnGuncelle.Size = new Size(75, 42);
            
        }

        

        private void btnBilgiKaydet_Click(object sender, EventArgs e)
        {
            Ogrenci ogr = new Ogrenci();

            OgrenciBilgileriAta(ogr);
            
            if(aramaAgaci.VarMi(ogr.ogrenciNo)==false)
            {
             aramaAgaci.Ekle(ogr);
             MessageBox.Show("Bilgileriniz sisteme kayıt olmuştur bilgilerinizi güncellemek isterseniz 'Menü'ye tıklayın");
                grpbxMznBilgi.Visible = false;
                bilgileriniguncelleToolStripMenuItem.Visible = true;
            sistemdekiBilgileriniSilToolStripMenuItem.Visible = true;
                çıkışYapToolStripMenuItem.Visible = true;
            }
            else
            {
                MessageBox.Show(ogr.ogrenciNo.ToString() + "numaralı bir mezun sistemde zaten var lütfen tekrar deneyiniz");
                
                txtOgrenciNo.Clear();
            }
            

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            Ogrenci ogr = new Ogrenci();
            OgrenciBilgileriAta(ogr);
            ogr.BilgileriGuncelle(aramaAgaci, ogr, ogr.ogrenciNo);

        }

        private void sistemdekiBilgileriniSilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ogrenci ogr=new Ogrenci();
            DialogResult karar;
            karar=MessageBox.Show("Bilgilerinizi silip sistemden ayrılmak istediğinize emin misiniz?","Soru", MessageBoxButtons.YesNo, MessageBoxIcon.Question, 0, MessageBoxOptions.RtlReading);
            if(karar==DialogResult.Yes)
            {
                int ogrenciNo = Convert.ToInt32(txtOgrenciNo.Text);
                OgrenciAgacDugum kisi = aramaAgaci.Ara(ogrenciNo);

                ogr.BilgileriSistemdenSil(aramaAgaci, ogrenciNo);
                MessageBox.Show("Sayın "+kisi.ogrenciBilgi.ad+" "+ kisi.ogrenciBilgi.soyad+ Environment.NewLine+ "sistemden çıkma işleminiz onaylanmıştır ");
                sistemdekiBilgileriniSilToolStripMenuItem.Visible = false;
               uyeSirketToolStripMenuItem.Visible = false;
                uyeMezunToolStripMenuItem.Visible = false;
                
                pictureBox1.Visible = true;
                girişYapToolStripMenuItem.Visible = true;
                grpbxMznBilgi.Visible = false;
               
            }

        }

        private void elemanAraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        

        private void uyeMezunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            çıkışYapToolStripMenuItem.Visible = false;
            uyeMezunToolStripMenuItem.Visible = false;
            girişYapToolStripMenuItem.Visible = true;
            grpbxMznBilgi.Visible = false;
        }

        private void çıkışYapToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            girişYapToolStripMenuItem.Visible = true;
            uyeMezunToolStripMenuItem.Visible = false;
            grpbxMznBilgi.Visible = false;
            çıkışYapToolStripMenuItem.Visible = false;
            btnGuncelle.Visible = false;
            btnBilgiKaydet.Visible = true;
            uyeSirketToolStripMenuItem.Visible = false;
            grpbxHepElemanAra.Visible = false;

        }

        private void heapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grpbxHepElemanAra.Visible = true;
            HashTabloHazirla();

        }

        private void btnElemanAra_Click(object sender, EventArgs e)
        {
            lstbxMezunlar.Items.Clear();
            int dilTuru;

            if(cmbBoxDilAra.SelectedIndex==0)
            {
                dilTuru = 0;
            }
            else if (cmbBoxDilAra.SelectedIndex == 1)
            {
                dilTuru = 1;
            }
            else if (cmbBoxDilAra.SelectedIndex == 2)
            {
                dilTuru = 2;
            }
            else if (cmbBoxDilAra.SelectedIndex == 3)
            {
                dilTuru = 3;
            }
           
           
            else if(cmbBoxDilAra.SelectedIndex==4)
            {
                dilTuru = 4;
                
            }
            else
            {
                MessageBox.Show("Hatalı Dil Girişi");
                dilTuru = 5;
            }


            if (cmbxBolumAra.SelectedIndex==0)
            {
               BolumTumMmezunListele(yazilim,dilTuru);
            }
            else if (cmbxBolumAra.SelectedIndex == 1)
            {
                BolumTumMmezunListele(makina,dilTuru);
            }
            else if (cmbxBolumAra.SelectedIndex == 2)
            {
             BolumTumMmezunListele(mekatronik,dilTuru) ;
            }
            else if (cmbxBolumAra.SelectedIndex == 3)
            {
                BolumTumMmezunListele(enerji, dilTuru);
            }
            else if (cmbxBolumAra.SelectedIndex == 4)
            {
                BolumTumMmezunListele(endustri, dilTuru);
            }
            else if (cmbxBolumAra.SelectedIndex == 5)
            {
                BolumTumMmezunListele(otomotiv, dilTuru);
            }
            else if (cmbxBolumAra.SelectedIndex == 6)
            {
                BolumTumMmezunListele(bilisim, dilTuru);
            }
            else
            {
                MessageBox.Show("Hatalı bölüm girişi!");
                
            }
            btnTeklif.Visible = true;
        }

    
        private void btnTeklif_Click(object sender, EventArgs e)
        {
            if (cmbxBolumAra.SelectedIndex == 0)
            {
                MessageBox.Show(yazilim.EnUygunMezun().ogrenci.ad + " adlı kişiye iş teklifi gönderildi");
            }
          else   if(cmbxBolumAra.SelectedIndex == 1)
            {
                MessageBox.Show(makina.EnUygunMezun().ogrenci.ad + " adlı kişiye iş teklifi gönderildi");
            }
          else  if (cmbxBolumAra.SelectedIndex == 2)
            {
                MessageBox.Show(mekatronik.EnUygunMezun().ogrenci.ad + " adlı kişiye iş teklifi gönderildi");
            }
            else if (cmbxBolumAra.SelectedIndex == 3)
            {
                MessageBox.Show(enerji.EnUygunMezun().ogrenci.ad + " adlı kişiye iş teklifi gönderildi");
            }
            else if (cmbxBolumAra.SelectedIndex == 4)
            {
                MessageBox.Show(endustri.EnUygunMezun().ogrenci.ad + " adlı kişiye iş teklifi gönderildi");
            }
            else if (cmbxBolumAra.SelectedIndex == 5)
            {
                MessageBox.Show(otomotiv.EnUygunMezun().ogrenci.ad + " adlı kişiye iş teklifi gönderildi");
            }
            else if (cmbxBolumAra.SelectedIndex == 6)
            {
                MessageBox.Show(bilisim.EnUygunMezun().ogrenci.ad + " adlı kişiye iş teklifi gönderildi");
            }
        }
    }
}
