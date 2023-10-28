using JRLW04CRRUD.Models.Entities;
using JRLW04CRRUD.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JRLW04CRRUD.Controllers;

[EnableCors]
[Route("api/book")]
[ApiController]
public class BookAPIController : ControllerBase
{
    private readonly IBookRepository _bookRepo;

    public BookAPIController(IBookRepository bookRepo)
    {
        _bookRepo = bookRepo;
    }

    [HttpGet("all")]
    public IActionResult Get()
    {
        return Ok(_bookRepo.ReadAll());
    }

    [HttpGet("one/{id}")]
    public IActionResult Get(int id)
    {
        var pet = _bookRepo.Read(id);
        if (pet == null)
        {
            return NotFound();
        }
        return Ok(pet);
    }

    [HttpPost("create")]
    public IActionResult Post([FromForm] Book book)
    {
        _bookRepo.Create(book);
        return CreatedAtAction("Get", new { id = book.Id }, book);
    }

    [HttpPut("update")]
    public IActionResult Put([FromForm] Book book)
    {
        _bookRepo.Update(book.Id, book);
        return NoContent(); // 204 as per HTTP specification
    }

    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id)
    {
        _bookRepo.Delete(id);
        return NoContent(); // 204 as per HTTP specification
    }


}
