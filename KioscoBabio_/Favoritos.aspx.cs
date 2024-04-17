
using System;
using System.Collections.Generic;
using System.Linq;
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
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)

            {

                ArticulosNegocio articulosNegocio = new ArticulosNegocio();

                try
                {

                    ListaFavoritos = articulosNegocio.ListarFavoritos((int)Session["UserId"]);
                    Repeater2.DataSource = ListaFavoritos;
                    Repeater2.DataBind();

                }
                catch (Exception ex)
                {

                    throw ex;
                }

            }


        }
    }
}