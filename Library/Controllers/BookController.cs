using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library.DAL.Repositories;
using Library.DAL;
using Library.DAL.Models;

namespace Library.Controllers
{
    [Route("book")]
    public class BookController : BaseController
    {
        private IBookRepo _bookRepo;

        public BookController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _bookRepo = UnitOfWork.GetBookRepo();
        }

        [HttpGet]
        [Route("get/{bookId:int}")]
        public async Task<IActionResult> GetBookByIdAsync(int bookId)
        {
            Book book = await _bookRepo.SelectByIdAsync(bookId);
            return book == null ? NotFound() : (IActionResult)Ok(book);
        }

        [HttpGet]
        [Route("get_list")]
        public async Task<IActionResult> GetBookListAsync()
        {
            IEnumerable<Book> bookList = await _bookRepo.SelectListAsync();
            return bookList.Count() == 0 ? NotFound() : (IActionResult)Ok(bookList);
        }

        [HttpGet]
        [Route("get_list_by_author/{author}")]
        public async Task<IActionResult> GetBookListByAuthorAsync(string author)
        {
            IEnumerable<Book> bookList = await _bookRepo.SelectListByAuthorAsync(author);
            return bookList.Count() == 0 ? NotFound() : (IActionResult)Ok(bookList);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateBookAsync([FromBody] Book book)
        {
            Book b = await _bookRepo.SelectByIdAsync(book.Id);
            if (b != null)
            {
                return Conflict();
            }
            else
            {
                _bookRepo.Insert(book);
                await UnitOfWork.SaveAsync();
                IEnumerable<Book> bookList = await _bookRepo.SelectListAsync();
                return bookList.Count() == 0 ? NotFound() : (IActionResult)Ok(bookList);
            }
        }

        [HttpPut]
        [Route("edit/{bookId:int}")]
        public async Task<IActionResult> EditBookAsync(int bookId, [FromBody] Book changedBook)
        {
            Book book = await _bookRepo.SelectByIdAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                _bookRepo.Update(changedBook);
                await UnitOfWork.SaveAsync();
                IEnumerable<Book> bookList = await _bookRepo.SelectListAsync();
                return bookList.Count() == 0 ? NotFound() : (IActionResult)Ok(bookList);
            }
        }

        [HttpDelete]
        [Route("delete_by_name_and_author")]
        public async Task<IActionResult> DeleteBookByNameAndAuthorAsync(string bookName, string author)
        {
            Book book = await _bookRepo.SelectByNameAndAuthorAsync(bookName.Trim(), author.Trim());
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                _bookRepo.Delete(book);
                await UnitOfWork.SaveAsync();
                IEnumerable<Book> bookList = await _bookRepo.SelectListAsync();
                return Ok(bookList);
            }
        }

        [HttpDelete]
        [Route("delete_by_id/{bookId:int}")]
        public async Task<IActionResult> DeleteBookByIdAsync(int bookId)
        {
            Book book = await _bookRepo.SelectByIdAsync(bookId);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                _bookRepo.Delete(book);
                await UnitOfWork.SaveAsync();
                IEnumerable<Book> bookList = await _bookRepo.SelectListAsync();
                return Ok(bookList);
            }
        }

    }
}