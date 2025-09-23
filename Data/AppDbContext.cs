using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaBiblioteca.Models;

namespace SistemaBiblioteca.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Livro> BIBLIOTECA { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Emprestimo> Emprestimos { get; set; }
    }

}