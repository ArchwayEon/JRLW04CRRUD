using JRLW04CRRUD.Models.Entities;

namespace JRLW04CRRUD.Services;

public class DbBookRepository : IBookRepository
{
    private readonly ApplicationDbContext _db;

    public DbBookRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public Book Create(Book newBook)
    {
        _db.Books.Add(newBook);
        _db.SaveChanges();
        return newBook;
    }

    public void Delete(int id)
    {
        Book? bookToDelete = Read(id);
        if (bookToDelete != null)
        {
            _db.Books.Remove(bookToDelete);
            _db.SaveChanges();
        }
    }


    public Book? Read(int id)
    {
        return _db.Books.Find(id);
    }

    public ICollection<Book> ReadAll()
    {
        return _db.Books.ToList();
    }

    public void Update(int oldId, Book book)
    {
        Book? bookToUpdate = Read(oldId);
        if (bookToUpdate != null)
        {
            bookToUpdate.Title = book.Title;
            bookToUpdate.Edition = book.Edition;
            bookToUpdate.PublicationYear = book.PublicationYear;
            _db.SaveChanges();
        }
    }

}
