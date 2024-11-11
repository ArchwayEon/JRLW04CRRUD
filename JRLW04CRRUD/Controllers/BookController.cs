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

    public async Task<IActionResult> Index()
    {
        var model = await _bookRepo.ReadAllAsync();
        return View(model);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Book newBook)
    {
        if (ModelState.IsValid)
        {
            await _bookRepo.CreateAsync(newBook);
            return RedirectToAction("Index");
        }
        return View(newBook);
    }

    public async Task<IActionResult> Details(int id)
    {
        var book = await _bookRepo.ReadAsync(id);
        if (book == null)
        {
            return RedirectToAction("Index");
        }
        return View(book);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var book = await _bookRepo.ReadAsync(id);
        if (book == null)
        {
            return RedirectToAction("Index");
        }
        return View(book);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Book book)
    {
        if (ModelState.IsValid)
        {
            await _bookRepo.UpdateAsync(book.Id, book);
            return RedirectToAction("Index");
        }
        return View(book);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var book = await _bookRepo.ReadAsync(id);
        if (book == null)
        {
            return RedirectToAction("Index");
        }
        return View(book);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _bookRepo.DeleteAsync(id);
        return RedirectToAction("Index");
    }


}
