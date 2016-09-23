using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme.webservis
{
    public class viewDoktorws
    {
        public int doktorID;
        public string doktorAd;
        public int klinikID;
        public string klinikAd;
        public int hastaneID;
        public string hastaneAd;
        public int ilceID;
        public string ilceAd;
        public int sehirID;
        public string sehirAd;
    }

    /// <summary>
    /// Summary description for WebServiceListele
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceListele : System.Web.Services.WebService
    {
        HastaneEntities db = new HastaneEntities();
        public string doktorID, klinikID, hastaneID, ilceID, sehirID;
        List<viewDoktor> doktor;
        
        public WebServiceListele(string doktorID, string klinikID, string hastaneID, string ilceID, string sehirID)
        {
            this.doktorID = doktorID;
            this.klinikID = klinikID;
            this.hastaneID = hastaneID;
            this.ilceID = ilceID;
            this.sehirID = sehirID;

            doktor = db.viewDoktors.Where(d => d.sehirAd == sehirID && d.ilceAd == ilceID && d.hastaneAd == hastaneID && d.klinikAd == klinikID && d.doktorAd.Contains(doktorID)).ToList();
        }
        public WebServiceListele(string klinikID, string hastaneID, string ilceID, string sehirID)
        {
            this.klinikID = klinikID;
            this.hastaneID = hastaneID;
            this.ilceID = ilceID;
            this.sehirID = sehirID;

            doktor = db.viewDoktors.Where(d => d.sehirAd == sehirID && d.ilceAd == ilceID && d.hastaneAd == hastaneID && d.klinikAd == klinikID).ToList();
        }
        public WebServiceListele(string hastaneID, string ilceID, string sehirID)
        {
            this.hastaneID = hastaneID;
            this.ilceID = ilceID;
            this.sehirID = sehirID;

            doktor = db.viewDoktors.Where(d => d.sehirAd == sehirID && d.ilceAd == ilceID && d.hastaneAd == hastaneID).ToList();
        }
        public WebServiceListele(string ilceID, string sehirID)
        {
            this.ilceID = ilceID;
            this.sehirID = sehirID;

            doktor = db.viewDoktors.Where(d => d.sehirAd == sehirID && d.ilceAd == ilceID).ToList();
        }
        public WebServiceListele(string sehirID)
        {
            this.sehirID = sehirID;

            doktor = db.viewDoktors.Where(d => d.sehirAd == sehirID).ToList();
        }

        [WebMethod]
        public string ListeleDoktor()
        {
            string gidecekVeri = string.Empty;
            List<viewDoktorws> list = new List<viewDoktorws>();
            viewDoktorws test;
            using (HastaneEntities db = new HastaneEntities())
            {
                foreach (var item in doktor)
                {
                    test = new viewDoktorws();
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
    }
}
