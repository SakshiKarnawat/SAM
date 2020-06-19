using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM2019.UI
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                DisableLinks();

                linkSubmit.Visible = true;

                if (Session["Role"].ToString().ToUpper().Equals("PCM"))
                {
                    linkReview.Visible = true;
                    linkClaim.Visible = true;
                }
                else if (Session["Role"].ToString().ToUpper().Equals("PCC"))
                {
                    linkAssign.Visible = true;
                    linkRate.Visible = true;
                }
                else if (Session["Role"].ToString().ToUpper().Equals("REGULAR")) { }
                else if (Session["Role"].ToString().ToUpper().Equals("ADMIN")) { }
            }
        }

        protected void DisableLinks()
        {
            linkAssign.Visible = false;
            linkClaim.Visible = false;
            linkReview.Visible = false;
            linkRate.Visible = false;
        }
    }
}