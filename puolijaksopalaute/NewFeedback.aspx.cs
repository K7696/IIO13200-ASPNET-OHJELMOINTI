using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NewFeedback : System.Web.UI.Page
{

    #region Private methods

    /// <summary>
    /// Save feedback to mysql
    /// </summary>
    /// <param name="feedback"></param>
    private bool saveFeedBack(Feedback feedback)
    {
        string insertSql = string.Format(@"
INSERT INTO palaute 
(
    opintojakso,
    tekija,
    opittu,
    haluanoppia,
    hyvaa,
    parannettavaa,
    muuta,
    pvm
)
VALUES 
(
    '{0}',
    '{1}',
    '{2}',
    '{3}',
    '{4}',
    '{5}',
    '{6}',
    '{7}'
)
", 
feedback.opintojakso,
feedback.tekija,
feedback.opittu,
feedback.haluanoppia,
feedback.hyvaa,
feedback.parannettavaa,
feedback.muuta,
feedback.pvm);

        try
        {
            string constr = ConfigurationManager.ConnectionStrings["Feedbacks"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = insertSql;
                    cmd.ExecuteNonQuery();
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("An error occured: " + ex.Message);
        }

        return true;
    }

    #endregion Private methods

    #region Protected methods

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSend_Click(object sender, EventArgs e)
    {
        if (Page.IsValid)
        {
            Feedback feedback = new Feedback
            {
                opintojakso = tbCourse.Text,
                tekija = tbName.Text,
                opittu = tbLearned.Text,
                haluanoppia = tbWantToLearn.Text,
                hyvaa = tbGood.Text,
                parannettavaa = tbToDoBetter.Text,
                muuta = tbOther.Text,
                pvm = DateTime.Now.ToString()
            };

            bool saved = saveFeedBack(feedback);

            if (saved)
            {
                Response.Redirect("Index.aspx");
            }
        }
    }

    #endregion Protected methods
}