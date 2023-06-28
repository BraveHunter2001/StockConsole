using StockConsole.Exceptions;
using StockConsole.Models;

namespace Tests
{
    public class Model_Pallet
    {
        [Fact]
        public void AddBox_Successful()
        {
            Pallet pallet = new Pallet(0, 10, 10, 10);
            Box b1 = new Box(0, 1, 1, 1, 2) { ExpirationDate = new DateOnly(2000, 1, 1) };
            Box b2 = new Box(0, 1, 1, 1, 2) { ExpirationDate = new DateOnly(2000, 2, 1) };
            Box b3 = new Box(0, 1, 1, 1, 2) { ExpirationDate = new DateOnly(2000, 2, 1) };

            pallet.Add(b1);
            pallet.Add(b2);
            pallet.Add(b3);

            Assert.Equal(pallet.Boxes.Count, 3);

            Assert.Contains(b1, pallet);
            Assert.Contains(b2, pallet);
            Assert.Contains(b3, pallet);

            Assert.Equal(b1.ExpirationDate, pallet.ExpirationDate);

            int weight = b1.Weight + b2.Weight + b3.Weight + Pallet.WEIGHT_ONLY_PALLET;
            Assert.Equal(weight, pallet.Weight);

            int volume = b1.Volume + b2.Volume + b3.Volume + pallet.Width*pallet.Height*pallet.Depth;
            Assert.Equal(volume, pallet.Volume);

        }

        [Fact]
        public void AddBox_Exceptions()
        {
            Pallet pallet = new Pallet(0, 10, 10, 10);
            Box b1 = new Box(0, 200, 10, 1, 2) { ExpirationDate = new DateOnly(2000, 1, 1) };
            

            Assert.Throws<InvalidAddedBoxException>(()=>pallet.Add(b1));


          
        }
    }
}
