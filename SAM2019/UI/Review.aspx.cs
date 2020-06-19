using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM2019.UI
{
    public partial class Review : System.Web.UI.Page
    {
        //private static String query_Fetch = "SELECT R.ReviewID, R.SubmissionID, S.Title " +
        //                                    "FROM Reviews R INNER JOIN Submissions S " +
        //                                    "WHERE R.UserID = ? AND R.SubmissionID = S.SubmissionID AND " +
        //                                    "(SELECT COUNT(*) FROM Reviews R1 WHERE R.SubmissionID = R1.SubmissionID AND R1.ReviewBin IS NOT NULL AND R1.Score IS NOT NULL) < 3";

        private static String query_Fetch = "SELECT R.ReviewID, R.SubmissionID, S.Title " +
                                            "FROM Reviews R INNER JOIN Submissions S " +
                                            "WHERE R.UserID = ? AND R.SubmissionID = S.SubmissionID AND " +
                                            "(R.ReviewBin IS NULL OR R.Score IS NULL)";

        private static String query_ReviewPending = "SELECT ReviewID FROM Reviews WHERE SubmissionID = ? AND (ReviewBin IS NULL OR Score IS NULL)";

        private static String query_SubmitReview = @"UPDATE Reviews
                                                    SET ReviewBin = ?, Score = ?, Format = ?, FileName = ?
                                                    WHERE ReviewID = ?";

        private static String query_UpdateStatus = "UPDATE Submissions SET StatusID = ? WHERE SubmissionID = ?";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fetch();
            }
        }

        protected void gvReview_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SubmissionID = gvReview.Rows[gvReview.SelectedIndex].Cells[0].Text;
            string title = gvReview.Rows[gvReview.SelectedIndex].Cells[2].Text.Replace(" ", "_");

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
            Response.Close();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DB sql = new DB();

            List<object> param1 = new List<object>();
            

            foreach (GridViewRow row in gvReview.Rows)
            {
                CheckBox chk = row.FindControl("cbSelect") as CheckBox;

                if (chk.Checked)
                {
                    FileUpload file = (row.FindControl("uploadReview") as FileUpload);

                    if (file.HasFile)
                    {
                        string ReviewID = gvReview.DataKeys[row.RowIndex].Value.ToString();
                        byte[] paper = file.FileBytes;
                        string format = Path.GetExtension(file.FileName);
                        string filename = Path.GetFileNameWithoutExtension(file.FileName);
                        string score = (row.FindControl("rdScore") as RadioButtonList).SelectedValue;

                        if (!String.IsNullOrWhiteSpace(score))
                        {
                            List<object> param = new List<object>();
                            param.Add(paper);
                            param.Add(score);
                            param.Add(format);
                            param.Add(filename);
                            param.Add(ReviewID);
                            
                            sql.ExecuteNonQuery_Parametized(query_SubmitReview, param);

                            string SubmissionID = gvReview.Rows[row.RowIndex].Cells[0].Text;
                            Update_Status(SubmissionID);
                        }
                    }
                }
            }

            Fetch();
        }

        private void Fetch()
        {
            DB sql = new DB();

            int StatusID = sql.getStatus("Submitted");

            List<object> param = new List<object>();
            param.Add(Session["UserID"].ToString());

            DataTable dt = sql.ExecuteQuery_Parametized(query_Fetch, param);

            gvReview.DataSource = dt;
            gvReview.DataBind();

            gvReview.Columns[0].Visible = false;
        }

        private void Update_Status(string SubmissionID)
        {
            DB sql = new DB();
            int StatusID = sql.getStatus("Reviewed");

            List<object> param = new List<object>();
            param.Add(SubmissionID);

            DataTable dt = sql.ExecuteQuery_Parametized(query_ReviewPending, param);

            if (dt.Rows.Count == 0)
            {
                param.Clear();
                param.Add(StatusID);
                param.Add(SubmissionID);
                sql.ExecuteNonQuery_Parametized(query_UpdateStatus, param);
            }
        }
    }
}