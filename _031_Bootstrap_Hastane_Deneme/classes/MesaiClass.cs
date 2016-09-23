using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _031_Bootstrap_Hastane_Deneme.classes
{
    public class MesaiClass
    {
        HastaneEntities db = new HastaneEntities();
        public TimeSpan MesaiSaat { get; set; }

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
        public List<Mesai> Getir(int doktorID)
        {
            try
            {
                List<Mesai> mesai = db.Mesais.Where(m => m.doktorID == doktorID).ToList();
                return mesai;
            }
            catch (Exception)
            {

                throw;
            }
        }
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