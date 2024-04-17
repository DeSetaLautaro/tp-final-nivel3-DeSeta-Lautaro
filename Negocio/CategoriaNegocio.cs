using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {

        public List<Categorias> ListarCategorias()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Categorias> Lista = new List<Categorias>();
            datos.setearConsulta("Select Id, Descripcion from CATEGORIAS");
            datos.ejecutarLectura();
            while (datos.Lector.Read())
            {
                Categorias categorias = new Categorias();
                categorias.Id = (int)datos.Lector["Id"];
                categorias.Descripcion = (string)datos.Lector["Descripcion"];

                Lista.Add(categorias);

            }

            return Lista;
        }


    }
}