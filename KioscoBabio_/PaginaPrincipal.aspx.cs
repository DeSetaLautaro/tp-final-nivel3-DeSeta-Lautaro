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
    public partial class PaginaPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {



        }

        protected void btnVerCatalofo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Catalogo.aspx");
        }
    }
}