using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _031_Bootstrap_Hastane_Deneme.classes
{
    public class DoktorClass
    {
        HastaneEntities db = new HastaneEntities();
        public string Email { get; set; }
        public string Parola { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Tc { get; set; }
        public string Telefon { get; set; }
        public string Cinsiyet { get; set; }
        public int Klinik { get; set; }

        public bool Ekle()
        {
            try
            {
                Doktor doktor = new Doktor();
                doktor.doktorEmail = Email;
                doktor.doktorSifre = Parola;
                doktor.doktorAd = Ad;
                doktor.doktorSoyad = Soyad;
                doktor.doktorTc = Tc;
                doktor.doktorTel = Telefon;
                doktor.doktorCinsiyet = Cinsiyet;
                doktor.klinikID = Klinik;
                db.Doktors.Add(doktor);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
        public bool Guncelle(int doktorID)
        {
            try
            {
                var doktor = db.Doktors.Where(d => d.doktorID == doktorID).FirstOrDefault();
                doktor.doktorEmail = Email;
                doktor.doktorSifre = Parola;
                //doktor.doktorTc = Tc;
                doktor.doktorAd = Ad;
                doktor.doktorSoyad = Soyad;
                doktor.doktorCinsiyet = Cinsiyet;
                doktor.doktorTel = Telefon;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }
    }
}