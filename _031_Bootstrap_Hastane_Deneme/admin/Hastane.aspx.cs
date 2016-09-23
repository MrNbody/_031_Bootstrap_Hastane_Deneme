using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme.admin
{
    public partial class Hastane : System.Web.UI.Page
    {
        int sehirID, ilceID;
        classes.VeriKontrol VK = new classes.VeriKontrol();
        //classes.Doldur d = new classes.Doldur();
        webservis.WebServiceDoldur d = new webservis.WebServiceDoldur();
        //classes.HastaneClass hastane = new classes.HastaneClass();
        webservis.WebServiceHastane hastane = new webservis.WebServiceHastane();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                object admin = Session["admin"];
                if (admin == null)
                {
                    Response.Redirect("Giris.aspx");
                }

                ListDoldur(dropListSehir, "sehirAd", "sehirID");

                ListItem lista = new ListItem("Şehir Seçiniz", "-1");
                dropListSehir.Items.Insert(0, lista);

                ListItem listb = new ListItem("İlçe Seçiniz", "-1");
                dropListIlce.Items.Insert(0, listb);

                dropListIlce.Enabled = false;
            }
        }

        protected void dropListSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropListSehir.SelectedIndex == 0)
            {
                dropListIlce.SelectedIndex = 0;
                dropListIlce.Enabled = false;
            }
            else
            {
                dropListIlce.Enabled = true;
                SelectSehir();

                ListItem listb = new ListItem("İlçe Seçiniz", "-1");
                dropListIlce.Items.Insert(0, listb);
            }
            up.Update();
        }
        private void SelectSehir()
        {
            sehirID = Convert.ToInt32(dropListSehir.SelectedValue);
            dropListIlce.DataSource = JsonConvert.DeserializeObject(d.DoldurIlce(sehirID));
            dropListIlce.DataTextField = "ilceAd";
            dropListIlce.DataValueField = "ilceID";
            dropListIlce.DataBind();
        }

        protected void buttonKayıt_Click(object sender, EventArgs e)
        {
            if (VK.Kontrol(textboxHastane.Text))
                hastane.HastaneAdi = textboxHastane.Text;
            if (VK.Kontrol(dropListIlce.SelectedValue))
                hastane.IlceID = Convert.ToInt32(dropListIlce.SelectedValue);
            if (hastane.Kontrol())
            {
                if (hastane.Ekle())
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "yes('Sisteme hastane eklenmiştir');", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Bilgilerinizi kontrol ediniz');", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Böyle bir hastane adı zaten var');", true);
            up.Update();
        }

        private void ListDoldur(DropDownList list, string ad, string id)
        {
            if (ad == "sehirAd")
                list.DataSource = JsonConvert.DeserializeObject(d.DoldurSehir());
            if (ad == "ilceAd")
            {
                sehirID = Convert.ToInt32(dropListSehir.SelectedValue);
                list.DataSource = JsonConvert.DeserializeObject(d.DoldurIlce(sehirID));
            }
            if (ad == "hastaneAd")
            {
                ilceID = Convert.ToInt32(dropListIlce.SelectedValue);
                list.DataSource = JsonConvert.DeserializeObject(d.DoldurHastane(ilceID));
            }

            list.DataTextField = ad;
            list.DataValueField = id;
            list.DataBind();
        }
    }
}