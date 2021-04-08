using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookClass
{
    public class BookListStorage : IBookStorage
    {
        /// <summary>
        /// Save books in file.
        /// </summary>
        public void Write(Book[] books)
        {
            using (var binaryWriter = new BinaryWriter(File.Open("BookListStorage.dat", FileMode.OpenOrCreate)))
            {
                foreach (var book in books)
                {
                    binaryWriter.Write($"{book.Author},{book.Title}," +
                    $"{book.Publisher},{book.ISBN}," +
                    $"{book.GetPublicationDate()}," +
                    $"{book.Pages}," +
                    $"{book.Price},{book.Currency}\n");
                }
            }
        }

        public List<Book> Read()
        {
            List<Book> books = new List<Book>();
            using (var binaryReader = new BinaryReader(File.Open("BookListStorage.dat", FileMode.OpenOrCreate)))
            {
                while (binaryReader.PeekChar() > -1)
                {
                    books.Add(Book.Parse(binaryReader.ReadString()));
                }
            }

            return books;
        }
    }
}