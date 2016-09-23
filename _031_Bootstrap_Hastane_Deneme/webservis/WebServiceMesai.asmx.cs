using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme.webservis
{
    public class Mesaiws
    {
        public int mesaiID { get; set; }
        public int doktorID { get; set; }
        public TimeSpan mesaiSaat { get; set; }
    }

    /// <summary>
    /// Summary description for WebServiceMesai
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceMesai : System.Web.Services.WebService
    {
        HastaneEntities db = new HastaneEntities();
        public TimeSpan MesaiSaat { get; set; }

        [WebMethod]
        public void Ekle(int doktorID, TimeSpan mesaiSaat)
        {
            try
            {
                Mesai mesai = new Mesai();
                mesai.doktorID = doktorID;
                mesai.mesaiSaat = mesaiSaat;
                db.Mesais.Add(mesai);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [WebMethod]
        public void Guncelle(int doktorID, TimeSpan mesaiSaat)
        {
            try
            {
                Mesai mesai = db.Mesais.Where(m => m.doktorID == doktorID).FirstOrDefault();
                mesai.doktorID = doktorID;
                mesai.mesaiSaat = mesaiSaat;
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [WebMethod]
        public string Getir(int doktorID)
        {
            string gidecekVeri = string.Empty;
            List<Mesaiws> list = new List<Mesaiws>();
            Mesaiws test;
            List<Mesai> mesai = db.Mesais.Where(m => m.doktorID == doktorID).ToList();
            foreach (var item in mesai)
            {
                test = new Mesaiws();
                test.mesaiID = item.mesaiID;
                test.doktorID = item.doktorID;
                test.mesaiSaat = item.mesaiSaat;
                list.Add(test);
            }
            gidecekVeri = JsonConvert.SerializeObject(list);
            return gidecekVeri;
        }

        [WebMethod]
        public int Kontrol(int doktorID)
        {
            try
            {
                int mesai = db.Mesais.Where(m => m.doktorID == doktorID).Count();
                return mesai;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [WebMethod]
        public void Sil(int doktorID)
        {
            try
            {
                IQueryable<Mesai> mesai = db.Mesais.Where(m => m.doktorID == doktorID);
                db.Mesais.RemoveRange(mesai);
                db.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
