using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace KioscoBabio_
{
    public partial class AltaArticulo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        {
            AccesoDatos accesoDatos = new AccesoDatos();
            txtId.Enabled = false;

            if (!IsPostBack)
            {
                CategoriaNegocio categoria = new CategoriaNegocio();
                List<Categorias> Lista = categoria.ListarCategorias();

                if (Request.QueryString["id"] != null)
                    btnModificar.Text = "Modificar";
                else
                    btnModificar.Text = "Agregar";

                ddlCategoria.DataSource = Lista;
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataBind();


                MarcasNegocio marcasNegocio = new MarcasNegocio();
                List<Marcas> ListaM = marcasNegocio.ListarMarcas();


                ddlMarcas.DataSource = ListaM;
                ddlMarcas.DataValueField = "Id";
                ddlMarcas.DataTextField = "Descripcion";
                ddlMarcas.DataBind();



            }




            string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
            if (!IsPostBack && id != null && id != "")
            {
                ArticulosNegocio articulosNegocio = new ArticulosNegocio();
                Articulos Seleccionado = articulosNegocio.ListarArticulosPorId(id)[0];

                txtCodigo.Text = Seleccionado.CodigoDeArticulo;
                txtDescripcion.Text = Seleccionado.Descripcion;
                txtNombre.Text = Seleccionado.Nombre;
                txtId.Text = id;
                txtPrecio.Text = Seleccionado.Precio.ToString();
                ddlCategoria.SelectedValue = Seleccionado.Categoria.Id.ToString();
                ddlMarcas.SelectedValue = Seleccionado.Marca.Id.ToString();
                if (!(string.IsNullOrEmpty(Seleccionado.Imagen)))
                {

                    txtImagen.Text = Seleccionado.Imagen;
                    txtImagen_TextChanged(sender, e);
                }


            }
        }

        protected void txtImagen_TextChanged(object sender, EventArgs e)
        {
            if (txtImagen.Text != null)
            {
                ImagenAltaArticulo.ImageUrl = txtImagen.Text;
            }
            else { }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            ArticulosNegocio articulosNeg = new ArticulosNegocio();
            Articulos articulos = new Articulos();



            if (Request.QueryString["id"] != null)
            {

                try
                {

                    articulos.Nombre = txtNombre.Text;
                    articulos.Id = Convert.ToInt32(txtId.Text);
                    articulos.Descripcion = txtDescripcion.Text;
                    articulos.Imagen = txtImagen.Text;
                    articulos.Categoria = new Categorias();
                    articulos.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                    articulos.Marca = new Marcas();
                    articulos.Marca.Id = int.Parse(ddlMarcas.SelectedValue);
                    articulos.Precio = decimal.Parse(txtPrecio.Text);
                    articulos.CodigoDeArticulo = txtCodigo.Text;
                    articulosNeg.Modificar(articulos);


                    Response.Redirect("ListaDeProductos.aspx");

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }
            else
            {


                articulos.Nombre = txtNombre.Text;
                articulos.Descripcion = txtDescripcion.Text;
                articulos.Imagen = txtImagen.Text;
                articulos.Categoria = new Categorias();
                articulos.Categoria.Id = int.Parse(ddlCategoria.SelectedValue);
                articulos.Marca = new Marcas();
                articulos.Marca.Id = int.Parse(ddlMarcas.SelectedValue);
                articulos.Precio = decimal.Parse(txtPrecio.Text);
                articulos.CodigoDeArticulo = txtCodigo.Text;
                articulosNeg.AgregarArticulo(articulos);


                Response.Redirect("ListaDeProductos.aspx");


            }




        }
    }
}