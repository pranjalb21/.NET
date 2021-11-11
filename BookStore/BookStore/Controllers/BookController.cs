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

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public string Index()
        {
            return "Books Page";
        }
        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooks();
            return View(data);
        }
        public async Task<ViewResult> GetBook(int id)
        {   TempData["b"] = await _bookRepository.GetBooksById(id);

            ViewBag.book = TempData["b"];
            return View();
        }
        public List<BookModel> SearchBook(string bookName, string author)
        {
            return _bookRepository.SearchBook(bookName, author);
        }

        public ViewResult AddBook(bool IsSuccess = false, int bookId = 0)
        {
            ViewBag.IsSuccess = IsSuccess;
            ViewBag.bookId = bookId;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBook), new { IsSuccess = true, bookId = id });
                }
            }

            return View();
        }
    }
}
