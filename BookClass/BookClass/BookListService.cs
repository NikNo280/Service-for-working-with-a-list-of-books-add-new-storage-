using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Text;
using System.Xml;

namespace BookClass
{
    /// <summary>
    /// Provides functions for managing books collection.
    /// </summary>
    public class BookListService
    {
        private List<Book> books;

        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        public BookListService()
        {
            this.books = new List<Book>();
        }

        /// <summary>
        /// Add new book.
        /// </summary>
        /// <param name="book">New book.</param>
        public void Add(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException($"{nameof(book)} is null");
            }

            this.books.Add(book);
        }

        /// <summary>
        /// Remove book.
        /// </summary>
        /// <param name="book">Removable book.</param>
        public void Remove(Book book)
        {
            if (book is null)
            {
                throw new ArgumentNullException($"{nameof(book)} is null");
            }

            this.books.Remove(book);
        }

        /// <summary>
        /// Find books by tag.
        /// </summary>
        /// <typeparam name="T">Type.</typeparam>
        /// <param name="tag">Tag.</param>
        /// <param name="source">Source.</param>
        /// <returns>ReadOnlyCollection of book.</returns>
        public IReadOnlyCollection<Book> FindByTag<T>(string tag, T source)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException($"{nameof(tag)} is null or empty");
            }

            PropertyInfo propertyInfo = typeof(Book).GetProperty(tag);

            if (propertyInfo is null)
            {
                throw new ArgumentNullException($"{nameof(propertyInfo)} is null");
            }

            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} is null");
            }

            var books = new List<Book>();
            foreach (var book in this.books)
            {
                if (propertyInfo.GetValue(book).Equals(source))
                {
                    books.Add(book);
                }
            }

            return books;
        }

        /// <summary>
        /// Sort books by tag.
        /// </summary>
        /// <param name="tag">Tag.</param>
        public void SortByTag(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                throw new ArgumentNullException($"{nameof(tag)} is null or empty");
            }

            PropertyInfo propertyInfo = typeof(Book).GetProperty(tag);

            if (propertyInfo is null)
            {
                throw new ArgumentNullException($"{nameof(propertyInfo)} is null");
            }

            var comparer = Comparer<dynamic>.Default;

            for (int i = 0; i < this.books.Count - 1; i++)
            {
                for (int j = i + 1; j < this.books.Count; j++)
                {
                    dynamic book1 = propertyInfo.GetValue(this.books[i]);
                    dynamic book2 = propertyInfo.GetValue(this.books[j]);
                    if (comparer.Compare(book1, book2) == -1)
                    {
                        (this.books[i], this.books[j]) = (this.books[j], this.books[i]);
                    }
                }
            }
        }

        /// <summary>
        /// Loads books from file.
        /// </summary>
        /// <param name="bookStorage">Storage.</param>
        public void Load(IBookStorage bookStorage)
        {
            if (bookStorage is null)
            {
                throw new ArgumentNullException(nameof(bookStorage));
            }

            this.books = bookStorage.Read();
        }

        /// <summary>
        /// Saves books to file.
        /// </summary>
        /// <param name="bookStorage">Storage.</param>
        public void Save(IBookStorage bookStorage)
        {
            if (bookStorage is null)
            {
                throw new ArgumentNullException(nameof(bookStorage));
            }

            bookStorage.Write(this.books.ToArray());
        }

        /// <summary>
        /// Gets array of books.
        /// </summary>
        /// <returns>ReadOnlyCollection of book.</returns>
        public IReadOnlyCollection<Book> GetBooks()
        {
            return new ReadOnlyCollection<Book>(this.books);
        }
    }
}
