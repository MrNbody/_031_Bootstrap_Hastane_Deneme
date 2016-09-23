using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _031_Bootstrap_Hastane_Deneme.classes
{
    public class SaatClass
    {
        HastaneEntities db = new HastaneEntities();
        public TimeSpan SaatBaslama { get; set; }
        public TimeSpan SaatBitis { get; set; }
        public TimeSpan SaatPeriyot { get; set; }
        public TimeSpan SaatOgleBaslama { get; set; }
        public TimeSpan SaatOgleBitis { get; set; }

        public Saat Ekle(int doktorID)
        {
            try
            {
                Saat saat = new Saat();
                saat.doktorID = doktorID;
                saat.saatBaslama = SaatBaslama;
                saat.saatBitis = SaatBitis;
                saat.saatPeriyot = SaatPeriyot;
                saat.saatOgleBaslama = SaatOgleBaslama;
                saat.saatOgleBitis = SaatOgleBitis;
                db.Saats.Add(saat);
                db.SaveChanges();
                return saat;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Saat Guncelle(int doktorID)
        {
            try
            {
                Saat saat = db.Saats.Where(s => s.doktorID == doktorID).FirstOrDefault();
                saat.doktorID = doktorID;
                saat.saatBaslama = SaatBaslama;
                saat.saatBitis = SaatBitis;
                saat.saatPeriyot = SaatPeriyot;
                saat.saatOgleBaslama = SaatOgleBaslama;
                saat.saatOgleBitis = SaatOgleBitis;
                db.SaveChanges();
                return saat;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int Kontrol(int doktorID)
        {
            try
            {
                int saat = db.Saats.Where(s => s.doktorID == doktorID).FirstOrDefault().doktorID;
                return saat;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        public Saat Doldur(int doktorID)
        {
            try
            {
                var saat = db.Saats.Where(s => s.doktorID == doktorID).FirstOrDefault();
                return saat;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}