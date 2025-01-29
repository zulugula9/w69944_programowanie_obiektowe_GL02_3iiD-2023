using System;
using System.Collections.Generic;
using System.Linq;

public class Ksiazka
{
    public string Tytul { get; set; }
    public string Autor { get; set; }
    public int RokWydania { get; set; }

    private static List<Ksiazka> ksiazki = new List<Ksiazka>();

    public Ksiazka(string tytul, string autor, int rokWydania)
    {
        Tytul = tytul;
        Autor = autor;
        RokWydania = rokWydania;
    }

    public static void DodajKsiazke(Ksiazka ksiazka)
    {
        ksiazki.Add(ksiazka);
        Console.WriteLine($"Dodano książkę: {ksiazka.Tytul} ({ksiazka.Autor}, {ksiazka.RokWydania})");
    }

    public static void UsunKsiazke(string tytul)
    {
        var ksiazka = ksiazki.FirstOrDefault(k => k.Tytul == tytul);
        if (ksiazka != null)
        {
            ksiazki.Remove(ksiazka);
            Console.WriteLine($"Usunięto książkę: {tytul}");
        }
        else
        {
            Console.WriteLine("Nie znaleziono książki o podanym tytule.");
        }
    }

    public static void EdytujKsiazke(string tytul, string nowyTytul, string nowyAutor, int nowyRok)
    {
        var ksiazka = ksiazki.FirstOrDefault(k => k.Tytul == tytul);
        if (ksiazka != null)
        {
            ksiazka.Tytul = nowyTytul;
            ksiazka.Autor = nowyAutor;
            ksiazka.RokWydania = nowyRok;
            Console.WriteLine("Dane książki zostały zaktualizowane.");
        }
        else
        {
            Console.WriteLine("Nie znaleziono książki do edycji.");
        }
    }

    public static void WyswietlKsiazkiAutora(string autor)
    {
        var znalezione = ksiazki.Where(k => k.Autor == autor).ToList();
        if (znalezione.Any())
        {
            Console.WriteLine($"Książki autora {autor}:");
            znalezione.ForEach(k => Console.WriteLine($"- {k.Tytul} ({k.RokWydania})"));
        }
        else
        {
            Console.WriteLine($"Brak książek autora {autor}.");
        }
    }

    public static void WyswietlKsiazkiZRoku(int rok)
    {
        var znalezione = ksiazki.Where(k => k.RokWydania == rok).ToList();
        if (znalezione.Any())
        {
            Console.WriteLine($"Książki wydane w {rok}:");
            znalezione.ForEach(k => Console.WriteLine($"- {k.Tytul} ({k.Autor})"));
        }
        else
        {
            Console.WriteLine($"Brak książek wydanych w roku {rok}.");
        }
    }

    public static void WyswietlWszystkieKsiazki()
    {
        if (ksiazki.Any())
        {
            Console.WriteLine("Lista książek w bibliotece:");
            ksiazki.ForEach(k => Console.WriteLine($"- {k.Tytul} ({k.Autor}, {k.RokWydania})"));
        }
        else
        {
            Console.WriteLine("Brak książek w bibliotece.");
        }
    }
}