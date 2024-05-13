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

            Page.Validate("RegistroValidationGroup");
            if (!Page.IsValid)
                return;


            try
            {
                Usuario usuario = new Usuario();
                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

                usuario.Email = txtEmail.Text;

                if (usuarioNegocio.VerificarEmailRepetido(usuario.Email))
                {
                    EmailRepetidoValidator.IsValid = false;
                    return;
                }







                usuario.NombreUsuario = txtNombreDeUsuario.Text;
                usuario.Pass = txtPass.Text;
                usuario.ApellidoUsuario = txtApellido.Text;

                if (txtImagen.PostedFile.FileName != "")
                {
                    string ruta = Server.MapPath("./Images/");
                    txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.NombreUsuario + ".JPG");
                    usuario.Imagen = "perfil-" + usuario.NombreUsuario + ".JPG";
                }


                int id = usuarioNegocio.InsertarUsuario(usuario);
                Session.Add("Usuario", usuario);
                Session.Add("UserId", id);
                EmailService emailService = new EmailService();
                emailService.armarCorreo(usuario.Email, "Login KioscoBabio", "Bienvenido! Gracias por unirte a KioscoBabio. Ya puedes comenzar a pedir.");
                emailService.enviarEmail();
                Response.Redirect("PaginaPrincipal.aspx");

            }
            catch (Exception)
            {

                throw;
            }



        }

    }
}