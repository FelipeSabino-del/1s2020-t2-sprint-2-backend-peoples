using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Email obrigatório!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatório!")]
        public string Senha { get; set; }

        public TipoUsuarioDomain IdTipoUsuario { get; set; }
    }
}
