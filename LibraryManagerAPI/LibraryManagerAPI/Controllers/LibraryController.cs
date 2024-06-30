using LibraryManagerAPI.Repository.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LibraryManagerAPI.Repository;
using LibraryManagerAPI.Data;
using LibraryManagerAPI.Models;

namespace LibraryManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryRepository _libraryRepository;

        public LibraryController(ILibraryRepository libraryRepository)
        {
            _libraryRepository = libraryRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetAllBooks()
        {
            var books = await _libraryRepository.GetAllBooks();
            return Ok(books);
        }


        [HttpGet("id/{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _libraryRepository.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet("genre/{genre}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByGenre(string genre)
        {
            var books = await _libraryRepository.GetBooksByGenre(genre);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpGet("author/{author}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByAuthor(string author)
        {
            var books = await _libraryRepository.GetBooksByAuthor(author);
            if (books == null)
            {
                return NotFound();
            }
            return Ok(books);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book)
        {
            var success = await _libraryRepository.AddBook(book);
            if (!success)
            {
                return BadRequest("Failed to add book");
            }
            var addedBook = await _libraryRepository.GetBookById(book.Id);
            if (addedBook == null)
            {
                return StatusCode(500, "Book was added but couldn't be retrieved");
            }
            return Ok(book);
        }

        [HttpPost("multiple")]
        public async Task<ActionResult<IEnumerable<Book>>> AddMultipleBooks(IEnumerable<Book>books)
        {
            var success = await _libraryRepository.AddMultipleBooks(books);
            if (!success)
            {
                return BadRequest("Failed to add the books");
            }
            if (books == null)
            {
                return BadRequest("Please specify the books to be added");
            }
            else return Ok(books);
        }

        [HttpPut("id/{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book)
        {
            var success = await _libraryRepository.UpdateBook(id, book);
            if (!success)
            {
                return BadRequest("Book couldn't be updated");
            }
            var updatedBook = await _libraryRepository.GetBookById(id);
            if (updatedBook == null)
            {
                return StatusCode(500, "Book was updated but couldn't be retrieved");
            }
            return Ok(updatedBook);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var success = await _libraryRepository.DeleteBookById(id);
            if (!success)
            {
                return NotFound($"The book with Id {id} couldn't be found");
            }
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllBooks()
        {
            var success = await _libraryRepository.DeleteAllBooks();
            if (!success)
            {
                return Problem("Failed to delete all books");
            }
            return NoContent();
        }
    }
}
