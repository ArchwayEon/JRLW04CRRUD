using JRLW04CRRUD.Models.Entities;

namespace JRLW04CRRUD.Services;

public interface IBookRepository
{
    ICollection<Book> ReadAll();
    Book Create(Book book);
    Book? Read(int id);
    void Update(int oldId, Book book);
    void Delete(int id);
}

