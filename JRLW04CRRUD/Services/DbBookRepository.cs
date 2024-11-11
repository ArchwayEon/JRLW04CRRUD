using JRLW04CRRUD.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace JRLW04CRRUD.Services;

public class DbBookRepository : IBookRepository
{
    private readonly ApplicationDbContext _db;

    public DbBookRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Book> CreateAsync(Book newBook)
    {
        await _db.Books.AddAsync(newBook);
        await _db.SaveChangesAsync();
        return newBook;
    }

    public async Task DeleteAsync(int id)
    {
        Book? bookToDelete = await ReadAsync(id);
        if (bookToDelete != null)
        {
            _db.Books.Remove(bookToDelete);
            await _db.SaveChangesAsync();
        }
    }

    public async Task<Book?> ReadAsync(int id)
    {
        return await _db.Books.FindAsync(id);
    }

    public async Task<ICollection<Book>> ReadAllAsync()
    {
        return await _db.Books.ToListAsync();
    }

    public async Task UpdateAsync(int oldId, Book book)
    {
        Book? bookToUpdate = await ReadAsync(oldId);
        if (bookToUpdate != null)
        {
            bookToUpdate.Title = book.Title;
            bookToUpdate.Edition = book.Edition;
            bookToUpdate.PublicationYear = book.PublicationYear;
            await _db.SaveChangesAsync();
        }
    }

}
