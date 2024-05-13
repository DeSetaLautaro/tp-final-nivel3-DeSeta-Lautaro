<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="AltaArticulo.aspx.cs" Inherits="KioscoBabio_.AltaArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="row g-3" style="margin-top:10px">
            <div class="col-12 col-md-6">

                <div class="col-12">
                    <label for="inputZip" class="form-label">Id</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="txtId"></asp:TextBox>

                    <label for="inputEmail4" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" class="form-control" ID="txtNombre"></asp:TextBox>


                    <label for="inputPassword4" class="form-label">Codigo</label>
                    <asp:TextBox runat="server" class="form-control" ID="txtCodigo"></asp:TextBox>


                    <label for="inputAddress" class="form-label">Descripción</label>
                    <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" ID="txtDescripcion"></asp:TextBox>
                </div>


                <div class="row" style="margin-top: 10px">
                    <div class="col-12">
                        <div class="row">


                            <div class="col-12 col-md-6 d-flex flex-column align-items-start">
                                <label style="margin: 8px; align-self: center">Categoria</label>
                                <asp:DropDownList runat="server" ID="ddlCategoria" class="btn btn-secondary dropdown-toggle w-100" type="button" data-bs-toggle="dropdown" data-bs-auto-close="outside" aria-expanded="false">
                                </asp:DropDownList>
                                <ul class="dropdown-menu">
                                </ul>
                            </div>
                            <div class="col-12 col-md-6 d-flex flex-column align-items-start">
                                <label style="margin: 8px; align-self: center">Marca</label>
                                <asp:DropDownList runat="server" ID="ddlMarcas" class="btn btn-secondary dropdown-toggle w-100" type="button" data-bs-toggle="dropdown" data-bs-auto-close="outside" aria-expanded="false">
                                </asp:DropDownList>
                                <ul class="dropdown-menu">
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <label>Precio</label>
                        <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control ml-2"></asp:TextBox>
                    </div>
                </div>
                <div class="col-md-2">
                </div>
                <div class="col-12">
                    
                </div>
                <div class="col-12">
                    <asp:Button runat="server" ID="btnModificar" OnClick="btnModificar_Click" type="submit" class="btn btn-primary"></asp:Button>
                </div>

            </div>

            <div class="col-md-6 d-flex justify-content-center">

                <div class="row g-3" style="max-height: 60%; max-width: 60%; margin-top: 10px">
                    <label>Imagen</label>
                    <asp:TextBox OnTextChanged="txtImagen_TextChanged" CssClass="form-control" runat="server" ID="txtImagen"></asp:TextBox>
                    <asp:Image ID="ImagenAltaArticulo" ImageUrl="~/Images/NoHayFoto.jpeg" runat="server" Height="100%" CssClass="mt-2" />
                </div>
            </div>
        </div>
    </div>


</asp:Content>