<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Favoritos.aspx.cs" Inherits="KioscoBabio_.Favoritos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="background-color: azure">

        <div class="container">

            <div class="row" >
                <div class="row" style="background-color:azure">

                    <div class="col-md-12 col-lg-6">
                        <div class="form-group" style="margin-top: 20px">
                            <asp:TextBox runat="server" ID="FiltroLista" CssClass="form-control" OnTextChanged="FiltroLista_TextChanged" placeholder="Filtrar por nombre..." AutoPostBack="true"></asp:TextBox>
                        </div>
                    </div>

                    <div class="col-md-12 col-lg-6">


                        <%if (Bandera)
                            {  %>
                        <asp:Button runat="server" Text="Restablecer" ID="btnRestablecer" OnClick="btnRestablecer_Click" CssClass="btn btn-secondary" />
                        <%} %>
                    </div>


                </div>


                <div class="col-12 row row-cols-1 row-cols-md-3 g-4">

                    <asp:Repeater ID="Repeater2" runat="server">
                        <ItemTemplate>


                            <div id="carta" class="card" style="width: 18rem; margin-right: 6px;">
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
        </div>
    </div>

</asp:Content>
