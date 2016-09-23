using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme.webservis
{
    public class Randevuws
    {
        public int randevuID { get; set; }
        public int uyeID { get; set; }
        public int doktorID { get; set; }
        public DateTime randevuTarihSaat { get; set; }
    }
    public class viewRandevuws : Randevuws
    {
        public int klinikID { get; set; }
        public int hastaneID { get; set; }
        public int ilceID { get; set; }
        public int sehirID { get; set; }
        public string uyeAd { get; set; }
        public string doktorAd { get; set; }
        public string klinikAd { get; set; }
        public string hastaneAd { get; set; }
        public string ilceAd { get; set; }
        public string sehirAd { get; set; }
    }
    /// <summary>
    /// Summary description for WebServiceRandevu
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceRandevu : System.Web.Services.WebService
    {
        HastaneEntities db = new HastaneEntities();
        public int UyeID { get; set; }
        public int DoktorID { get; set; }
        public DateTime TarihSaat { get; set; }

        [WebMethod]
        public void Ekle()
        {
            try
            {
                Randevu randevu = new Randevu();
                randevu.uyeID = UyeID;
                randevu.doktorID = DoktorID;
                randevu.randevuTarihSaat = TarihSaat;
                db.Randevus.Add(randevu);
                db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
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

        [WebMethod]
        public string Kontrol()
        {
            string gidecekVeri = string.Empty;
            List<DateTime> randevu = db.Randevus.Where(r => r.randevuTarihSaat == TarihSaat && r.doktorID == DoktorID).Select(k => k.randevuTarihSaat).ToList();
            gidecekVeri = JsonConvert.SerializeObject(randevu);
            return gidecekVeri;
        }

        [WebMethod(MessageName = "CiftTarih")]
        public string GetirRandevu(bool a,int uyeID, DateTime tarihBaslangic, DateTime tarihBitis)
        {
            string gidecekVeri = string.Empty;
            List<viewRandevuws> list = new List<viewRandevuws>();
            viewRandevuws test;
            List<viewRandevuDetay> randevuGecmis = new List<viewRandevuDetay>();
            if (a)
                randevuGecmis = db.viewRandevuDetays.Where(r => r.uyeID == uyeID).ToList();
            else
                randevuGecmis = db.viewRandevuDetays.Where(r => r.doktorID == uyeID).ToList();
            foreach (var item in randevuGecmis)
            {
                if (item.randevuTarihSaat.Date >= tarihBaslangic && item.randevuTarihSaat.Date <= tarihBitis)
                {
                    test = new viewRandevuws();
                    test.randevuID = item.randevuID;
                    test.randevuTarihSaat = item.randevuTarihSaat;
                    test.uyeID = item.uyeID;
                    test.uyeAd = item.uyeAd;
                    test.doktorID = item.doktorID;
                    test.doktorAd = item.doktorAd;
                    test.klinikID = item.klinikID;
                    test.klinikAd = item.klinikAd;
                    test.hastaneID = item.hastaneID;
                    test.hastaneAd = item.hastaneAd;
                    test.ilceID = item.ilceID;
                    test.ilceAd = item.ilceAd;
                    test.sehirID = item.sehirID;
                    test.sehirAd = item.sehirAd;
                    list.Add(test);
                }
            }
            gidecekVeri = JsonConvert.SerializeObject(list);
            return gidecekVeri;
        }

        [WebMethod(MessageName = "TekTarih")]
        public string GetirRandevuu(bool a,int uyeID, DateTime tarih, bool b)
        {
            string gidecekVeri = string.Empty;
            List<viewRandevuws> list = new List<viewRandevuws>();
            viewRandevuws test;
            List<viewRandevuDetay> randevuGecmis = new List<viewRandevuDetay>();
            if (a)
                randevuGecmis = db.viewRandevuDetays.Where(r => r.uyeID == uyeID).ToList();
            else
                randevuGecmis = db.viewRandevuDetays.Where(r => r.doktorID == uyeID).ToList();
            if (b)
            {
                foreach (viewRandevuDetay item in randevuGecmis)
                {
                    if (item.randevuTarihSaat.Date >= tarih)
                    {
                        test = new viewRandevuws();
                        test.randevuID = item.randevuID;
                        test.randevuTarihSaat = item.randevuTarihSaat;
                        test.uyeID = item.uyeID;
                        test.uyeAd = item.uyeAd;
                        test.doktorID = item.doktorID;
                        test.doktorAd = item.doktorAd;
                        test.klinikID = item.klinikID;
                        test.klinikAd = item.klinikAd;
                        test.hastaneID = item.hastaneID;
                        test.hastaneAd = item.hastaneAd;
                        test.ilceID = item.ilceID;
                        test.ilceAd = item.ilceAd;
                        test.sehirID = item.sehirID;
                        test.sehirAd = item.sehirAd;
                        list.Add(test);
                    }
                }
            }
            else
            {
                foreach (viewRandevuDetay item in randevuGecmis)
                {
                    if (item.randevuTarihSaat.Date <= tarih)
                    {
                        test = new viewRandevuws();

                        test.randevuID = item.randevuID;
                        test.randevuTarihSaat = item.randevuTarihSaat;
                        test.uyeID = item.uyeID;
                        test.uyeAd = item.uyeAd;
                        test.doktorID = item.doktorID;
                        test.doktorAd = item.doktorAd;
                        test.klinikID = item.klinikID;
                        test.klinikAd = item.klinikAd;
                        test.hastaneID = item.hastaneID;
                        test.hastaneAd = item.hastaneAd;
                        test.ilceID = item.ilceID;
                        test.ilceAd = item.ilceAd;
                        test.sehirID = item.sehirID;
                        test.sehirAd = item.sehirAd;

                        list.Add(test);
                    }
                }
            }
            gidecekVeri = JsonConvert.SerializeObject(list);
            return gidecekVeri;
        }

        [WebMethod(MessageName = "Varsayilan")]
        public string GetirRandevuuu(DateTime tarih)
        {
            string gidecekVeri = string.Empty;
            viewRandevuws test = new viewRandevuws();
            viewRandevuDetay randevuGecmis = db.viewRandevuDetays.Where(r => r.randevuTarihSaat == tarih).FirstOrDefault();

            test.randevuID = randevuGecmis.randevuID;
            test.randevuTarihSaat = randevuGecmis.randevuTarihSaat;
            test.uyeID = randevuGecmis.uyeID;
            test.uyeAd = randevuGecmis.uyeAd;
            test.doktorID = randevuGecmis.doktorID;
            test.doktorAd = randevuGecmis.doktorAd;
            test.klinikID = randevuGecmis.klinikID;
            test.klinikAd = randevuGecmis.klinikAd;
            test.hastaneID = randevuGecmis.hastaneID;
            test.hastaneAd = randevuGecmis.hastaneAd;
            test.ilceID = randevuGecmis.ilceID;
            test.ilceAd = randevuGecmis.ilceAd;
            test.sehirID = randevuGecmis.sehirID;
            test.sehirAd = randevuGecmis.sehirAd;

            gidecekVeri = JsonConvert.SerializeObject(test);
            return gidecekVeri;
        }

        [WebMethod]
        public string GetirRandevuTarih()
        {
            string gidecekVeri = string.Empty;
            List<string> liste = new List<string>();
            List<DateTime> listTarih = db.Randevus.Select(r => r.randevuTarihSaat).ToList();
            listTarih.Sort();
            foreach (var item in listTarih)
            {
                liste.Add(item.Date.ToShortDateString());
            }
            liste = liste.Distinct().ToList();
            gidecekVeri = JsonConvert.SerializeObject(liste);
            return gidecekVeri;
        }

        [WebMethod]
        public string GetirDoktor(int doktorID, DateTime tarih)
        {
            string gidecekVeri = string.Empty;
            List<viewRandevuws> liste = new List<viewRandevuws>();
            viewRandevuws test;
            List<viewRandevuDetay> randevuGecmis = db.viewRandevuDetays.Where(r => r.doktorID == doktorID).ToList();
            foreach (viewRandevuDetay item in randevuGecmis)
            {
                if (item.randevuTarihSaat.Date == tarih)
                {
                    test = new viewRandevuws();
                    test.randevuID = item.randevuID;
                    test.randevuTarihSaat = item.randevuTarihSaat;
                    test.uyeID = item.uyeID;
                    test.uyeAd = item.uyeAd;
                    test.doktorID = item.doktorID;
                    test.doktorAd = item.doktorAd;
                    test.klinikID = item.klinikID;
                    test.klinikAd = item.klinikAd;
                    test.hastaneID = item.hastaneID;
                    test.hastaneAd = item.hastaneAd;
                    test.ilceID = item.ilceID;
                    test.ilceAd = item.ilceAd;
                    test.sehirID = item.sehirID;
                    test.sehirAd = item.sehirAd;
                    liste.Add(test);
                }
            }
            gidecekVeri = JsonConvert.SerializeObject(liste);
            return gidecekVeri;
        }
    }
}
