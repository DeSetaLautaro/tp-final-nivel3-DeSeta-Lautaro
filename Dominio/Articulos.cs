using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Dominio
{
    public class Articulos
    {
        public string CodigoDeArticulo { get; set; }

        public string Nombre { get; set; }

        public Marcas Marca { get; set; }

        public Categorias Categoria { get; set; }

        public string Imagen { get; set; }

        public decimal Precio { get; set; }

        public string Descripcion { get; set; }

        public int Id { get; set; }

    }
}