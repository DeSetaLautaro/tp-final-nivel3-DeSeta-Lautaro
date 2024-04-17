
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{

    public class ArticulosNegocio
    {

        public List<Articulos> ListarArticulos()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulos> ListaDeArticulos = new List<Articulos>();

            try
            {

                datos.setearProcedimiento("ListarArticulos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos articulo = new Articulos();
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Precio = Convert.ToDecimal(datos.Lector["Precio"]);
                    if (!(string.IsNullOrEmpty((string)(datos.Lector["ImagenUrl"]))) && (IsUrlValid((string)(datos.Lector["ImagenUrl"]))))
                        articulo.Imagen = (string)datos.Lector["ImagenUrl"];
                    else
                        articulo.Imagen = "/Images/NoHayFoto.JPEG";
                    articulo.CodigoDeArticulo = (string)datos.Lector["Codigo"];
                    articulo.Categoria = new Categorias();
                    articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    articulo.Marca = new Marcas();
                    articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)datos.Lector["Marca"];

                    ListaDeArticulos.Add(articulo);


                }


                return ListaDeArticulos;
            }
            catch (Exception ex)

            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        //Verifica si la Url es valida
        public bool IsUrlValid(string url)
        {
            Uri uriResult;
            return Uri.TryCreate(url, UriKind.Absolute, out uriResult) &&
                   (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("delete from Articulos where Id=@id");
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();


            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public List<Articulos> ListarArticulosPorId(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulos> ListaDeArticulos = new List<Articulos>();

            datos.setearConsulta("select Articulos.Id, Nombre, Codigo, Articulos.Descripcion, MARCAS.Descripcion Marca, CATEGORIAS.Descripcion Categoria , ImagenUrl, ARTICULOS.IdCategoria, ARTICULOS.IdMarca, Precio from ARTICULOS, MARCAS, CATEGORIAS where MARCAS.Id = Articulos.IdMarca AND CATEGORIAS.Id = Articulos.IdCategoria and Articulos.Id=" + id);
            datos.ejecutarLectura();
            try
            {
                while (datos.Lector.Read())
                {
                    Articulos articulo = new Articulos();
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Precio = Convert.ToDecimal(datos.Lector["Precio"]);
                    if (!(string.IsNullOrEmpty((string)(datos.Lector["ImagenUrl"]))) && (IsUrlValid((string)(datos.Lector["ImagenUrl"]))))
                        articulo.Imagen = (string)datos.Lector["ImagenUrl"];
                    else
                        articulo.Imagen = "";
                    articulo.CodigoDeArticulo = (string)datos.Lector["Codigo"];
                    articulo.Categoria = new Categorias();
                    articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    articulo.Marca = new Marcas();
                    articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)datos.Lector["Marca"];

                    ListaDeArticulos.Add(articulo);


                }
                return ListaDeArticulos;


            }
            catch (Exception ex)

            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }



        }


        public void Modificar(Articulos articulos)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("Modificar");
                datos.setearParametro("@Nombre", articulos.Nombre);
                datos.setearParametro("@Codigo", articulos.CodigoDeArticulo);
                datos.setearParametro("@Descripcion", articulos.Descripcion);
                datos.setearParametro("@IdMarca", articulos.Marca.Id);
                datos.setearParametro("@IdCategoria", articulos.Categoria.Id);
                datos.setearParametro("@ImagenUrl", articulos.Imagen);
                datos.setearParametro("@Precio", articulos.Precio);
                datos.setearParametro("@Id", articulos.Id);
                datos.ejecutarAccion();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }




        }

        public void AgregarArticulo(Articulos articulos)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearProcedimiento("AgregarArticulo");
            datos.setearParametro("@Codigo", articulos.CodigoDeArticulo);
            datos.setearParametro("@Nombre", articulos.Nombre);
            datos.setearParametro("@Descripcion", articulos.Descripcion);
            datos.setearParametro("@IdMarca", articulos.Marca.Id);
            datos.setearParametro("@IdCategoria", articulos.Categoria.Id);
            datos.setearParametro("@ImagenUrl", articulos.Imagen);
            datos.setearParametro("@Precio", articulos.Precio);






            datos.ejecutarAccion();
        }


        public List<Articulos> ListarFavoritos(int IdUser)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulos> ListaFavoritos = new List<Articulos>();


            datos.setearProcedimiento("ListarFavoritos");
            datos.setearParametro("@IdUser", IdUser);
            datos.ejecutarLectura();

            try
            {
                while (datos.Lector.Read())
                {
                    Articulos articulos = new Articulos();
                    articulos.Id = (int)datos.Lector["Id"];
                    articulos.Nombre = (string)datos.Lector["Nombre"];
                    articulos.Descripcion = (string)datos.Lector["Descripcion"];
                    articulos.Nombre = (string)datos.Lector["Nombre"];
                    articulos.Imagen = (string)datos.Lector["ImagenUrl"];
                    articulos.Categoria = new Categorias();
                    articulos.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articulos.CodigoDeArticulo = (string)datos.Lector["Codigo"];
                    articulos.Precio = Convert.ToDecimal(datos.Lector["Precio"]);
                    articulos.Marca = new Marcas();
                    articulos.Marca.Id = (int)datos.Lector["IdMarca"];

                    ListaFavoritos.Add(articulos);







                }

                return ListaFavoritos;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }


        public void AgrearAFavoritos(int idArticulo, int IdUser)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearProcedimiento("AgregarAfavoritos");
            datos.setearParametro("@IdUser", IdUser);
            datos.setearParametro("@IdArticulo", idArticulo);
            datos.ejecutarAccion();
            

        }


        public bool EsFavorito(int Id, int IdUser)
        {
            AccesoDatos datos = new AccesoDatos();

            datos.setearProcedimiento("ListarFavoritos");
            datos.setearParametro("@IdUser", IdUser);
            datos.ejecutarLectura();

            while (datos.Lector.Read())
            {
                if ((int)datos.Lector["Id"] == Id)
                {
                    return true;


                }
            }

            return false;

        }

        public void EliminarDeFavoritos(int IdArticulo, int IdUser)
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setearProcedimiento("EliminarDeFavoritos");
            datos.setearParametro("@IdUser", IdUser);
            datos.setearParametro("@IdArticulo", IdArticulo);
            datos.ejecutarAccion();
        }

        public List<Articulos> Filtrar(string categoria, string marca, string nombre, string valorPrecio, string tipoPrecio)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulos> ListaFiltrada = new List<Articulos>();

            try
            {
                string consulta = "SELECT A.Id, Codigo, Nombre, A.Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio, M.Descripcion Marcas, M.Id, C.Descripcion Categorias, C.Id FROM Articulos as A, MARCAS as M, CATEGORIAS AS C WHERE 1 = 1 AND M.Id=IdMarca AND C.Id=IdCategoria"; // Comenzamos con una condición que siempre sea verdadera para poder agregar condiciones adicionales

                // Agregar condiciones según los filtros seleccionados
                if (!string.IsNullOrEmpty(categoria) && categoria != "SELECCIONAR")
                {
                    consulta += " AND C.Descripcion = @Categoria";
                    datos.setearParametro("@Categoria", categoria);
                }
                if (!string.IsNullOrEmpty(marca) && marca != "SELECCIONAR")
                {
                    consulta += " AND M.Descripcion = @Marca";
                    datos.setearParametro("@Marca", marca);
                }
                if (!string.IsNullOrEmpty(nombre))
                {
                    consulta += " AND Nombre LIKE '%' + @Nombre + '%'";
                    datos.setearParametro("@Nombre", nombre);
                }

                if (!string.IsNullOrEmpty(valorPrecio) && !string.IsNullOrEmpty(tipoPrecio))
                {
                    datos.setearParametro("@Precio", valorPrecio);
                    switch (tipoPrecio)
                    {
                        case "Mayor a":
                            consulta += " AND Precio > @Precio";
                            break;
                        case "Igual a":
                            consulta += " AND Precio = @Precio";
                            break;
                        case "Menor a":
                            consulta += " AND Precio < @Precio";
                            break;
                    }
                }
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulos articulo = new Articulos();
                    articulo.Nombre = (string)datos.Lector["Nombre"];
                    articulo.Id = (int)datos.Lector["Id"];
                    articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    articulo.Precio = Convert.ToDecimal(datos.Lector["Precio"]);
                    if (!(string.IsNullOrEmpty((string)(datos.Lector["ImagenUrl"]))) && (IsUrlValid((string)(datos.Lector["ImagenUrl"]))))
                        articulo.Imagen = (string)datos.Lector["ImagenUrl"];
                    else
                        articulo.Imagen = "/Images/NoHayFoto.JPEG";
                    articulo.CodigoDeArticulo = (string)datos.Lector["Codigo"];
                    articulo.Categoria = new Categorias();
                    articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    articulo.Categoria.Descripcion = (string)datos.Lector["Categorias"];
                    articulo.Marca = new Marcas();
                    articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                    articulo.Marca.Descripcion = (string)datos.Lector["Marcas"];

                    ListaFiltrada.Add(articulo);
                }


                return ListaFiltrada;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }

}
