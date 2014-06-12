using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Ontwikkelopdracht
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(HttpContext.Current.User.Identity.IsAuthenticated)
            {
                try
                {
                    if ((Session["Lid"] as Lid).Naam != null)
                    {
                        InLogDiv.Visible = false;
                        OutLogDiv.Visible = true;
                    }
                    else
                    {
                        FormsAuthentication.SignOut();
                        InLogDiv.Visible = true;
                        OutLogDiv.Visible = false;
                        
                    }
                }
                catch
                {
                    FormsAuthentication.SignOut();
                    InLogDiv.Visible = true;
                    OutLogDiv.Visible = false;
                }
            }
            else
            {
                FormsAuthentication.SignOut();
                InLogDiv.Visible = true;
                OutLogDiv.Visible = false;
            }
        }

        protected void LogInButton_Click(object sender, EventArgs e)
        {
            try
            {
                Lid lid = Database.GetLid(Convert.ToInt32(Request["LidNr"]));
                if (lid.CheckWachtwoord(Request["wachtwoord"]))
                {
                    FormsAuthentication.SetAuthCookie(lid.Naam,false);
                    Session["Lid"] = lid;
                    Response.Redirect("Home.aspx");
                }
            }
            catch 
            {
            }
        }

        protected void LogOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("Home.aspx");
        }
    }
}