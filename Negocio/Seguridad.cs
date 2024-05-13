using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Seguridad
    {

        public static bool HaySesionActiva(Usuario user)

        {
            Usuario usuario = user != null ? user : null;
            if (usuario == null || usuario.Id == 0)
            {
                return false;
            }
            else
                return true;
        }

        public static bool EsAdmin(Usuario usuario)
        {
            if (usuario.TipoDeUsuario == Usuario.TipoUsuario.Admin)
                return true;
            else
                return false;
        }

        public static string ManejarError(Exception ex)
        {
            
            return ex.Message;
            
        }
    
    }

}