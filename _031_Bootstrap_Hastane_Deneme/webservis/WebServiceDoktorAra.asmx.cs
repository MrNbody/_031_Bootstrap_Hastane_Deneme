using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace _031_Bootstrap_Hastane_Deneme.webservis
{
    /// <summary>
    /// Summary description for WebServiceDoktorAra
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class WebServiceDoktorAra : System.Web.Services.WebService
    {
        HastaneEntities db = new HastaneEntities();
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string[] DoktorGetir(string prefix)
        {
            List<string> list = new List<string>();
            List<Doktor> doktor = db.Doktors.Where(o => o.doktorAd.Contains(prefix) || o.doktorSoyad.Contains(prefix)).ToList();
            foreach (Doktor item in doktor)
            {
                list.Add(string.Format("{0}-{1}", (item.doktorAd + " " + item.doktorSoyad), item.doktorID));
            }
            return list.ToArray();
        }
    }
}
