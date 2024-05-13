
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
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
                accesoDatos.setearConsulta("select Id, admin, UrlImagenPerfil, apellido, nombre, email from USERS where email=@email and pass=@Pass");
                accesoDatos.setearParametro("@email", usuario.Email);
                accesoDatos.setearParametro("@Pass", usuario.Pass);

                accesoDatos.ejecutarLectura();

                while (accesoDatos.Lector.Read())
                {
                    usuario.Id = (int)accesoDatos.Lector["Id"];
                    usuario.Admin = (bool)accesoDatos.Lector["admin"];
                    usuario.ApellidoUsuario = accesoDatos.Lector["apellido"].ToString();
                    usuario.NombreUsuario = accesoDatos.Lector["nombre"].ToString();
                    usuario.Email = accesoDatos.Lector["email"].ToString();
                    object valor = accesoDatos.Lector["urlImagenPerfil"];
                    if (valor != DBNull.Value && !(string.IsNullOrEmpty((string)valor)))
                    {
                        usuario.Imagen = (string)valor;
                    }

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

        public void ModificarDatosPerfil(Usuario usuario)
        {
            
            AccesoDatos accesoDatos = new AccesoDatos();

            try
            {
                
                accesoDatos.setearProcedimiento("ModificarDatosPerfil");
                accesoDatos.setearParametro("@Id", usuario.Id);
                accesoDatos.setearParametro("@Email", usuario.Email);
                accesoDatos.setearParametro("@Nombre", usuario.NombreUsuario);
                accesoDatos.setearParametro("@Apellido", usuario.ApellidoUsuario);
                accesoDatos.setearParametro("@UrlImagenPerfil", (object)usuario.Imagen ?? DBNull.Value);
                accesoDatos.ejecutarAccion();
                
                
            }
            catch (Exception)
            {

                throw;
            }
            finally 
            {
                accesoDatos.cerrarConexion();
            }






        }

        public bool VerificarEmailRepetido(string email)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearProcedimiento("ChekearSiExisteEmail");
            datos.setearParametro("@email",email);
            if(datos.ejecutarAccionScalar() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
