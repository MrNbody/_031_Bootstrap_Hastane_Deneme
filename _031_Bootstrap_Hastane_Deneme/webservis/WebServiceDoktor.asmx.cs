using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace _031_Bootstrap_Hastane_Deneme.webservis
{
    /// <summary>
    /// Summary description for WebServiceDoktor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceDoktor : System.Web.Services.WebService
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

        [WebMethod]
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

        [WebMethod]
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


        [WebMethod]
        public bool Kontrol()
        {
            try
            {
                string durum = db.Doktors.Where(a => a.doktorTc == Tc).FirstOrDefault().doktorTc;
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
