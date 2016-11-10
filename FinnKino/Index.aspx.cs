using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

public class Theatre
{
    #region Properties

    public int Id { get; set; }
    public string Name { get; set; }

    #endregion Properties
}

public class Movie
{
    #region Properties

    public int Id { get; set; }
    public string Name { get; set; }
    public string RatingImageUrl { get; set; }

    #endregion Properties
}

public partial class Index : System.Web.UI.Page
{
    #region Private methods

    private List<Movie> getMovies(string id)
    {
        List<Movie> list = new List<Movie>();

        try
        {
            XmlDocument doc = new XmlDocument();

            var monday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Monday);

            date.Text = string.Format("{0}-{1}", monday.ToShortDateString(), monday.AddDays(7).ToShortDateString());

            // Load data  
            doc.Load(string.Format("http://www.finnkino.fi/xml/Schedule/?area={0}&dt={1}&nrOfDays={2}", id, monday.ToShortDateString(), 7));

            XmlNodeList nodes = doc.SelectNodes("//Shows/Show");

            foreach (XmlNode node in nodes)
            {
                list.Add(new Movie
                {
                    Id = int.Parse(node.ChildNodes[0].InnerText),
                    Name = node.ChildNodes[15].InnerText,
                    RatingImageUrl = node.ChildNodes[35].ChildNodes[2].InnerText
                });
            }
        }
        catch (Exception)
        {
            err.Text = "Elokuvia ei voitu nyt hakea.";
        }
       
        return list;
    }

    private List<Theatre> getTheatres()
    {
        List<Theatre> list = new List<Theatre>();

        try
        {
            XmlDocument doc = new XmlDocument();

            // Load data  
            doc.Load("http://www.finnkino.fi/xml/TheatreAreas/");
 
            XmlNodeList nodes = doc.SelectNodes("//TheatreArea");

            foreach (XmlNode node in nodes)
            {
                list.Add(new Theatre
                {
                    Id = int.Parse(node.ChildNodes[0].InnerText),
                    Name = node.ChildNodes[1].InnerText
                });
            }
        }
        catch (Exception)
        {
            err.Text = "Teattereiden haku ei onnistunut.";
        }

        return list;
    }

    #endregion Private methods

    #region Protected methods

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Theatre> list = getTheatres();

            foreach (var item in list)
            {
                ListBox1.Items.Add(new ListItem(item.Name, item.Id.ToString()));
            }
        }
    }

    protected void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Get the currently selected item in the ListBox.
        ListItem item = ListBox1.SelectedItem;
        string id = item.Value;
        string name = item.Text;

        lblHeader.Text = name;

        List<Movie> list = getMovies(id);

        rptMovies.DataSource = list;
        rptMovies.DataBind();
    }

    #endregion Protected methods

}