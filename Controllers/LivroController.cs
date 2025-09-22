using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SistemaBiblioteca.Data;
using SistemaBiblioteca.Models;

namespace SistemaBiblioteca.Controllers
{
    [Route("api/[controller]")]
    public class LivroController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public LivroController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddLivro([FromBody] Livro livro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _appDbContext.BIBLIOTECA.Add(livro);
            await _appDbContext.SaveChangesAsync();

            return Created("Livro adicionado: ", livro);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            var livros = await _appDbContext.BIBLIOTECA.ToListAsync();

            return Ok(livros);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Livro>> GetLivro(int id)
        {
            var livro = await _appDbContext.BIBLIOTECA.FindAsync(id);

            if (livro == null)
            {
                return NotFound("Livro não encontrado!");
            }

            return Ok(livro);
        }
    }
}
