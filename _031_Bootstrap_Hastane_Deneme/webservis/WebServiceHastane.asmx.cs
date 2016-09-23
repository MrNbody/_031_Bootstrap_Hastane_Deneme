using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace _031_Bootstrap_Hastane_Deneme.webservis
{
    /// <summary>
    /// Summary description for WebServiceHastane
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceHastane : System.Web.Services.WebService
    {
        HastaneEntities db = new HastaneEntities();
        public int IlceID { get; set; }
        public string HastaneAdi { get; set; }

        [WebMethod]
        public bool Ekle()
        {
            try
            {
                Hastane hastane = new Hastane();
                hastane.hastaneAd = HastaneAdi;
                hastane.ilceID = IlceID;
                db.Hastanes.Add(hastane);
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
                string durum = db.Hastanes.Where(a => a.hastaneAd == HastaneAdi).FirstOrDefault().hastaneAd;
                return false;
            }
            catch (Exception)
            {
                return true;
            }
        }
    }
}
