using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace _031_Bootstrap_Hastane_Deneme.webservis
{
    /// <summary>
    /// Summary description for WebServiceKlinik
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceKlinik : System.Web.Services.WebService
    {
        HastaneEntities db = new HastaneEntities();
        public int HastaneID { get; set; }
        public string KlinikAdi { get; set; }

        [WebMethod]
        public bool Ekle()
        {
            try
            {
                Klinik klinik = new Klinik();
                klinik.klinikAd = KlinikAdi;
                klinik.hastaneID = HastaneID;
                db.Kliniks.Add(klinik);
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
                string durum = db.Kliniks.Where(a => a.klinikAd == KlinikAdi).FirstOrDefault().klinikAd;
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
