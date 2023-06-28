using StockConsole.DAL.Repositories;
using StockConsole.Services;

PalletRepository palletRepository = new PalletRepository(PalletRepository.initData());

PalletService palletService = new PalletService(palletRepository);

// Задание 1
Console.WriteLine("Task 1:");
var ans_1 = palletService.GetPalletGroupByExpirationDateAndSort();

foreach (var pair in ans_1)
{
    Console.WriteLine("Group by date: {0}",pair.Key);
    foreach (var pallet in pair.Value)
        Console.WriteLine(" -> {0}", pallet);
    Console.WriteLine();
}

Console.WriteLine();
Console.WriteLine();

// Задание 2
var ans_2 = palletService.GetThreePalletsWithMoreDate();
Console.WriteLine("Task 2:");
Console.WriteLine("3 pallets that contain the boxes with the longest shelf life, sorted by increasing depth:");
foreach (var pallet in ans_2)
    Console.WriteLine(" -> {0}",pallet);

