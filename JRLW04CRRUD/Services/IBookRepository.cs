using JRLW04CRRUD.Models.Entities;

namespace JRLW04CRRUD.Services;

public interface IBookRepository
{
    Task<ICollection<Book>> ReadAllAsync();
    Task<Book> CreateAsync(Book book);
    Task<Book?> ReadAsync(int id);
    Task UpdateAsync(int oldId, Book book);
    Task DeleteAsync(int id);
}

