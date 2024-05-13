using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;
using System.Text;


namespace KioscoBabio_
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (Seguridad.HaySesionActiva((Usuario)Session["Usuario"]))
            {

                NombreDeUsuario.Text = ((Usuario)(Session["Usuario"])).NombreUsuario.ToString();
                NombreDeUsuario.Style["font-size"] = "20px";
                
                if (!(string.IsNullOrEmpty(((Usuario)(Session["Usuario"])).Imagen)))
                    FotoPerfilMenu.ImageUrl = "~/Images/" + (((Usuario)Session["Usuario"])).Imagen;

            }

            //Sin tener sesion activa solo se puede entrar a las páginas de registro y al catálogo.

            if (!(Page is Catalogo || Page is Registro || Page is RegistroMovil || Page is PaginaPrincipal || Page is DetalleArticulo || Page is Error))
            {
                if (!Seguridad.HaySesionActiva((Usuario)Session["Usuario"]))
                {

                    Response.Redirect("Registro.aspx");
                }

           






            }


        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {



            Session.Clear();

            Response.Redirect("Registro.aspx");


        }

     


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }

        protected void usuarioConFoto_Click_Click(object sender, EventArgs e)
        {

            if (MenuDesplegablePerfil.Style["display"] == "block")
            {
                MenuDesplegablePerfil.Style["display"] = "none";
            }
            else
            {
                MenuDesplegablePerfil.Style["display"] = "block";


            }
        
    }
    }
}