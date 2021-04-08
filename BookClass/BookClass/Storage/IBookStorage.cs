using System;
using System.Collections.Generic;
using System.Text;

namespace BookClass
{
    public interface IBookStorage
    {
        public void Write(Book[] books);

        public List<Book> Read();
    }
}
