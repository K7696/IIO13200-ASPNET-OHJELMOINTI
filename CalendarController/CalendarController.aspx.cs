using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DateTimeSpan;

public partial class CalendarController : System.Web.UI.Page
{
    #region Properties

    private DateTime _today { get; set; }
    private DateTime _selectedDate { get; set; }
    private string _selectedDateStr { get; set; }
    private readonly string _cookieName = "Today";

    // Poikkeudet
    private readonly string _cookieError = "Varoitus: Keksistä lukeminen epäonnistui.";
    private readonly string _error = "Varoitus: Päivien lukumäärän laskeminen epäonnistui.";

    #endregion // Properties

    #region Private methods

    /// <summary>
    /// Laske päivämääräerotus
    /// </summary>
    private void _calculateDateDifference()
    {
        // Kalenterin valittupäivä
        _selectedDateStr = Calendar1.SelectedDate.ToShortDateString();
        lblChosenDate.Text = _selectedDateStr;
        _selectedDate = DateTime.Parse(_selectedDateStr);

        // Laske päivien erotus (Voidaan laskea myös näin)
        TimeSpan dateDifference = (DateTime.Now.Date - _selectedDate);
        // Päivinä yht.
        lblAllDays.Text = dateDifference.TotalDays.ToString();

        // Helpompi tapa saada päivämäärien erot on
        var dateSpan = DateTimeSpan.DateTimeSpan.CompareDates(_selectedDate, DateTime.Now.Date);

        // Päivät
        lblDateDifference.Text = dateSpan.Days.ToString();

        // Kuukaudet
        lblMonthDifference.Text = dateSpan.Months.ToString();

        // Vuodet
        lblYearDifference.Text = dateSpan.Years.ToString();
    }

    /// <summary>
    /// Aseta kalenterin päivä sivulle tultaessa ekaa kertaa
    /// </summary>
    private void _setCalendarDateOnLoad()
    {
        Calendar1.VisibleDate = _today;
        Calendar1.TodaysDate = _today;
        Calendar1.SelectedDate = _today;
    }

    /// <summary>
    /// Kirjoita _today keksiin
    /// </summary>
    private void _createCookie()
    {
        // Luodaan keksi ja kirjoitetaan siihen viesti
        HttpCookie cookie = new HttpCookie(_cookieName, _today.ToString());
        cookie.Expires = DateTime.Now.AddMinutes(30);
        Response.Cookies.Add(cookie);
    }

    /// <summary>
    /// Lue päivämäärä keksistä
    /// </summary>
    private void _readCookie()
    {
        // Tarkastetaan, että löytyykö keksiä
        if(Request.Cookies[_cookieName] != null)
        {
            string strToday = Request.Cookies[_cookieName].Value;
            DateTime dt;
            bool todayParse = DateTime.TryParse(strToday, out dt);

            if(todayParse)
            {
                _today = dt;
            }
            else
            {
                throw new Exception(_cookieError);
            }
        }
        else
        {
            throw new Exception(_cookieError);
        }

    }

    #endregion // Private methods

    #region Protected methods

    /// <summary>
    /// Sivun latautuessa
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Tultiin sivulle, joten aseta tämä päivä
        lblToday.Text = "TÄNÄÄN ON " + DateTime.Today.ToShortDateString();

        if (IsPostBack)
        {
            try
            {
                // Luetaan keksiin tallennettu päivämäärä
                _readCookie();
            }
            catch (Exception ex)
            {
                lblSystemMessage.Text = ex.Message;
            }
            
        }
        else
        {
            try
            {
                // Alustetaan nykyhetki
                _today = DateTime.Today;

                // Kirjoitetaan nykyhetki keksiin
                _createCookie();

                // Asetetaan kalenteri
                _setCalendarDateOnLoad();
            }
            catch (Exception ex)
            {
                lblSystemMessage.Text = ex.Message;
            }
        }
    }

    

    /// <summary>
    /// Valitaan päivä kalenterista
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        try
        {
            _calculateDateDifference();
        }
        catch (Exception)
        {
            lblSystemMessage.Text = _error;
        }
    }

    /// <summary>
    /// Vähennä vuosi
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void bntPrevious_Click(object sender, EventArgs e)
    {
        try
        {
            // Vähennä vuosi
            _today = new DateTime(_today.Year, _today.Month, _today.Day).AddMonths(-12);
            _setCalendarDateOnLoad();
            _createCookie();
        }
        catch (Exception)
        {
            lblSystemMessage.Text = _error;
        }
    }

    /// <summary>
    /// Lisää vuosi
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnNext_Click(object sender, EventArgs e)
    {
        try
        {
            // Lisää vuosi
            _today = new DateTime(_today.Year, _today.Month, _today.Day).AddMonths(12);
            _setCalendarDateOnLoad();
            _createCookie();
        }
        catch (Exception)
        {
            lblSystemMessage.Text = _error;
        }
    }

    #endregion // Protected methods

}