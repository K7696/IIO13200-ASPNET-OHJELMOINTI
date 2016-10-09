using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Station
/// </summary>
public class Station
{
    #region Properties

    /// <summary>
    /// Passenger traffic (true/false)
    /// </summary>
    public string passengerTraffic { get; set; }
    
    /// <summary>
    /// Type (STATION)
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Station name (Ahonpää)
    /// </summary>
    public string stationName { get; set; }

    /// <summary>
    /// Station short code (AHO)
    /// </summary>
    public string stationShortcode { get; set; }

    /// <summary>
    /// Station UIC code (1343)
    /// </summary>
    public string stationUICCode { get; set; }

    /// <summary>
    /// Country code (FI)
    /// </summary>
    public string countryCode { get; set; }

    /// <summary>
    /// Longitude (25.01206612315972)
    /// </summary>
    public string longitude { get; set; }

    /// <summary>
    /// Latitude (64.55181651445501)
    /// </summary>
    public string latitude { get; set; }

    #endregion // Properties

    #region Constructors

    /// <summary>
    /// Default constructor
    /// </summary>
    public Station()
    {

    }

    #endregion // Constructors
}