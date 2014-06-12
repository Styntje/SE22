using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ontwikkelopdracht
{
    public partial class Wedstrijden : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                WedstrijdenView.DataSource = Database.GetWedstrijden();
                WedstrijdenView.DataBind();
        }

        protected void WedstrijdenView_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            WedstrijdenView.CurrentPageIndex = e.NewPageIndex;
            WedstrijdenView.DataBind();
        }
    }
}