using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ontwikkelopdracht
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RepeaterNieuwtje.DataSource = Database.GetNieuwsbericht(Convert.ToInt32(Session["NieuwsNr"]));
            RepeaterNieuwtje.DataBind();
        }
    }
}