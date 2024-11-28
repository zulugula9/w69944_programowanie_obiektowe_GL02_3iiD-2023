//using System;
//using System.Collections.Generic;

//class Shape
//{
//    public int X { get; set; }
//    public int Y { get; set; }
//    public int Height { get; set; }
//    public int Width { get; set; }

//    public virtual void Draw()
//    {
//        Console.WriteLine("Rysowanie kształtu.");
//    }
//}

//class Rectangle : Shape
//{
//    public override void Draw()
//    {
//        Console.WriteLine($"Rysowanie prostokąta: X={X}, Y={Y}, Width={Width}, Height={Height}");
//        for (int i = 0; i < Height; i++)
//        {
//            for (int j = 0; j < Width; j++)
//            {
//                Console.Write("*");
//            }
//            Console.WriteLine();
//        }
//    }
//}

//class Triangle : Shape
//{
//    public override void Draw()
//    {
//        Console.WriteLine($"Rysowanie trójkąta: X={X}, Y={Y}, Width={Width}, Height={Height}");
//        for (int i = 0; i < Height; i++)
//        {
//            for (int j = 0; j < Width - i; j++)
//            {
//                Console.Write(" ");
//            }
//            for (int j = 0; j <= i * 2; j++)
//            {
//                Console.Write("*");
//            }
//            Console.WriteLine();
//        }
//    }
//}

//class Circle : Shape
//{
//    public override void Draw()
//    {
//        Console.WriteLine($"Rysowanie koła: X={X}, Y={Y}, Width={Width}, Height={Height}");
//        int rX = Width / 2;
//        int rY = Height / 2;

//        for (int y = 0; y <= Height; y++)
//        {
//            for (int x = 0; x <= Width; x++)
//            {
//                int dx = x - rX;
//                int dy = y - rY;
//                if (dx * dx + dy * dy <= rX * rX)
//                {
//                    Console.Write("*");
//                }
//                else
//                {
//                    Console.Write(" ");
//                }
//            }
//            Console.WriteLine();
//        }
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        List<Shape> shapes = new List<Shape>();


//        shapes.Add(new Rectangle { X = 1, Y = 1, Width = 5, Height = 3 });
//        shapes.Add(new Triangle { X = 2, Y = 2, Width = 7, Height = 4 });
//        shapes.Add(new Circle { X = 3, Y = 3, Width = 7, Height = 7 });


//        foreach (var shape in shapes)
//        {
//            shape.Draw();
//            Console.WriteLine();
//        }
//    }
//}
using System;
using System.Collections.Generic;

class Osoba
{
    public string Imie { get; set; }
    public string Nazwisko { get; set; }
    public string Pesel { get; set; }

    public void UstawImie(string imie) => Imie = imie;
    public void UstawNazwisko(string nazwisko) => Nazwisko = nazwisko;
    public void UstawPesel(string pesel) => Pesel = pesel;

    public int PobierzWiek()
    {

        string pesel = Pesel;
        int year = int.Parse(pesel.Substring(0, 2));
        int month = int.Parse(pesel.Substring(2, 2));
        int day = int.Parse(pesel.Substring(4, 2));

        if (year > 20)
        {
            year += 1900; 
        }
        else
        {
            year += 2000;  
        }

        DateTime birthDate = new DateTime(year, month, day);
        return (int)((DateTime.Now - birthDate).TotalDays / 365.25);
    }

    public string PobierzPlec()
    {
     
        return int.Parse(Pesel.Substring(9, 1)) % 2 == 0 ? "Kobieta" : "Mężczyzna";
    }

    public virtual string PobierzInformacjeOEdukacji() => "Brak informacji o edukacji.";
    public virtual string PobierzPelneImieNazwisko() => $"{Imie} {Nazwisko}";
    public virtual bool CzyMozeSamWrocicDoDomu() => false;
}

class Uczen : Osoba
{
    public string Szkola { get; set; }
    public bool MozeSamWrocicDoDomu { get; set; }

    public void UstawSzkole(string szkola) => Szkola = szkola;
    public void ZmienSzkole(string szkola) => Szkola = szkola;
    public void UstawCzyMozeSamWrocic(bool moze) => MozeSamWrocicDoDomu = moze;

    public override string PobierzInformacjeOEdukacji() => $"Uczeń: {Imie} {Nazwisko}, Szkoła: {Szkola}";
    public override bool CzyMozeSamWrocicDoDomu()
    {

        if (PobierzWiek() < 12)
            return MozeSamWrocicDoDomu;
        return true; 
    }
}

class Nauczyciel : Osoba
{
    public string TytulNaukowy { get; set; }
    public List<Uczen> UczniowieKlasy { get; set; } = new List<Uczen>();

    public void DodajUcznia(Uczen uczen) => UczniowieKlasy.Add(uczen);

    public List<string> KtorzyUczniowieMogaWrocicSamodzielnie()
    {
        List<string> lista = new List<string>();
        foreach (var uczen in UczniowieKlasy)
        {
            if (uczen.CzyMozeSamWrocicDoDomu())
            {
                lista.Add($"{uczen.Imie} {uczen.Nazwisko} - {uczen.PobierzPlec()}");
            }
        }
        return lista;
    }

    public void PodsumowanieKlasy(DateTime data)
    {
        Console.WriteLine($"Dnia: {data.ToShortDateString()}");
        Console.WriteLine($"Nauczyciel: {TytulNaukowy} {Imie} {Nazwisko}");
        Console.WriteLine("Lista uczniów:");
        foreach (var uczen in UczniowieKlasy)
        {
            string verdict = uczen.CzyMozeSamWrocicDoDomu() ? "Tak" : "Nie";
            string reason = uczen.CzyMozeSamWrocicDoDomu() ? "Ma pozwolenie lub jest pełnoletni" : "Jest za młody";
            Console.WriteLine($"{uczen.PobierzPelneImieNazwisko()} - {uczen.PobierzPlec()} - {verdict} {reason}");
        }
    }
}

class Program
{
    static void Main()
    {
   
        Uczen uczen1 = new Uczen { Imie = "Jan", Nazwisko = "Kowalski", Pesel = "12345678901", Szkola = "Szkoła Podstawowa", MozeSamWrocicDoDomu = true };
        Uczen uczen2 = new Uczen { Imie = "Anna", Nazwisko = "Nowak", Pesel = "23456789012", Szkola = "Szkoła Podstawowa", MozeSamWrocicDoDomu = false };

      
        Nauczyciel nauczyciel = new Nauczyciel { Imie = "Marek", Nazwisko = "Zieliński", TytulNaukowy = "Dr" };

  
        nauczyciel.DodajUcznia(uczen1);
        nauczyciel.DodajUcznia(uczen2);

       
        nauczyciel.PodsumowanieKlasy(DateTime.Now);

     
        var uczniowieMogaWrocic = nauczyciel.KtorzyUczniowieMogaWrocicSamodzielnie();
        Console.WriteLine("\nUczniowie, którzy mogą wrócić samodzielnie:");
        foreach (var uczen in uczniowieMogaWrocic)
        {
            Console.WriteLine(uczen);
        }
    }
}
