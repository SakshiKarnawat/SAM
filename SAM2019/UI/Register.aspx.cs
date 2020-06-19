using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM2019.UI
{
    public partial class Register : System.Web.UI.Page
    {

        private static string query_insert = @"INSERT INTO Users (Email, Name, IsActive, RoleID) VALUES (?, ?, true, 2)";
        private static string query_checkEmail = @"SELECT Email FROM Users WHERE Email LIKE ?";
        private static string query_credentials = @"INSERT INTO Credentials (UserID, pwd) VALUES (?, ?)";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblWarning.Visible = false;
                divAlert.Attributes.Clear();
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DB sql = new DB();
            
            List<object> param = new List<object>();
            param.Add(txtEmail.Text);

            DataTable dt = sql.ExecuteQuery_Parametized(query_checkEmail, param);

            if (dt.Rows.Count > 0)
            {
                lblWarning.Text = "Email already in use.";
                lblWarning.Visible = true;
                divAlert.Attributes.Add("class", "alert alert-danger");
                return;
            }

            if (txtPWD.Text != txtPWDConfirm.Text)
            {
                lblWarning.Text = "Password does not match.";
                lblWarning.Visible = true;
                divAlert.Attributes.Add("class", "alert alert-danger");
                return;
            }

            if (String.IsNullOrWhiteSpace(txtPWD.Text) || String.IsNullOrWhiteSpace(txtEmail.Text) || String.IsNullOrWhiteSpace(txtName.Text) || String.IsNullOrWhiteSpace(txtPWDConfirm.Text))
            {
                lblWarning.Text = "All fields must be filled.";
                lblWarning.Visible = true;
                divAlert.Attributes.Add("class", "alert alert-danger");
                return;
            }

            param.Clear();
            param.Add(txtEmail.Text);
            param.Add(txtName.Text);

            object key = sql.ExecuteNonQuery_Parametized_getKey(query_insert, param);

            param.Clear();
            param.Add(key);
            param.Add(txtPWD.Text);

            sql.ExecuteNonQuery_Parametized(query_credentials, param);

            Response.Redirect("Login.aspx");
        }
    }
}