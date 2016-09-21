using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLLotto;
using System.Data;

public partial class Lotto : System.Web.UI.Page
{

    #region Properties

    // Virheet
    private readonly string _invalidLotteryRowCount = "Huomio: Arvottavien lottorivien lukumäärän tulee olla vähintään yksi. Tarkasta syöte.";
    private readonly string _lotteryRowError = "Virhe: Loton riviä ei saatu muodostettua.";
    private readonly string _systemLoadError = "Virhe: Ohjelmaa ei saatu alustettua. Ota yhteyttä ylläpitoon.";
    
    // Tyylit
    private readonly string _activeDiv = "tab-pane fade in active";
    private readonly string _inActiveDiv = "tab-pane fade in";
    private readonly string _activeClass = "active";

    // BusinessLogiikka
    private Lottery _lotto { get; set; }

    #endregion // Properties

    #region Private methods

    /// <summary>
    /// Palauta dataView gridille.
    /// Tämä tehdään näin, koska DataTable:n muodostaminen on ui-logiikkaa.
    /// Lottorivin muodostus tehdään erillisessä dll:ssa, koska se on business-logiikkaa.
    /// </summary>
    /// <param name="rows">Lottorivien lkm</param>
    /// <param name="charactercount">6 = Viking-lotto, 7 tavallinen lotto</param>
    /// <param name="type">1 = Tavallinen lotto, 2 = Viking-lotto</param>
    /// <returns>DataView:n, mikä sisältää lottorivit</returns>
    private DataView _getLottoDv(int rows, int charactercount, int type)
    {
        List<int> lotteryRow = new List<int>();
        DataTable dt = new DataTable();
        DataView dv = new DataView();

        // Aseta rivi-otsikko
        dt.Columns.Add("[Rivi]");

        for (int i = 0; i < charactercount; i++)
        {
            // Aseta numeroille otsikot
            dt.Columns.Add("nro" + (i + 1).ToString());
        }

        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            // Lisää rivi
            dt.Rows.Add();

            // Lisää rivinumero
            dt.Rows[i][0] = "[" + (i + 1).ToString() + "]";

            // Hae lottorivi
            lotteryRow = _lotto.GenerateLottoRow(type);

            // Jos lottorivi on null, heitä poikkeus
            if (lotteryRow == null) throw new Exception(_lotteryRowError);

            // Järjestä rivin numerot pienimmästä suurempaan
            lotteryRow.Sort();

            index = 0;
            foreach (var number in lotteryRow)
            {
                // Lisää rivin "soluun" lottonumero
                dt.Rows[i][index+1] = number;
                index++;
            }

        }

        dv = dt.DefaultView;

        return dv;
    }

    /// <summary>
    /// Reset ui
    /// </summary>
    /// <param name="type">1 = Tavallinen lotto, 2 = Viking-lotto</param>
    private void _resetUI(int type)
    {
        lblSystemMessage.Text = "";

        // Tyhjennä gridit
        gvLottoRows.DataSource = null;
        gvLottoRows.DataBind();

        gvVikingRows.DataSource = null;
        gvVikingRows.DataBind();

        if(type == 1)
        {
            tab1.Attributes.Add("class", _activeClass);
            tab2.Attributes.Add("class", "");

            lottoDiv.Attributes.Add("class", _activeDiv);
            vikingDiv.Attributes.Add("class", _inActiveDiv);
        }            
        else if(type == 2)
        {
            tab1.Attributes.Add("class", "");
            tab2.Attributes.Add("class", _activeClass);

            lottoDiv.Attributes.Add("class", _inActiveDiv);
            vikingDiv.Attributes.Add("class", _activeDiv);
        }
    }


    #endregion // Private methods

    #region Protected methods

    /// <summary>
    /// Suoritetaan sivun alussa
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        // Alusta lotto-olio
        try
        {
            _lotto = new Lottery();
        }
        catch (Exception ex)
        {
            lblSystemMessage.Text = _systemLoadError;
        }

        // Aseta aktiivinen tab
        tab1.Attributes.Add("class", _activeClass);
        lottoDiv.Attributes.Add("class", _activeDiv);
        vikingDiv.Attributes.Add("class", _inActiveDiv);
    }

    /// <summary>
    /// Arvotaaan rivit tavalliselle lotolle
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnLotto_Click(object sender, EventArgs e)
    {
        // Reset UI
        _resetUI(1);

        // Rivimäärä ja tarkasta syöte
        int rows = 0;
        bool rowsParse = int.TryParse(txtLottoRows.Text, out rows);

        if (!rowsParse || rows == 0) {
            lblSystemMessage.Text = _invalidLotteryRowCount;
        }
        else {
            try
            {
                gvLottoRows.DataSource = _getLottoDv(rows, _lotto.lotteryCharacterCount, 1);
                gvLottoRows.DataBind();
            }
            catch (Exception ex)
            {
                lblSystemMessage.Text = ex.Message;
            }
        }
    }

    /// <summary>
    /// Arvotaan rivit viking-lotolle
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnViking_Click(object sender, EventArgs e)
    {
        // Reset UI
        _resetUI(2);

        // Rivimäärä ja tarkasta syöte
        int rows = 0;
        bool rowsParse = int.TryParse(txtVikingLottoRows.Text, out rows);

        if (!rowsParse || rows == 0)
        {
            lblSystemMessage.Text = _invalidLotteryRowCount;
        }
        else
        {
            try
            {               
                gvVikingRows.DataSource = _getLottoDv(rows, _lotto.vikingLotteryCharacterCount, 2);
                gvVikingRows.DataBind();
            }
            catch (Exception ex)
            {
                lblSystemMessage.Text = ex.Message;
            }
        }
    }

    #endregion // Protected methods
}