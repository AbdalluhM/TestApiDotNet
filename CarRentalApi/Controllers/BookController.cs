using CarRentalApi.Data.Services;
using CarRentalApi.Data.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarRentalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public BookService _BookService;

        public BookController(BookService bookService)
        {
           _BookService = bookService;
        }

        [HttpPost]
        public ActionResult AddBook([FromBody]BookVM book) 
        {
            _BookService.AddBook(book);
            return Ok();
        }
        [HttpGet]
        public ActionResult getAll()
        {
            var books = _BookService.GetAll();
            return Ok(books);
        }

        [HttpGet("book-id/{id}")]
        public ActionResult getBook(int id)
        {
            var book = _BookService.GeById(id);
            return Ok(book);
        }
        [HttpPut("book-updated/{id}")]
        public ActionResult updateBook(int id , BookVM book)
        {
            var bookUpdated= _BookService.update(id, book);
            return Ok(bookUpdated);
        }

        [HttpDelete("book-delete/{id}")]
        public ActionResult delete(int id)
        {
            _BookService.delete(id);
            return Ok();
        }
    }

}
