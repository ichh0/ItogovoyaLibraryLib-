using System;
using LibraryLib;

class Program
{
    static void Main()
    {
        var lib = new LibraryFunctions();

        Console.WriteLine($"Библиотека: {lib.GetLibraryName()}");
        Console.WriteLine($"Главный библиотекарь: {lib.GetChiefLibrarian()}");

        Console.WriteLine("Сотрудники:");
        foreach (var staff in lib.GetStaff())
        Console.WriteLine($"  {staff}");

        lib.SetChiefLibrarian("Иванова М.П.");
        Console.WriteLine($"Новый главный библиотекарь: {lib.GetChiefLibrarian()}");

        lib.SetChiefLibrarian("Неизвестный И.И.");
        Console.WriteLine($"Главный библиотекарь после неудачной смены: {lib.GetChiefLibrarian()}");

        var random = new Random();
        var code = lib.GenerateBookCode("Фантастика", random.Next(1, 1000));
        Console.WriteLine($"Код книги: {code}");

        lib.AddStaff("Новиков А.А.");
        Console.WriteLine("Сотрудники после добавления:");
        foreach (var staff in lib.GetStaff())
        Console.WriteLine($"  {staff}");
    }
}