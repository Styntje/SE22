using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ontwikkelopdracht
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Naam.Text = (Session["Lid"] as Lid).Naam;
                Team.Text = (Session["Lid"] as Lid).TeamCode;
                GeboorteDatum.Text = (Session["Lid"] as Lid).Geboortedatum.ToShortDateString();
                Adres.Text = (Session["Lid"] as Lid).Postcode + " Nummer: " + (Session["Lid"] as Lid).Adres;
                TelefoonNummer.Text = (Session["Lid"] as Lid).TelefoonNummer;
            }
            catch
            {
                Response.Redirect("Home.aspx");
            }

        }
    }
}