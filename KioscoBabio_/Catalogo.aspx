<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="KioscoBabio_.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


 

    <%-- Al apretar el botón de favoritos se cambia el icono de la estrella y además se agrega o quita de la lista de favoritos según corresponda --%>
    <script type="text/javascript">
        const faveados = [<%= string.Join(",", Faveados) %>];
        const faveadosString = JSON.stringify(faveados);
        window.sessionStorage.setItem('faveados', faveadosString);
        
        function toggleFavorite(container, button) {
            var userId = <%= Session["UserId"] %>; // Obtén el ID de usuario desde la             var url
            var faveadosString = window.sessionStorage.getItem('faveados');
            var faveados = JSON.parse(faveadosString); // Convierte la cadena JSON a un array JavaScript
            var pathIcon = button.querySelector('svg path');
            var idArticulo = container.querySelector('#producto').getAttribute('data-id');
            var isFavorite = false;
            var url;
            if (faveados.includes(idArticulo)) {
                isFavorite = true;
            }
            if (isFavorite) {
                url = 'Catalogo.aspx/EliminarDeFavoritos';
                var index = faveados.indexOf(idArticulo);
                while (index !== -1) {
                    faveados.splice(index, 1);
                    index = faveados.indexOf(idArticulo);
                }

               

            }
            else {

                url = 'Catalogo.aspx/AgregarAFavoritos';
                faveados.push(idArticulo);

            }

            window.sessionStorage.setItem('faveados', JSON.stringify(faveados));

            console.log(faveados);
            
            
            // Realiza una solicitud AJAX al servidor
            $.ajax({
                type: "POST",
                url: url,
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify({ Articulo: idArticulo, User: userId }),
                dataType: "json",
                success: function (response) {

                    if (!isFavorite) {

                        pathIcon.setAttribute('d', 'M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z');
                        pathIcon.style.fill = 'yellow';


                    } else {
                        
                        pathIcon.setAttribute('d', 'M2.866 14.85c-.078.444.36.791.746.593l4.39-2.256 4.389 2.256c.386.198.824-.149.746-.592l-.83-4.73 3.522-3.356c.33-.314.16-.888-.282-.95l-4.898-.696L8.465.792a.513.513 0 0 0-.927 0L5.354 5.12l-4.898.696c-.441.062-.612.636-.283.95l3.523 3.356-.83 4.73zm4.905-2.767-3.686 1.894.694-3.957a.56.56 0 0 0-.163-.505L1.71 6.745l4.052-.576a.53.53 0 0 0 .393-.288L8 2.223l1.847 3.658a.53.53 0 0 0 .393.288l4.052.575-2.906 2.77a.56.56 0 0 0-.163.506l.694 3.957-3.686-1.894a.5.5 0 0 0-.461 0z');
                        pathIcon.style.fill = ''; // Elimina el color de relleno para que vuelva al color predeterminado
                        

                    }

                },
                error: function (error) {
                    console.error(error);
                }
            });
            return false

           
        }


    </script>

   



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>


   <script type="text/javascript">
       // Define una función para manejar la carga completa de la ventana
      
       let i = 0;

       function handleWindowLoad() { 
           // Paso 1: Selecciona todos los elementos del Repeater
           const cards = document.querySelectorAll('.card');
           var faveadosString1 = window.sessionStorage.getItem('faveados');
           var faveados = JSON.parse(faveadosString1);

           console.log(faveados);
           i++;
           console.log("entre" + i);

           console.log("chau");
           const cardDataArray = [];
           // Paso 2 y 3: Itera sobre los elementos y guarda los datos en un array
          
           console.log(faveados);
           cards.forEach(card => {
               const cardData = {
                   id: parseInt(card.querySelector('#producto').dataset.id),

               };
               let isFavorite = false;
               const idArticulo = cardData.id; // Convierte el id a cadena

               if (faveados.includes(idArticulo)) { // Utiliza includes para verificar si el id está en la lista
                   isFavorite = true;
               }

               

               //PROBAR PRIMERO LLENANDO EL ARRAY DE LISTA Y DESPUES HACIENDO LA ITERACION.
               const pathIcon = card.querySelector('svg path');

               if (!isFavorite) {
                   pathIcon.setAttribute('d', 'M2.866 14.85c-.078.444.36.791.746.593l4.39-2.256 4.389 2.256c.386.198.824-.149.746-.592l-.83-4.73 3.522-3.356c.33-.314.16-.888-.282-.95l-4.898-.696L8.465.792a.513.513 0 0 0-.927 0L5.354 5.12l-4.898.696c-.441.062-.612.636-.283.95l3.523 3.356-.83 4.73zm4.905-2.767-3.686 1.894.694-3.957a.56.56 0 0 0-.163-.505L1.71 6.745l4.052-.576a.53.53 0 0 0 .393-.288L8 2.223l1.847 3.658a.53.53 0 0 0 .393.288l4.052.575-2.906 2.77a.56.56 0 0 0-.163.506l.694 3.957-3.686-1.894a.5.5 0 0 0-.461 0z');
                   console.log("nosoy");
               } else  {
                   // Si no es favorito, asegúrate de eliminar la clase en caso de que esté presente
                   console.log("soy");
                   pathIcon.setAttribute('d', 'M3.612 15.443c-.386.198-.824-.149-.746-.592l.83-4.73L.173 6.765c-.329-.314-.158-.888.283-.95l4.898-.696L7.538.792c.197-.39.73-.39.927 0l2.184 4.327 4.898.696c.441.062.612.636.282.95l-3.522 3.356.83 4.73c.078.443-.36.79-.746.592L8 13.187l-4.389 2.256z');
                   pathIcon.style.fill = 'yellow';

               }

               // Si es favorito, cambia el color del ícono
               cardDataArray.push(cardData);

               // Ahora, `cardDataArray` contiene todos los datos de los elementos del Repeater
           });

       }

       // Asigna la función handleWindowLoad a window.onload
       window.onload = handleWindowLoad;
       window.onpageshow = handleWindowLoad;
      

     

     


       



   </script>

<div class="container" style="margin-top: 10px">
    <div class="row">
        <div class="col-md-9 col-lg-6">
            <div class="form-group">
                <asp:TextBox runat="server" ID="FiltroLista" CssClass="form-control" OnTextChanged="FiltroLista_TextChanged" placeholder="Filtrar por nombre..." AutoPostBack="true"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-3 col-lg-2 mx-md-auto">
            <div class="form-group">
                <a class="text-decoration-none" id="btnFiltroAvanzado" onclick="toggleFiltroAvanzado()">Filtro Avanzado
                    <svg style="width: 40px" xmlns="http://www.w3.org/2000/svg" width="20" height="20" fill="currentColor" class="bi bi-filter-circle" viewBox="0 0 16 16">
                          <path d="M8 15A7 7 0 1 1 8 1a7 7 0 0 1 0 14m0 1A8 8 0 1 0 8 0a8 8 0 0 0 0 16" />
                          <path d="M7 11.5a.5.5 0 0 1 .5-.5h1a.5.5 0 0 1 0 1h-1a.5.5 0 0 1-.5-.5m-2-3a.5.5 0 0 1 .5-.5h5a.5.5 0 0 1 0 1h-5a.5.5 0 0 1-.5-.5m-2-3a.5.5 0 0 1 .5-.5h9a.5.5 0 0 1 0 1h-9a.5.5 0 0 1-.5-.5" />
                    </svg>
                </a>
            </div>
        </div>
    </div>


    <div class="contenedor">

        <div id="menuDesplegable" class="menu-desplegable d-none">
            <!-- Contenido del menú desplegable -->
            <div class="container">
                <div class="row">
                    <div class="col">
                        <div class="row mb-3">
                            <div class="col">
                                <label class="form-label fw-bold">Categorias</label>
                                <asp:DropDownList ID="ddlCategoriasLista1" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                            <div class="col">
                                <label class="form-label fw-bold">Marcas</label>
                                <asp:DropDownList ID="ddlMarcasLista1" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col">
                                <label class="form-label fw-bold">Nombre</label>
                                <asp:TextBox ID="txtNombreLista1" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col">
                                <label class="form-label fw-bold">Precio</label>
                                <div class="input-group">
                                    <asp:DropDownList ID="ddlPrecio1" runat="server" CssClass="form-select">
                                        <asp:ListItem Text="Mayor a"></asp:ListItem>
                                        <asp:ListItem Text="Igual a"> </asp:ListItem>
                                        <asp:ListItem Text="Menor a"> </asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox ID="PrecioValor1" runat="server" CssClass="form-control"></asp:TextBox>

                                </div>
                                <asp:Button runat="server" Text="Buscar" ID="btnBuscarLista1" OnClick="btnBuscarLista1_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="container" style="margin-top: 30px">


            <div id="GridView" class="col-12 row row-cols-1 row-cols-md-3 g-4">

                <asp:Repeater ID="Repeater1" runat="server">
                    <ItemTemplate>


                        <div id="carta" class="card" style="width: 18rem; margin-right: 6px">
                            <img src="<%#Eval("Imagen") %>" class="card-img-top" alt="..." style="max-width: 100%; height: 200px;">
                            <div class="card-body">
                                <div id="producto" data-id="<%#Eval("Id") %>"></div>
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <h6 class="card-text"><%#Eval("Precio") %></h6>
                                <h9 class="card-text"><%#"Marca: " + Eval("Marca.Descripcion") + " Categoría: " + Eval("Categoria.Descripcion") %></h9>
                                <p class="card-text"><%# Eval("Descripcion") %></p>
                                <asp:LinkButton runat="server" ID="btnFavoritos" Class="favorite" ForeColor="White" BorderColor="White" CommandArgument='<%#Eval("Id") %>' OnClientClick="toggleFavorite(this.parentElement, this); return false;">
                                                            

                                <svg xmlns="http://www.w3.org/2000/svg" color="white" width="20" height="20" viewBox="0 0 16 16">
                                      <path d=""/>
                                </svg>
                    
                           
           
                                   
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" Text="Ver Detalle" ID="btnDetalle" Style="margin-left: 2px; color: white" class="btn btn-primary" CommandArgument='<%#Eval("Id") %>' OnClick="btnDetalle_Click"></asp:LinkButton>
                                



                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>

        </div>
        </div>
    </div>
    
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
</asp:Content>