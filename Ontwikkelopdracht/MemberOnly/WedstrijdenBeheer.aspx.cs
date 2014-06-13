using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ontwikkelopdracht.MemberOnly
{
    public partial class WedstrijdenBeheer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (string s in Database.GetTeamsBasko())
                {
                    TeamBasko.Items.Add(new ListItem("Basko - " + s, s));
                }
                foreach (string s in Database.GetTeamsTegenstander())
                {
                    TeamTegenstander.Items.Add(new ListItem(s,s));
                }
            }
        }

        protected void OK_Click(object sender, EventArgs e)
        {
            try
            {
                Database.AddWedstrijd(TeamBasko.Text, TeamTegenstander.Text, Datum.SelectedDate, Thuis.Checked);
                Response.Redirect("/Wedstrijden.aspx");
            }
            catch { OK.Text = "Fout in invoer"; }
        }
    }
}