using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ORedigir.Models
{
    public class PropostaTextual
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ID { get; set; }

        [ForeignKey("TurmaID")]
        public int? TurmaID { get; set; }
        public Turma Turma { get; set; }

        [Required]
        [ForeignKey("UsuarioID")]
        [Column(TypeName = "nvarchar(450)")]

        public string UsuarioID { get; set; }
        public ApplicationUser Usuario { get; set; }


        [Required]
        [ForeignKey("RepoID")]
        public int RepoID { get; set; }
        public SA SA { get; set; }


        [Required]
        [Column(TypeName ="varchar(2000)")]
        public string Titulo { get; set; }
        [Required]
        [Column(TypeName = "Text")]
        public string Conteudo { get; set; }
        [Required]
        [Column(TypeName = "varchar(2000)")]
        public string  Url { get; set; }
        [Required]
        public int NotaMaxima { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataFechamento { get; set; }


    }
}
