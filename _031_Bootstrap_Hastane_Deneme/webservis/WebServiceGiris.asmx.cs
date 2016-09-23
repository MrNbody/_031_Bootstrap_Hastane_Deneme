using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme.webservis
{
    /// <summary>
    /// Summary description for WebServiceGiris
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceGiris : System.Web.Services.WebService
    {
        public string tc { get; set; }
        public string parola { get; set; }

        [WebMethod]
        public string UyeGirisYap()
        {
            string gidecekVeri = string.Empty;
            Uyews test;
            using (HastaneEntities db = new HastaneEntities())
            {
                Uye uye = db.Uyes.Where(u => u.uyeTc == tc && u.uyeSifre == parola).FirstOrDefault();
                test = new Uyews();
                test.uyeID = uye.uyeID;
                test.uyeAd = uye.uyeAd;
            }
            gidecekVeri = JsonConvert.SerializeObject(test);
            return gidecekVeri;
        }


        [WebMethod]
        public string DoktorGirisYap()
        {
            string gidecekVeri = string.Empty;
            Doktorws test;
            using (HastaneEntities db = new HastaneEntities())
            {
                Doktor doktor = db.Doktors.Where(u => u.doktorTc == tc && u.doktorSifre == parola).FirstOrDefault();
                test = new Doktorws();
                test.doktorID = doktor.doktorID;
                test.doktorAd = doktor.doktorAd;
            }
            gidecekVeri = JsonConvert.SerializeObject(test);
            return gidecekVeri;
        }
    }
}
