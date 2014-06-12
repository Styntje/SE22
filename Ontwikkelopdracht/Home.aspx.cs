using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ontwikkelopdracht
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RepeaterNieuws.DataSource = Database.GetNieuwsberichten();
            RepeaterNieuws.DataBind();
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)(sender);
            Session.Add("NieuwsNr",Convert.ToInt32(btn.CommandArgument));
            Response.Redirect("/Nieuwsbericht.aspx");
        }
    }
}