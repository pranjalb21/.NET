using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }
        public BookModel GetBooksById(int id)
        {
            return DataSource().Where(x => x.Id == id).FirstOrDefault();
        }
        public List<BookModel> SearchBook(string title, string author)
        {
            return DataSource().Where(x => x.Title.Contains(title) || x.Author.Contains(author)).ToList();
        }
        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id = 1, Title = "Vivekadeepini", Author = "Adi Shankaracharya", Description = "This is a book by Adi Shankaracharya", Source = "/images/Book_1.jpg", Category = "Life Style", Language = "Tamil", Pages = 1046 },
                new BookModel() { Id = 2, Title = "ABSALOM, ABSALOM!", Author = "WILLIAM FAULKNER", Description = "This quotation for Faulkner’s 1936 novel comes from the Books of Samuel.", Source = "/images/Book_2.jpg", Category = "Novel", Language = "English", Pages = 996 },
                new BookModel() { Id = 3, Title = "A TIME TO KILL", Author = "JOHN GRISHAM", Description = "This one is from 3:3 in the Ecclesiastes, again part of the Old Testament.", Source = "/images/Book_3.jpg", Category = "Historic", Language = "Sanskrit", Pages = 2046 },
                new BookModel() { Id = 4, Title = " THE HOUSE OF MIRTH", Author = "EDITH WHARTON",Description = "One of Wharton’s best-known novels, it came out in 1905.", Source = "/images/Book_4.jpg", Category = "Historic", Language = "English", Pages = 1001  },
                new BookModel() { Id = 5, Title = " EAST OF EDEN", Author = "JOHN STEINBECK", Description = "Steinbeck apparently considered this 1952 novel to be his magnum opus.", Source = "/images/Book_5.jpg", Category = "Fantasy", Language = "Hindi", Pages = 3001 },
            };
        }
    }
}
