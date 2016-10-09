using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Train
/// https://msdn.microsoft.com/en-us/library/hh674188.aspx
/// http://stackoverflow.com/questions/8270464/best-way-to-call-a-json-webservice-from-a-net-console
/// http://jsonlint.com/
/// </summary>
public class Train
{
    #region Properties

    /// <summary>
    /// Train number
    /// </summary>
    public string trainNumber { get; set; }

    /// <summary>
    /// Departure date
    /// </summary>
    public string departureDate { get; set; }

    /// <summary>
    /// Operator UIC Code
    /// </summary>
    public string operatorUICCode { get; set; }

    /// <summary>
    /// Train type (IC)
    /// </summary>
    public string trainType { get; set; }

    /// <summary>
    /// Train category (Long-distance)
    /// </summary>
    public string trainCategory { get; set; }

    /// <summary>
    /// Commuter line ID
    /// </summary>
    public string commuterLineID { get; set; }

    /// <summary>
    /// Running currently (true/false)
    /// </summary>
    public string runningCurrently { get; set; }

    /// <summary>
    /// Cancelled (true/false)
    /// </summary>
    public string cancelled { get; set; }

    /// <summary>
    /// Version (142004786692)
    /// </summary>
    public string version { get; set; }

    /// <summary>
    /// List of timeTable objects
    /// </summary>
    public List<TimeTable> timeTableRows { get; set; }

    #endregion // Properties

    #region Constructors

    /// <summary>
    /// Default constructor
    /// </summary>
    public Train()
    {
        timeTableRows = new List<TimeTable>();
    }

    #endregion // Constructors
}