using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Book book1 = new Book { Name = "Vanish", Author = "Sophie Jordan", Annotation = "An Impossible Romance.Bitter Rivalries.Deadly Choices.To save..." };
                Book book2 = new Book { Name = " Sharp Objects", Author = "Gillian Flynn", Annotation = "Fresh from a brief stay at a psych hospital, reporter Camille..." };
                Book book3 = new Book { Name = "Peter Pan", Author = "J. M. Barrie", Annotation = "Peter Pan is a character created by Scottish novelist and playwright..." };

                db.Books.Add(book1);
                db.Books.Add(book2);
                db.Books.Add(book3);
                db.SaveChanges();

                var books = db.Books.ToList();
                Console.WriteLine("Список объектов:");
                foreach (Book b in books)
                {
                    Console.WriteLine($"Book {b.Id} - {b.Name} - {b.Author} - {b.Annotation}");
                }

                List<Book> booksList = new List<Book>(5)
                {
                    new Book() { Name = "name1", Author = "author1", Annotation = "annotation1" },
                    new Book() { Name = "name2", Author = "author2", Annotation = "annotation2" },
                    new Book() { Name = "name3", Author = "author3", Annotation = "annotation3" },
                    new Book() { Name = "name4", Author = "author4", Annotation = "annotation4" },
                    new Book() { Name = "name5", Author = "author5", Annotation = "annotation5" }
                };

                db.Books.AddRange(booksList);
                db.SaveChanges();


                var books2 = db.Books.ToList();
                Console.WriteLine("Список объектов №2:");
                foreach (Book b in books2)
                {
                    Console.WriteLine($"Book {b.Id} - {b.Name} - {b.Author} - {b.Annotation}");
                }
            }
            Console.ReadKey();
        }
    }
}
