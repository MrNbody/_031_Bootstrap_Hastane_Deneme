using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _031_Bootstrap_Hastane_Deneme.classes
{
    public class KlinikClass
    {
        HastaneEntities db = new HastaneEntities();
        public int HastaneID { get; set; }
        public string KlinikAdi { get; set; }
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
    }
}