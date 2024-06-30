using LibraryManagerAPI.Models;

namespace LibraryManagerAPI.Repository.Services
{
    public interface ILibraryRepository
    {
        Task<Book> GetBookById (int id);
        Task<IEnumerable<Book>> GetAllBooks();
        Task<IEnumerable<Book>> GetBooksByGenre(string genre);
        Task<IEnumerable<Book>> GetBooksByAuthor(string author);

        Task<bool> AddBook(Book book);
        Task<bool> AddMultipleBooks(IEnumerable<Book> books);

        Task<bool> UpdateBook(int id, Book updatedBook);
        Task<bool> DeleteBookById(int id);
        Task <bool> DeleteAllBooks();

    }
}
