using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme.doktor
{
    public partial class HesapBilgileri : System.Web.UI.Page
    {
        classes.VeriKontrol VK = new classes.VeriKontrol();
        //classes.Doldur doktor = new classes.Doldur();
        webservis.WebServiceDoldur doktor = new webservis.WebServiceDoldur();
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
                    Doldur();
            }
        }
        private void Doldur()
        {
            Doktor liste = JsonConvert.DeserializeObject<Doktor>(doktor.TextBoxDoktor(Convert.ToInt32(Session["doktorID"])));
            textboxEmail.Text = liste.doktorEmail;
            textboxParola.Text = liste.doktorSifre;
            textboxTc.Text = liste.doktorTc;
            textboxAd.Text = liste.doktorAd;
            textboxSoyad.Text = liste.doktorSoyad;
            textboxCinsiyet.Text = liste.doktorCinsiyet;
            textboxTelefon.Text = liste.doktorTel;

        }

        protected void buttonKayıt_Click(object sender, EventArgs e)
        {
            classes.DoktorClass uye = new classes.DoktorClass();
            if (VK.Kontrol(textboxEmail.Text))
                uye.Email = textboxEmail.Text;
            if (VK.Kontrol(textboxParola.Text))
                uye.Parola = textboxParola.Text;
            //if (VK.Kontrol(TextBoxTc.Text))
            //    uye.Tc = TextBoxTc.Text;
            if (VK.Kontrol(textboxAd.Text))
                uye.Ad = textboxAd.Text;
            if (VK.Kontrol(textboxSoyad.Text))
                uye.Soyad = textboxSoyad.Text;
            if (VK.Kontrol(textboxCinsiyet.Text))
                uye.Cinsiyet = textboxCinsiyet.Text;
            if (VK.Kontrol(textboxTelefon.Text))
                uye.Telefon = textboxTelefon.Text;

            if (uye.Guncelle(Convert.ToInt32(Session["doktorID"])))
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "yes('Bilgileriniz güncellenmiştir');", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Bilgilerinizi kontrol ediniz');", true);
            up.Update();
        }
    }
}