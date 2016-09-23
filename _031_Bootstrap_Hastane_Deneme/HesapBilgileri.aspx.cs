using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _031_Bootstrap_Hastane_Deneme
{
    public partial class HesapBilgileri : System.Web.UI.Page
    {
        classes.VeriKontrol VK = new classes.VeriKontrol();
        classes.Doldur uye = new classes.Doldur();
        //webservis.WebServiceDoldur uye = new webservis.WebServiceDoldur();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                object uye = Session["uyeID"];
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
            var liste = uye.TextBoxUye(Convert.ToInt32(Session["uyeID"]));
            textboxEmail.Text = liste.uyeEmail;
            textboxParola.Text = liste.uyeSifre;
            textboxTc.Text = liste.uyeTc;
            textboxAd.Text = liste.uyeAd;
            textboxSoyad.Text = liste.uyeSoyad;
            textboxCinsiyet.Text = liste.uyeCins;
            textboxDogumYeri.Text = liste.uyeDogumYer;
            textboxDogumTarihi.Text = liste.uyeDogumTarih.ToShortDateString();
            textboxBabaAdı.Text = liste.uyeBabaAd;
            textboxAnneAdı.Text = liste.uyeAnneAd;
            textboxTelefon.Text = liste.uyeTel;

        }

        protected void buttonKayıt_Click(object sender, EventArgs e)
        {
            classes.UyeClass uye = new classes.UyeClass();
            if (VK.Kontrol(textboxEmail.Text))
                uye.Email = textboxEmail.Text;
            if (VK.Kontrol(textboxParola.Text))
                uye.Sifre = textboxParola.Text;
            //if (VK.Kontrol(TextBoxTc.Text))
            //    uye.Tc = TextBoxTc.Text;
            if (VK.Kontrol(textboxAd.Text))
                uye.Ad = textboxAd.Text;
            if (VK.Kontrol(textboxSoyad.Text))
                uye.Soyad = textboxSoyad.Text;
            if (VK.Kontrol(textboxCinsiyet.Text))
                uye.Cins = textboxCinsiyet.Text;
            if (VK.Kontrol(textboxDogumYeri.Text))
                uye.DogumYeri = textboxDogumYeri.Text;
            if (VK.Kontrol(textboxDogumTarihi.Text))
                uye.DogumTarihi = Convert.ToDateTime(textboxDogumTarihi.Text);
            if (VK.Kontrol(textboxAnneAdı.Text))
                uye.AnneAd = textboxAnneAdı.Text;
            if (VK.Kontrol(textboxBabaAdı.Text))
                uye.BabaAd = textboxBabaAdı.Text;
            if (VK.Kontrol(textboxTelefon.Text))
                uye.Tel = textboxTelefon.Text;

            if (uye.Guncelle(Convert.ToInt32(Session["uyeID"])))
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "yes('Bilgileriniz güncellenmiştir');", true);
            else
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Bilgilerinizi kontrol ediniz');", true);
            up.Update();
        }
    }
}