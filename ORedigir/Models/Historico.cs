using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ORedigir.Models
{
    public class Historico
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [ForeignKey("UsuarioID")]
        [Column(TypeName = "nvarchar(450)")]
        [Required]
        public string UsuarioID { get; set; }
        public ApplicationUser Usuario { get; set; }
        [Required]
        public byte Tipo { get; set; }
        [Column(TypeName = "varchar(500)")]
        [Required]
        public string Mensagem { get; set; }
        [Required]
        public DateTime AtualizadoEm { get => DateTime.Now; }
    }
}

