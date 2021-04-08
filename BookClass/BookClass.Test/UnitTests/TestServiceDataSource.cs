using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookClass.Test.UnitTests
{
    public class TestServiceDataSource
    {
        public static IEnumerable<TestCaseData> TestCasesFindByTag
        {
            get
            {
                yield return new TestCaseData(
                    new Book[]
                    {
                        new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", "12345678"),
                        new Book("Александр Пушкин", "Евгений Онегин", "Secker and Warburg", "1234556757"),
                        new Book("Александр Пушкин", "Борис Годунов", "Secker and Warburg", "23623623623"),
                        new Book("Александр Пушкин", "Моцарт и Сальери", "Secker and Warburg", "5325235235"),
                    },
                    new Book[]
                    {
                        new Book("Александр Пушкин", "Евгений Онегин", "Secker and Warburg", "1234556757"),
                        new Book("Александр Пушкин", "Борис Годунов", "Secker and Warburg", "23623623623"),
                        new Book("Александр Пушкин", "Моцарт и Сальери", "Secker and Warburg", "5325235235"),
                    },
                    "Author",
                    "Александр Пушкин");
                yield return new TestCaseData(
                    new Book[]
                    {
                        new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", "12345678"),
                        new Book("Александр Пушкин", "Евгений Онегин", "Secker and Warburg", "1234556757"),
                        new Book("Александр Пушкин", "Борис Годунов", "Secker and Warburg", "23623623623"),
                        new Book("Александр Пушкин", "Моцарт и Сальери", "Secker and Warburg", "5325235235"),
                    },
                    new Book[]
                    {
                        new Book("Джорджа Оруэлла", "1984", "Secker and Warburg", "12345678"),
                        new Book("Александр Пушкин", "Евгений Онегин", "Secker and Warburg", "1234556757"),
                        new Book("Александр Пушкин", "Борис Годунов", "Secker and Warburg", "23623623623"),
                        new Book("Александр Пушкин", "Моцарт и Сальери", "Secker and Warburg", "5325235235"),
                    },
                    "Publisher",
                    "Secker and Warburg");
            }
        }

        public static IEnumerable<TestCaseData> TestCasesSortByTag
        {
            get
            {
                yield return new TestCaseData(
                    new Book[]
                    {
                        new Book("5234", "234", "2134", "12345678"),
                        new Book("2234", "23asfg4", "4fas56", "1234556757"),
                        new Book("1234", "2cbx34", "4fsaf56", "23623623623"),
                        new Book("3234", "2gds34", "456", "5325235235"),
                        new Book("4234", "234", "45fasf6", "412634763246"),
                    },
                    new Book[]
                    {
                        new Book("5234", "234", "2134", "12345678"),
                        new Book("4234", "234", "45fasf6", "412634763246"),
                        new Book("3234", "2gds34", "456", "5325235235"),
                        new Book("2234", "23asfg4", "4fas56", "1234556757"),
                        new Book("1234", "2cbx34", "4fsaf56", "23623623623"),
                    },
                    "Author");
                yield return new TestCaseData(
                    new Book[]
                    {
                        new Book("5234", "234", "2134", "12345678"),
                        new Book("2234", "23asfg4", "4fas56", "1234556757"),
                        new Book("1234", "2cbx34", "4fsaf56", "23623623623"),
                        new Book("3234", "2gds34", "456", "5325235235"),
                        new Book("4234", "234", "45fasf6", "412634763246"),
                    },
                    new Book[]
                    {
                        new Book("3234", "2gds34", "456", "5325235235"),
                        new Book("1234", "2cbx34", "4fsaf56", "23623623623"),
                        new Book("2234", "23asfg4", "4fas56", "1234556757"),
                        new Book("5234", "234", "2134", "12345678"),
                        new Book("4234", "234", "45fasf6", "412634763246"),
                    },
                    "Title");
            }
        }
    }
}
