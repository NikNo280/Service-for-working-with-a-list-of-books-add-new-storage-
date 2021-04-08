using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClass.Test.MockTests
{
    public class MockTests
    {
        [Test]
        public void TestLoad()
        {
            BookListService service = new BookListService();
            var mock = new Mock<IBookStorage>();
            mock.Setup(obj => obj.Read());
            service.Load(mock.Object);
            mock.Verify();
        }

        [Test]
        public void TestSave()
        {
            BookListService service = new BookListService();
            List<Book> books = new List<Book>();
            var mock = new Mock<IBookStorage>();
            mock.Setup(obj => obj.Write(books.ToArray()));
            service.Load(mock.Object);
            mock.Verify();
        }
    }
}