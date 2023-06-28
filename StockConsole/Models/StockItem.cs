using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockConsole.Models
{
    public abstract class StockItem
    {
        public int ID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Depth { get; set; }
        public int Weight { get; set; }
        public int Volume { get; set; }
        public abstract DateOnly ExpirationDate { get; set; }
        

    }
}
