using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using BookClass;
using BookClass.Tests;
using NUnit.Framework;

#pragma warning disable SA1600

namespace BookClass.Test.UnitTests
{
    [TestFixture]
    public class BookServiceTests
    {
        [TestCaseSource(typeof(TestServiceDataSource), nameof(TestServiceDataSource.TestCasesFindByTag))]
        public void BookService_FindByTag(Book[] value, Book[] result, string tag, string source)
        {
            var bookListService = new BookListService();
            foreach (var item in value)
            {
                bookListService.Add(item);
            }

            CollectionAssert.AreEqual(bookListService.FindByTag(tag, source), result);
        }

        [TestCaseSource(typeof(TestServiceDataSource), nameof(TestServiceDataSource.TestCasesSortByTag))]
        public void BookService_SortByTag(Book[] value, Book[] result, string tag)
        {
            var bookListService = new BookListService();
            foreach (var item in value)
            {
                bookListService.Add(item);
            }

            bookListService.SortByTag(tag);
            CollectionAssert.AreEqual(bookListService.GetBooks(), result);
        }
    }
}
