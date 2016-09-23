using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _031_Bootstrap_Hastane_Deneme
{
    public partial class Giris : System.Web.UI.Page
    {
        classes.VeriKontrol VK = new classes.VeriKontrol();
        webservis.WebServiceUyeGiris uye = new webservis.WebServiceUyeGiris();
        //classes.UyeClass uye = new classes.UyeClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session.Abandon();
            }
        }

        protected void buttonGirisPanel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "loading();", true);
            panelKaydol.Visible = false;
            buttonGiris.Text = "Giriş Yap";
            up.Update();
        }

        protected void buttonKaydolPanel_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "loading();", true);
            panelKaydol.Visible = true;
            buttonGiris.Text = "Kayıt Ol";
            up.Update();
        }

        protected void buttonGiris_Click(object sender, EventArgs e)
        {
            if (buttonGiris.Text == "Giriş Yap")
            {
                classes.GirisClass giris = new classes.GirisClass();
                if (VK.Kontrol(textboxTc.Text))
                    giris.tc = textboxTc.Text;
                if (VK.Kontrol(textboxParola.Text))
                    giris.parola = textboxParola.Text;
                Uye uye = giris.UyeGirisYap();
                if (uye != null)
                {
                    Giriss(uye.uyeID, uye.uyeAd, uye.uyeSoyad);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Bilgilerinizi kontrol ediniz');", true);
                }
            }
            else if (buttonGiris.Text == "Kayıt Ol")
            {
                Kaydol();
            }
        }
        private void Giriss(int uyeID, string uyeAd, string uyeSoyad)
        {
            Session["uyeID"] = uyeID;
            Session["uyeAd"] = uyeAd;
            Session["uyeSoyad"] = uyeSoyad;
            Response.Redirect("Anasayfa.aspx");
        }
        private void Kaydol()
        {
            if (VK.Kontrol(textboxEmail.Text))
                uye.Email = textboxEmail.Text;
            if (VK.Kontrol(textboxParola.Text))
                uye.Sifre = textboxParola.Text;
            if (VK.Kontrol(textboxTc.Text))
                uye.Tc = textboxTc.Text;
            if (VK.Kontrol(textboxAd.Text))
                uye.Ad = textboxAd.Text;
            if (VK.Kontrol(textboxSoyad.Text))
                uye.Soyad = textboxSoyad.Text;
            if (VK.Kontrol(dropdawnlistCinsiyet.Text))
                uye.Cins = dropdawnlistCinsiyet.Text;
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


            if (uye.UyeKontrol(textboxTc.Text) != null)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Böyle bir TC ile zaten kayıt var');", true);
            }
            else
            {
                if (uye.Ekle() != 0)
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "yes('Kaydınız alınmıştır');", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Bilgilerinizi kontrol ediniz');", true);
            }
        }
    }
}