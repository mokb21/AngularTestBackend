using AngularTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace AngularTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookListController : ControllerBase
    {
        private readonly ILogger<BookListController> _logger;
        private readonly ApplicationContext _context;

        public BookListController(ILogger<BookListController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.BookLists.ToList());
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:Guid}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var bookList = _context.BookLists.Find(id);
                if (bookList == null) return NotFound();

                return Ok(bookList);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id:Guid}/Books")]
        public IActionResult Books(Guid id)
        {
            try
            {
                return Ok(_context.Books.Where(e => e.BookListId == id).ToList());
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookList bookList)
        {
            try
            {
                if (bookList == null) return NotFound();

                bookList.Id = Guid.NewGuid();
                _context.Add(bookList);
                _context.SaveChanges();
                return Ok(bookList);

            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut]
        public IActionResult Put([FromBody] BookList bookList)
        {
            try
            {
                if (bookList == null) return NotFound();

                var dbBookList = _context.BookLists.AsNoTracking().SingleOrDefault(e => e.Id == bookList.Id);
                if (dbBookList == null) return NotFound();

                _context.Update(bookList);
                _context.SaveChanges();

                return Ok(bookList);

            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id:Guid}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var bookList = _context.BookLists.Find(id);
                if (bookList == null) return NotFound();

                _context.Remove(bookList);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
