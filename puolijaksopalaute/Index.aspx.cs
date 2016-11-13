using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using MySql.Data.MySqlClient;

public partial class Index : System.Web.UI.Page
{
    #region Private methods

    /// <summary>
    /// Get feedbacks from mysql
    /// </summary>
    /// <returns></returns>
    private List<Feedback> getFeedbacksFromMysql()
    {
        List<Feedback> list = new List<Feedback>();

        try
        {
            string constr = ConfigurationManager.ConnectionStrings["Feedbacks"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM palaute"))
                {
                    using (MySqlDataAdapter sda = new MySqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            foreach (DataRow dr in dt.Rows)
                            {
                                list.Add(new Feedback {
                                    pid = int.Parse(dr[0].ToString()),
                                    opintojakso = dr[1].ToString(),
                                    tekija = dr[2].ToString(),
                                    opittu = dr[3].ToString(),
                                    haluanoppia = dr[4].ToString(),
                                    hyvaa = dr[5].ToString(),
                                    parannettavaa = dr[6].ToString(),
                                    muuta = dr[7].ToString(),
                                    pvm = dr[8].ToString()
                                });
                            }
                            
                        }
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Response.Write("An error occured: " + ex.Message);
        }

        return list;
    }
    
    #endregion Private methods

    #region Protected methods

    protected void Page_Load(object sender, EventArgs e)
    {
        List<Feedback> list = getFeedbacksFromMysql();

        gvFeedbacks.DataSource = list;
        gvFeedbacks.DataBind();
    }

    #endregion Protected methods
}