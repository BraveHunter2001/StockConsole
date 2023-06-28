using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockConsole.Models
{
    public class Box : StockItem
    {
        public DateOnly? DateOfProduction { get; set; } = null;

        private DateOnly expirationDate;
        public override DateOnly ExpirationDate { get {
                if (DateOfProduction == null)
                    return expirationDate;
                else
                    return DateOfProduction.Value.AddDays(DAYS_FOR_EXPIRATE);

            } set => expirationDate= value; }

        public const int DAYS_FOR_EXPIRATE = 100;

        public Box(int id, int width, int height, int depth, int weigh)
        {
            ID = id;
            Width = width; 
            Height = height;
            Depth = depth;
            Weight = weigh;
            Volume = width * height * depth;
        }

        public override string ToString()
        {
            return $"BOX {ID}: Width[{Width}]" +
                $" Heigth[{Height}]" +
                $" Depth[{Depth}]" +
                $" Weight[{Weight}]" +
                $" Volume[{Volume}]" +
                $" DateExp[{ExpirationDate}]";
        }
    }
}
