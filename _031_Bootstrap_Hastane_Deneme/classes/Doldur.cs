using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _031_Bootstrap_Hastane_Deneme.classes
{
    public class Doldur
    {
        HastaneEntities db = new HastaneEntities();
        public List<Sehir> DoldurSehir()
        {
            var sehir = db.Sehirs.ToList();
            return sehir;
        }
        public List<Ilce> DoldurIlce(int sehirID)
        {
            var ilce = db.Ilces.Where(k => k.sehirID == sehirID).ToList();
            return ilce;
        }
        public List<Hastane> DoldurHastane(int ilceID)
        {
            var hastane = db.Hastanes.Where(k => k.ilceID == ilceID).ToList();
            return hastane;
        }
        public List<Klinik> DoldurKlinik(int hastaneID)
        {
            var klinik = db.Kliniks.Where(k => k.hastaneID == hastaneID).ToList();
            return klinik;
        }
        public List<Doktor> DoldurDoktor(int klinikID)
        {
            var doktor = db.Doktors.Where(k => k.klinikID == klinikID).ToList();
            return doktor;
        }
        public Uye TextBoxUye(int uyeID)
        {
            var uye = db.Uyes.Where(u => u.uyeID == uyeID).FirstOrDefault();
            return uye;
        }
        public Doktor TextBoxDoktor(int doktorID)
        {
            var doktor = db.Doktors.Where(d => d.doktorID == doktorID).FirstOrDefault();
            return doktor;
        }
    }
}