using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Data;
using DAL;

namespace SAM2019.UI
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DB sql = new DB();

            DataTable dt = sql.ExecuteQuery(String.Format(@"SELECT U.UserID, U.Email, R.Role 
                                                            FROM Users U INNER JOIN Credentials C INNER JOIN Roles R
                                                            WHERE U.Email = '{0}' AND C.pwd = '{1}' AND U.UserID = C.UserID AND U.RoleID = R.RoleID"
                                            , txtUsername.Text, txtPWD.Text));

            if (dt.Rows.Count == 1) {
                Session["UserID"] = dt.Rows[0]["UserID"].ToString();
                Session["User"] = dt.Rows[0]["Email"].ToString();
                Session["Role"] = dt.Rows[0]["Role"].ToString();

                Response.Redirect("Home.aspx");

            }
            else { return; }
        }
    }
}