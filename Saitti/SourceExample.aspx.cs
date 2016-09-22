using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SourceExample : System.Web.UI.Page
{
    public string SecretMessage {
        get
        {
            return txtMessage.Text;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // Alustetaan kontrollit yleensä vain kerran

        if(!IsPostBack)
        {
            ddlMessages.Items.Add("Hello.");
            ddlMessages.Items.Add("Ping?");
            ddlMessages.Items.Add("HandShake?");
            ddlMessages.Items.Add("Goodbye!");
        }
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        // Tarvii web.configiin asetuksen: http://stackoverflow.com/questions/16660900/webforms-unobtrusivevalidationmode-requires-a-scriptresourcemapping-for-jquery
        // Asetus: <add key="ValidationSettings:UnobtrusiveValidationMode" value="None" />
        if (Page.IsValid)
        {
            // We will use standard redirection with redirect
            Response.Redirect("SourceExampleTarget.aspx?User=Esa&Message=" + txtMessage.Text);
        }       
    }

    protected void btnSession_Click(object sender, EventArgs e)
    {
        // Kirjoitetaan sessioniin ja siirrytään toiselle sivulle
        Session["Message"] = txtMessage.Text;
        Response.Redirect("SourceExampleTarget.aspx");
    }

    protected void btnCookie_Click(object sender, EventArgs e)
    {
        // Luodaan keksi ja kirjoitetaan siihen viesti
        HttpCookie cookie = new HttpCookie("Message", txtMessage.Text);
        cookie.Expires = DateTime.Now.AddMinutes(15);
        Response.Cookies.Add(cookie);
    }

    protected void btnPublicProperty_Click(object sender, EventArgs e)
    {
        // Siirretään propertyt (SecretMessage) allaolevaan sivulle
        // Tarvii vastaanottavalle sivulle määrityksen: <%@ PreviousPageType VirtualPath="~/SourceExample.aspx" %>
        Server.Transfer("SourceExampleTarget.aspx");
    }

    protected void ddlMessages_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Kirjoitetaan valittu vakioteksti txtboxiin
        txtMessage.Text = ddlMessages.SelectedItem.ToString();
    }
}