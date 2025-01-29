using System;

class Program
{
    static void Main()
    {
        Ksiazka.DodajKsiazke(new Ksiazka("Wiedźmin", "Andrzej Sapkowski", 1993));
        Ksiazka.DodajKsiazke(new Ksiazka("Lalka", "Bolesław Prus", 1890));
        Ksiazka.DodajKsiazke(new Ksiazka("Dziady", "Adam Mickiewicz", 1822));
        Ksiazka.DodajKsiazke(new Ksiazka("Wiedźmin: Krew Elfów", "Andrzej Sapkowski", 1994));

        Console.WriteLine("\n--- Wszystkie książki ---");
        Ksiazka.WyswietlWszystkieKsiazki();

        Console.WriteLine("\n--- Książki Andrzeja Sapkowskiego ---");
        Ksiazka.WyswietlKsiazkiAutora("Andrzej Sapkowski");

        Console.WriteLine("\n--- Książki z roku 1890 ---");
        Ksiazka.WyswietlKsiazkiZRoku(1890);

        Console.WriteLine("\n--- Usunięcie książki 'Lalka' ---");
        Ksiazka.UsunKsiazke("Lalka");
        Ksiazka.WyswietlWszystkieKsiazki();

        Console.WriteLine("\n--- Edycja książki 'Dziady' ---");
        Ksiazka.EdytujKsiazke("Dziady", "Dziady - część II", "Adam Mickiewicz", 1823);
        Ksiazka.WyswietlWszystkieKsiazki();
    }
}