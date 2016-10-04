using JAMK.IT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Asiakastiedot : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DataView dv = new DataView();
            DataTable dt = DBDemoxOy.GetDataReal();
            dv = dt.DefaultView;
            sqlCustomers.DataSource = dv;
            sqlCustomers.DataBind();
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.ToString();
        }
        
    }
}