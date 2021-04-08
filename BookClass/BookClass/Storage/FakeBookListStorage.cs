using System;
using System.Collections.Generic;
using System.Text;

namespace BookClass.Storage
{
    public class FakeBookListStorage : IBookStorage
    {
        public List<Book> Read()
        {
            return new List<Book>();
        }

        public void Write(Book[] books)
        {
        }
    }
}
