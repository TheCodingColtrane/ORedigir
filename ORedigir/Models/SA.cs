using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ORedigir.Models
{
    public class SA
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(TypeName = "char(36)")]
        public string PastaNome { get; set; }
   
        [Required]
        [Column(TypeName = "char(36)")]
        public string NomeArquivo { get; set; }
        [Required]
        [Column(TypeName = "varchar(5)")]
        public string Formato { get; set; }
        [Required]
        [Column(TypeName = "int")]
        public long Tamanho { get; set; }
        public DateTime CriadoEm { get => DateTime.Now; }
    }
}
