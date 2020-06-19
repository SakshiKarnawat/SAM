using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DAL;
using System.Data;

namespace SAM2019.UI
{
    public partial class Submit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (filePaper.HasFile)
            {
                DB sql = new DB();

                int UserID = Int16.Parse(Session["UserID"].ToString());
                int StatusID = sql.getStatus("Submitted");
                byte[] paper = filePaper.FileBytes;
                string author = Session["User"].ToString();
                string title = txtTitle.Text;
                string format = Path.GetExtension(filePaper.FileName);
                string filename = Path.GetFileNameWithoutExtension(filePaper.FileName);

                string query = @"INSERT INTO Submissions (UserID, StatusID, Title, Format, FileName) VALUES ({0}, {1}, '{2}', '{3}', '{4}')";
                query = String.Format(query, UserID, StatusID, title, format, filename);

                sql.ExecuteNonQuery(query);

                List<object> parameters = new List<object>();
                parameters.Add(title);
                query = @"SELECT SubmissionID FROM Submissions WHERE Title = ?";

                DataTable dt = sql.ExecuteQuery_Parametized(query, parameters);

                int SubmissionID = Int16.Parse(dt.Rows[0]["SubmissionID"].ToString());


                parameters.Clear();
                parameters.Add(paper);
                parameters.Add(SubmissionID);
                query = @"INSERT INTO Papers (PaperBin, SubmissionID) VALUES (?, ?)";

                sql.ExecuteNonQuery_Parametized(query, parameters);
            }
        }
    }
}