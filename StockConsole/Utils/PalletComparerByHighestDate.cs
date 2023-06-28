using StockConsole.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockConsole.Utils
{
    public class PalletComparerByHighestDate : IComparer<Pallet>
    {
        public int Compare(Pallet? x, Pallet? y)
        {
            var maxDatePalletX = x.Max(box => box.ExpirationDate);
            var maxDatePalletY = y.Max(box => box.ExpirationDate);

            return (maxDatePalletX.DayNumber - maxDatePalletY.DayNumber);
        }
    }
}
