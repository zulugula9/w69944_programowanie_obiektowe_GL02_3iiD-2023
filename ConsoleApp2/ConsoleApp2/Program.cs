using System;
using System.Security.Cryptography.X509Certificates;
//zad1
//public class Osoba
//{

//    private string imie;
//    private string nazwisko;
//    private int wiek;
//    private string pesel;


//    public Osoba(string imie, string nazwisko, int wiek, string pesel)
//    {
//        this.imie = imie;
//        this.nazwisko = nazwisko;
//        this.wiek = wiek >= 0 ? wiek : 0;
//    }

//    public string Imie
//    {
//        get { return imie; }
//        set { imie = value; }
//    }

//    public string Nazwisko
//    {
//        get { return nazwisko; }
//        set { nazwisko = value; }
//    }

//    public int Wiek
//    {
//        get { return wiek; }
//        set
//        {

//            wiek = value >= 0 ? value : 0;
//        }
//    }


//    public string Pesel
//    {
//        get { return pesel; }
//    }

//    public string PrzedstawSie()
//    {
//        return $"Nazywam się {imie} {nazwisko} i mam {wiek} lat";
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        Osoba osoba = new Osoba("Jan", "Kowalski", 25, "12345678901");
//        Console.WriteLine(osoba.PrzedstawSie());  

//        osoba.Wiek = -5; 
//        Console.WriteLine(osoba.PrzedstawSie()); 

//        Console.WriteLine(osoba.Pesel); 
//    }
//}
//zad2


//public class Licz
//{

//    private int wartosc;


//    public Licz(int wartosc)
//    {
//        this.wartosc = wartosc;
//    }

//    public void Dodaj(int wartoscDoDodania)
//    {
//        wartosc += wartoscDoDodania;
//    }

//    public void Odejmij(int wartoscDoOdejmowania)
//    {
//        wartosc -= wartoscDoOdejmowania;
//    }

//    public void WypiszStan()
//    {
//        Console.WriteLine($"Aktualna wartość: {wartosc}");
//    }
//}

//class Program
//{
//    static void Main () {
//        Licz liczba = new Licz(10);


//        liczba.WypiszStan();  


//        liczba.Dodaj(5);
//        liczba.WypiszStan();  

//        liczba.Odejmij(3);
//        liczba.WypiszStan();
//    }
//}
//zad 3
//public class Sumator
//{
//    private int[] Liczby;
//    public Sumator(int[] liczby)
//    {
//        Liczby = liczby;
//    }
//    public int Suma()
//    {
//        int suma = 0;
//        foreach (int i in Liczby) { suma += i; }
//        return suma;
//    }
//    public int SumaPodziel3()
//    {
//        int suma = 0;
//        foreach (int i in Liczby)
//        {
//            if (i % 3 == 0)
//            {
//                suma += i;
//            }
//        }
//        return suma;
//    }
//    public int IleElementow() {
//        return Liczby.Length;
//    }
//    public void WypiszWszystkie()
//    {
//        foreach (int i in Liczby) {
//            Console.WriteLine(i+" ");
//         }
//    }
//    public void WypiszZakres(int LowIndex,int HighIndes)

//    {
//        if (Liczby == null || Liczby.Length == 0)
//        {
//            return;
//        }
//        for (int i = LowIndex; i <= HighIndes; i++)
//        {
//        if(i>=0 && i < Liczby.Length)
//            {
//                Console.WriteLine(Liczby[i]+" ");
//            }
//        }
//    }
//}
//class Program
//{
//    static void Main()
//    {
//        int[] liczby = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
//        Sumator sumator=new Sumator(liczby);
//        sumator.WypiszWszystkie();
//        Console.WriteLine("Suma: " + sumator.Suma());
//        Console.WriteLine("Suma liczb podzielnych przez 3: "+sumator.SumaPodziel3());
//        Console.WriteLine("Liczba elementow: " + sumator.IleElementow());
//        sumator.WypiszZakres(1, 6);
//    }
//}