using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ORedigir.Models
{
    public class ApplicationUser: IdentityUser
    {
        [ForeignKey("TurmaID")]
        [Column(Order = 1, TypeName = "int")]
        public int? TurmaID { get; set; }
        public Turma Turma { get; set; }
        [Column(Order = 2, TypeName = "varchar(100)")]
        public string NomeCompleto { get; set; }
        [Column(Order = 3, TypeName = "varchar(100)")]
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        [Column(Order = 7, TypeName = "Date")]
        public DateTime DataCadastro 
        {
            get => DateTime.Now;
        }
        [Column(Order = 8, TypeName = "Time")]
        public TimeSpan HoraCadastro
        {
            get => DateTime.Now.TimeOfDay;
        }

        [NotMapped]
        public int TipoUsuario { get; set; }


    }
}
