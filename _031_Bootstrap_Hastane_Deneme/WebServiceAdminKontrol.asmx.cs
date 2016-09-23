using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace _031_Bootstrap_Hastane_Deneme
{
    /// <summary>
    /// Summary description for WebServiceAdminKontrol
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceAdminKontrol : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        [WebMethod]
        public bool AdminKontrol(string username, string password)
        {
            if (username == "halitak" && password == "636363")
            {
                return true;
            }
            else
                return false;
        }
    }
}
