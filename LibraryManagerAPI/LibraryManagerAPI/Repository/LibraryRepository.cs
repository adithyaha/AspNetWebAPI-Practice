using LibraryManagerAPI.Data;
using LibraryManagerAPI.Models;
using LibraryManagerAPI.Repository.Services;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagerAPI.Repository
{
    public class LibraryRepository : ILibraryRepository
    {

        private readonly LibraryContext _context;

        public LibraryRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBook(Book book)
        {
            try
            {
                _context.Library.Add(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> AddMultipleBooks(IEnumerable<Book> books)
        {
            try
            {
                _context.Library.AddRange(books);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAllBooks()
        {
            try
            {
                _context.RemoveRange(_context.Library);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteBookById(int id)
        {
            var book = await _context.Library.FindAsync(id);
            if (book == null)
            {
                return false;
            }
            try
            {
                _context.Library.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _context.Library.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByAuthor(string author)
        {
            return await _context.Library.Where(b => b.Author == author).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksByGenre(string genre)
        {
            return await _context.Library.Where(b => b.Genre == genre).ToListAsync();
        }

        public async Task<Book> GetBookById(int id)
        {
            return await _context.Library.FindAsync(id);
        }

        public async Task<bool> UpdateBook(int id, Book updatedBook)
        {
            var oldBook = _context.Library.Find(id);
            if (oldBook == null)
            {
                return false;
            }
            try
            {
                _context.Library.Remove(oldBook);
                await _context.AddAsync(updatedBook);
                return true;
            } catch (Exception ex)
            {
                return false;
            }
        }
    }
}
