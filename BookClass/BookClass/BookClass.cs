using System;
using System.Globalization;

#pragma warning disable SA1600
namespace BookClass
{
    /// <summary>
    /// Sealed class called Book that represents the book as a type of publication.
    /// </summary>
    public sealed class Book : IEquatable<Book>, IComparable<Book>, IComparable, IFormattable
    {
        private bool published;
        private DateTime datePublished;
        private int totalPages;

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="author">Author's name.</param>
        /// <param name="title">Title.</param>
        /// <param name="publisher">Publisher.</param>
        public Book(string author, string title, string publisher)
        {
            this.Author = author;
            this.Title = title;
            this.Publisher = publisher;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="author">Author's name.</param>
        /// <param name="title">Title.</param>
        /// <param name="publisher">Publisher.</param>
        /// <param name="isbn">ISBN code.</param>
        public Book(string author, string title, string publisher, string isbn)
            : this(author, title, publisher)
        {
            this.ISBN = isbn;
        }

        /// <summary>
        /// Gets author's name.
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// Gets title.
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// Gets Publisher.
        /// </summary>
        public string Publisher { get; }

        /// <summary>
        /// Gets or sets ISBN.
        /// </summary>
        public string ISBN { get; set; }

        /// <summary>
        /// Gets or sets Pages.
        /// </summary>
        public int Pages
        {
            get => this.totalPages;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "value must be a positive");
                }

                this.totalPages = value;
            }
        }

        /// <summary>
        /// Gets price.
        /// </summary>
        public decimal Price { get; private set; }

        /// <summary>
        /// Gets Currency.
        /// </summary>
        public string Currency { get; private set; }

        /// <summary>
        /// The Publish method sets a private published flag to true when it is called and
        /// assigns the date passed to it as an argument to the private datePublished field.
        /// </summary>
        /// <param name="date">Date of publication.</param>
        public void Publish(DateTime date)
        {
            this.datePublished = date;
            this.published = true;
        }

        /// <summary>
        /// The GetPublicationDate method returns the string "NYP" if the published flag is false,
        /// and the value of the datePublished field if it is true.
        /// </summary>
        /// <returns>
        /// The string "NYP" if the published flag is false,
        /// and the value of the datePublished field if it is true.
        /// </returns>
        public string GetPublicationDate()
        {
            if (this.published)
            {
                return this.datePublished.ToString("dd:mm:yyyy", CultureInfo.InvariantCulture);
            }

            return "NYP";
        }

        public string GetPublicationYear()
        {
            if (this.published)
            {
                return this.datePublished.Year.ToString(CultureInfo.InvariantCulture);
            }

            return "NYP";
        }

        /// <summary>
        /// A SetPrice method, which sets the values of the Price and Currency properties.
        /// Those values are returned by those same properties.
        /// </summary>
        /// <param name="price">Price.</param>
        /// <param name="currency">Currency.</param>
        public void SetPrice(decimal price, string currency)
        {
            this.Price = price;
            this.Currency = currency;
        }

        /// <summary>
        /// A ToString method to return the information about author and title of book.
        /// </summary>
        /// <example>
        /// Title = C# in Depth, Author = Jon Skeet, datePublished = 2019, Publisher = Manning Publications, ISBN: 9781617294532, Pages = 528, Price = $39.99,
        /// method ToString should return following string "C# in Depth by Jon Skeet".
        /// </example>
        /// <returns>The information about author and title of book.</returns>
        public override string ToString()
        {
            return $"{this.Title} by {this.Author}";
        }

        public override int GetHashCode()
        {
            int hash = 0;
            for (int i = 0; i < this.ISBN.Length; i++)
            {
                if (char.IsDigit(this.ISBN[i]))
                {
                    int digit = this.ISBN[i] - '0';
                    hash += digit * ((this.ISBN.Length - i) * 10);
                }
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            Book bookClass = obj as Book;
            if (bookClass == null)
            {
                return false;
            }

            return this.Equals(bookClass);
        }

        public bool Equals(Book other)
        {
            if (other is null)
            {
                return false;
            }

            if (other.ISBN is null && this.ISBN is null)
            {
                return true;
            }
            else if ((this.ISBN is null && !(other.ISBN is null)) ||
                (!(this.ISBN is null) && other.ISBN is null))
            {
                return false;
            }

            return this.GetHashCode() == other.GetHashCode();
        }

        public int CompareTo(object obj)
        {
            Book other = obj as Book;
            if (other is null)
            {
                return 1;
            }
            else
            {
                return this.CompareTo(other);
            }
        }

        public int CompareTo(Book other)
        {
            if (other is null)
            {
                return 1;
            }

            if (this.Title is null && other.Title is null)
            {
                return 0;
            }
            else if (this.Title is null && !(other.Title is null))
            {
                return -1;
            }
            else if (!(this.Title is null) && other.Title is null)
            {
                return 1;
            }

            return string.Compare(this.Title, other.Title, StringComparison.InvariantCultureIgnoreCase);
        }

        public string ToString(string format, IFormatProvider formatProvider = null)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "A";
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            string symbol = string.Empty;
            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            foreach (CultureInfo ci in cultures)
            {
                RegionInfo ri = new RegionInfo(ci.LCID);
                if (ri.ISOCurrencySymbol == this.Currency)
                {
                    symbol = ri.CurrencySymbol;
                }
            }

            switch (format.ToUpperInvariant())
            {
                case "A":
                    return $"{this.Title} by {this.Author}.";
                case "P":
                    return $"{this.Title} by {this.Author} {symbol}{this.Price.ToString(formatProvider)}.";
                case "B":
                    return $"{this.Title} by {this.Author}. {this.datePublished.Year}. {this.Pages} pages.";
                case "C":
                    return $"{this.Title} by {this.Author}. {this.datePublished.Year}. {this.Publisher}. {this.Pages} pages.";
                case "D":
                    return $"{this.Title} by {this.Author}. {this.datePublished.Year}. {this.Publisher}. ISBN: {this.ISBN}.  {this.Pages} pages.";
                case "F":
                    return $"{this.Title} by {this.Author}. {this.datePublished.Year}. {this.Publisher}. ISBN: {this.ISBN}.  {this.Pages} pages. {symbol}{this.Price.ToString(formatProvider)}.";
                default:
                    throw new FormatException($"The {format} format string is not supported.");
            }
        }

        public static Book Parse(string source)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)} is null");
            }

            var items = source.Split(",");
            if (items.Length < 3)
            {
                throw new ArgumentException("items lenght not equals 7");
            }

            var book = new Book(items[0], items[1], items[2], items[3]);

            if (items.Length > 3)
            {
                foreach (var i in items[3])
                {
                    if (!char.IsDigit(i))
                    {
                        throw new ArgumentException("ISBN is not a number");
                    }
                }

                if (items[3].Length >= 10)
                {
                    book.ISBN = items[3];
                }
            }

            if (items.Length > 4)
            {
                if (items[4] != "NYP")
                {
                    int year;
                    bool result = int.TryParse(items[4], out year);
                    if (!result)
                    {
                        throw new ArgumentException("year is not a number");
                    }
                    book.Publish(new DateTime(year, 1, 1));
                }
            }
            if (items.Length > 5)
            {
                int pages;
                bool result = int.TryParse(items[5], out pages);

                if (!result)
                {
                    throw new ArgumentException("pages is not a number");
                }

                if (pages > 0)
                {
                    book.Pages = pages;
                }
            }

            if (items.Length > 7)
            {
                decimal price;
                bool result = decimal.TryParse(items[6], NumberStyles.Number | NumberStyles.AllowCurrencySymbol, CultureInfo.CreateSpecificCulture("en-GB"), out price);

                if (!result)
                {
                    throw new ArgumentException("price is not a number");
                }

                book.SetPrice(price, items[7]);
            }

            return book;
        }

        public static bool TryParse(string source, out Book book)
        {
            try
            {
                book = Parse(source);
                return true;
            }
            catch
            {
                book = default(Book);
                return false;
            }
        }
    }
}
