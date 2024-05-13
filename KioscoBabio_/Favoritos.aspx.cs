
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace KioscoBabio_
{
    public partial class Favoritos : System.Web.UI.Page
    {
        public List<Articulos> ListaFavoritos { get; set; }
        public bool Bandera { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                ArticulosNegocio articulosNegocio = new ArticulosNegocio();
                if (!IsPostBack)

                {
                    if (Session["UserId"] != null)
                    {
                        ListaFavoritos = articulosNegocio.ListarFavoritos((int)Session["UserId"]);
                        Session.Add("ListaDeFavoritos", ListaFavoritos);
                        Repeater2.DataSource = ListaFavoritos;
                        Repeater2.DataBind();
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





        protected void FiltroLista_TextChanged(object sender, EventArgs e)
        {

            try
            {

                List<Articulos> Lista = (List<Articulos>)Session["ListaDeFavoritos"];
                List<Articulos> ListaFiltrada = Lista.FindAll(x => x.Nombre.ToLower().StartsWith(FiltroLista.Text.ToLower()));
                CargarCatalogo(ListaFiltrada);

                if (string.IsNullOrEmpty(FiltroLista.Text))
                {
                    CargarCatalogo(Lista);
                }

                Bandera = true;
            }

            catch (Exception ex)
            {

                Session.Add("Error", Seguridad.ManejarError(ex));
                Response.Redirect("Error.aspx");
            }
        }
        protected void btnRestablecer_Click(object sender, EventArgs e)
        {
            Bandera = false;
            CargarCatalogo((List<Articulos>)Session["ListaDeFavoritos"]);
        }

        public void CargarCatalogo(List<Articulos> Lista)
        {
            Repeater2.DataSource = Lista;
            Repeater2.DataBind();
        }
    }
}
