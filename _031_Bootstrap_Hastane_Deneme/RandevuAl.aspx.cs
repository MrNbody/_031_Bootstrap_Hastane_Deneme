using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace _031_Bootstrap_Hastane_Deneme
{
    public partial class RandevuAl : System.Web.UI.Page
    {
        classes.VeriKontrol VK = new classes.VeriKontrol();
        //classes.Doldur d = new classes.Doldur();
        webservis.WebServiceDoldur doldur = new webservis.WebServiceDoldur();
        //classes.Listele liste;
        webservis.WebServiceListele liste;
        static int sehirID, ilceID, hastaneID, klinikID, doktorID;
        static string hastaneAdi, klinikAdi, doktorAdi;
        static List<viewDoktor> doktorListesi = new List<viewDoktor>();
        viewRandevuDetay randevu = new viewRandevuDetay();
        static TimeSpan randevuSaat;
        //classes.MesaiClass mesai = new classes.MesaiClass();
        webservis.WebServiceMesai mesai = new webservis.WebServiceMesai();
        //static classes.RandevuClass randevuNesne = new classes.RandevuClass();
        static webservis.WebServiceRandevu randevuNesne = new webservis.WebServiceRandevu();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                object uye = Session["uyeID"];
                if (uye == null)
                {
                    Response.Redirect("Giris.aspx");
                }

                labelSaat.Text =DateTime.Now.ToLongTimeString();
                labelhosgeldiniz.Text =Session["uyeAd"] + " " + Session["uyeSoyad"];
                
                ListDoldur(dropListSehir, "sehirAd", "sehirID");

                dropListSehir.Items.Insert(0, new ListItem("Şehir Seçiniz", "-1"));

                dropListIlce.Items.Insert(0, new ListItem("İlçe Seçiniz", "-1"));

                dropListHastane.Items.Insert(0, new ListItem("Hastane Seçiniz", "-1"));

                dropListKlinik.Items.Insert(0, new ListItem("Klinik Seçiniz", "-1"));

                dropListDoktor.Items.Insert(0, new ListItem("Doktor Seçiniz", "-1"));

                dropListIlce.Enabled = false;
                dropListHastane.Enabled = false;
                dropListKlinik.Enabled = false;
                dropListDoktor.Enabled = false;

            }
        }
        private void ListDoldur(DropDownList list, string ad, string id)
        {
            if (ad == "sehirAd")
                list.DataSource = JsonConvert.DeserializeObject(doldur.DoldurSehir());
            if (ad == "ilceAd"){
                sehirID = Convert.ToInt32(dropListSehir.SelectedValue);
                list.DataSource = JsonConvert.DeserializeObject(doldur.DoldurIlce(sehirID));
            }
            if (ad == "hastaneAd"){
                ilceID = Convert.ToInt32(dropListIlce.SelectedValue);
                list.DataSource = JsonConvert.DeserializeObject(doldur.DoldurHastane(ilceID));
            }
            if (ad == "klinikAd"){
                hastaneID = Convert.ToInt32(dropListHastane.SelectedValue);
                list.DataSource = JsonConvert.DeserializeObject(doldur.DoldurKlinik(hastaneID));
            }
            if (ad == "doktorAd"){
                klinikID = Convert.ToInt32(dropListKlinik.SelectedValue);
                list.DataSource = JsonConvert.DeserializeObject(doldur.DoldurDoktor(klinikID));
            }
            list.DataTextField = ad;
            list.DataValueField = id;
            list.DataBind();
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
                dropListDoktor.SelectedIndex = 0;
                dropListDoktor.Enabled = false;
            }
            else{
                dropListIlce.Enabled = true;
                SelectSehir();
                dropListHastane.SelectedIndex = 0;
                dropListHastane.Enabled = false;
                dropListKlinik.SelectedIndex = 0;
                dropListKlinik.Enabled = false;
                dropListDoktor.SelectedIndex = 0;
                dropListDoktor.Enabled = false;
                ListItem listb = new ListItem("İlçe Seçiniz", "-1");
                dropListIlce.Items.Insert(0, listb);
            }
            up1.Update();
        }
        private void SelectSehir()
        {
            sehirID = Convert.ToInt32(dropListSehir.SelectedValue);
            dropListIlce.DataSource = JsonConvert.DeserializeObject(doldur.DoldurIlce(sehirID));
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

                dropListDoktor.SelectedIndex = 0;
                dropListDoktor.Enabled = false;
            }
            else
            {
                dropListHastane.Enabled = true;
                SelectIlce();

                dropListKlinik.SelectedIndex = 0;
                dropListKlinik.Enabled = false;

                dropListDoktor.SelectedIndex = 0;
                dropListDoktor.Enabled = false;

                ListItem listc = new ListItem("Hastane Seçiniz", "-1");
                dropListHastane.Items.Insert(0, listc);
            }
            up1.Update();
        }
        private void SelectIlce()
        {
            ilceID = Convert.ToInt32(dropListIlce.SelectedValue);
            dropListHastane.DataSource = JsonConvert.DeserializeObject(doldur.DoldurHastane(ilceID));
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

                dropListDoktor.SelectedIndex = 0;
                dropListDoktor.Enabled = false;
            }
            else
            {
                dropListKlinik.Enabled = true;
                SelectHastane();

                dropListDoktor.SelectedIndex = 0;
                dropListDoktor.Enabled = false;

                ListItem listd = new ListItem("Klinik Seçiniz", "-1");
                dropListKlinik.Items.Insert(0, listd);
            }
            up1.Update();
        }
        private void SelectHastane()
        {
            hastaneID = Convert.ToInt32(dropListHastane.SelectedValue);
            dropListKlinik.DataSource = JsonConvert.DeserializeObject(doldur.DoldurKlinik(hastaneID));
            dropListKlinik.DataTextField = "klinikAd";
            dropListKlinik.DataValueField = "klinikID";
            dropListKlinik.DataBind();
        }

        protected void dropListKlinik_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropListKlinik.SelectedIndex == 0)
            {
                dropListDoktor.SelectedIndex = 0;
                dropListDoktor.Enabled = false;
            }
            else
            {
                dropListDoktor.Enabled = true;
                SelectKlinik();

                ListItem liste = new ListItem("Doktor Seçiniz", "-1");
                dropListDoktor.Items.Insert(0, liste);
            }
            up1.Update();
        }
        private void SelectKlinik()
        {
            klinikID = Convert.ToInt32(dropListKlinik.SelectedValue);
            dropListDoktor.DataSource = JsonConvert.DeserializeObject(doldur.DoldurDoktor(klinikID));
            dropListDoktor.DataTextField = "doktorAd";
            dropListDoktor.DataValueField = "doktorID";
            dropListDoktor.DataBind();
        }

        protected void dropListDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            doktorID = Convert.ToInt32(dropListDoktor.SelectedValue);
            up1.Update();
        }

        protected void buttonTemizle_Click(object sender, EventArgs e)
        {
            panelDoktorListe.Visible = false;
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "loading();", true);
            Temizle();
            up1.Update();
        }
        private void Temizle()
        {
            dropListSehir.SelectedIndex = 0;
            dropListIlce.SelectedIndex = 0;
            dropListHastane.SelectedIndex = 0;
            dropListKlinik.SelectedIndex = 0;
            dropListDoktor.SelectedIndex = 0;
            textboxTarih.Text = "";

            dropListIlce.Enabled = false;
            dropListHastane.Enabled = false;
            dropListKlinik.Enabled = false;
            dropListDoktor.Enabled = false;
        }

        static DateTime randevuTarih;

        protected void repeaterSaat_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Button btn = (Button)e.Item.FindControl("btnRandevu");
                RandevuKontrol(btn);

            }
        }
        protected void buttonDoktor_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "loading();", true);
            Button btn = (Button)sender;
            doktorID = Convert.ToInt32(btn.CommandArgument);

            hastaneAdi =doktorListesi.Where(w => w.doktorID == doktorID).FirstOrDefault().hastaneAd;
            klinikAdi = doktorListesi.Where(w => w.doktorID == doktorID).FirstOrDefault().klinikAd;
            doktorAdi = doktorListesi.Where(w => w.doktorID == doktorID).FirstOrDefault().doktorAd;

            panelRandevuAl.Visible = true;
            panelDoktorListe.Visible = false;
            panelRandevuAra.Visible = false;

            repeaterSaat.DataSource =JsonConvert.DeserializeObject(mesai.Getir(doktorID));
            repeaterSaat.DataBind();
            up1.Update();
        }

        private void RandevuKontrol(Button btn)
        {
            randevuNesne.DoktorID = Convert.ToInt32(doktorID);
            //   randevuNesne.RandevuTarih = randevuTarih;
            // randevuNesne.RandevuSaat = TimeSpan.Parse(btn.Text);
            randevuNesne.TarihSaat = randevuTarih.Add(TimeSpan.Parse(btn.Text));
            List<DateTime> randevuListe =JsonConvert.DeserializeObject<List<DateTime>>(randevuNesne.Kontrol());
            foreach (var item in randevuListe)
            {
                //if (btn.Text == item.randevuSaat.ToString().Substring(0, 5))
                //{
                //    btn.Enabled = false;
                //}
                if (btn.Text == item.ToShortTimeString())
                {
                    //btn.Enabled = false;
                    btn.CssClass = "btn btn-danger btn-sm";
                    btn.CommandName = "dolu";
                }
            }
        }

        protected void btnRandevu_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            randevuSaat = TimeSpan.Parse(btn.Text);
            if (btn.CommandName=="bos")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call1", "modalHeaderYesil();", true);
                labelModalHeader.Text = "Randevu Al";
                panelRandevuAra.Visible = false;
                panelModalDetay.Visible = true;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call2", "acModal();", true);//$('#myModal').modal('hide');
                Randevu_Al();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call1", "modalHeaderKirmizi();", true);
                labelModalHeader.Text = "Randevu Saati Dolu !";
                randevu =JsonConvert.DeserializeObject<viewRandevuDetay>(randevuNesne.GetirRandevuuu(randevuTarih.Add(randevuSaat)));

                labelModalDoktor.Text = randevu.doktorAd;
                labelModalHasta.Text = randevu.uyeAd;
                labelModalTarih.Text = randevuTarih.ToShortDateString();
                labelModalSaat.Text = randevuSaat.ToString().Substring(0, 5); ;
                labelModalHastane.Text = randevu.hastaneAd;
                labelModalKlinik.Text = randevu.klinikAd;
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call2", "acModal();", true);
                panelModalDetay.Visible = false;
            }
            up1.Update();
        }
        private void Randevu_Al()
        {
            randevuNesne.DoktorID = Convert.ToInt32(doktorID);
            randevuNesne.UyeID = Convert.ToInt32(Session["uyeID"]);
            //    randevuNesne.RandevuTarih = randevuTarih;
            //    randevuNesne.RandevuSaat = TimeSpan.Parse(btn.Text);
            randevuNesne.TarihSaat = randevuTarih.Add(randevuSaat);
            labelModalHastane.Text = hastaneAdi;
            labelModalKlinik.Text = klinikAdi;
            labelModalDoktor.Text = doktorAdi;
            labelModalHasta.Text = Session["uyeAd"] + " " + Session["uyeSoyad"];
            labelModalTarih.Text = randevuTarih.ToShortDateString();
            labelModalSaat.Text = randevuSaat.ToString().Substring(0, 5);
        }

        protected void buttonDetayRandevuAl_Click(object sender, EventArgs e)
        {
            //ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "yes('Randevunuz alınmıştır');", true);

            randevuNesne.Ekle();
            panelModalDetay.Visible = false;
            panelRandevuAl.Visible = true;
            panelRandevuAra.Visible = false;
            
            hastaneAdi = doktorListesi.Where(w => w.doktorID == doktorID).FirstOrDefault().hastaneAd;
            klinikAdi = doktorListesi.Where(w => w.doktorID == doktorID).FirstOrDefault().klinikAd;
            doktorAdi = doktorListesi.Where(w => w.doktorID == doktorID).FirstOrDefault().doktorAd;

            repeaterSaat.DataSource =JsonConvert.DeserializeObject(mesai.Getir(Convert.ToInt32(doktorID)));
            repeaterSaat.DataBind();

            //ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "$('#myModal').modal('close');", true);
            //ScriptManager.RegisterStartupScript(this, GetType(), "hide", "$(function () { $('#myModal').modal('hide'); });", true);
            up1.Update();
        }

        protected void buttonRandevuAra_Click(object sender, EventArgs e)
        {
            if (textboxTarih.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Tarih seçmelisiniz');", true);
            }
            else
            {
                DateTime a = DateTime.Today;
                DateTime b = Convert.ToDateTime(textboxTarih.Text);
                if (a > b)
                {
                    textboxTarih.Text = "";
                    ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('Geçerli bir tarih seçmelisiniz');", true);
                }
                else
                {
                    panelDoktorListe.Visible = true;
                    ListeleDoktor();
                    if (VK.Kontrol(dropListHastane.SelectedItem.Text))
                        hastaneAdi = dropListHastane.SelectedItem.Text;
                    if (VK.Kontrol(dropListKlinik.SelectedItem.Text))
                        klinikAdi = dropListKlinik.SelectedItem.Text;
                    if (VK.Kontrol(dropListDoktor.SelectedItem.Text))
                        doktorAdi = dropListDoktor.SelectedItem.Text;
                    if ((VK.Kontrol(textboxTarih.Text)))
                        randevuTarih = Convert.ToDateTime(textboxTarih.Text);
                }
            }
            up1.Update();
        }
        private void ListeleDoktor()
        {
            try
            {
                if (dropListSehir.SelectedIndex != 0)
                {
                    if (dropListIlce.SelectedIndex != 0)
                    {
                        if (dropListHastane.SelectedIndex != 0)
                        {
                            if (dropListKlinik.SelectedIndex != 0)
                            {
                                if (dropListDoktor.SelectedIndex != 0)
                                    liste = new webservis.WebServiceListele(dropListDoktor.SelectedItem.Text, dropListKlinik.SelectedItem.Text, dropListHastane.SelectedItem.Text, dropListIlce.SelectedItem.Text, dropListSehir.SelectedItem.Text);
                                else
                                    liste = new webservis.WebServiceListele(dropListKlinik.SelectedItem.Text, dropListHastane.SelectedItem.Text, dropListIlce.SelectedItem.Text, dropListSehir.SelectedItem.Text);
                            }
                            else
                                liste = new webservis.WebServiceListele(dropListHastane.SelectedItem.Text, dropListIlce.SelectedItem.Text, dropListSehir.SelectedItem.Text);
                        }
                        else
                            liste = new webservis.WebServiceListele(dropListIlce.SelectedItem.Text, dropListSehir.SelectedItem.Text);
                    }
                    else
                        liste = new webservis.WebServiceListele(dropListSehir.SelectedItem.Text);
                }
                randevuTarih = Convert.ToDateTime(textboxTarih.Text);
                doktorListesi = JsonConvert.DeserializeObject<List<viewDoktor>>(liste.ListeleDoktor());
                repeaterDoktor.DataSource = doktorListesi;
                repeaterDoktor.DataBind();
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "loading();", true);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), "call", "no('En azından bir şehir seçmelisiniz');", true);
            }
        }

    }
}