//zad1
//public abstract class Shape
//{
//    public abstract double CalculateArea();
//}

//public class Circle : Shape
//{
//    public double Radius { get; set; }

//    public Circle(double radius)
//    {
//        Radius = radius;
//    }

//    public override double CalculateArea()
//    {
//        return Math.PI * Radius * Radius;
//    }
//}

//public class Square : Shape
//{
//    public double Side { get; set; }

//    public Square(double side)
//    {
//        Side = side;
//    }

//    public override double CalculateArea()
//    {
//        return Side * Side;
//    }
//}
//class Program
//{
//    static void Main(string[] args)
//    {

//        Shape circle = new Circle(5); 
//        Shape square = new Square(4); 


//        Console.WriteLine($"Pole koła o promieniu 5 wynosi: {circle.CalculateArea()}");
//        Console.WriteLine($"Pole kwadratu o boku 4 wynosi: {square.CalculateArea()}");
//    }
//}
//zad2
//using System;

//public interface IVehicle
//{
//    void Start();
//    void Stop();
//    int MaxSpeed { get; set; }
//}

//public class Car : IVehicle
//{
//    public int MaxSpeed { get; set; }
//    public int NumberOfDoors { get; set; }

//    public void Start()
//    {
//        Console.WriteLine("Samochod rusza.");
//    }

//    public void Stop()
//    {
//        Console.WriteLine("Samochod sie zatrzymuje.");
//    }
//}

//public class Bike : IVehicle
//{
//    public int MaxSpeed { get; set; }
//    public bool HasBell { get; set; }

//    public void Start()
//    {
//        Console.WriteLine("Rower rusza.");
//    }

//    public void Stop()
//    {
//        Console.WriteLine("Rower sie zatrzymuje.");
//    }
//}

//class Program
//{
//    static void Main(string[] args)
//    {
//        // Tworzymy instancje klas Car i Bike
//        IVehicle myCar = new Car { MaxSpeed = 150, NumberOfDoors = 4 };
//        IVehicle myBike = new Bike { MaxSpeed = 25, HasBell = true };

//        // Wywołujemy metody Start i Stop
//        Console.WriteLine("Samochod:");
//        myCar.Start();
//        Console.WriteLine($"Maksymalna predkosc auta: {myCar.MaxSpeed} km/h");
//        myCar.Stop();

//        Console.WriteLine("\nRower:");
//        myBike.Start();
//        Console.WriteLine($"Maksymalna predkosc roweru: {myBike.MaxSpeed} km/h");
//        myBike.Stop();
//    }
//}
using System;
using System.Collections.Generic;

public interface IEntity<T>
{
    T Id { get; set; }
}

public interface ICreationDate
{
    DateTime CreationDate { get; set; }
}

public class Book : IEntity<int>, ICreationDate
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public DateTime CreationDate { get; set; }

    public Book(int id, string title, string author, int year)
    {
        Id = id;
        Title = title;
        Author = author;
        Year = year;
        CreationDate = DateTime.Now;
    }
}

public class Person : IEntity<int>, ICreationDate
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public List<Book> BorrowedBooks { get; set; } = new List<Book>();
    public DateTime CreationDate { get; set; }

    public Person(int id, string firstName, string lastName, int age)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        CreationDate = DateTime.Now;
    }
}

public interface IBaseRepository<T, TEntity> where T : IEntity<TEntity>
{
    void Create(T entity);
    void Update(T entity);
    IEnumerable<T> GetAll();
    T Get(int id);
    void Delete(int id);
}

public interface IBookRepository : IBaseRepository<Book, int>
{
}

public interface IPersonRepository : IBaseRepository<Person, int>
{
}

public class BookRepository : IBookRepository
{
    private readonly List<Book> books = new List<Book>();

    public void Create(Book book)
    {
        books.Add(book);
    }

    public void Update(Book book)
    {
        var existingBook = Get(book.Id);
        if (existingBook != null)
        {
            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Year = book.Year;
        }
    }

    public IEnumerable<Book> GetAll()
    {
        return books;
    }

    public Book Get(int id)
    {
        return books.Find(b => b.Id == id);
    }

    public void Delete(int id)
    {
        var book = Get(id);
        if (book != null)
        {
            books.Remove(book);
        }
    }
}

public class PersonRepository : IPersonRepository
{
    private readonly List<Person> people = new List<Person>();

    public void Create(Person person)
    {
        people.Add(person);
    }

    public void Update(Person person)
    {
        var existingPerson = Get(person.Id);
        if (existingPerson != null)
        {
            existingPerson.FirstName = person.FirstName;
            existingPerson.LastName = person.LastName;
            existingPerson.Age = person.Age;
        }
    }

    public IEnumerable<Person> GetAll()
    {
        return people;
    }

    public Person Get(int id)
    {
        return people.Find(p => p.Id == id);
    }

    public void Delete(int id)
    {
        var person = Get(id);
        if (person != null)
        {
            people.Remove(person);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        IBookRepository bookRepo = new BookRepository();
        IPersonRepository personRepo = new PersonRepository();

        Book book1 = new Book(1, "Programowanie w C#", "John Doe", 2021);
        Book book2 = new Book(2, "Podstawy Javy", "Jane Smith", 2020);
        Person person1 = new Person(1, "Alicja", "Johnson", 25);
        person1.BorrowedBooks.Add(book1);

        bookRepo.Create(book1);
        bookRepo.Create(book2);
        personRepo.Create(person1);

        Console.WriteLine("Książki w repozytorium:");
        foreach (var book in bookRepo.GetAll())
        {
            Console.WriteLine($"Id: {book.Id}, Tytuł: {book.Title}, Autor: {book.Author}, Rok: {book.Year}, Data utworzenia: {book.CreationDate}");
        }

        Console.WriteLine("\nOsoby w repozytorium:");
        foreach (var person in personRepo.GetAll())
        {
            Console.WriteLine($"Id: {person.Id}, Imię: {person.FirstName} {person.LastName}, Wiek: {person.Age}, Data utworzenia: {person.CreationDate}");
            Console.WriteLine("Wypożyczone książki:");
            foreach (var borrowedBook in person.BorrowedBooks)
            {
                Console.WriteLine($" - {borrowedBook.Title} autorstwa {borrowedBook.Author}");
            }
        }

        person1.Age = 26;
        personRepo.Update(person1);

        bookRepo.Delete(1);

        Console.WriteLine("\nZaktualizowane książki w repozytorium:");
        foreach (var book in bookRepo.GetAll())
        {
            Console.WriteLine($"Id: {book.Id}, Tytuł: {book.Title}, Autor: {book.Author}, Rok: {book.Year}, Data utworzenia: {book.CreationDate}");
        }
    }
}
