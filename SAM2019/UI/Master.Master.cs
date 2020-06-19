using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM2019
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session != null)
            {
                if (Session["UserID"] != null)
                {
                    linkSignOut.Visible = true;
                }
                else
                {
                    linkSignOut.Visible = false;
                }
            }
            else
            {
                linkSignOut.Visible = false;
            }
        }

        protected void linkSignOut_Click(object sender, EventArgs e)
        {
            Session.Clear();

            Response.Redirect("Login.aspx");
        }
    }
}