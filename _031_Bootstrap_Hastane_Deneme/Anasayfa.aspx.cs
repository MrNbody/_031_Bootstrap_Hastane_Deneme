using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _031_Bootstrap_Hastane_Deneme
{
    public partial class Anasayfa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                object uye = Session["uyeID"];
                if (uye == null)
                {
                    Response.Redirect("Giris.aspx");
                }
            }
        }
    }
}