using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace _031_Bootstrap_Hastane_Deneme.webservis
{
    /// <summary>
    /// Summary description for WebServiceUyeGiris
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
     [System.Web.Script.Services.ScriptService]
    public class WebServiceUyeGiris : System.Web.Services.WebService
    {
        HastaneEntities db = new HastaneEntities();
        public string Email { get; set; }
        public string Sifre { get; set; }
        public string Tc { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Cins { get; set; }
        public string DogumYeri { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string AnneAd { get; set; }
        public string BabaAd { get; set; }
        public string Tel { get; set; }

        [WebMethod]
        public bool Guncelle(int uyeID)
        {
            try
            {
                Uye uye = db.Uyes.Where(u => u.uyeID == uyeID).FirstOrDefault();
                uye.uyeEmail = Email;
                uye.uyeSifre = Sifre;
                uye.uyeAd = Ad;
                uye.uyeSoyad = Soyad;
                uye.uyeCins = Cins;
                uye.uyeDogumYer = DogumYeri;
                uye.uyeDogumTarih = DogumTarihi;
                uye.uyeAnneAd = AnneAd;
                uye.uyeBabaAd = BabaAd;
                uye.uyeTel = Tel;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        [WebMethod]
        public int Ekle()
        {
            try
            {
                Uye uye = new Uye();
                uye.uyeEmail = Email;
                uye.uyeSifre = Sifre;
                uye.uyeTc = Tc;
                uye.uyeAd = Ad;
                uye.uyeSoyad = Soyad;
                uye.uyeCins = Cins;
                uye.uyeDogumYer = DogumYeri;
                uye.uyeDogumTarih = DogumTarihi;
                uye.uyeAnneAd = AnneAd;
                uye.uyeBabaAd = BabaAd;
                uye.uyeTel = Tel;
                db.Uyes.Add(uye);
                db.SaveChanges();
                return uye.uyeID;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
        [WebMethod]
        public string UyeKontrol(string uyeTC)
        {
            try
            {
                string uye = db.Uyes.Where(u => u.uyeTc == uyeTC).FirstOrDefault().uyeTc;
                return uye;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }
    }
}
