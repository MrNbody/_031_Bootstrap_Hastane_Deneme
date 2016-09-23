using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _031_Bootstrap_Hastane_Deneme.classes
{
    public class RandevuClass
    {
        HastaneEntities db = new HastaneEntities();
        public int UyeID { get; set; }
        public int DoktorID { get; set; }
        public DateTime TarihSaat { get; set; }

        public void Ekle()
        {
            Randevu randevu = new Randevu();
            randevu.uyeID = UyeID;
            randevu.doktorID = DoktorID;
            randevu.randevuTarihSaat = TarihSaat;
            db.Randevus.Add(randevu);
            db.SaveChanges();
        }
        public void Sil(int randevuID)
        {
            try
            {
                Randevu randevu = db.Randevus.Where(r => r.randevuID == randevuID).FirstOrDefault();
                db.Randevus.Remove(randevu);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<DateTime> Kontrol()
        {
            try
            {
                List<DateTime> randevu = db.Randevus.Where(r => r.randevuTarihSaat == TarihSaat && r.doktorID == DoktorID).Select(k => k.randevuTarihSaat).ToList();
                return randevu;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<viewRandevuDetay> GetirRandevu(int uyeID, DateTime tarihBaslangic, DateTime tarihBitis)
        {
            try
            {
                List<viewRandevuDetay> tut = new List<viewRandevuDetay>();
                List<viewRandevuDetay> randevuGecmis = db.viewRandevuDetays.Where(r => r.uyeID == uyeID).ToList();
                foreach (viewRandevuDetay item in randevuGecmis)
                {
                    if (item.randevuTarihSaat.Date >= tarihBaslangic && item.randevuTarihSaat.Date <= tarihBitis)
                    {
                        tut.Add(item);
                    }
                }
                return tut;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<viewRandevuDetay> GetirRandevu(int uyeID, DateTime tarih, bool a)
        {
            try
            {
                List<viewRandevuDetay> tut = new List<viewRandevuDetay>();
                List<viewRandevuDetay> randevuGecmis = db.viewRandevuDetays.Where(r => r.uyeID == uyeID).ToList();
                if (a)
                {
                    foreach (viewRandevuDetay item in randevuGecmis)
                    {
                        if (item.randevuTarihSaat.Date >= tarih)
                        {
                            tut.Add(item);
                        }
                    }
                }
                else
                {
                    foreach (viewRandevuDetay item in randevuGecmis)
                    {
                        if (item.randevuTarihSaat.Date <= tarih)
                        {
                            tut.Add(item);
                        }
                    }
                }
                return tut;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public viewRandevuDetay GetirRandevu(DateTime tarih)
        {
            try
            {
                viewRandevuDetay randevu = db.viewRandevuDetays.Where(r => r.randevuTarihSaat == tarih).FirstOrDefault();
                return randevu;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<string> GetirRandevuTarih()
        {
            List<string> tut = new List<string>();
            List<DateTime> listTarih = db.Randevus.Select(r => r.randevuTarihSaat).ToList();
            listTarih.Sort();
            foreach (var item in listTarih)
            {
                tut.Add(item.Date.ToShortDateString());
            }
            tut = tut.Distinct().ToList();
            return tut;
        }
        public List<viewRandevuDetay> GetirDoktor(int doktorID, DateTime tarih)
        {
            try
            {
                List<viewRandevuDetay> tut = new List<viewRandevuDetay>();
                List<viewRandevuDetay> randevuGecmis = db.viewRandevuDetays.Where(r => r.doktorID == doktorID).ToList();
                foreach (viewRandevuDetay item in randevuGecmis)
                {
                    if (item.randevuTarihSaat.Date == tarih)
                    {
                        tut.Add(item);
                    }
                }
                return tut;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}