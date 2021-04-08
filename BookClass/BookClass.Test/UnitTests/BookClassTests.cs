using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using BookClass;
using BookClass.Tests;
using NUnit.Framework;

#pragma warning disable SA1600

namespace BookClassNameSpace.Tests
{
    [TestFixture]
    public class BookClassTests
    {
        [TestCase(0)]
        [TestCase(-26)]
        public void BookClass_PagesSet_ArgumentOutOfRangeException(int pages)
        {
            var book = new Book("1", "2", "3");
            Assert.Throws<ArgumentOutOfRangeException>(() => book.Pages = pages);
        }

        [TestCase("title", "author", ExpectedResult = "title by author")]
        [TestCase("C# in Depth", "Jon Skeet", ExpectedResult = "C# in Depth by Jon Skeet")]
        public string BookClass_ToString(string title, string author)
        {
            var book = new Book(author, title, "3");
            return book.ToString();
        }

        [Test]
        public void BookClass_GetAndSetpublish()
        {
            DateTime date = DateTime.Now;
            var book = new Book("1", "2", "3");
            book.Publish(date);
            Assert.AreEqual(book.GetPublicationDate(), date.ToString("dd:mm:yyyy", CultureInfo.InvariantCulture));
        }

        [Test]
        public void BookClass_SetPrice()
        {
            var book = new Book("1", "2", "3");
            book.SetPrice(15, "U.S.D");
            Assert.AreEqual(book.Price, 15);
            Assert.AreEqual(book.Currency, "U.S.D");
        }

        [TestCaseSource(typeof(TestCasesDataSource), nameof(TestCasesDataSource.TestCasesEquals))]
        public void BookClass_Equals(Book book1, Book book2, bool result)
        {
            Assert.AreEqual(book1.Equals(book2), result);
        }

        [TestCaseSource(typeof(TestCasesDataSource), nameof(TestCasesDataSource.TestCasesCompareTo))]
        public void BookClass_CompareTo(Book book1, Book book2, int result)
        {
            Assert.AreEqual(book1.CompareTo(book2), result);
        }

        [TestCaseSource(typeof(TestCasesDataSource), nameof(TestCasesDataSource.TestCasesCompareToObj))]
        public void BookClass_CompareToObj(Book book1, object obj, int result)
        {
            Assert.AreEqual(book1.CompareTo(obj), result);
        }

        [TestCaseSource(typeof(TestCasesDataSource), nameof(TestCasesDataSource.TestCasesToStringFormat))]
        public void BookClass_ToStringFormat(string title, string author, string publisher, string isbn, int pages, decimal price, string currency, DateTime datePublished, string format, IFormatProvider formatProvider, string result)
        {
            var book = new Book(author, title, publisher, isbn);
            book.Publish(datePublished);
            book.Pages = pages;
            book.SetPrice(price, currency);
            Assert.AreEqual(result, book.ToString(format, formatProvider));
        }
    }
}
