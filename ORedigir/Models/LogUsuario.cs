using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ORedigir.Models
{
    public class LogUsuario
    {
        [Key]
        [Required]
        public int LogID { get; set; }
        [ForeignKey("UsuarioID")]
        [Column(TypeName ="nvarchar(450)")]
        [Required]
        public string UsuarioID { get; set; }
        [Required]
        public short TipoLog { get; set; }
        [Required]
        public string Mensagem { get; set; }
        [Required]
        public DateTime Criado{ get; set; }
    }
}
