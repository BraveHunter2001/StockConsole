using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockConsole.Exceptions
{
    public class InvalidAddedBoxException: Exception
    {
        public InvalidAddedBoxException(string msg) : base(msg) { }
     
    }
}
