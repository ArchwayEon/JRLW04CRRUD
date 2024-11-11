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
    public async Task<IActionResult> Get()
    {
        return Ok(await _bookRepo.ReadAllAsync());
    }

    [HttpGet("one/{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var pet = await _bookRepo.ReadAsync(id);
        if (pet == null)
        {
            return NotFound();
        }
        return Ok(pet);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Post([FromForm] Book book)
    {
        await _bookRepo.CreateAsync(book);
        return CreatedAtAction("Get", new { id = book.Id }, book);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Put([FromForm] Book book)
    {
        await _bookRepo.UpdateAsync(book.Id, book);
        return NoContent(); // 204 as per HTTP specification
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _bookRepo.DeleteAsync(id);
        return NoContent(); // 204 as per HTTP specification
    }


}
