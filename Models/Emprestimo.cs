using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SistemaBiblioteca.Models
{
    public class Emprestimo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DataEmprestimo { get; set; }

        [Required]
        public DateTime DataDevolucaoPrevista { get; set; }

        public DateTime? DataDevolucaoRealizada { get; set; }

        public int LivroId { get; set; }
        [ForeignKey("LivroId")]
        public Livro Livro { get; set; }

        public int AlunoId { get; set; }
        [ForeignKey("AlunoId")]
        public Aluno Aluno { get; set; }

        [NotMapped]
        public decimal Multa { get; set; }
    }
}