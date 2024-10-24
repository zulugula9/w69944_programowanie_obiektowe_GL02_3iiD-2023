//zad1
//int liczba = 1;
//if (liczba % 2 == 1)
//{
//    Console.WriteLine("Liczba jest nieparzysta");

//}
//else
//{
//    Console.WriteLine("Liczba jest parzysta");
//}
//zad2
//string liczba = Console.ReadLine();
//int n= int.Parse(liczba);
//for(int i = 0; i <= n; i++)
//{
//    if (i % 2 == 0)
//    {
//        Console.WriteLine(i);
//    }
//}
//zad3


//while(true){
//    Console.WriteLine("0.Wyjście");
//    Console.WriteLine("1.print siema");
//    Console.WriteLine("2.print elo");
//    Console.WriteLine("3.print czesc");
//    Console.WriteLine("Podaj liczbe: ");
//    string liczba = Console.ReadLine();
//    int n = int.Parse(liczba);
//    if (n == 0)
//    {
//        break;
//    }
//    else if (n == 1)
//    {
//        Console.WriteLine("siema");
//    }
//    else if (n == 2)
//    {
//        Console.WriteLine("elo");
//    }
//    else if (n == 3)
//    {
//        Console.WriteLine("czesc");
//    }


//}
//zad4
//   string liczba = Console.ReadLine();
//int n = int.Parse(liczba);
//int wynik = 1;
//for(int i=0; i<=n; i++)
//{
//    if (i > 1) {
//        wynik = wynik * i;
//    }
//}
//Console.WriteLine(wynik);
//zad5
//Random rnd = new Random();

//int wylosowana = rnd.Next(1, 11);
//int proby = 1;
//while (true)
//{
//    Console.WriteLine(wylosowana);
//    Console.WriteLine("Zgadnij liczbe z przedzialu od 1 do 10");
//    string x = Console.ReadLine();
//    int liczba = int.Parse(x);

//    if (liczba == wylosowana)
//    {
//        Console.WriteLine("Zgadles liczbe za proba: "+proby);
        
//        proby++;
        
//        break;
//    }
//    else
//    {
//        Console.WriteLine("Probuj dalej"); 
//        proby++;
//    }
//}