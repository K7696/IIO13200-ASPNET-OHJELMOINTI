using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.UI.WebControls;

public partial class AsemapaikanJunat : System.Web.UI.Page
{
    #region Properties

    // Webservice urls
    private string trainsUrl = "http://rata.digitraffic.fi/api/v1/live-trains?station=";
    private string stationsUrl = "http://rata.digitraffic.fi/api/v1/metadata/stations";

    // Error messages
    private const string trainsNotFoundError = "Huomio: Valitulla liikennepaikalla ei ole junaliikennettä.";

    #endregion // Properties

    #region Private methods

    /// <summary>
    /// Get trains
    /// </summary>
    /// <param name="stationShortCode">Station short code</param>
    /// <returns>List of trains</returns>
    private List<Train> getTrains(string stationShortCode)
    {
        List<Train> trains = null;

        using (var client = new WebClient())
        {
            string completeUrl = trainsUrl + stationShortCode;
            client.Encoding = Encoding.UTF8;
            var json = client.DownloadString(completeUrl);
            var serializer = new JavaScriptSerializer();
            trains = serializer.Deserialize<List<Train>>(json);
        }

        return trains;
    }

    /// <summary>
    /// Get stations
    /// </summary>
    /// <returns>List of stations</returns>
    private List<Station> getStations()
    {
        List<Station> stations = null;

        using (var client = new WebClient())
        {
            client.Encoding = Encoding.UTF8;
            var json = client.DownloadString(stationsUrl);
            var serializer = new JavaScriptSerializer();
            stations = serializer.Deserialize<List<Station>>(json);
        }

        return stations;
    }

    /// <summary>
    /// Resets ui
    /// </summary>
    private void resetUI()
    {
        lblSystemMessage.Text = "";

        gvTrains.DataSource = null;
        gvTrains.DataBind();
    }

    #endregion // Private methods

    #region Protected methods

    /// <summary>
    /// Page loading
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblNow.Text = DateTime.Now.ToShortDateString();

            if (!IsPostBack)
            {
                List<Station> stations = getStations();

                foreach (var st in stations)
                {
                    dpStations.Items.Add(new ListItem {
                        Text = st.stationName,
                        Value = st.stationShortcode
                    });
                }
            }           
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// Get trains
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnGetTrains_Click(object sender, EventArgs e)
    {
        try
        {
            resetUI();

            // Get selected item's value
            string stationShortCode = dpStations.SelectedItem.Value;

            List<Train> trains = getTrains(stationShortCode);

            if(trains != null && trains.Count > 0)
            {
                List<Train> completeTrainList = new List<Train>();                  
                completeTrainList.AddRange(trains.Where(x => DateTime.Parse(x.departureDate) > DateTime.Now.AddDays(-1)));

                // Format dates
                completeTrainList.ForEach(x => {
                    x.departureDate = DateTime.Parse(x.departureDate).ToString("dd.MM.yyyy");
                });

                gvTrains.DataSource = completeTrainList;
                gvTrains.DataBind();

                if (completeTrainList.Count() > 0)
                {
                    lblTrains.Text = "Junat";
                    lblSystemMessage.Text = "Junia löytyi: " + completeTrainList.Count();
                }                   
                else
                    lblSystemMessage.Text = trainsNotFoundError;
            }
            else
            {
                lblSystemMessage.Text = trainsNotFoundError;
            }
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = ex.Message;
        }
    }

    #endregion // Protected methods

}