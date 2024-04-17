using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario

    {
        public Usuario() { }

        public enum TipoUsuario
        {
            Normal = 1,
            Admin = 2
        }

        public string NombreUsuario { get; set; }
        public string Email { get; set; }

        public string ApellidoUsuario { get; set; }
        public int Id { get; set; }

        public string Pass { get; set; }

        public string Direccion { get; set; }

        public bool Admin { get; set; }
        public string Imagen { get; set; }

        public TipoUsuario TipoDeUsuario { get; set; }

        public Usuario(string user, string pass, bool admin)
        {
            NombreUsuario = user;
            Pass = pass;
            TipoDeUsuario = admin ? TipoUsuario.Admin : TipoUsuario.Normal;
        }


    }
}