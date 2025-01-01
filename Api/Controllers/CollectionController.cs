using bot.Database;
using bot.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CollectionController : ControllerBase
{
    private readonly DatabaseContext _context;

    public CollectionController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet("collection/all")]
    public async Task<ActionResult<IEnumerable<Card>>> GetAllCards()
    {
        var cards = await _context.Collections.ToListAsync();
        return Ok(cards);
    }
}
