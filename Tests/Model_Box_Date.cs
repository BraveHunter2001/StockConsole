using StockConsole.Models;

namespace Tests
{
    public class Model_Box_Date
    {
        [Fact]
        public void CreateBoxWithDateOfProduct()
        {
            DateOnly checkDate = new DateOnly(2001, 1, 1);
            Box box = new Box(0, 0, 1, 1, 1) {DateOfProduction = checkDate};
            Assert.Equal(box.ExpirationDate, checkDate.AddDays(Box.DAYS_FOR_EXPIRATE));
        }
    }
}