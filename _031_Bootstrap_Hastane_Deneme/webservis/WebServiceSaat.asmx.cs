using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme.webservis
{
    public class Saatws
    {
        public int saatID { get; set; }
        public int doktorID { get; set; }
        public TimeSpan saatBaslama { get; set; }
        public TimeSpan saatBitis { get; set; }
        public TimeSpan saatPeriyot { get; set; }
        public TimeSpan saatOgleBaslama { get; set; }
        public TimeSpan saatOgleBitis { get; set; }
    }
    /// <summary>
    /// Summary description for WebServiceSaat
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceSaat : System.Web.Services.WebService
    {
        HastaneEntities db = new HastaneEntities();
        public TimeSpan SaatBaslama { get; set; }
        public TimeSpan SaatBitis { get; set; }
        public TimeSpan SaatPeriyot { get; set; }
        public TimeSpan SaatOgleBaslama { get; set; }
        public TimeSpan SaatOgleBitis { get; set; }

        [WebMethod]
        public string Ekle(int doktorID)
        {
            string gidecekVeri = string.Empty;
            List<Saatws> list = new List<Saatws>();
            Saatws test;

            Saat saat = new Saat();
            saat.doktorID = doktorID;
            saat.saatBaslama = SaatBaslama;
            saat.saatBitis = SaatBitis;
            saat.saatPeriyot = SaatPeriyot;
            saat.saatOgleBaslama = SaatOgleBaslama;
            saat.saatOgleBitis = SaatOgleBitis;
            db.Saats.Add(saat);
            db.SaveChanges();

            test = new Saatws();
            test.saatID = saat.saatID;
            test.doktorID = saat.doktorID;
            test.saatBaslama = saat.saatBaslama;
            test.saatBitis = saat.saatBitis;
            test.saatPeriyot = saat.saatPeriyot;
            test.saatOgleBaslama = saat.saatOgleBaslama;
            test.saatOgleBitis = saat.saatOgleBitis;
            gidecekVeri = JsonConvert.SerializeObject(test);
            return gidecekVeri;
        }

        [WebMethod]
        public string Guncelle(int doktorID)
        {
            string gidecekVeri = string.Empty;
            List<Saatws> list = new List<Saatws>();
            Saatws test;
            Saat saat = db.Saats.Where(s => s.doktorID == doktorID).FirstOrDefault();
            saat.doktorID = doktorID;
            saat.saatBaslama = SaatBaslama;
            saat.saatBitis = SaatBitis;
            saat.saatPeriyot = SaatPeriyot;
            saat.saatOgleBaslama = SaatOgleBaslama;
            saat.saatOgleBitis = SaatOgleBitis;
            db.SaveChanges();

            test = new Saatws();
            test.saatID = saat.saatID;
            test.doktorID = saat.doktorID;
            test.saatBaslama = saat.saatBaslama;
            test.saatBitis = saat.saatBitis;
            test.saatPeriyot = saat.saatPeriyot;
            test.saatOgleBaslama = saat.saatOgleBaslama;
            test.saatOgleBitis = saat.saatOgleBitis;
            gidecekVeri = JsonConvert.SerializeObject(test);
            return gidecekVeri;
        }

        [WebMethod]
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

        [WebMethod]
        public string Doldur(int doktorID)
        {
            string gidecekVeri = string.Empty;
            Saatws test = new Saatws();
            Saat saat = db.Saats.Where(s => s.doktorID == doktorID).FirstOrDefault();
            test.saatID = saat.saatID;
            test.doktorID = saat.doktorID;
            test.saatBaslama = saat.saatBaslama;
            test.saatBitis = saat.saatBitis;
            test.saatPeriyot = saat.saatPeriyot;
            test.saatOgleBaslama = saat.saatOgleBaslama;
            test.saatOgleBitis = saat.saatOgleBitis;
            gidecekVeri = JsonConvert.SerializeObject(test);
            return gidecekVeri;
        }
    }
}
