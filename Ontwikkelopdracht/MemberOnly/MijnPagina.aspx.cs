using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Ontwikkelopdracht
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private static bool adreswijzigen = false;
        private static bool telnrwijzigen = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Naam.Text = (Session["Lid"] as Lid).Naam;
                Team.Text = (Session["Lid"] as Lid).TeamCode;
                GeboorteDatum.Text = (Session["Lid"] as Lid).Geboortedatum.ToShortDateString();
                Adres.Text = (Session["Lid"] as Lid).Postcode + "<br />Nummer: " + (Session["Lid"] as Lid).Adres;
                TelefoonNummer.Text = (Session["Lid"] as Lid).TelefoonNummer;
            }
            catch
            {
                Response.Redirect("Home.aspx");
            }

        }

        protected void BtAdres_Click(object sender, EventArgs e)
        {
            telnrwijzigen = !telnrwijzigen;
            if (telnrwijzigen)
            {
                Adres.Visible = false;
                tbAdres.Visible = true;
                tbNummer.Visible = true;
                BtAdres.Text = "Wijzig";
            }
            else
            {
                Adres.Visible = true;
                tbAdres.Visible = false;
                tbNummer.Visible = false;
                BtAdres.Text = "Wijzigen";
                Database.VoerUit("UPDATE LID SET POSTCODE = '" + tbAdres.Text + "', ADRES = '" + tbNummer.Text + "' WHERE LIDNR = " + (Session["Lid"] as Lid).LidNummer);
                Session.Clear();
                FormsAuthentication.SignOut();
                Response.Redirect("Home.aspx");
            }
        }

        protected void btTelNr_Click(object sender, EventArgs e)
        {
            adreswijzigen = !adreswijzigen;
            if (adreswijzigen)
            {
                TelefoonNummer.Visible = false;
                tbTelNr.Visible = true;
                BtAdres.Text = "Wijzig";
            }
            else
            {
                Adres.Visible = true;
                tbAdres.Visible = false;
                BtAdres.Text = "Wijzigen";
                Database.VoerUit("UPDATE LID SET TELEFOONNUMMER = '" + tbAdres.Text + "' WHERE LIDNR = " + (Session["Lid"] as Lid).LidNummer);
                Session.Clear();
                FormsAuthentication.SignOut();
                Response.Redirect("Home.aspx");
            }
        }
    }
}