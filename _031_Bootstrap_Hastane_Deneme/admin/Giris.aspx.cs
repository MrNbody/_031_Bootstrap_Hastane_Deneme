using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _031_Bootstrap_Hastane_Deneme.admin
{
    public partial class Giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session.Abandon();
            }
        }

        protected void buttonGiris_Click(object sender, EventArgs e)
        {
            ServiceReference.WebServiceAdminKontrolSoapClient kontrol = new ServiceReference.WebServiceAdminKontrolSoapClient();
            if (kontrol.AdminKontrol(textboxKullaniciAdi.Text,textboxParola.Text))
            {
                Session["admin"] = textboxKullaniciAdi.Text;
                Response.Redirect("Anasayfa.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Bilgilerinizi kontrol ediniz');", true);
            }
            up.Update();
        }
    }
}