using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                CreatedOn = DateTime.UtcNow,
                Title = model.Title,
                Description = model.Description,
                Pages = model.Pages.HasValue ? model.Pages.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };
            await _context.AddAsync(newBook);
            await _context.SaveChangesAsync();

            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if(allbooks != null)
            {
                foreach (var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Description = book.Description,
                        Category = book.Category,
                        Id = book.Id,
                        Pages = book.Pages,
                        Language = book.Language
                    });
                }
            }
            return books;
        }
        public async Task<BookModel> GetBooksById(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book != null)
            {
                var bookDetails = new BookModel()
                {
                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    Category = book.Category,
                    Id = book.Id,
                    Pages = book.Pages,
                    Language = book.Language
                };
                return bookDetails;
            }
            return null;
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
