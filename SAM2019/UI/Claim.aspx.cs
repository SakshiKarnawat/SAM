using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace SAM2019.UI
{
    public partial class Claim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string query = @"SELECT SubmissionID, Title FROM Submissions WHERE StatusID = 1"; ;

                DB sql = new DB();
                DataTable dt = sql.ExecuteQuery(query);

                gvPapers.DataSource = dt;
                gvPapers.DataBind();
            }
            
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            DB sql = new DB();

            string query = @"DELETE FROM Interested WHERE UserID = ?";
            List<object> param = new List<object>();
            param.Add(UserID);
            sql.ExecuteNonQuery_Parametized(query, param);

            foreach (GridViewRow row in gvPapers.Rows)
            {
                CheckBox chk = row.FindControl("cbSelect") as CheckBox;

                if (chk.Checked)
                {
                    string SubmissionID = gvPapers.DataKeys[row.RowIndex].Value.ToString();

                    param.Clear();
                    param.Add(UserID);
                    param.Add(SubmissionID);

                    query = @"INSERT INTO Interested (UserID, SubmissionID) VALUES (?, ?)";
                    sql.ExecuteNonQuery_Parametized(query, param);
                }
            }
        }

        protected void gvPapers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SubmissionID = gvPapers.SelectedDataKey.Value.ToString();
            string title = gvPapers.Rows[gvPapers.SelectedIndex].Cells[1].Text.Replace(" ", "_");
            DB sql = new DB();

            string query = @"SELECT P.PaperBin, S.Format, S.FileName FROM Papers P INNER JOIN Submissions S WHERE P.SubmissionID = ? and P.SubmissionID = S.SubmissionID";
            List<object> param = new List<object>();
            param.Add(SubmissionID);

            DataTable dt = sql.ExecuteQuery_Parametized(query, param);

            byte[] retrievePaper = (byte[])dt.Rows[0]["PaperBin"];
            string format = dt.Rows[0]["Format"].ToString();
            string fileName = dt.Rows[0]["FileName"].ToString();

            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + format + "\"");
            Response.OutputStream.Write(retrievePaper, 0, retrievePaper.Length);
            Response.Flush();
        }
    }
}