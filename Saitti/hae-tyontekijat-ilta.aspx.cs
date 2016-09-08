using System;
using System.Configuration; // Web.Configia varten
using System.Data; // Ado.net-luokkia varten
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class hae_tyontekijat_ilta : System.Web.UI.Page
{

    string xmlFilu; 

    protected void Page_Load(object sender, EventArgs e)
    {
        // Luetaan Web.Config:sta xml-tiedoston nimi.
        xmlFilu = ConfigurationManager.AppSettings["tiedosto"];
        lglMessage.Text = xmlFilu;
    }

    protected void btnHae_Click(object sender, EventArgs e)
    {
        // Luetaan xml-tiedostosta työntekijöiden tiedot ja esitetään ne gridView:ssa.
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataView dv = new DataView(); // Filtteröintiä ja suoritusta varten

        ds.ReadXml(Server.MapPath(xmlFilu)); // Kannattaa käyttää Server.MapPathia
        dt = ds.Tables[0];
        dv = dt.DefaultView;

        // Datan sitominen ui-kontrolliin
        gvData.DataSource = dv;
        gvData.DataBind();

        lglMessage.Text = string.Format("Löytyi {0} työntekijää", dt.Rows.Count);
    }
}