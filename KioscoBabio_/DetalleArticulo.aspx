<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="KioscoBabio_.DetalleArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container d-flex justify-content-center align-items-center vh-100">

        <div class="card" id="CartaDetalle" style="width: 23rem;">
            <h2 style="align-self: center;" runat="server">
                <asp:Literal runat="server" ID="lblTitulo"></asp:Literal>
            </h2>
            <img src="<%#Imagen%>" id="imgDetalle" class="card-img-top" style="max-width: 100%; height:400px">
            <div class="card-body">
                <div class="row">
                    <div class="col 12 col-s-6">
                        <p class="card-text">Marca = <asp:Literal runat="server" ID="lblMarca"></asp:Literal></p>

                    </div>
                    <div class="col 12 col-s-6" style="display:flex; flex-wrap:nowrap">

                        <p style="white-space:nowrap"> Categoria = <asp:Literal runat="server" ID="lblCategoria"></asp:Literal>
                           
                    </div>
                    <div class="row" style="margin-left:-3px">
                        <br>
                        <asp:Literal runat="server" ID="lblDescripcion"></asp:Literal>

                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>