using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services.Discovery;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM2019.UI
{
    public partial class Rate : System.Web.UI.Page
    {
        private static String query_Papers_Ready = "SELECT SubmissionID, Title FROM SUBMISSIONS WHERE StatusID = ?";

        private static String query_Fetch = "SELECT R.ReviewID, R.Score, U.Email, U.Name " +
                                            "FROM Reviews R INNER JOIN Users U " +
                                            "WHERE R.UserID = U.UserID AND R.SubmissionID = ?";

        private static String query_getReview = "SELECT ReviewBin, FileName, Format FROM Reviews WHERE ReviewID = ?";

        private static String query_SubmitRating = "UPDATE Submissions SET Score = ?, StatusID = ? WHERE SubmissionID = ?";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fetch();
                rdScore.Visible = false;
                btnSubmit.Visible = false;
                lblFinalScore.Visible = false;
            }
        }

        protected void gvPapers_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ReviewID = gvReviews.SelectedDataKey.Value.ToString();
            string title = gvReviews.Rows[gvReviews.SelectedIndex].Cells[0].Text.Replace(" ", "_") + ddPapers.SelectedItem.Text.Replace(" ", "_") + "_Review";

            DB sql = new DB();
            List<object> param = new List<object>();
            param.Add(ReviewID);

            DataTable dt = sql.ExecuteQuery_Parametized(query_getReview, param);

            byte[] retrievePaper = (byte[])dt.Rows[0]["ReviewBin"];
            string format = dt.Rows[0]["Format"].ToString();
            string fileName = dt.Rows[0]["FileName"].ToString();

            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + format + "\"");
            Response.OutputStream.Write(retrievePaper, 0, retrievePaper.Length);
            Response.Flush();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (rdScore.SelectedIndex >= 0)
            {
                DB sql = new DB();

                int StatusID = sql.getStatus("Rated");
                string score = rdScore.SelectedValue;
                string submissionID = ddPapers.SelectedValue;

                List<object> param = new List<object>();
                param.Add(score);
                param.Add(StatusID);
                param.Add(submissionID);

                sql.ExecuteNonQuery_Parametized(query_SubmitRating, param);

                Fetch();

                rdScore.Visible = false;
                btnSubmit.Visible = false;
                gvReviews.Visible = false;
                lblFinalScore.Visible = false;
            }
        }

        protected void Fetch()
        {
            DB sql = new DB();

            int StatusID = sql.getStatus("Reviewed");

            List<object> param = new List<object>();
            param.Add(StatusID);

            DataTable dt = sql.ExecuteQuery_Parametized(query_Papers_Ready, param);

            ddPapers.DataSource = dt;
            ddPapers.DataBind();

            ddPapers.Items.Insert(0, new ListItem(String.Empty, String.Empty));
            ddPapers.SelectedIndex = 0;
        }

        protected void Fetch_Reviews(string SubmissionID)
        {
            DB sql = new DB();

            List<object> param = new List<object>();
            param.Add(SubmissionID);

            DataTable dt = sql.ExecuteQuery_Parametized(query_Fetch, param);

            gvReviews.DataSource = dt;
            gvReviews.DataBind();

            rdScore.Visible = true;
            btnSubmit.Visible = true;
            lblFinalScore.Visible = true;
        }

        protected void ddPapers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddPapers.SelectedIndex != 0)
            {
                Fetch_Reviews(ddPapers.SelectedValue);
            }
            else
            {
                rdScore.Visible = false;
                btnSubmit.Visible = false;
                gvReviews.Visible = false;
                lblFinalScore.Visible = false;
            }
        }
    }
}