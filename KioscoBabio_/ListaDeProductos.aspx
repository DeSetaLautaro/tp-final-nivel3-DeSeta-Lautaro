<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="ListaDeProductos.aspx.cs" Inherits="KioscoBabio_.ListaDeProductos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
   <asp:UpdatePanel runat="server">
       <ContentTemplate>
                   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

<div class="container" style="margin-top: 20px">


    <div class="row">
        <div class="col-12 col-md-9 col-lg-6">
            <div class="form-group">
                <asp:TextBox runat="server" ID="FiltroLista" CssClass="form-control" OnTextChanged="FiltroLista_TextChanged" placeholder="Filtrar por nombre..."></asp:TextBox>
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
                        <asp:DropDownList ID="ddlCategoriasLista" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                    <div class="col">
                        <label class="form-label fw-bold">Marcas</label>
                        <asp:DropDownList ID="ddlMarcasLista" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row mb-3">
                    <div class="col">
                        <label class="form-label fw-bold">Nombre</label>
                        <asp:TextBox ID="txtNombreLista" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <div class="col">
                        <label class="form-label fw-bold">Precio</label>
                        <div class="input-group">
                            <asp:DropDownList ID="ddlPrecio" runat="server" CssClass="form-select">
                                <asp:ListItem Text="Mayor a"></asp:ListItem>
                                <asp:ListItem Text="Igual a"> </asp:ListItem>
                                <asp:ListItem Text="Menor a"> </asp:ListItem>
                            </asp:DropDownList>
                            <asp:TextBox ID="PrecioValor" runat="server" CssClass="form-control"></asp:TextBox>

                        </div>
                        <asp:Button runat="server" Text="Buscar" ID="btnBuscarLista" OnClick="btnBuscarLista_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>



        <div class="row" id="GridView">
            <asp:UpdatePanel runat="server" ID="UpdPanelGridView">
                <ContentTemplate>

            <asp:GridView runat="server" ID="dgvArticulos" AutoGenerateColumns="false" CssClass="table" DataKeyNames="Id" OnPageIndexChanging="dgvArticulos_PageIndexChanging" AllowPaging="true" PageSize="4">
                <Columns>

                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Marca" DataField="Marca.Descripcion" />
                    <asp:BoundField HeaderText="Categoria" DataField="Categoria.Descripcion" />
                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" />
                    <asp:BoundField HeaderText="Codigo" DataField="CodigoDeArticulo" />
                    <asp:BoundField HeaderText="Precio" DataField="Precio" />
                    <asp:TemplateField HeaderText="Acción">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkModificar" OnClick="lnkModificar_Click" runat="server" CommandName="Modificar" Text="Modificar" />
                            <asp:LinkButton ID="lnkEliminar" runat="server" CommandName="Eliminar" Text="Eliminar" OnClientClick="return confirm('¿Estás seguro de eliminar este registro?');" OnClick="lnkEliminar_Click" />
                        </ItemTemplate>
                    </asp:TemplateField>


                </Columns>

            </asp:GridView>

                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:Button runat="server" Text="Agregar Articulo" ID="btnAgregarArticulo" OnClick="btnAgregarArticulo_Click" />

        </div>
    </div>
    </div>
       </ContentTemplate>
   </asp:UpdatePanel>
</asp:Content>