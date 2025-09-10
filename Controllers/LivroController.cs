using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}
