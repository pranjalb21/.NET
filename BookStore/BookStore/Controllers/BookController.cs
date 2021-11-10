using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BookController()
        {
            _bookRepository = new BookRepository();
        }

        public string Index()
        {
            return "Books Page";
        }
        public ViewResult GetAllBooks()
        {
            var data = _bookRepository.GetAllBooks();
            return View(data);
        }
        public ViewResult GetBook(int id)
        {   TempData["b"] = _bookRepository.GetBooksById(id);

            ViewBag.book = TempData["b"];
            return View();
        }
        public List<BookModel> SearchBook(string bookName, string author)
        {
            return _bookRepository.SearchBook(bookName, author);
        }

        public ViewResult AddBook()
        {
            return View();
        }

        [HttpPost]
        public ViewResult AddBook(BookModel bookModel)
        {
            return View();
        }
    }
}
