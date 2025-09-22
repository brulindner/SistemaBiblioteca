using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SistemaBiblioteca.Models
{
    public class Aluno
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do Aluno é um campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Matrícula é um campo obrigatório!")]
        public string Matricula { get; set; }
    }
}