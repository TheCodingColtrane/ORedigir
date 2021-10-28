using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORedigir.Models
{
    public class PesquisasAdministrativas
    {
        public string IDUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public int? TurmaID { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string Name { get; set; }
        public string IdPapel { get; set; }
        public int TipoUsuario { get; set; }
        public string Senha { get; set; }
    }
}
