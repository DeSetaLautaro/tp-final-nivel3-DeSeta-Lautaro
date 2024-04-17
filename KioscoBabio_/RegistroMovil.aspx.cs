using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KioscoBabio_
{
    public partial class RegistroMovil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
                Session.Add("Usuario", usuario);
                Response.Redirect("PaginaPrincipal.aspx");

                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.NombreUsuario + ".jpg");
                    usuario.Imagen = "perfil-" + usuario.NombreUsuario + ".jpg";
                }


                int id = usuarioNegocio.InsertarUsuario(usuario);
            }
            catch (Exception)
            {

                throw;
            }



        }

    }
}