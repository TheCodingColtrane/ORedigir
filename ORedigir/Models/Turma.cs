using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ORedigir.Models
{
    public class Turma
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Criador")]
        [Required]
        [Column(TypeName = "nvarchar(450)")]
        public string Professor { get; set; }
        public ApplicationUser Usuario { get; set; }

        [Required]
        [Column(TypeName = "varchar(6)")]
        public string TurmaNome { get; set; }
        [Required]
        public byte Turno { get; set; }
        [Required]
        public byte Numero { get; set; }
        
    }
}
    