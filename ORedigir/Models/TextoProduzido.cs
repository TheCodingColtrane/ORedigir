using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ORedigir.Models
{
    public class TextoProduzido
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ID { get; set; }
        [Required]
        [ForeignKey("PropostaTextualID")]
        public int PropostaTextualID { get; set; }
        public PropostaTextual PropostaTextual { get; set; }

        [Required]
        [ForeignKey("UsuarioID")]
        [Column(TypeName = "nvarchar(450)")]
        public string UsuarioID { get; set; }
        public ApplicationUser Usuario { get; set; }

        [Required]
        [Column(TypeName = "varchar(2000)")]
        public string Titulo { get; set; }
        [Required]
        [Column(TypeName = "text")]
        public string Conteudo{ get; set; }
        [Required]
        [Column(TypeName = "varchar(2000)")]
        public string Url { get; set; }
        public decimal? Nota { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DataCadastro { get => DateTime.Now; }
        [Column(TypeName = "Time")]
        public TimeSpan HoraCadastro { get => DateTime.Now.TimeOfDay; }

    }
}
