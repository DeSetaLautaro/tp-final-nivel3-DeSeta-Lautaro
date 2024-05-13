<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RegistroMovil.aspx.cs" Inherits="KioscoBabio_.RegistroMovil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <%--SCRIPT DE VALIDACIÓN--%>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            var emailInput = document.getElementById("<%= txtEmail.ClientID %>");
            var nombreInput = document.getElementById("<%= txtNombreDeUsuario.ClientID %>");
            var passInput = document.getElementById("<%=txtPass.ClientID%>");

            emailInput.addEventListener("input", function () {
                validateInput(emailInput, /^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/);
            });

            nombreInput.addEventListener("input", function () {
                validateInput(nombreInput, /^.{7,}$/);
            });

            passInput.addEventListener("input", function () {
                validateInput(passInput, /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$/);
            });

            function validateInput(inputElement, regex) {
                if (regex.test(inputElement.value)) {
                    inputElement.classList.remove("is-invalid");
                    inputElement.classList.add("is-valid");
                } else {
                    inputElement.classList.remove("is-valid");
                    inputElement.classList.add("is-invalid");
                }
            }
        });
    </script>

    <%---------------------------------------------------%>


    <div class="container-fluid" style="background: rgb(182, 207, 225)">


        <div class="row" style="width: 100%">
            <div class="offset-md-3 col-md-6">


                <!-- Agregar la clase offset-md-3 al contenedor del formulario -->
                <h1 style="text-align: center; margin-top: 7px; font-family: fantasy">Registro</h1>
                <div class="row g-3">
                    <div class="col-12">
                        <label for="inputEmail4" class="form-label">Email</label>
                        <asp:TextBox runat="server" TextMode="Email" class="form-control" ID="txtEmail" />
                        <asp:RegularExpressionValidator ID="EmailValidatorRegistro" ControlToValidate="txtEmail" ErrorMessage="Ingese un formato Email" runat="server" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                        <asp:CustomValidator ID="EmailRepetidoValidator" runat="server" ControlToValidate="txtEmail" ErrorMessage="El email ya se encuentra registrado" ValidationGroup="RegistroValidationGroup"></asp:CustomValidator>


                    </div>
                    <div class="col-12">
                        <label for="inputPassword4" class="form-label">Contraseña</label>
                        <asp:TextBox runat="server" TextMode="Password" class="form-control" ID="txtPass" />
                    </div>
                    <asp:RegularExpressionValidator ControlToValidate="txtPass" ErrorMessage="La contraseña debe contener una mayúscula y un número" runat="server" ValidationGroup="RegistroValidationGroup" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"></asp:RegularExpressionValidator>

                    <div class="row" style="margin-top: 4px">
                        <div class="col-6">
                            <label class="form-label">Nombre</label>
                            <asp:TextBox runat="server" class="form-control" ID="txtNombreDeUsuario" TextMode="SingleLine" />
                            <asp:RegularExpressionValidator ControlToValidate="txtNombreDeUsuario" ErrorMessage="Nombre demasiado corto. 6 caracteres mínimo" runat="server" ValidationGroup="RegistroValidationGroup" ValidationExpression="^.{7,}$"></asp:RegularExpressionValidator>

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

                                <asp:Button runat="server" Text="Registrarse" ID="btnRegistrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" ValidationGroup="RegistroValidationGroup" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
