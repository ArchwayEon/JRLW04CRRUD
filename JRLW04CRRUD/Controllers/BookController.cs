using JRLW04CRRUD.Models.Entities;
using JRLW04CRRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace JRLW04CRRUD.Controllers;

public class BookController : Controller
{
    private readonly IBookRepository _bookRepo;

    public BookController(IBookRepository bookRepo)
    {
        _bookRepo = bookRepo;
    }

    public IActionResult Index()
    {
        var model = _bookRepo.ReadAll();
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Book newBook)
    {
        if (ModelState.IsValid)
        {
            _bookRepo.Create(newBook);
            return RedirectToAction("Index");
        }
        return View(newBook);
    }

    public IActionResult Details(int id)
    {
        var book = _bookRepo.Read(id);
        if (book == null)
        {
            return RedirectToAction("Index");
        }
        return View(book);
    }

    public IActionResult Edit(int id)
    {
        var book = _bookRepo.Read(id);
        if (book == null)
        {
            return RedirectToAction("Index");
        }
        return View(book);
    }

    [HttpPost]
    public IActionResult Edit(Book book)
    {
        if (ModelState.IsValid)
        {
            _bookRepo.Update(book.Id, book);
            return RedirectToAction("Index");
        }
        return View(book);
    }

    public IActionResult Delete(int id)
    {
        var book = _bookRepo.Read(id);
        if (book == null)
        {
            return RedirectToAction("Index");
        }
        return View(book);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        _bookRepo.Delete(id);
        return RedirectToAction("Index");
    }


}
