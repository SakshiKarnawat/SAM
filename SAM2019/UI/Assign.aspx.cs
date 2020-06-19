using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM2019.UI
{
    public partial class Assign : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Fetch();
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
            Response.Close();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            DB sql = new DB();
            
            string query = @"INSERT INTO Reviews (UserID, SubmissionID) VALUES (?, ?)";
            int StatusID = sql.getStatus("Assigned");

            string update = @"UPDATE Submissions
                                SET StatusID = ?
                                WHERE SubmissionID = ?";

            foreach (GridViewRow row in gvPapers.Rows)
            {
                CheckBox chk = row.FindControl("cbSelect") as CheckBox;

                if (chk.Checked)
                {
                    string SubmissionID = gvPapers.DataKeys[row.RowIndex].Value.ToString();

                    List<object> paramUpdate = new List<object>();
                    paramUpdate.Add(StatusID);
                    paramUpdate.Add(SubmissionID);

                    sql.ExecuteNonQuery_Parametized(update, paramUpdate);

                    string PCM1 = (row.FindControl("ddAssign1") as DropDownList).SelectedValue;
                    string PCM2 = (row.FindControl("ddAssign2") as DropDownList).SelectedValue;
                    string PCM3 = (row.FindControl("ddAssign3") as DropDownList).SelectedValue;

                    List<object> param1 = new List<object>();
                    List<object> param2 = new List<object>();
                    List<object> param3 = new List<object>();
                    
                    param1.Add(PCM1);
                    param2.Add(PCM2);
                    param3.Add(PCM3);

                    param1.Add(SubmissionID);
                    param2.Add(SubmissionID);
                    param3.Add(SubmissionID);

                    sql.ExecuteNonQuery_Parametized(query, param1);
                    sql.ExecuteNonQuery_Parametized(query, param2);
                    sql.ExecuteNonQuery_Parametized(query, param3);
                }
            }

            Fetch();
        }


        private void Fetch()
        {
            DB sql = new DB();

            int StatusID = sql.getStatus("Submitted");

            string query = @"SELECT SubmissionID, Title FROM Submissions WHERE StatusID = ?"; ;
            List<object> param = new List<object>();
            param.Add(StatusID);

            DataTable dt = sql.ExecuteQuery_Parametized(query, param);


            gvPapers.DataSource = dt;
            gvPapers.DataBind();

            query = @"SELECT 
                        CASE WHEN (SELECT COUNT(*) FROM Interested I WHERE U.UserID = I.UserID AND I.SubmissionID = ?) > 0
                        THEN U.Name || ' (Interested)'
                        ELSE U.Name
                        END AS Name,
                        UserID 
                        FROM USERS U WHERE RoleID = 3;";

            foreach (GridViewRow row in gvPapers.Rows)
            {
                string SubmissionID = gvPapers.DataKeys[row.RowIndex].Value.ToString();

                param = new List<object>();
                param.Add(SubmissionID);

                dt = sql.ExecuteQuery_Parametized(query, param);

                DropDownList dd1 = row.FindControl("ddAssign1") as DropDownList;
                DropDownList dd2 = row.FindControl("ddAssign2") as DropDownList;
                DropDownList dd3 = row.FindControl("ddAssign3") as DropDownList;

                dd1.DataSource = dt;
                dd2.DataSource = dt;
                dd3.DataSource = dt;

                dd1.DataBind();
                dd2.DataBind();
                dd3.DataBind();
            }
        }
    }
}