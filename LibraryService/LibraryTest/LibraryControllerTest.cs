using Xunit;
using System;
using Microsoft.EntityFrameworkCore;
using LibraryService.Model;
using LibraryService.Controllers;
using System.Threading.Tasks;

namespace LibraryTest
{
    public class LibraryControllerTest
    {
        private async Task<LibraryContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
                    .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;
                var dataContext = new LibraryContext(options);
            dataContext.Database.EnsureCreated();
            if (await dataContext.BookModel.CountAsync() <= 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    dataContext.BookModel.Add(new tblBooks() { BooKId = "a68aad99-f514- 401e-b410-ff697312f0a9", Name = "Rich Dad Poor Dad", AuthorName = "Robert Kiyosaki" });
                    dataContext.BookModel.Add(new tblBooks() {  BooKId = "07cb5767-d059-4a0a- bbf1-d80dd3158b5a", Name = "Prophecy", AuthorName = "Robert Kiyosaki" });
                    dataContext.BookModel.Add(new tblBooks() {  BooKId = "6173a278-4b33-49e5- b704-5992174762ef", Name = "Cashflow Quadrant", AuthorName = "Robert Kiyosaki" });
                    dataContext.BookModel.Add(new tblBooks() {  BooKId = "2a7ed687-a9a8-4c83- b6ac-5ea829f1e229", Name = "Guide to Investing", AuthorName = "Robert Kiyosaki" });
                    await dataContext.SaveChangesAsync();
                }
            }
            return dataContext;
        }
        [Fact]
        public async void TestGetBooks()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var libraryBooks = new LibraryController(dbContext);
            //Act
            var result = libraryBooks.Get();

            //Assert
            Assert.NotNull(result);

        }
        [Fact]
        public async void TestGetBookByID()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var libraryBooks = new LibraryController(dbContext);
            var libraryModel = new tblBooks();
            string bookID = "a68aad99-f514- 401e-b410-ff697312f0a9";

            //Act
            var result = libraryBooks.Get(bookID);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<tblBooks>(libraryModel);
        }
        [Fact]
        public async void TestDeleteBook()
        {
            //Arrange
            var dbContext = await GetDatabaseContext();
            var libraryBooks = new LibraryController(dbContext);
            
            //Act
            libraryBooks.Delete(1);
        }
    }
}




