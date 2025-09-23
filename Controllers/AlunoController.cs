using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Data;
using SistemaBiblioteca.Models;


namespace SistemaBiblioteca.Controllers
{
    [Route("api/[controller]")]
    public class AlunoController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public AlunoController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarAluno([FromBody] Aluno aluno)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _appDbContext.Alunos.Add(aluno);
            await _appDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(ObterPorId), new { id = aluno.Id }, aluno);
        }

        [HttpGet]
        public async Task<IActionResult> ListarAlunos()
        {
            var alunos = await _appDbContext.Alunos.ToListAsync();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var aluno = await _appDbContext.Alunos.FindAsync(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado");

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarAluno(int id, [FromBody] Aluno alunoAtualizado)
        {
            var aluno = await _appDbContext.Alunos.FindAsync(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado");

            aluno.Nome = alunoAtualizado.Nome;
            aluno.Matricula = alunoAtualizado.Matricula;
            aluno.Cpf = alunoAtualizado.Cpf;
            aluno.Telefone = alunoAtualizado.Telefone;

            _appDbContext.Alunos.Update(aluno);
            await _appDbContext.SaveChangesAsync();

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoverAluno(int id)
        {
            var aluno = await _appDbContext.Alunos.FindAsync(id);
            if (aluno == null)
                return NotFound("Aluno não encontrado");

            _appDbContext.Alunos.Remove(aluno);
            await _appDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}