using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLotto
{
    /// <summary>
    /// Lotto-vaihtoehtoja Suomessa on kaksi: Suomi ja VikingLotto. Suomi-lotossa arvotaan seitsemän (7) numero 39:sta, 
    /// Viking Lotossa arvotaan kuusi (6) numeroa 48:sta.
    /// </summary>
    public class Lottery
    {
        #region Properties
        /// <summary>
        /// Example: int randomNumber = random.Next(0, 1000);
        /// </summary>
        private Random randomizer = new Random();

        private readonly int lotteryStart = 1;
        private readonly int lotteryEnd = 39;
        public readonly int lotteryCharacterCount = 7;
        private readonly int vikingLotteryStart = 1;
        private readonly int vikingLotteryEnd = 49;
        public readonly int vikingLotteryCharacterCount = 6;

        #endregion // Properties

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public Lottery()
        {
            // Alusta tarvittavat 
            randomizer = new Random();
        }

        #endregion // Constructors

        #region Private methods

        /// <summary>
        /// Generoi lottorivi
        /// </summary>
        /// <param name="lotteryCharacterCount"></param>
        /// <returns></returns>
        private List<int> _getLotteryRow(int lotteryCharacterCount, int lotteryStart, int lotteryEnd)
        {
            List<int> lotteryRow = new List<int>();
            int number = 0;

            for (int i = 0; i < lotteryCharacterCount; i++)
            {
                do
                {
                    number = randomizer.Next(lotteryStart, lotteryEnd);
                } while (lotteryRow.Contains(number));

                lotteryRow.Add(number);
            }

            return lotteryRow;
        }

        #endregion // Private methods

        #region Public methods

        /// <summary>
        /// Palauta loton rivi
        /// </summary>
        /// <param name="type">1 = Tavallinen lotto, 2 = Viking-lotto</param>
        /// <param name="rows">Rivien lukumäärä</param>
        public List<int> GenerateLottoRow(int type)
        {
            if(type == 1)
                return _getLotteryRow(lotteryCharacterCount, lotteryStart, lotteryEnd);
            else if(type == 2)
                return _getLotteryRow(vikingLotteryCharacterCount, vikingLotteryStart, vikingLotteryEnd);

            return null;
        }

        #endregion // Public methods

    }
}
