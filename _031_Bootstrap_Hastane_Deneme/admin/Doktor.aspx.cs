using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme.admin
{
    public partial class Doktor : System.Web.UI.Page
    {
        int sehirID, ilceID, hastaneID;
        string emailREG = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        //    string parolaREG = @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{4,20}$";
        string tcREG = @"^\d*$";
        string telREG = @"^(0(\d{3})([ -])?(\d{3})([ -])?(\d{2})([ -])?(\d{2}))$";
        classes.VeriKontrol VK = new classes.VeriKontrol();
        //classes.Doldur d = new classes.Doldur();
        webservis.WebServiceDoldur d = new webservis.WebServiceDoldur();
        //classes.DoktorClass doktor = new classes.DoktorClass();
        webservis.WebServiceDoktor doktor = new webservis.WebServiceDoktor();

        protected void buttonKayıt_Click(object sender, EventArgs e)
        {
            Regex regEmail = new Regex(emailREG);
            //  Regex regParola = new Regex(parolaREG);
            Regex regTc = new Regex(tcREG);
            Regex regTel = new Regex(telREG);

            if ((VK.Kontrol(textboxEmail.Text)) && (regEmail.Match(textboxEmail.Text).Success))
                doktor.Email = textboxEmail.Text;

            if (VK.Kontrol(textboxParola.Text)/* && (regParola.Match(textboxParola.Text).Success)*/)
                doktor.Parola = textboxParola.Text;

            if (VK.Kontrol(textboxAd.Text))
                doktor.Ad = textboxAd.Text;

            if (VK.Kontrol(textboxSoyad.Text))
                doktor.Soyad = textboxSoyad.Text;

            if (VK.Kontrol(textboxTc.Text) && (regTc.Match(textboxTc.Text).Success) && textboxTc.Text.Length == 11)
                doktor.Tc = textboxTc.Text;

            if (VK.Kontrol(textboxTelefon.Text) && (regTel.Match(textboxTelefon.Text).Success))
                doktor.Telefon = textboxTelefon.Text;

            if (VK.Kontrol(dropdownlistCinsiyet.Text))
                doktor.Cinsiyet = dropdownlistCinsiyet.Text;

            if (VK.Kontrol(dropListKlinik.SelectedValue))
                doktor.Klinik = Convert.ToInt32(dropListKlinik.SelectedValue);

            if (doktor.Kontrol())
            {
                if (doktor.Ekle())
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "yes('Sisteme doktor eklenmiştir');", true);
                else
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Bilgilerinizi kontrol ediniz');", true);
            }
            else
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Böyle bir TC ile doktor zaten mevcut');", true);
            up.Update();
        }
        
        protected void dropListSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropListSehir.SelectedIndex == 0)
            {
                dropListIlce.SelectedIndex = 0;
                dropListIlce.Enabled = false;

                dropListHastane.SelectedIndex = 0;
                dropListHastane.Enabled = false;

                dropListKlinik.SelectedIndex = 0;
                dropListKlinik.Enabled = false;
            }
            else
            {
                dropListIlce.Enabled = true;
                SelectSehir();

                dropListHastane.SelectedIndex = 0;
                dropListHastane.Enabled = false;

                dropListKlinik.SelectedIndex = 0;
                dropListKlinik.Enabled = false;

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

        protected void dropListIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropListIlce.SelectedIndex == 0)
            {
                dropListHastane.SelectedIndex = 0;
                dropListHastane.Enabled = false;

                dropListKlinik.SelectedIndex = 0;
                dropListKlinik.Enabled = false;
            }
            else
            {
                dropListHastane.Enabled = true;
                SelectIlce();

                dropListKlinik.SelectedIndex = 0;
                dropListKlinik.Enabled = false;

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

        protected void dropListHastane_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropListHastane.SelectedIndex == 0)
            {
                dropListKlinik.SelectedIndex = 0;
                dropListKlinik.Enabled = false;
            }
            else
            {
                dropListKlinik.Enabled = true;
                SelectHastane();

                ListItem listd = new ListItem("Klinik Seçiniz", "-1");
                dropListKlinik.Items.Insert(0, listd);
            }
            up.Update();
        }
        private void SelectHastane()
        {
            hastaneID = Convert.ToInt32(dropListHastane.SelectedValue);
            dropListKlinik.DataSource = JsonConvert.DeserializeObject(d.DoldurKlinik(hastaneID));
            dropListKlinik.DataTextField = "klinikAd";
            dropListKlinik.DataValueField = "klinikID";
            dropListKlinik.DataBind();
        }

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

                ListItem listd = new ListItem("Klinik Seçiniz", "-1");
                dropListKlinik.Items.Insert(0, listd);

                dropListIlce.Enabled = false;
                dropListHastane.Enabled = false;
                dropListKlinik.Enabled = false;
            }
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
            if (ad == "klinikAd")
            {
                hastaneID = Convert.ToInt32(dropListHastane.SelectedValue);
                list.DataSource = JsonConvert.DeserializeObject(d.DoldurKlinik(hastaneID));
            }

            list.DataTextField = ad;
            list.DataValueField = id;
            list.DataBind();
        }
    }
}