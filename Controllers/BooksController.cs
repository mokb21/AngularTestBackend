using AngularTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly ApplicationContext _context;

        public BooksController(ILogger<BooksController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_context.Books.ToList());
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
                var book = _context.Books.Find(id);
                if (book == null) return NotFound();

                return Ok(book);
            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            try
            {
                if (book == null) return NotFound();

                book.Id = Guid.NewGuid();
                _context.Add(book);
                _context.SaveChanges();
                return Ok(book);

            }
            catch (Exception ex)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            try
            {
                if (book == null) return NotFound();

                var dbBook = _context.Books.AsNoTracking().SingleOrDefault(e => e.Id == book.Id);
                if (dbBook == null) return NotFound();

                _context.Update(book);
                _context.SaveChanges();

                return Ok(book);

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
                var book = _context.Books.Find(id);
                if (book == null) return NotFound();

                _context.Remove(book);
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
