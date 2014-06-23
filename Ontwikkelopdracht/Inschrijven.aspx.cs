using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ontwikkelopdracht
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnK_Click(object sender, EventArgs e)
        {
            try
            {
                Database.AddAanvraag(new Lid(1, Naam.Text, GebDat.SelectedDate, (Geslacht.Text == Lid.EGeslacht.M.ToString() ? Lid.EGeslacht.M : Lid.EGeslacht.V), RekeningNummer.Text, TelefoonNummer.Text, Postcode.Text, Adres.Text, Woonplaats.Text, "No team", -1, Lid.ERecht.Lid, Wachtwoord.Text));
                Response.Redirect("Home.aspx");
            }
            catch { btnK.Text = "Inschrijven niet mogelijk op dit moment";}
        }
    }
}