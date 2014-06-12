using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ontwikkelopdracht.MemberOnly
{
    public partial class LedenBeheer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Info.Text = Database.GetAanvraag();
        }

        protected void VoegToeLid_Click(object sender, EventArgs e)
        {
            try
            {
                Database.SetTeam(Lid.current, Convert.ToInt32(Teamcode.Text));
            }
            catch
            {
                Teamcode.Text = "Geen Geldig Team!";
            }
        }
    }
}