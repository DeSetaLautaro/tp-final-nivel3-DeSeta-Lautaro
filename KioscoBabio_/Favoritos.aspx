<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="KioscoBabio_.Favoritos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container" style="margin-top: 50px">

        <div class="col-12 row row-cols-1 row-cols-md-3 g-4">

            <asp:Repeater ID="Repeater2" runat="server">
                <ItemTemplate>


                    <div id="carta" class="card" style="width: 18rem; margin-right: 6px">
                        <img src="<%#Eval("Imagen") %>" class="card-img-top" alt="..." style="max-width: 100%; height: 200px;">
                        <div class="card-body">
                            <h5 class="card-title"><%#Eval("Nombre") %></h5>
                            <h6 class="card-text"><%#Eval("Precio") %></h6>
                            <h9 class="card-text"><%#"Marca: " + Eval("Marca.Descripcion") + " Categoría: " + Eval("Categoria.Descripcion") %></h9>
                            <p class="card-text"><%# Eval("Descripcion") %></p>
                            <asp:Button runat="server" Text="Go somewhere" Style="margin-left: 2px; color: white" class="btn btn-primary"></asp:Button>


                        </div>
                    </div>


                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>
</asp:Content>