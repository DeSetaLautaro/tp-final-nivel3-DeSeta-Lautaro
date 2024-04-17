<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistroMovil.aspx.cs" Inherits="KioscoBabio_.RegistroMovil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">

        <div class="row">
            <div class="offset-md-3 col-md-6">
                <!-- Agregar la clase offset-md-3 al contenedor del formulario -->
                <h1>Registro</h1>
                <div class="row g-3">
                    <div class="col-12">
                        <label for="inputEmail4" class="form-label">Email</label>
                        <asp:TextBox runat="server" TextMode="Email" class="form-control" ID="txtEmail" />

                    </div>
                    <div class="col-12">
                        <label for="inputPassword4" class="form-label">Contraseña</label>
                        <asp:TextBox runat="server" TextMode="Password" class="form-control" ID="txtPass" />
                    </div>
                    <div class="row" style="margin-top: 4px">
                        <div class="col-6">
                            <label class="form-label">Nombre</label>
                            <asp:TextBox runat="server" class="form-control" ID="txtNombreDeUsuario" TextMode="SingleLine" />
                        </div>
                        <div class="col-6">
                            <label class="form-label">Apellido</label>
                            <asp:TextBox runat="server" class="form-control" ID="txtApellido" TextMode="SingleLine" />
                        </div>
                    </div>
                    <div class="col-12">
                        <label for="inputAddress" class="form-label">Dirección</label>
                        <asp:TextBox runat="server" TextMode="SingleLine" class="form-control" ID="txtDireccion" />
                    </div>

                    <div class="row">
                        <div class="col-6">
                            <label for="inputCity" class="form-label">Localidad</label>
                            <asp:TextBox runat="server" TextMode="SingleLine" class="form-control" ID="txtLocalidad" />
                        </div>
                    </div>

                    <div class="input-group mb-3">
                        <label class="input-group-text" for="txtImagen">Upload</label>
                        <input type="file" class="form-control" runat="server" id="txtImagen">
                    </div>

                    <div class="row">

                        <div class="col-6" style="margin-top: 8px">
                            <asp:Image Width="120" AlternateText="FotoPerfil" class="rounded-circle" ID="imgUsuarioRegistro" src="Images/PerfilSinFoto.jpeg" runat="server" />
                        </div>

                        <div class="col-6">
                            <div class="form-check" style="margin-top: 5px">
                                <input class="form-check-input" type="checkbox" id="gridCheck">
                                <label class="form-check-label" for="gridCheck">
                                    Iniciar Sesión
                                </label>
                            </div>
                            <div style="margin-top: 10px">

                                <asp:Button runat="server" Text="Registrarse" ID="btnRegistrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            </div>
        </div>
    
</asp:Content>