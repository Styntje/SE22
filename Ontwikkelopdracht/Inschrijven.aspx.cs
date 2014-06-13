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
            //try
            //{
                Database.AddAanvraag(new Lid(Convert.ToInt32(Nummer.Text), Naam.Text, new DateTime(Convert.ToInt32(GeboortedatumJ.Text), Convert.ToInt32(GeboortedatumM.Text), Convert.ToInt32(GeboortedatumD.Text)), (Geslacht.Text == Lid.EGeslacht.M.ToString() ? Lid.EGeslacht.M : Lid.EGeslacht.V), RekeningNummer.Text, TelefoonNummer.Text, Postcode.Text, Adres.Text, Teamcode.Text, -1, Lid.ERecht.Lid, "ww88"));
            //}
            //catch { btnK.Text = "Foute Gegevens";}
        }
    }
}