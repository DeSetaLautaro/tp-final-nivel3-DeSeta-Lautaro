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
    public partial class PerfilUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Usuario usuario = (Usuario)Session["Usuario"];


            try
            {
                if (!IsPostBack)
                {
                    if (usuario != null)
                    {
                        txtApellido.Text = usuario.ApellidoUsuario;
                        txtEmail.Text = usuario.Email;
                        txtNombreDeUsuario.Text = usuario.NombreUsuario;
                        if (!string.IsNullOrEmpty(usuario.Imagen))
                            imgUsuarioRegistro.ImageUrl = "~/Images/" + usuario.Imagen;

                    }
                    else
                    {
                        Session.Add("Error", "No hay usuario en sesión");
                        Response.Redirect("Error.aspx");

                    }
                }
            }
            catch (System.Threading.ThreadAbortException) { }

            catch (Exception ex)
            {

                Session.Add("Error", Seguridad.ManejarError(ex));
                Response.Redirect("Error.aspx");
            }

        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuario = (Usuario)Session["Usuario"];
            try
            {
                Page.Validate();
                if (!Page.IsValid)
                    return;

                if (usuario != null)
                {
                    usuario.NombreUsuario = txtNombreDeUsuario.Text;
                    usuario.ApellidoUsuario = txtApellido.Text;
                    usuario.Email = txtEmail.Text;
                    usuario.Id = int.Parse(Session["UserId"].ToString());
                    if (txtImagen.PostedFile.FileName != "")
                    {
                        string ruta = Server.MapPath("./Images/");
                        txtImagen.PostedFile.SaveAs(ruta + "perfil-" + usuario.NombreUsuario + ".JPG");
                        usuario.Imagen = "perfil-" + usuario.NombreUsuario + ".JPG";
                    }
                    else
                    {
                        usuario.Imagen = "";
                    }


                    usuarioNegocio.ModificarDatosPerfil(usuario);

                }
                else
                {
                    Session.Add("Error", "No hay usuario en sesión");
                    Response.Redirect("Error.aspx");
                }
            }
            catch (System.Threading.ThreadAbortException) { }

            catch (Exception ex)
            {


                Session.Add("Error", Seguridad.ManejarError(ex));
                Response.Redirect("Error.aspx");
            }


        }
    }
}