using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _031_Bootstrap_Hastane_Deneme.classes
{
    public class HastaneClass
    {
        HastaneEntities db = new HastaneEntities();
        public int IlceID { get; set; }
        public string HastaneAdi { get; set; }
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
    }
}