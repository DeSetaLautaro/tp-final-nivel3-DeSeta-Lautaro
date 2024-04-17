
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using static Dominio.Usuario;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public int InsertarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("insertarNuevo");
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@pass", usuario.Pass);
                datos.setearParametro("@nombre", usuario.NombreUsuario);
                datos.setearParametro("@apellido", usuario.ApellidoUsuario);
                datos.setearParametro("@urlimagen", usuario.Imagen);
                return datos.ejecutarAccionScalar();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }

        public int Loguear(Usuario usuario)

        {
            AccesoDatos accesoDatos = new AccesoDatos();
            try
            {
                accesoDatos.setearConsulta("select Id, admin from USERS where nombre=@User and pass=@Pass");
                accesoDatos.setearParametro("@User", usuario.NombreUsuario);
                accesoDatos.setearParametro("@Pass", usuario.Pass);
                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    usuario.Id = (int)accesoDatos.Lector["Id"];
                    usuario.Admin = (bool)accesoDatos.Lector["admin"];
                    if (usuario.Admin)
                    {
                        usuario.TipoDeUsuario = TipoUsuario.Admin;
                    }
                    else
                    {
                        usuario.TipoDeUsuario = TipoUsuario.Normal;
                        // Manejar el caso en que el valor de la columna sea nulo o no sea un booleano válido.
                    }
                    return usuario.Id;
                }
                return 0;
            }

            catch (Exception)
            {

                throw;
            }
        }
    }
}
