using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SourceExampleTarget : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string msg = "";

        // VE1 query string 
        msg += "<h3>QueryString</h3>";
        msg += "URL:sta välitetty viesti: " + Request.QueryString["Message"];
        msg += "<br />";

        foreach (string key in Request.QueryString)
        {
            msg += "URL:sta löytyy avain: " + key + " ja sen arvo on " + Request.QueryString[key] + "<br />";
        }

        // VE2 session 
        msg += "<h3>Session</h3>";
        msg += "Sessionista haettu viesti: " + Session["Message"];
        msg += "<br />";

        // VE3 cookie 
        msg += "<h3>Cookie</h3>";

        // Tarkastetaan löytyykö haluttua keksiä
        foreach (string kex in Request.Cookies)
        {
            if (kex == "Message")
                msg += "Keksissä lukee: " + Request.Cookies[kex].Value;
        }

        msg += "<br />";

        // VE4 Property 
        msg += "<h3>Property</h3>";

        var previousPage = PreviousPage;
        if(previousPage != null)
        {
            msg += "Ed.sivun property on: " + previousPage.SecretMessage;
            msg += "<br />";
        }        

        myText.InnerHtml = msg;
    }
}