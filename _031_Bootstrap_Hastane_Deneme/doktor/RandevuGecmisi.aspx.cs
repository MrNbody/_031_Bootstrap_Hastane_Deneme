using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme.doktor
{
    public partial class RandevuGecmisi : System.Web.UI.Page
    {
        static int randevuID;
        //classes.RandevuClass rGecmis = new classes.RandevuClass();
        webservis.WebServiceRandevu rGecmis = new webservis.WebServiceRandevu();
        static List<viewRandevuDetay> randevuDetay = new List<viewRandevuDetay>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                object uye = Session["doktorID"];
                if (uye == null)
                    Response.Redirect("Giris.aspx");
                else
                    RGecmisGetir();
            }
        }
        private void RGecmisGetir()
        {
            randevuDetay = JsonConvert.DeserializeObject<List<viewRandevuDetay>>
            (rGecmis.GetirRandevu(false,Convert.ToInt32(Session["doktorID"]),
            DateTime.Today, DateTime.Today));
            repeaterRandevuGecmis.DataSource = randevuDetay;
            repeaterRandevuGecmis.DataBind();
        }

        protected void repeaterRandevuGecmis_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item ||
                e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("labelRandevuDurum");
                foreach (viewRandevuDetay item in randevuDetay)
                {
                    if (item.randevuTarihSaat < DateTime.Now)
                        label.Text = "Geçmiş";
                    else
                        label.Text = "Geçmemiş";
                }
            }
        }

        protected void buttonRandevuGecmisAra_Click(object sender, EventArgs e)
        {
            if (textboxTarihBaslangic.Text == "" && textboxTarihBitis.Text == "")
                randevuDetay = JsonConvert.DeserializeObject<List<viewRandevuDetay>>
                (rGecmis.GetirRandevu(false,Convert.ToInt32(Session["doktorID"]), DateTime.Today, DateTime.Today));
            else if (textboxTarihBaslangic.Text != "" && textboxTarihBitis.Text == "")
                randevuDetay = JsonConvert.DeserializeObject<List<viewRandevuDetay>>
                (rGecmis.GetirRandevuu(false, Convert.ToInt32(Session["doktorID"]), Convert.ToDateTime(textboxTarihBaslangic.Text), true));
            else if (textboxTarihBaslangic.Text == "" && textboxTarihBitis.Text != "")
                randevuDetay = JsonConvert.DeserializeObject<List<viewRandevuDetay>>
                (rGecmis.GetirRandevuu(false, Convert.ToInt32(Session["doktorID"]), Convert.ToDateTime(textboxTarihBitis.Text), false));
            else if (textboxTarihBaslangic.Text != "" && textboxTarihBitis.Text != "")
                randevuDetay = JsonConvert.DeserializeObject<List<viewRandevuDetay>>
                (rGecmis.GetirRandevu(false, Convert.ToInt32(Session["doktorID"]), Convert.ToDateTime(textboxTarihBaslangic.Text),
                Convert.ToDateTime(textboxTarihBitis.Text)));
            repeaterRandevuGecmis.DataSource = randevuDetay;
            repeaterRandevuGecmis.DataBind();
        }

        protected void buttonDoktor_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            randevuID = Convert.ToInt32(btn.CommandArgument);
            up.Update();
        }

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            rGecmis.Sil(randevuID);
            RGecmisGetir();
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "yes('Randevunuz iptal edilmiştir');", true);
            up.Update();
        }
    }
}