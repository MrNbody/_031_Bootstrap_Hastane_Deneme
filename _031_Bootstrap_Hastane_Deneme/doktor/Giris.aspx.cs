using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme.doktor
{
    public partial class Giris : System.Web.UI.Page
    {
        classes.VeriKontrol VK = new classes.VeriKontrol();
        //classes.GirisClass giris = new classes.GirisClass();
        webservis.WebServiceGiris giris = new webservis.WebServiceGiris();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session.Abandon();
            }

        }

        protected void buttonGiris_Click(object sender, EventArgs e)
        {
            if (VK.Kontrol(textboxTc.Text))
                giris.tc = textboxTc.Text;
            if (VK.Kontrol(textboxParola.Text))
                giris.parola = textboxParola.Text;
            Doktor doktor = JsonConvert.DeserializeObject<Doktor>(giris.DoktorGirisYap());
            if (doktor != null)
            {
                Giriss(doktor);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Bilgilerinizi kontrol ediniz');", true);
            up.Update();
        }
        private void Giriss(Doktor doktor)
        {
            Session["doktorID"] = doktor.doktorID;
            Session["doktoAd"] = doktor.doktorAd;
            Session["doktoSoyad"] = doktor.doktorSoyad;
            Response.Redirect("Anasayfa.aspx");
        }
    }
}