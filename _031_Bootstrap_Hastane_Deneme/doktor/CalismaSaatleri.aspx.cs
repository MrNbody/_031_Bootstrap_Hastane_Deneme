using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme.doktor
{
    public partial class CalismaSaatleri : System.Web.UI.Page
    {
        classes.VeriKontrol VK = new classes.VeriKontrol();
        //classes.SaatClass saat = new classes.SaatClass();
        webservis.WebServiceSaat saat = new webservis.WebServiceSaat();
        //classes.MesaiClass mesaiClass = new classes.MesaiClass();
        webservis.WebServiceMesai mesaiClass = new webservis.WebServiceMesai();
        static int doktorID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                object uye = Session["doktorID"];
                if (uye == null)
                {
                    Response.Redirect("Giris.aspx");
                }
                else
                {
                    doktorID = Convert.ToInt32(Session["doktorID"]);
                    if (saat.Kontrol(doktorID) != 0)
                    {
                        buttonKaydet.Text = "Guncelle";
                        Doldur();
                    }
                    else
                        buttonKaydet.Text = "Ekle";
                }
            }
        }
        private void Ekle()
        {
            if (VK.Kontrol(textboxBaslamaSaati.Text))
                saat.SaatBaslama = TimeSpan.Parse(textboxBaslamaSaati.Text);
            if (VK.Kontrol(textboxBitisSaati.Text))
                saat.SaatBitis = TimeSpan.Parse(textboxBitisSaati.Text);
            if (VK.Kontrol(textboxCalismaPeriyodu.Text))
                saat.SaatPeriyot = TimeSpan.Parse(textboxCalismaPeriyodu.Text);
            if (VK.Kontrol(textboxOgleBaslangıcSaati.Text))
                saat.SaatOgleBaslama = TimeSpan.Parse(textboxOgleBaslangıcSaati.Text);
            if (VK.Kontrol(textboxOgleBitisSaati.Text))
                saat.SaatOgleBitis = TimeSpan.Parse(textboxOgleBitisSaati.Text);
            if (saat.Ekle(doktorID)!=null)
            {
                Mesai(saat);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "yes('Çalışma saatleriniz eklenmiştir');", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Çalışma saatlerinizi kontrol ediniz');", true);
        }
        private void Guncelle()
        {
            if (VK.Kontrol(textboxBaslamaSaati.Text))
                saat.SaatBaslama = TimeSpan.Parse(textboxBaslamaSaati.Text);
            if (VK.Kontrol(textboxBitisSaati.Text))
                saat.SaatBitis = TimeSpan.Parse(textboxBitisSaati.Text);
            if (VK.Kontrol(textboxCalismaPeriyodu.Text))
                saat.SaatPeriyot = TimeSpan.Parse(textboxCalismaPeriyodu.Text);
            if (VK.Kontrol(textboxOgleBaslangıcSaati.Text))
                saat.SaatOgleBaslama = TimeSpan.Parse(textboxOgleBaslangıcSaati.Text);
            if (VK.Kontrol(textboxOgleBitisSaati.Text))
                saat.SaatOgleBitis = TimeSpan.Parse(textboxOgleBitisSaati.Text);

            if (saat.Guncelle(doktorID)!=null)
            {
                Mesai(saat);
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "yes('Çalışma saatleriniz güncellenmiştir');", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Çalışma saatlerinizi kontrol ediniz');", true);
        }
        private void Doldur()
        {
            Saat saatDoldur = JsonConvert.DeserializeObject<Saat>(saat.Doldur(doktorID));
            textboxBaslamaSaati.Text = saatDoldur.saatBaslama.ToString();
            textboxBitisSaati.Text = saatDoldur.saatBitis.ToString();
            textboxCalismaPeriyodu.Text = saatDoldur.saatPeriyot.ToString();
            textboxOgleBaslangıcSaati.Text = saatDoldur.saatOgleBaslama.ToString();
            textboxOgleBitisSaati.Text = saatDoldur.saatOgleBitis.ToString();
        }

        protected void buttonKaydet_Click(object sender, EventArgs e)
        {
            if (buttonKaydet.Text == "Guncelle")
                Guncelle();
            else if (buttonKaydet.Text == "Ekle")
                Ekle();
            up.Update();
        }
        private void Mesai(webservis.WebServiceSaat saat)
        {
            TimeSpan mesai = saat.SaatBaslama;
            if (mesaiClass.Kontrol(doktorID) == 0)
            {
                MesaiEkle(mesai);
            }
            else
            {
                mesaiClass.Sil(doktorID);
                MesaiEkle(mesai);
            }
        }
        private TimeSpan SaatHesap(TimeSpan baslama, TimeSpan periyot)
        {
            return baslama + periyot;
        }
        private void MesaiEkle(TimeSpan mesai)
        {
            while (SaatHesap(mesai, saat.SaatPeriyot) < saat.SaatBitis)
            {
                if (SaatHesap(mesai, saat.SaatPeriyot) >= saat.SaatOgleBaslama && SaatHesap(mesai, saat.SaatPeriyot) <= saat.SaatOgleBitis)
                {
                    mesai = SaatHesap(mesai, saat.SaatPeriyot);
                    continue;
                }
                else
                {
                    mesai = SaatHesap(mesai, saat.SaatPeriyot);
                    mesaiClass.Ekle(doktorID, mesai);
                }
            }
        }
    }
}