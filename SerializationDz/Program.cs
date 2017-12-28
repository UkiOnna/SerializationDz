using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerializationDz
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Book> books = new List<Book>();
            List<string> authors = new List<string>();

            authors.Add("Леха");
            authors.Add("Джереми");
            authors.Add("Брунгильда");
            authors.Add("Амахаши");
            authors.Add("Рудэус");

            List<string> bookNames = new List<string>();
            bookNames.Add("Как стать успешным");
            bookNames.Add("Рыцарское правоведение");
            bookNames.Add("Тактика ведения боя");
            bookNames.Add("Исскуство ниндзя");
            bookNames.Add("Как возродиться в другом мире");

            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                Book bookTemp = new Book();
                bookTemp.Author = authors[i];
                bookTemp.Name = bookNames[i];
                bookTemp.Price = random.Next(200, 5000);
                bookTemp.Year = random.Next(1998, 2018);
                books.Add(bookTemp);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(List<Book>));

            using (FileStream stream = new FileStream("book.bin", FileMode.OpenOrCreate))
            {
                serializer.Serialize(stream, books);
            }

            using (FileStream stream = new FileStream("book.bin", FileMode.OpenOrCreate))
            {
                List<Book> newBooks = serializer.Deserialize(stream) as List<Book>;
                foreach (var book in newBooks)
                {
                    Console.WriteLine("Название книги: {0}", book.Name);
                    Console.WriteLine("Автор: {0}", book.Author);
                    Console.WriteLine("Цена: {0} тенге", book.GetAttribute());
                    Console.WriteLine("Год издания: {0}", book.Year);
                }
            }

            Console.ReadLine();

        }
    }
}
