using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _031_Bootstrap_Hastane_Deneme.classes
{
    public class Listele
    {
        HastaneEntities db = new HastaneEntities();
        public string doktorID, klinikID, hastaneID, ilceID, sehirID;
        List<viewDoktor> doktor;

        public Listele(string doktorID, string klinikID, string hastaneID, string ilceID, string sehirID)
        {
            this.doktorID = doktorID;
            this.klinikID = klinikID;
            this.hastaneID = hastaneID;
            this.ilceID = ilceID;
            this.sehirID = sehirID;

            doktor = db.viewDoktors.Where(d => d.sehirAd == sehirID && d.ilceAd == ilceID && d.hastaneAd == hastaneID && d.klinikAd == klinikID && d.doktorAd.Contains(doktorID)).ToList();
        }
        public Listele(string klinikID, string hastaneID, string ilceID, string sehirID)
        {
            this.klinikID = klinikID;
            this.hastaneID = hastaneID;
            this.ilceID = ilceID;
            this.sehirID = sehirID;

            doktor = db.viewDoktors.Where(d => d.sehirAd == sehirID && d.ilceAd == ilceID && d.hastaneAd == hastaneID && d.klinikAd == klinikID).ToList();
        }
        public Listele(string hastaneID, string ilceID, string sehirID)
        {
            this.hastaneID = hastaneID;
            this.ilceID = ilceID;
            this.sehirID = sehirID;

            doktor = db.viewDoktors.Where(d => d.sehirAd == sehirID && d.ilceAd == ilceID && d.hastaneAd == hastaneID).ToList();
        }
        public Listele(string ilceID, string sehirID)
        {
            this.ilceID = ilceID;
            this.sehirID = sehirID;

            doktor = db.viewDoktors.Where(d => d.sehirAd == sehirID && d.ilceAd == ilceID).ToList();
        }
        public Listele(string sehirID)
        {
            this.sehirID = sehirID;

            doktor = db.viewDoktors.Where(d => d.sehirAd == sehirID).ToList();
        }

        public List<viewDoktor> ListeleDoktor()
        {
            return doktor;
        }
    }
}