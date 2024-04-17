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
    public partial class ListaDeProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            MarcasNegocio marcasNegocio = new MarcasNegocio();
            ArticulosNegocio negocio = new ArticulosNegocio();
            List<Articulos> Lista;
            try
            {

                if (!IsPostBack)
                {
                    Lista = negocio.ListarArticulos();
                    Session.Add("ListaDeArticulos", Lista);
                    dgvArticulos.DataSource = Session["ListaDeArticulos"];
                    dgvArticulos.DataBind();

                    ddlCategoriasLista.DataSource = categoriaNegocio.ListarCategorias();
                    ddlCategoriasLista.DataBind();
                    ddlCategoriasLista.Items.Insert(0, new ListItem("SELECCIONAR", ""));
                    ddlCategoriasLista.AppendDataBoundItems = true;



                    ddlMarcasLista.DataSource = marcasNegocio.ListarMarcas();

                    ddlMarcasLista.DataBind();
                    ddlMarcasLista.Items.Insert(0, new ListItem("SELECCIONAR", ""));
                    ddlMarcasLista.AppendDataBoundItems = true;

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        protected void dgvArticulos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            dgvArticulos.PageIndex = e.NewPageIndex;
            dgvArticulos.DataBind();

        }

        protected void lnkEliminar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio negocio = new ArticulosNegocio();

            try
            {

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }



        protected void dgvArticulos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                // Aquí ejecutas el código para eliminar la fila según el comando "Eliminar"

            }
            else if (e.CommandName == "Modificar")

            {
                // Aquí ejecutas el código para modificar la fila según el comando "Modificar"

                // Obtiene el ID de la fila seleccionada

            }
        }

        protected void lnkModificar_Click(object sender, EventArgs e)
        {
            // Obtener el botón que desencadenó el evento
            LinkButton lnkModificar = (LinkButton)sender;

            // Obtener el índice de la fila que contiene el botón
            GridViewRow row = (GridViewRow)lnkModificar.NamingContainer;
            int rowIndex = row.RowIndex;

            // Obtener el ID del artículo utilizando los DataKeys del GridView
            string id = dgvArticulos.DataKeys[rowIndex].Value.ToString();

            // Redirigir a la página de modificación con el ID del artículo como parámetro
            Response.Redirect("AltaArticulo.aspx?id=" + id);
        }

        protected void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            Response.Redirect("AltaArticulo.aspx");
        }

        protected void FiltroLista_TextChanged(object sender, EventArgs e)
        {

            List<Articulos> Lista = (List<Articulos>)Session["ListaDeArticulos"];
            List<Articulos> ListaFiltrada = Lista.FindAll(x => x.Nombre.ToLower().StartsWith(FiltroLista.Text.ToLower()));
            dgvArticulos.DataSource = ListaFiltrada;
            dgvArticulos.DataBind();

        }

        protected void btnBuscarLista_Click(object sender, EventArgs e)
        {
            ArticulosNegocio articulosNegocio = new ArticulosNegocio();
            List<Articulos> ListaFiltrada = articulosNegocio.Filtrar(
                string.IsNullOrEmpty(ddlCategoriasLista.SelectedValue) ? null : ddlCategoriasLista.SelectedValue,
                string.IsNullOrEmpty(ddlMarcasLista.SelectedValue) ? null : ddlMarcasLista.SelectedValue,
                txtNombreLista.Text,
                string.IsNullOrEmpty(PrecioValor.Text) ? null : PrecioValor.Text,
                string.IsNullOrEmpty(ddlPrecio.SelectedValue) ? null : ddlPrecio.SelectedValue
            );
            dgvArticulos.DataSource = ListaFiltrada;
            dgvArticulos.DataBind();
        }
    }
}