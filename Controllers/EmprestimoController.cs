using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Data;
using SistemaBiblioteca.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace SistemaBiblioteca.Controllers
{
    [Route("api/[controller]")]
    public class EmprestimoController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public EmprestimoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost("emprestar")]
        public async Task<IActionResult> EmprestarLivro(int livroId, int alunoId)
        {
            var livro = await _appDbContext.BIBLIOTECA.FindAsync(livroId);
            var aluno = await _appDbContext.Alunos.FindAsync(alunoId);

            if (livro == null)
            {
                return NotFound("Livro não encontrado!");
            }

            if (aluno == null)
            {
                return NotFound("Aluno não encontrado. Verifique e tente novamente!");
            }

            var emprestimoExistente = await _appDbContext.Emprestimos
                .AnyAsync(e => e.LivroId == livroId && e.DataDevolucaoRealizada == null);

            if (emprestimoExistente)
            {
                return BadRequest("O livro já está emprestado!");
            }

            var emprestimo = new Emprestimo
            {
                LivroId = livroId,
                AlunoId = alunoId,
                DataEmprestimo = DateTime.Now,
                DataDevolucaoPrevista = DateTime.Now.AddDays(7)
            };

            _appDbContext.Emprestimos.Add(emprestimo);
            await _appDbContext.SaveChangesAsync();

            return Ok(emprestimo);
        }

        [HttpPost("devolver/{id}")]
        public async Task<IActionResult> DevolverLivro(int id)
        {
            var emprestimo = await _appDbContext.Emprestimos.Include(e => e.Livro).Include(e => e.Aluno).FirstOrDefaultAsync(e => e.Id == id);

            if (emprestimo == null)
            {
                return NotFound("Empréstimo não encontrado!");
            }

            if (emprestimo.DataDevolucaoRealizada != null)
            {
                return NotFound("Este livro emprestado já foi devolvido");
            }

            emprestimo.DataDevolucaoRealizada = DateTime.Now;

            await _appDbContext.SaveChangesAsync();

            return Ok(new { Message = "Livro devolvido com sucesso", Emprestimo = emprestimo });
        }

        [HttpGet]

        public async Task<IActionResult> ListarEmprestimos()
        {
            var emprestimos = await _appDbContext.Emprestimos
            .Include(e => e.Aluno)
            .Include(e => e.Livro)
            .ToListAsync();

            return Ok(emprestimos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmprestimo(int id)
        {
            var emprestimo = await _appDbContext.Emprestimos
            .Include(e => e.Aluno)
            .Include(e => e.Livro)
            .FirstOrDefaultAsync(e => e.Id == id);

            if (emprestimo == null)
                return NotFound();

            return Ok(emprestimo);
        }
    }
}