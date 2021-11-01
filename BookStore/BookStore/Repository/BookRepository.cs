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
                new BookModel() { Id = 1, Title = "Book1", Author = "Author1" },
                new BookModel() { Id = 2, Title = "Book2", Author = "Author2" },
                new BookModel() { Id = 3, Title = "Book3", Author = "Author3" },
                new BookModel() { Id = 4, Title = "Book4", Author = "Author4" },
                new BookModel() { Id = 5, Title = "Book5", Author = "Author5" },
            };
        }
    }
}
