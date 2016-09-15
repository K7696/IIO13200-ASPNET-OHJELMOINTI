using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class TarjousLaskuri : System.Web.UI.Page
{

    #region Properties

    /// <summary>
    /// kate% = 30% 
    /// </summary>
    private double marginPercent;

    /// <summary>
    /// LasinNelioHinta=45€/m2
    /// </summary>
    private double windowSquareMeterPrice;

    /// <summary>
    /// AlumiiniKarminJuoksumetriHinta=100€/jm 
    /// </summary>
    private double aluminiumFrameMeterPrice;

    /// <summary>
    /// Työmenekki=150€/ikkuna
    /// </summary>
    private double workPrice;

    #endregion // Properties

    #region Private methods

    /// <summary>
    /// Laske ikkunan pinta-ala
    /// </summary>
    /// <param name="width">Ikkunan leveys</param>
    /// <param name="height">Ikkunan korkeus</param>
    /// <param name="frame">Karmin leveys</param>
    /// <returns></returns>
    private double calculateWindowArea(double width, double height, double frameWidth) {
        // Tässä on vähän hämäävä speksi, että onko ikkunan pinta-alan oltava lasin ala vai ala karmeineen?????
        // Jos karmeineen, niin silloin allaoleva kaava ei toimi oikein?
        return ((height - (2 * frameWidth)) / 1000) * ((width - (2 * frameWidth)) / 1000);
    }

    /// <summary>
    /// Laske karmin piiri
    /// </summary>
    /// <param name="width">ikkunan leveys</param>
    /// <param name="height">ikkunan korkeus</param>
    /// <returns></returns>
    private double calculateFrame(double width, double height)
    {
        return 2 * ((width / 1000) + (height / 1000));
    }

    /// <summary>
    /// Laske ikkunan hinta
    /// </summary>
    /// <param name="windowArea">Ikkunan pinta-ala</param>
    /// <param name="frame">Karmipuun piiri</param>
    /// <returns></returns>
    private double calculateWindowPrice(double windowArea, double frame)
    {
        return (1 + (marginPercent / 100)) * ((windowArea * windowSquareMeterPrice) + (frame * aluminiumFrameMeterPrice) + (workPrice));
    }

    /// <summary>
    /// Lue web.config
    /// </summary>
    private void readConfiguration()
    {
        // Luetaan tarvittavat parametrit web.config:sta
        bool marginPercentParse = double.TryParse(
                ConfigurationManager.AppSettings["marginPercent"], out marginPercent);

        bool windowSquareMeterPriceParse = double.TryParse(
            ConfigurationManager.AppSettings["windowSquareMeterPrice"], out windowSquareMeterPrice);

        bool aluminiumFrameMeterPriceParse = double.TryParse(
                ConfigurationManager.AppSettings["aluminiumFrameMeterPrice"], out aluminiumFrameMeterPrice);

        bool workPriceParse = double.TryParse(
                ConfigurationManager.AppSettings["workPrice"], out workPrice);


        if (!marginPercentParse ||
            !windowSquareMeterPriceParse ||
            !aluminiumFrameMeterPriceParse ||
            !workPriceParse)
        {
            // Ei saatu luettua web.config:sta, joten heitä poikkeus
            throw new Exception("Varoitus: Ohjelman alustuksessa tapahtui virhe. Ota yhteyttä ylläpitoon.");
        }
    }

    /// <summary>
    /// Aseta labelit default-arvoihin
    /// </summary>
    private void resetLabels()
    {
        lblSystemMessage.Text = "";
        lblFrameCircuit.Text = "...";
        lblWindowArea.Text = "...";
        lblPrice.Text = "...";
    }

    /// <summary>
    /// Ikkunan lasku
    /// </summary>
    private void calculateWindowPrice()
    {
        // Tyhjennä edelliset arvot
        resetLabels();

        // Alusta tarvittavat muuttujat
        double windowWidth = 0;
        double windowHeight = 0;
        double frameWidth = 0;

        // Ota kentistä arvot
        string strWindowWidth = tbWindowWidth.Text;
        string strWindowHeight = tbWindowHeight.Text;
        string strFrameWidth = tbFrameWidth.Text;

        // Parse doubles
        bool windowWidthParse = double.TryParse(strWindowWidth, out windowWidth);
        bool windowHeightParse = double.TryParse(strWindowHeight, out windowHeight);
        bool frameParse = double.TryParse(strFrameWidth, out frameWidth);

        if (windowWidth == 0.0 ||
            windowHeight == 0.0 ||
            !windowWidthParse ||
            !windowHeightParse ||
            !frameParse)
        {
            // Heitä poikkeus virheellisistä syötteistä
            throw new Exception("Varoitus: Ikkunan hintaa ei voitu laskea. Tarkasta syötteet.");
        }
        else
        {
            double frame = 0;
            double windowArea = 0;
            double windowPrice = 0;

            // Laske ikkunan pinta-ala
            windowArea = calculateWindowArea(windowWidth, windowHeight, frameWidth);
            lblWindowArea.Text = windowArea.ToString();

            // Laske karmin piiri
            frame = calculateFrame(windowWidth, windowHeight);
            lblFrameCircuit.Text = frame.ToString();

            // Laske ikkunan hinta
            windowPrice = calculateWindowPrice(windowArea, frame);
            lblPrice.Text = Math.Round(windowPrice, 2).ToString();
        }
    }

    #endregion // Private methods

    #region Protected methods

    /// <summary>
    /// Suoritetaan sivun latautuessa
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try { 
            // Lue configuraatio
            readConfiguration();
        }
        catch (Exception ex)
        {
            // Näytä poikkeus
            lblSystemMessage.Text = ex.Message;
        }
    }

    /// <summary>
    /// Suoritetaan kun klikataan laske tarjoushintapainiketta
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnCalculateOffer_Click(object sender, EventArgs e)
    {
        try
        {
            // Laske ikkunan hinta
            calculateWindowPrice();
        }
        catch (Exception ex)
        {
            // Näytä poikkeus
            lblSystemMessage.Text = ex.Message;
        }
    }

    #endregion // Protected methods
}