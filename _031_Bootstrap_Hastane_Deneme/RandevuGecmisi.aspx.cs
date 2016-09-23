using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme
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
                object uye = Session["uyeID"];
                if (uye == null)
                {
                    Response.Redirect("Giris.aspx");
                }
                else
                {
                //    RTarihGetir();
                //    dropdawnlistTarih.Items.Insert(0, new ListItem("Tarih Seçiniz"));
                    RGecmisGetir();
                }
            }
        }
        //private void RTarihGetir()
        //{
        //    dropdawnlistTarih.DataSource = rGecmis.GetirRandevuTarih();
        //    dropdawnlistTarih.DataBind();
        //}
        private void RGecmisGetir()
        {
            randevuDetay =JsonConvert.DeserializeObject<List<viewRandevuDetay>>(rGecmis.GetirRandevu(true,Convert.ToInt32(Session["uyeID"]), DateTime.Today, DateTime.Today));
            repeaterRandevuGecmis.DataSource = randevuDetay;
            repeaterRandevuGecmis.DataBind();
        }
        //protected void buttonDoktor_Click(object sender, EventArgs e)
        //{
        //    //ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "return iptal2();", true);
        //    Button btn = (Button)sender;
        //    int randevuID = Convert.ToInt32(btn.CommandArgument);
        //    rGecmis.Sil(randevuID);
        //    RGecmisGetir();
        //    //ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "yes('Randevunuz iptal edilmiştir');", true);
        //    up.Update();
        //}

        protected void buttonLogin_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "return iptal2();", true);
            //LinkButton btn = (LinkButton)sender;
            //int randevuID = Convert.ToInt32(btn.CommandArgument);
            rGecmis.Sil(randevuID);
            RGecmisGetir();
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "yes('Randevunuz iptal edilmiştir');", true);
            up.Update();
        }

        protected void buttonDoktor_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            randevuID = Convert.ToInt32(btn.CommandArgument);
            up.Update();
        }

        protected void repeaterRandevuGecmis_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label label = (Label)e.Item.FindControl("labelRandevuDurum");

                foreach (viewRandevuDetay item in randevuDetay)
                {
                    if (item.randevuTarihSaat<DateTime.Now)
                    {
                        label.Text = "Geçmiş";
                    }
                    else
                    {
                        label.Text = "Geçmemiş";
                    }
                }
            }
        }

        protected void buttonRandevuGecmisAra_Click(object sender, EventArgs e)
        {
            if (textboxTarihBaslangic.Text == "" && textboxTarihBitis.Text=="")
            {
                randevuDetay = JsonConvert.DeserializeObject<List<viewRandevuDetay>>(rGecmis.GetirRandevu(true, Convert.ToInt32(Session["uyeID"]), DateTime.Today, DateTime.Today));
            }
            else if (textboxTarihBaslangic.Text != "" && textboxTarihBitis.Text == "")
            {
                randevuDetay = JsonConvert.DeserializeObject<List<viewRandevuDetay>>(rGecmis.GetirRandevuu(true, Convert.ToInt32(Session["uyeID"]), Convert.ToDateTime(textboxTarihBaslangic.Text), true));
            }
            else if (textboxTarihBaslangic.Text == "" && textboxTarihBitis.Text != "")
            {
                randevuDetay = JsonConvert.DeserializeObject<List<viewRandevuDetay>>(rGecmis.GetirRandevuu(true, Convert.ToInt32(Session["uyeID"]), Convert.ToDateTime(textboxTarihBitis.Text), false));
            }
            else if(textboxTarihBaslangic.Text != "" && textboxTarihBitis.Text != "")
            {
                randevuDetay = JsonConvert.DeserializeObject<List<viewRandevuDetay>>(rGecmis.GetirRandevu(true, Convert.ToInt32(Session["uyeID"]), Convert.ToDateTime(textboxTarihBaslangic.Text), Convert.ToDateTime(textboxTarihBitis.Text)));
            }
            repeaterRandevuGecmis.DataSource = randevuDetay;
            repeaterRandevuGecmis.DataBind();
        }

        //protected void dropdawnlistTarih_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (dropdawnlistTarih.Text == "Tarih Seçiniz")
        //    {

        //    }
        //    else if (dropdawnlistTarih.Text == "") 
        //    {
        //        randevuDetay = rGecmis.GetirRandevu(Convert.ToInt32(Session["uyeID"]), DateTime.Today);
        //    }
        //    else
        //    {
        //        randevuDetay = rGecmis.GetirRandevu(Convert.ToInt32(Session["uyeID"]), Convert.ToDateTime(dropdawnlistTarih.Text));
        //    }
        //    repeaterRandevuGecmis.DataSource = randevuDetay;
        //    repeaterRandevuGecmis.DataBind();
        //}
    }
}