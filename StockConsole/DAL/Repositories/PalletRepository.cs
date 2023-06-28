using StockConsole.Interfaces;
using StockConsole.Models;

namespace StockConsole.DAL.Repositories
{
    public class PalletRepository : IRepository<Pallet>
    {
        List<Pallet> pallets = new List<Pallet>();
        public PalletRepository() { initData(); }
        public IEnumerable<Pallet> GetAll()
        {
            return pallets;
        }

        private void initData()
        {
            List<Box> boxes0 = new List<Box>()
            {
                new Box(0,10,10,10,5) { ExpirationDate = new DateOnly(2000,5,1) },
                new Box(1,10,10,10,10) { DateOfProduction = new DateOnly(2000,1,1) },
                new Box(2,10,10,10,56) { ExpirationDate = new DateOnly(2000,2,16) },
                new Box(3,10,10,10,23) { ExpirationDate = new DateOnly(2000,5,1) },
                new Box(4,10,10,10,34) { ExpirationDate = new DateOnly(2000,2,16) },
            };
            Pallet pl0 = new Pallet(0, 50, 50, 50, boxes0);


            List<Box> boxes1 = new List<Box>()
            {
                new Box(5,5,10,10,15) { ExpirationDate = new DateOnly(2000,6,6) },
                new Box(6,5,10,10,9) { DateOfProduction = new DateOnly(2000,1,17) },
                new Box(7,10,5,10,6) { DateOfProduction = new DateOnly(2000,2,16) },
                new Box(8,10,7,10,43) { ExpirationDate = new DateOnly(2000,5,23) },
                new Box(9,3, 4,10,74) { ExpirationDate = new DateOnly(2000,2,16) },
            };
            Pallet pl1 = new Pallet(1, 25, 25, 25, boxes1);


            List<Box> boxes2 = new List<Box>()
            {
                new Box(10,2,2,2,15) { ExpirationDate = new DateOnly(2000,6,6) },
                new Box(11,2,3,3,9) { DateOfProduction = new DateOnly(2000,2,16) },
                new Box(12,2,3,2,6) { DateOfProduction = new DateOnly(2000,2,16) },
            };
            Pallet pl2 = new Pallet(2, 10, 10, 10, boxes2);

            List<Box> boxes3 = new List<Box>()
            {
                new Box(13,2,1,2,10) { ExpirationDate = new DateOnly(2000,1,17)  },
                new Box(14,2,1,1,10) { DateOfProduction = new DateOnly(2000,6,6) },
                new Box(15,2,1,2,2) { DateOfProduction = new DateOnly(2000,6,6) },
            };
            Pallet pl3 = new Pallet(3, 5, 5, 5, boxes3);

            List<Box> boxes4 = new List<Box>()
            {
                new Box(16,5,10,10,5) { ExpirationDate = new DateOnly(2000,1,17) },
                new Box(17,5,10,10,4) { DateOfProduction = new DateOnly(2000,2,20) },
                new Box(18,2,6,3,2) { DateOfProduction = new DateOnly(2000,3,16) },
                new Box(19,10,7,10,2) { ExpirationDate = new DateOnly(2000,1,17) },
                new Box(20,3, 4,10,2) { ExpirationDate = new DateOnly(2000,2,21) },
            };
            Pallet pl4 = new Pallet(4, 30, 30, 30, boxes4);

            pallets.Add(pl0);
            pallets.Add(pl1);
            pallets.Add(pl2);
            pallets.Add(pl3);
            pallets.Add(pl4);
        }
    }
}
