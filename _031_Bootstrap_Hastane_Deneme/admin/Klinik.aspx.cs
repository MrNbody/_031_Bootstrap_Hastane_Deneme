using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme.admin
{
    public partial class Klinik : System.Web.UI.Page
    {
        int sehirID, ilceID;
        classes.VeriKontrol VK = new classes.VeriKontrol();
        //classes.Doldur d = new classes.Doldur();
        webservis.WebServiceDoldur d = new webservis.WebServiceDoldur();
        //classes.KlinikClass klinik = new classes.KlinikClass();
        webservis.WebServiceKlinik klinik = new webservis.WebServiceKlinik();

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

                ListItem listc = new ListItem("Hastane Seçiniz", "-1");
                dropListHastane.Items.Insert(0, listc);

                dropListIlce.Enabled = false;
                dropListHastane.Enabled = false;
            }
        }

        protected void dropListIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropListIlce.SelectedIndex == 0)
            {
                dropListHastane.SelectedIndex = 0;
                dropListHastane.Enabled = false;
            }
            else
            {
                dropListHastane.Enabled = true;
                SelectIlce();

                ListItem listc = new ListItem("Hastane Seçiniz", "-1");
                dropListHastane.Items.Insert(0, listc);
            }
            up.Update();
        }
        private void SelectIlce()
        {
            ilceID = Convert.ToInt32(dropListIlce.SelectedValue);
            dropListHastane.DataSource = JsonConvert.DeserializeObject(d.DoldurHastane(ilceID));
            dropListHastane.DataTextField = "hastaneAd";
            dropListHastane.DataValueField = "hastaneID";
            dropListHastane.DataBind();
        }

        protected void dropListSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropListSehir.SelectedIndex == 0)
            {
                dropListIlce.SelectedIndex = 0;
                dropListIlce.Enabled = false;

                dropListHastane.SelectedIndex = 0;
                dropListHastane.Enabled = false;
            }
            else
            {
                dropListIlce.Enabled = true;
                SelectSehir();

                dropListHastane.SelectedIndex = 0;
                dropListHastane.Enabled = false;

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
            if (VK.Kontrol(textboxKlinik.Text))
                klinik.KlinikAdi = textboxKlinik.Text;
            if (VK.Kontrol(dropListHastane.SelectedValue))
                klinik.HastaneID = Convert.ToInt32(dropListHastane.SelectedValue);
            if (klinik.Kontrol())
            {
                if (klinik.Ekle())
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "yes('Sisteme klinik eklenmiştir');", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Bilgilerinizi kontrol ediniz');", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Böyle bir klinik adı zaten mevcut');", true);
            up.Update();
        }

        private void ListDoldur(DropDownList list, string ad, string id)
        {
            if (ad == "sehirAd")
                list.DataSource =JsonConvert.DeserializeObject(d.DoldurSehir());
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