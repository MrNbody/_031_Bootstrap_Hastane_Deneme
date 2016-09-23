using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
namespace _031_Bootstrap_Hastane_Deneme.webservis
{
    public class Sehirws
    {
        public int sehirID { set; get; }
        public string sehirAd { set; get; }
    }
    public class Ilcews
    {
        public int ilceID { set; get; }
        public string ilceAd { set; get; }
    }
    public class Hastanews
    {
        public int hastaneID { set; get; }
        public string hastaneAd { set; get; }
    }
    public class Klinikws
    {
        public int klinikID { set; get; }
        public string klinikAd { set; get; }
    }
    public class Doktorws
    {
        public int doktorID { set; get; }
        public string doktorAd { set; get; }
        public string doktorSoyad { set; get; }
        public string doktorTc { set; get; }
        public string doktorTel { set; get; }
        public string doktorCinsiyet { set; get; }
        public string doktorEmail { set; get; }
        public string doktorSifre { set; get; }
    }
    public class Uyews
    {
        public int uyeID { set; get; }
        public string uyeTc { get; set; }
        public string uyeAd { set; get; }
        public string uyeSoyad { set; get; }
        public string uyeCins { set; get; }
        public string uyeDogumYer { set; get; }
        public DateTime uyeDogumTarih { set; get; }
        public string uyeBabaAd { set; get; }
        public string uyeAnneAd { set; get; }
        public string uyeTel { set; get; }
        public string uyeEmail { set; get; }
        public string uyeSifre { set; get; }
    }
    /// <summary>
    /// Summary description for WebServiceDoldur
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceDoldur : System.Web.Services.WebService
    {
        [WebMethod]
        public string DoldurSehir()
        {
            string retval = string.Empty;
            List<Sehirws> list = new List<Sehirws>();
            Sehirws test;
            using (HastaneEntities db = new HastaneEntities())
            {
                List<Sehir> sehir = db.Sehirs.ToList();
                foreach (var item in sehir)
                {

                    test = new Sehirws();
                    test.sehirID = item.sehirID;
                    test.sehirAd = item.sehirAd;
                    list.Add(test);
                }
            }
            retval = JsonConvert.SerializeObject(list);
            return retval;
        }

        [WebMethod]
        public string DoldurIlce(int sehirID)
        {
            string retval = string.Empty;
            List<Ilcews> list = new List<Ilcews>();
            Ilcews test;
            using (HastaneEntities db = new HastaneEntities())
            {
                List<Ilce> ilce = db.Ilces.Where(k => k.sehirID == sehirID).ToList();
                foreach (var item in ilce)
                {

                    test = new Ilcews();
                    test.ilceID = item.ilceID;
                    test.ilceAd = item.ilceAd;
                    list.Add(test);
                }
            }
            retval = JsonConvert.SerializeObject(list);
            return retval;
        }

        [WebMethod]
        public string DoldurHastane(int ilceID)
        {
            string retval = string.Empty;
            List<Hastanews> list = new List<Hastanews>();
            Hastanews test;
            using (HastaneEntities db = new HastaneEntities())
            {
                List<Hastane> hastane = db.Hastanes.Where(k => k.ilceID == ilceID).ToList();
                foreach (var item in hastane)
                {

                    test = new Hastanews();
                    test.hastaneID = item.hastaneID;
                    test.hastaneAd = item.hastaneAd;
                    list.Add(test);
                }
            }
            retval = JsonConvert.SerializeObject(list);
            return retval;
        }

        [WebMethod]
        public string DoldurKlinik(int hastaneID)
        {
            string retval = string.Empty;
            List<Klinikws> list = new List<Klinikws>();
            Klinikws test;
            using (HastaneEntities db = new HastaneEntities())
            {
                List<Klinik> klinik = db.Kliniks.Where(k => k.hastaneID == hastaneID).ToList();
                foreach (var item in klinik)
                {

                    test = new Klinikws();
                    test.klinikID = item.klinikID;
                    test.klinikAd = item.klinikAd;
                    list.Add(test);
                }
            }
            retval = JsonConvert.SerializeObject(list);
            return retval;
        }

        [WebMethod]
        public string DoldurDoktor(int klinikID)
        {
            string retval = string.Empty;
            List<Doktorws> list = new List<Doktorws>();
            Doktorws test;
            using (HastaneEntities db = new HastaneEntities())
            {
                List<Doktor> doktor = db.Doktors.Where(k => k.klinikID == klinikID).ToList();
                foreach (var item in doktor)
                {

                    test = new Doktorws();
                    test.doktorID = item.doktorID;
                    test.doktorAd = item.doktorAd;
                    test.doktorSoyad = item.doktorSoyad;
                    test.doktorTc = item.doktorTc;
                    test.doktorTel = item.doktorTel;
                    test.doktorCinsiyet = item.doktorCinsiyet;
                    test.doktorEmail = item.doktorEmail;
                    test.doktorSifre = item.doktorSifre;
                    list.Add(test);
                }
            }
            retval = JsonConvert.SerializeObject(list);
            return retval;
        }

        [WebMethod]
        public string TextBoxUye(int uyeID)
        {
            string retval = string.Empty;
            List<Uyews> list = new List<Uyews>();
            Uyews test;
            using (HastaneEntities db = new HastaneEntities())
            {
                Uye uye = db.Uyes.Where(u => u.uyeID == uyeID).FirstOrDefault();
                test = new Uyews();
                test.uyeID = uye.uyeID;
                test.uyeTc = uye.uyeTc;
                test.uyeAd = uye.uyeAd;
                test.uyeSoyad = uye.uyeSoyad;
                test.uyeCins = uye.uyeCins;
                test.uyeDogumYer = uye.uyeDogumYer;
                test.uyeDogumTarih = uye.uyeDogumTarih;
                test.uyeBabaAd = uye.uyeBabaAd;
                test.uyeAnneAd = uye.uyeAnneAd;
                test.uyeTel = uye.uyeTel;
                test.uyeEmail = uye.uyeEmail;
                test.uyeSifre = uye.uyeSifre;
            }
            retval = JsonConvert.SerializeObject(test);
            return retval;
        }

        [WebMethod]
        public string TextBoxDoktor(int doktorID)
        {
            string retval = string.Empty;
            List<Doktorws> list = new List<Doktorws>();
            Doktorws test;
            using (HastaneEntities db = new HastaneEntities())
            {
                Doktor doktor = db.Doktors.Where(d => d.doktorID == doktorID).FirstOrDefault();
                test = new Doktorws();
                test.doktorID = doktor.doktorID;
                test.doktorAd = doktor.doktorAd;
                test.doktorSoyad = doktor.doktorSoyad;
                test.doktorTc = doktor.doktorTc;
                test.doktorTel = doktor.doktorTel;
                test.doktorCinsiyet = doktor.doktorCinsiyet;
                test.doktorEmail = doktor.doktorEmail;
                test.doktorSifre = doktor.doktorSifre;
            }
            retval = JsonConvert.SerializeObject(test);
            return retval;
        }
    }
}
