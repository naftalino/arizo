using bot.Database;
using bot.Database.Models;
using bot.Database.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace bot.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SerieController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public SerieController(DatabaseContext context)
        {
            _context = context;
        }

        // POST: api/Serie
        [HttpPost]
        public IActionResult CreateSerie([FromBody] Serie serie)
        {
            // Validar a entrada de dados
            if (serie == null)
            {
                return BadRequest("A série não pode ser nula.");
            }

            // Validação de dados da série
            if (string.IsNullOrEmpty(serie.Name))
            {
                return BadRequest("O nome da série é obrigatório.");
            }

            if (serie.ReleaseDate == default)
            {
                return BadRequest("A data de lançamento é obrigatória.");
            }

            if (!Enum.IsDefined(typeof(Genre), serie.Genre))
            {
                return BadRequest("O gênero informado não é válido.");
            }

            // Se a série é uma sub-série, devemos garantir que a SubSerieId seja válida
            if (serie.IsFromSubSerie && serie.SubSerieId == 0)
            {
                return BadRequest("O SubSerieId deve ser maior que 0 quando a série for uma sub-série.");
            }

            // Adicionando a série ao banco de dados
            _context.Serie.Add(serie);
            _context.SaveChanges();

            // Retorna a série criada com o status 201 Created
            return CreatedAtAction(nameof(GetSerieById), new { id = serie.Id }, serie);
        }

        // GET: api/Serie/{id}
        [HttpGet("{id}")]
        public IActionResult GetSerieById(int id)
        {
            var serie = _context.Serie.Find(id);
            if (serie == null)
            {
                return NotFound();
            }

            return Ok(serie);
        }
    }
}
