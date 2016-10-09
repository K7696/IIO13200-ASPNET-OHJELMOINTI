using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TimeTable
/// </summary>
public class TimeTable
{
    #region Properties

    /// <summary>
    /// Station short code (JNS)
    /// </summary>
    public string stationShortCode { get; set; }

    /// <summary>
    /// Station UIC code (460)
    /// </summary>
    public string stationUICCode { get; set; }

    /// <summary>
    /// Country code (FI)
    /// </summary>
    public string countryCode { get; set; }

    /// <summary>
    /// Type (DEPARTURE)
    /// </summary>
    public string Type { get; set; }

    /// <summary>
    /// Train stopping (true/false)
    /// </summary>
    public string trainStopping { get; set; }

    /// <summary>
    /// Commercial stop (true/false)
    /// </summary>
    public string commercialStop { get; set; }

    /// <summary>
    /// Commercial track (3)
    /// </summary>
    public string commercialTrack { get; set; }

    /// <summary>
    /// Cancelled (true/false)
    /// </summary>
    public string cancelled { get; set; }

    /// <summary>
    /// Scheduled time (2016-10-08T12:17:00.000Z)
    /// </summary>
    public string scheduledTime { get; set; }

    /// <summary>
    /// Actual time (2016-10-08T12:17:42.000Z)
    /// </summary>
    public string actualTime { get; set; }

    /// <summary>
    /// Difference in minutes (1)
    /// </summary>
    public string differenceInMinutes { get; set; }

    // causes on jotain mitä en tiedä vielä

    #endregion // Properties

    #region Constructors

    /// <summary>
    /// Default constructors
    /// </summary>
    public TimeTable()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #endregion // Constructors
}