using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using NUnit.Framework;

#pragma warning disable SA1600
namespace BookClass.Tests
{
    internal class TestCasesDataSource
    {
        public static IEnumerable<TestCaseData> TestCasesEquals
        {
            get
            {
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", null),
                    true);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", "1234567890"),
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", null),
                    false);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", "1234567890"),
                    false);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", "9879999999999"),
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", "9879999999999"),
                    true);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", "12345678901"),
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", "1234567890"),
                    false);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", "12345678901"),
                    null,
                    false);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesCompareTo
        {
            get
            {
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "B1984", "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", "A1984", "Secker and Warburg", null),
                    1);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "A1984", "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", "B1984", "Secker and Warburg", null),
                    -1);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", null),
                    0);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", null, "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", null),
                    -1);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", null, "Secker and Warburg", null),
                    1);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", null, "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", null, "Secker and Warburg", null),
                    0);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", null, "Secker and Warburg", null),
                    null,
                    1);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesCompareToObj
        {
            get
            {
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "B1984", "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", "A1984", "Secker and Warburg", null),
                    1);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "A1984", "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", "B1984", "Secker and Warburg", null),
                    -1);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", null),
                    0);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", null, "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", null),
                    -1);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", null, "Secker and Warburg", null),
                    1);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", null, "Secker and Warburg", null),
                    new Book("Джорджа Оруэлла", null, "Secker and Warburg", null),
                    0);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", null, "Secker and Warburg", null),
                    null,
                    1);
                yield return new TestCaseData(
                    new Book("Джорджа Оруэлла", null, "Secker and Warburg", null),
                    new int[] { 1, 2, 3, 4, 5 },
                    1);
            }
        }

        public static IEnumerable<TestCaseData> TestCasesToStringFormat
        {
            get
            {
                yield return new TestCaseData(
                    "C# in Depth",
                    "Jon Skeet",
                    "Manning Publications",
                    "9781617294532",
                    528,
                    39.99m,
                    "USD",
                    new DateTime(2019, 10, 1),
                    "A",
                    CultureInfo.InvariantCulture,
                    "C# in Depth by Jon Skeet.");
                yield return new TestCaseData(
                    "C# in Depth",
                    "Jon Skeet",
                    "Manning Publications",
                    "9781617294532",
                    528,
                    39.99m,
                    "USD",
                    new DateTime(2019, 10, 1),
                    "P",
                    CultureInfo.InvariantCulture,
                    "C# in Depth by Jon Skeet $39.99.");
                yield return new TestCaseData(
                    "C# in Depth",
                    "Jon Skeet",
                    "Manning Publications",
                    "9781617294532",
                    528,
                    39.99m,
                    "USD",
                    new DateTime(2019, 10, 1),
                    "B",
                    CultureInfo.InvariantCulture,
                    "C# in Depth by Jon Skeet. 2019. 528 pages.");
                yield return new TestCaseData(
                    "C# in Depth",
                    "Jon Skeet",
                    "Manning Publications",
                    "9781617294532",
                    528,
                    39.99m,
                    "USD",
                    new DateTime(2019, 10, 1),
                    "C",
                    CultureInfo.InvariantCulture,
                    "C# in Depth by Jon Skeet. 2019. Manning Publications. 528 pages.");
                yield return new TestCaseData(
                    "C# in Depth",
                    "Jon Skeet",
                    "Manning Publications",
                    "9781617294532",
                    528,
                    39.99m,
                    "USD",
                    new DateTime(2019, 10, 1),
                    "D",
                    CultureInfo.InvariantCulture,
                    "C# in Depth by Jon Skeet. 2019. Manning Publications. ISBN: 9781617294532.  528 pages.");
                yield return new TestCaseData(
                    "C# in Depth",
                    "Jon Skeet",
                    "Manning Publications",
                    "9781617294532",
                    528,
                    39.99m,
                    "USD",
                    new DateTime(2019, 10, 1),
                    "F",
                    CultureInfo.InvariantCulture,
                    "C# in Depth by Jon Skeet. 2019. Manning Publications. ISBN: 9781617294532.  528 pages. $39.99.");
            }
        }

        public static IEnumerable<TestCaseData> TestCasesFormat
        {
            get
            {
                yield return new TestCaseData(
                    "C# in Depth",
                    "Jon Skeet",
                    "Manning Publications",
                    "9781617294532",
                    528,
                    39.99m,
                    "USD",
                    new DateTime(2019, 10, 1),
                    $"{$"Product details:\nAuthor: Jon Skeet"}{$"\nTitle: C# in Depth"}{$"\nPublisher: Manning Publications, 2019"}{$"\nISBN-13: 9781617294532"}{$"\nPaperback: 528 pages"}");
            }
        }
    }
}
