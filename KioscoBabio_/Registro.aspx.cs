using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace KioscoBabio_
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // cuando la pantalla se achica aparece este botón que te redirije a la página de RegistroMovil.
        protected void BotonRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroMovil.aspx");
        }







        protected void botonIngresar_Click(object sender, EventArgs e)
        {
            AccesoDatos datos = new AccesoDatos();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();
            try
            {
                usuario.NombreUsuario = txtNombreUsuarioLogin.Text;
                usuario.Pass = txtContraseñaLogin.Text;
                int UserId = usuarioNegocio.Loguear(usuario);
                if (UserId > 0)
                {
                    Session.Add("Usuario", usuario);
                    Session.Add("UserId", usuario.Id);
                    Response.Redirect("PaginaPrincipal.aspx");
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {

            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                usuario.NombreUsuario = txtNombreDeUsuario.Text;
                usuario.Pass = txtPass.Text;
                usuario.Email = txtEmail.Text;
                usuario.ApellidoUsuario = txtApellido.Text;

                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.NombreUsuario + ".jpg");
                    usuario.Imagen = "perfil-" + usuario.NombreUsuario + ".jpg";
                }


                int id = usuarioNegocio.InsertarUsuario(usuario);
                Session.Add("Usuario", usuario);
                Session.Add("UserId", id);
                Response.Redirect("PaginaPrincipal.aspx");

            }
            catch (Exception)
            {

                throw;
            }



        }

    }






}