using StockConsole.DAL.Repositories;
using StockConsole.Models;
using StockConsole.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    public class Test_PalletService
    {

        [Fact]
        public void GetGroupPallets_Successful()
        {
            List<Box> boxes1 = new List<Box>() 
            {
                new Box(0,1,1,1,2) {ExpirationDate = new DateOnly(2000,1,1)},
                new Box(0,1,1,1,2) {ExpirationDate = new DateOnly(2000,1,1)},
                new Box(0,1,1,1,2) {ExpirationDate = new DateOnly(2000,1,1)},
            };

            List<Box> boxes2 = new List<Box>()
            {
                new Box(0,1,1,1,5) {ExpirationDate = new DateOnly(2000,1,1)},
                new Box(0,1,1,1,5) {ExpirationDate = new DateOnly(2000,2,1)},
                new Box(0,1,1,1,5) {ExpirationDate = new DateOnly(2000,2,1)},
            };
            List<Box> boxes3 = new List<Box>()
            {
                new Box(0,1,1,1,5) {ExpirationDate = new DateOnly(2000,3,2)},
                new Box(0,1,1,1,5) {ExpirationDate = new DateOnly(2000,3,2)},
                new Box(0,1,1,1,5) {ExpirationDate = new DateOnly(2000,3,10)},
            };


            List<Pallet> pallets = new List<Pallet>()
            {
                new Pallet(0,10,10,10,boxes1),
                new Pallet(1,10,10,10,boxes2),
                new Pallet(2,10,10,10,boxes3)
            };

            Dictionary<DateOnly, IEnumerable<Pallet>> expect = new Dictionary<DateOnly, IEnumerable<Pallet>>()
            {
                {new DateOnly(2000,1,1),  new List<Pallet>(){ pallets[0], pallets[1] } },
                {new DateOnly(2000,3,2),  new List<Pallet>(){ pallets[2] } },
            };


            PalletRepository repo = new PalletRepository(pallets);
            PalletService service = new PalletService(repo);

            var ans = service.GetPalletGroupByExpirationDateAndSort();
            var ansEnum = ans.ToDictionary(x => x.Key, x => (IEnumerable<Pallet>)x.Value);


            Assert.Equal(expect, ansEnum);
        }

        [Fact]
        public void GetThreePalletDate_Successful()
        {
            List<Box> boxes1 = new List<Box>()
            {
                new Box(0,1,1,1,2) {ExpirationDate = new DateOnly(2000,1,1)},
                new Box(0,1,1,1,2) {ExpirationDate = new DateOnly(2000,1,1)},
                new Box(0,1,1,1,2) {ExpirationDate = new DateOnly(2000,1,1)},
            };

            List<Box> boxes2 = new List<Box>()
            {
                new Box(0,2,2,2,5) {ExpirationDate = new DateOnly(2000,1,1)},
                new Box(0,2,2,2,5) {ExpirationDate = new DateOnly(2000,2,1)},
                new Box(0,1,1,1,5) {ExpirationDate = new DateOnly(2000,2,1)},
            };
            List<Box> boxes3 = new List<Box>()
            {
                new Box(0,1,2,1,5) {ExpirationDate = new DateOnly(2000,3,2)},
                new Box(0,1,2,1,5) {ExpirationDate = new DateOnly(2000,3,2)},
                new Box(0,1,1,1,5) {ExpirationDate = new DateOnly(2000,3,10)},
            };
            List<Box> boxes4 = new List<Box>()
            {
                new Box(0,1,1,1,5) {ExpirationDate = new DateOnly(2000,3,2)},
                new Box(0,1,1,1,10) {ExpirationDate = new DateOnly(2000,3,10)},
                new Box(0,1,1,1,5) {ExpirationDate = new DateOnly(2000,3,10)},
            };


            List<Pallet> pallets = new List<Pallet>()
            {
                new Pallet(0,10,10,10,boxes1),
                new Pallet(1,10,10,10,boxes2),
                new Pallet(2,10,10,10,boxes3),
                new Pallet(3,10,10,10,boxes4)
            };

            List<Pallet> expect = new List<Pallet>()
            {
                pallets[3],
                pallets[2],
                pallets[1]
            };


            PalletRepository repo = new PalletRepository(pallets);
            PalletService service = new PalletService(repo);

            var ans = service.GetThreePalletsWithMoreDate();
            


            Assert.Equal(expect, ans);
        }

    }
}
