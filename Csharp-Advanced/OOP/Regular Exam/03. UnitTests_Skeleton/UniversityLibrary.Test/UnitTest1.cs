namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System;
    using System.Reflection.Emit;

    public class Tests
    {
        private TextBook textBook;
        private const string DEF_TITLE = "title";
        private const string DEF_AUTHOR = "author";
        private const string DEF_CATEGORY = "category";
        private UniversityLibrary universityLibrary;
        [SetUp]
        public void Setup()
        {
            textBook = new TextBook(DEF_TITLE, DEF_AUTHOR, DEF_CATEGORY);
            universityLibrary = new UniversityLibrary();
        }

        [Test]
        public void TextBook_Constructor()
        {
            Assert.AreEqual(DEF_TITLE, textBook.Title);
            Assert.AreEqual(DEF_AUTHOR, textBook.Author);
            Assert.AreEqual(DEF_CATEGORY, textBook.Category);
            Assert.AreEqual(0, textBook.InventoryNumber);
            Assert.Null(textBook.Holder);
        }

        [Test]
        public void UniversityLibrary_Constructor()
        {
            Assert.AreEqual(0, universityLibrary.Catalogue.Count);
            Assert.NotNull(universityLibrary.Catalogue);
        }

        [Test]
        public void TextBook_ToString()
        {
            var expected = $"Book: {DEF_TITLE} - {0}" +
                Environment.NewLine +
                $"Category: {DEF_CATEGORY}" +
                Environment.NewLine +
                $"Author: {DEF_AUTHOR}";

            var actual = textBook.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(7)]
        public void AddTextBookLibrary_AddTextBook(int times)
        {
            for (int i = 0; i < times; i++)
                universityLibrary.AddTextBookToLibrary(textBook);

            Assert.AreEqual(textBook, universityLibrary.Catalogue[0]);
            Assert.AreEqual(times, universityLibrary.Catalogue.Count);
        }

        [Test]
        public void AddTextBookLibrary_SetTextBookInventoryNumber()
        {
            universityLibrary.AddTextBookToLibrary(textBook);
            Assert.AreEqual(1, textBook.InventoryNumber);
        }

        [Test]
        public void AddTextBookLibrary_ReturnMessage()
        {
            var actual = universityLibrary.AddTextBookToLibrary(textBook);
            var expected = textBook.ToString();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LoanTextBook_LoanBook()
        {
            universityLibrary.AddTextBookToLibrary(textBook);
            var expected = $"{textBook.Title} loaned to Liam.";
            var actual = universityLibrary.LoanTextBook(textBook.InventoryNumber, "Liam");
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void LoanTextBook_SetTextBookHolder()
        {
            universityLibrary.AddTextBookToLibrary(textBook);
            universityLibrary.LoanTextBook(textBook.InventoryNumber, "Liam");
            Assert.AreEqual("Liam", textBook.Holder);
        }

        [Test]
        public void LoanTextBook_WhenSameHolderDoesntReturnTextBook()
        {
            universityLibrary.AddTextBookToLibrary(textBook);
            universityLibrary.LoanTextBook(textBook.InventoryNumber, "Liam");
            var actual = universityLibrary.LoanTextBook(textBook.InventoryNumber, "Liam");
            var expected = $"Liam still hasn't returned {textBook.Title}!";
            Assert.AreEqual(expected,actual);
        }

        [TestCase(1)]
        public void LoanTextBook_WithInvalidInventoryNumber(int invalid)
        {
            Assert.Throws<NullReferenceException>(() => universityLibrary.LoanTextBook(invalid,"Liam"));
        }

        [Test]
        public void ReturnTextBook_Message()
        {
            universityLibrary.AddTextBookToLibrary(textBook);
            universityLibrary.LoanTextBook(textBook.InventoryNumber, "Liam");
            var expected = $"{textBook.Title} is returned to the library.";
            var actual = universityLibrary.ReturnTextBook(textBook.InventoryNumber);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ReturnTextBook_SetHolderToEmpty()
        {
            universityLibrary.AddTextBookToLibrary(textBook);
            universityLibrary.LoanTextBook(textBook.InventoryNumber, "Liam");
            universityLibrary.ReturnTextBook(textBook.InventoryNumber);
            
            Assert.AreEqual(string.Empty,textBook.Holder);
        }


        [TestCase(1)]
        public void ReturnTextBook_WithInvalidInventoryNumber(int invalid)
        {
            Assert.Throws<NullReferenceException>(() => universityLibrary.ReturnTextBook(invalid));
        }
    }
}