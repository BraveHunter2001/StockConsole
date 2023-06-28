using StockConsole.DAL.Repositories;
using StockConsole.Models;
using StockConsole.Utils;

namespace StockConsole.Services
{
    public class PalletService
    {
        private readonly PalletRepository repository;
        public PalletService(PalletRepository palletRepository)
        {
            repository = palletRepository;
        }

        public Dictionary<DateOnly, IOrderedEnumerable<Pallet>> GetPalletGroupByExpirationDateAndSort()
        {
            var pallets = repository.GetAll();

            var groups = pallets
                .GroupBy(pallet => pallet.ExpirationDate)
                .OrderBy(group => group.Key);

            var PalletsSortInGroup = groups.ToDictionary(group => group.Key, group => group.OrderBy(pallet=> pallet.Weight));

            return PalletsSortInGroup;
        }

        public IEnumerable<Pallet> GetThreePalletsWithMoreDate()
        {
            var pallets = repository.GetAll();

            //// вариант 1
            //var palletsDate_1 = pallets
            //    .Select(pallet => pallet.Select(box => new { box, pallet }))
            //    .SelectMany(pare => pare)
            //    .OrderByDescending(pare => pare.box.ExpirationDate)
            //    .DistinctBy(pare => pare.pallet);

            //var ans_1 = palletsDate_1
            //    .Take(3)
            //    .OrderBy(pare => pare.pallet.Volume);


            // вариант 2
            var palletsDate = pallets.OrderByDescending(
                    pallet => pallet,
                    new PalletComparerByHighestDate()
                );
                
            var ans = palletsDate.Take(3)
                .OrderBy(pallet => pallet.Volume);


            return ans;
        }
    }
}
