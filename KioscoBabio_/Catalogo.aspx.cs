using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace KioscoBabio_
{
    

    public partial class Catalogo : System.Web.UI.Page
    {
        public List<Articulos> Lista { get; set; }
        public string productId { get; set; }

        public List<Articulos> Listafavs { get; set; }


        public List<int> Faveados { get; set; }

        public bool Faveado { get; set; }


        
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticulosNegocio Negocio = new ArticulosNegocio();
            MarcasNegocio marcasNegocio = new MarcasNegocio();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();

            if (!IsPostBack)
            {



                Lista = Negocio.ListarArticulos();
                Session.Add("ListaCatalogo", Lista);
                Repeater1.DataSource = Session["ListaCatalogo"];
                Repeater1.DataBind();

                ddlCategoriasLista1.DataSource = categoriaNegocio.ListarCategorias();
                ddlCategoriasLista1.DataBind();
                ddlCategoriasLista1.Items.Insert(0, new ListItem("SELECCIONAR", ""));
                ddlCategoriasLista1.AppendDataBoundItems = true;



                ddlMarcasLista1.DataSource = marcasNegocio.ListarMarcas();

                ddlMarcasLista1.DataBind();
                ddlMarcasLista1.Items.Insert(0, new ListItem("SELECCIONAR", ""));
                ddlMarcasLista1.AppendDataBoundItems = true;
                

                
            }
                    Listafavs = Negocio.ListarFavoritos((int)Session["UserId"]);
                    Session.Add("ListaDeFavoritos", Listafavs);
                    Faveados = new List<int>();

                foreach (Articulos articulo in (List<Articulos>) Session["ListaDeFavoritos"] )
                {
                    Faveados.Add(articulo.Id);
                }

        }

      






        [System.Web.Services.WebMethod]
        public static string AgregarAFavoritos(string Articulo, string User)
        {
            
            int IdArticulo = int.Parse(Articulo);
            int UserId = int.Parse(User);
            ArticulosNegocio articulosNegocio = new ArticulosNegocio();
            articulosNegocio.AgrearAFavoritos(IdArticulo, UserId);
            return "Artículo agregado a favoritos con éxito";




        }


        [System.Web.Services.WebMethod]
        public static string EliminarDeFavoritos(string Articulo, string User)
        {

            int IdArticulo = int.Parse(Articulo);
            int UserId = int.Parse(User);
            ArticulosNegocio articulosNegocio = new ArticulosNegocio();
            articulosNegocio.EliminarDeFavoritos(IdArticulo, UserId);
            return "Artículo eliminado de favoritos con éxito";
        }



        protected void btnBuscarLista1_Click(object sender, EventArgs e)
        {
            ArticulosNegocio articulosNegocio = new ArticulosNegocio();
            List<Articulos> ListaFiltrada = articulosNegocio.Filtrar(
                string.IsNullOrEmpty(ddlCategoriasLista1.SelectedValue) ? null : ddlCategoriasLista1.SelectedValue,
                string.IsNullOrEmpty(ddlMarcasLista1.SelectedValue) ? null : ddlMarcasLista1.SelectedValue,
                txtNombreLista1.Text,
                string.IsNullOrEmpty(PrecioValor1.Text) ? null : PrecioValor1.Text,
                string.IsNullOrEmpty(ddlPrecio1.SelectedValue) ? null : ddlPrecio1.SelectedValue
            );
            Repeater1.DataSource = ListaFiltrada;
            Repeater1.DataBind();
        }

        protected void FiltroLista_TextChanged(object sender, EventArgs e)
        {

            List<Articulos> Lista = (List<Articulos>)Session["ListaCatalogo"];
            List<Articulos> ListaFiltrada = Lista.FindAll(x => x.Nombre.ToLower().StartsWith(FiltroLista.Text.ToLower()));
            Repeater1.DataSource = ListaFiltrada;
            Repeater1.DataBind();

        }

        


        protected void btnDetalle_Click(object sender, EventArgs e)
        {
            LinkButton btnDetalle = (LinkButton)sender;
            string id = btnDetalle.CommandArgument;

            Response.Redirect("DetalleArticulo.aspx?id=" + id);
        }
    }


}