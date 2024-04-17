
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
    public partial class DetalleArticulo : System.Web.UI.Page
    {

        public string Imagen { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    string id = Request.QueryString["id"];

                    ArticulosNegocio articulosNegocio = new ArticulosNegocio();

                    Articulos Seleccionado = articulosNegocio.ListarArticulosPorId(id)[0];

                    lblMarca.Text = Seleccionado.Marca.Descripcion.ToString();
                    lblCategoria.Text = Seleccionado.Categoria.Descripcion.ToString();
                    lblDescripcion.Text = Seleccionado.Descripcion.ToString();
                    Imagen = Seleccionado.Imagen.ToString();
                    lblTitulo.Text = Seleccionado.Nombre.ToString();
                    DataBind();



                }
            }
            catch (Exception)
            {

                throw;
            }




        }
    }
}