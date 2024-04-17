using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class MarcasNegocio
    {

        public List<Marcas> ListarMarcas()
        {
            List<Marcas> Lista = new List<Marcas>();
            AccesoDatos datos = new AccesoDatos();

            datos.setearConsulta("Select Id, Descripcion from MARCAS");
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                Marcas marcas = new Marcas();
                marcas.Id = (int)datos.Lector["Id"];
                marcas.Descripcion = (string)datos.Lector["Descripcion"];

                Lista.Add(marcas);
            }

            return Lista;
        }

    }
}