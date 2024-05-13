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
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            try
            {

                if (Negocio.Seguridad.HaySesionActiva((Usuario)Session["Usuario"]))
                {

                    Response.Redirect("PaginaPrincipal.aspx");

                }
            }
            catch (Exception ex)
            {

                Session.Add("Error", Seguridad.ManejarError(ex));
                Response.Redirect("Error.aspx");

            }





        }

        // cuando la pantalla se achica aparece este botón que te redirije a la página de RegistroMovil.
        protected void BotonRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegistroMovil.aspx");

        }







        protected void botonIngresar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = new Usuario();
            try
            {
                usuario.Email = txtEmailLogin.Text;
                usuario.Pass = txtPassLogin.Text;
                int UserId = usuarioNegocio.Loguear(usuario);
                if (UserId > 0)
                {
                    Session.Add("Usuario", usuario);
                    Session.Add("UserId", usuario.Id);
                    Response.Redirect("PaginaPrincipal.aspx", false);
                }
                else
                {
                    ValidatorEmailLogin1.IsValid = false;
                    txtEmailLogin.CssClass = "form-control is-invalid";
                    txtPassLogin.CssClass = "form-control is-invalid";
                }

            }
            catch (Exception ex)
            {

                Session.Add("Error", Seguridad.ManejarError(ex));
                Response.Redirect("Error.aspx");

            }

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            
            try
            {
           
                Page.Validate("RegistroValidationGroup");
            if (!Page.IsValid)
                return;
             

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
                Response.Redirect("PaginaPrincipal.aspx", false);

            }
            catch (Exception ex)
            {
                Session.Add("Error", Seguridad.ManejarError(ex));
                Response.Redirect("Error.aspx");
            }



        }
      



    }






}