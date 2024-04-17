using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;


namespace KioscoBabio_ 
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            
            //Sin tener sesion activa solo se puede entrar a las páginas de registro y al catálogo.
            
            if (!(Page is Catalogo || Page is Registro || Page is RegistroMovil || Page is PaginaPrincipal || Page is ListaDeProductos))
            {
                if (!Seguridad.HaySesionActiva((Usuario)Session["Usuario"]))
                {

                    Response.Redirect("Registro.aspx");
                }
                else
                {
                  FotoPerfilMenu.ImageUrl = ((Usuario)Session["Usuario"]).Imagen;
                    
                    
                    
                }

            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {



            Session.Clear();

            Response.Redirect("Registro.aspx");


        }
    }
}