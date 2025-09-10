using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaBiblioteca.Models
{
    public class Livro
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Título é um campo obrigatório!")]
        public string Titulo { get; set; }
        [Required (ErrorMessage = "Autor é um campo obrigatório")]
        public string Autor { get; set; }

        public string Genero { get; set; }
    }
}