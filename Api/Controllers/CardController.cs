using bot.Database;
using bot.Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class CardsController : ControllerBase
{
    private readonly DatabaseContext _context;

    public CardsController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Card>>> GetAllCards()
    {
        var cards = await _context.Card.ToListAsync();
        return Ok(cards);
    }

    [HttpGet("serie/{serieId}")]
    public async Task<ActionResult<IEnumerable<Card>>> GetCardsBySerie(int serieId)
    {
        // Buscando a série pelo ID e incluindo os cards
        var serie = await _context.Serie
            .Include(s => s.Cards) // Inclui os cards relacionados à série
            .FirstOrDefaultAsync(s => s.Id == serieId);

        if (serie == null)
        {
            return NotFound(new { message = "Série não encontrada." });
        }

        // Retorna os cards da série
        return Ok(serie.Cards);
    }

    // POST: api/cards
    [HttpPost]
    public IActionResult CreateCard([FromBody] Card card)
    {
        if (card == null)
        {
            return BadRequest("O card não pode ser nulo.");
        }

        // Verifica se os campos obrigatórios estão preenchidos
        if (string.IsNullOrEmpty(card.Name) || string.IsNullOrEmpty(card.Description))
        {
            return BadRequest("O nome e a descrição do card são obrigatórios.");
        }

        // Verifica se a série existe
        var serie = _context.Serie.Find(card.SerieId);
        if (serie == null)
        {
            return BadRequest("A série com o ID fornecido não foi encontrada.");
        }

        // Associa a série ao card
        card.Serie = serie;

        // Adiciona o card ao banco de dados
        _context.Card.Add(card);
        _context.SaveChanges();

        // Retorna o card criado
        return CreatedAtAction(nameof(GetCardById), new { id = card.Id }, card);
    }

    // GET: api/cards/{id}
    [HttpGet("{id}")]
    public IActionResult GetCardById(int id)
    {
        var card = _context.Card.Include(c => c.Serie).FirstOrDefault(c => c.Id == id);
        if (card == null)
        {
            return NotFound();
        }

        return Ok(card);
    }
}
