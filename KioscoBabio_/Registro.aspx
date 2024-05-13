<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="KioscoBabio_.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--script que muestra u oculta el boton para ir a la página de registro móvil cuando la pantalla se achica--%>
    <script type="text/javascript">
        function ocultarMostrarBoton() {
            var boton = document.getElementById('<%=BotonRegistro.ClientID %>')
            var ColRegistro = document.getElementById('ColumnaRegistro')
            if (window.innerWidth > 767) {
                boton.style.display = 'none';
                ColRegistro.style.display = 'block';
            } else {
                boton.style.display = 'block';
                ColRegistro.style.display = 'none';
            }
        }

        window.onload = ocultarMostrarBoton; // Llama a la función al cargar la página
        window.onresize = ocultarMostrarBoton; // Llama a la función cuando cambia el tamaño de la pantalla
    </script>
    <%------------------------------------------------------------------------------------------------------------------
        ---------------------------------------------------------------------------------------------------------------%>


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



    <section id="Registro" class="align-items-stretch">
        <div class="container">
            <div class="row d-flex justify-content-center align-items-center">
                <%-- fila que engloba a las dos columnas --%>

                <%-- COLUMNA DE LOGIN. COLUMNA IZQUIERDA--%>
                <div class="col-12 col-md-6" style="margin-top: -60px" id="LoginRow">
                    <h1 style="font-family: fantasy; font-size: 60px; text-align: center">Login</h1>
                    <div>
                        <div class="mb-3">
                            <label for="exampleInputEmail1" class="form-label">Email</label>
                            <asp:TextBox runat="server" class="form-control" ID="txtEmailLogin" aria-describedby="emailHelp" />
                            <asp:RequiredFieldValidator runat="server" ID="ValidatorEmailLogin" ControlToValidate="txtEmailLogin" ErrorMessage="Ingrese un email" ValidationGroup="LoginValidationGroup" CssClass="requiredFieldValidatorErrorMessage"></asp:RequiredFieldValidator>
                            <asp:CustomValidator runat="server" ID="ValidatorEmailLogin1" ControlToValidate="txtEmailLogin" ValidationGroup="LoginValidationGroup" ErrorMessage="Email o Pass incorrectos" CssClass="requiredFieldValidatorErrorMessage"></asp:CustomValidator>
                        </div>
                        <div class="mb-3">
                            <label for="exampleInputPassword1" class="form-label">Contraseña</label>
                            <asp:TextBox runat="server" type="password" class="form-control" ID="txtPassLogin" />
                            <asp:RequiredFieldValidator runat="server" ID="ValidatorPassLogin" ControlToValidate="txtPassLogin" ErrorMessage="Ingrese una contraseña"  ValidationGroup="LoginValidationGroup" CssClass="requiredFieldValidatorErrorMessage"></asp:RequiredFieldValidator>

                        </div>

                        <asp:Button runat="server" Text="Ingresar" ID="botonIngresar" OnClick="botonIngresar_Click" CssClass="btn btn-primary" ValidationGroup="LoginValidationGroup"></asp:Button>
                        <asp:Button runat="server" CausesValidation="true" ID="BotonRegistro" type="submit" Text="Registrarse" OnClick="BotonRegistro_Click" class="btn btn-primary mt-2"></asp:Button>

                    </div>
                </div>


                <%-- COLUMNA DE LA PARTE DE REGISTRO. COLUMNA REGISTRO--%>

                <div id="ColumnaRegistro" class="col-12 col-md-6">

                    <h1 style="font-family: fantasy; font-size: 60px">Registro</h1>
                    <div class="row g-3">
                        <div class="col-12">
                            <label for="inputEmail4" class="form-label">Email</label>
                            <%-- TXT EMAIL--%>
                            <asp:TextBox runat="server" TextMode="Email" class="form-control" ID="txtEmail" />
                            <asp:RegularExpressionValidator ID="EmailValidatorRegistro" ControlToValidate="txtEmail" ErrorMessage="Ingese un formato Email" runat="server" CssClass="requiredFieldValidatorErrorMessage" ValidationExpression="^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"></asp:RegularExpressionValidator>
                            <asp:CustomValidator ID="EmailRepetidoValidator" runat="server" ControlToValidate="txtEmail" ErrorMessage="El email ya se encuentra registrado" CssClass="requiredFieldValidatorErrorMessage" ValidationGroup="RegistroValidationGroup" ></asp:CustomValidator>


                        </div>
                        <div class="col-12">
                            <%-- TXT CONTRASEÑA--%>
                            <label for="inputPassword4" class="form-label">Contraseña</label>
                            <asp:TextBox runat="server" TextMode="Password" class="form-control" ID="txtPass" />
                            <asp:RegularExpressionValidator ControlToValidate="txtPass" CssClass="requiredFieldValidatorErrorMessage" ErrorMessage="La contraseña debe contener una mayúscula, una minúscula y un número" runat="server" ValidationGroup="RegistroValidationGroup" ValidationExpression="^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,}$"></asp:RegularExpressionValidator>
                        </div>
                        <div class="row" style="margin-top: 4px">
                            <div class="col-6">
                                <%-- TXT NOMBRE --%>
                                <label class="form-label">Nombre</label>
                                <asp:TextBox runat="server" class="form-control" ID="txtNombreDeUsuario" TextMode="SingleLine" />
                                <asp:RegularExpressionValidator CssClass="requiredFieldValidatorErrorMessage" ControlToValidate="txtNombreDeUsuario" ErrorMessage="Nombre demasiado corto. 6 caracteres mínimo" runat="server" ValidationGroup="RegistroValidationGroup" ValidationExpression="^.{7,}$"></asp:RegularExpressionValidator>
                            </div>
                            <div class="col-6">
                                <%-- TXT APELLIDO--%>
                                <label class="form-label">Apellido</label>
                                <asp:TextBox runat="server" class="form-control" ID="txtApellido" TextMode="SingleLine" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col md-12">
                                <%-- TXT DIRECCIÓN--%>
                                <label for="inputAddress" class="form-label">Dirección</label>
                                <asp:TextBox runat="server" Enabled="false" TextMode="SingleLine" class="form-control" ID="txtDireccion" />
                            </div>

                            <div class="col md-12">
                                <%-- TXT LOCALIDAD--%>
                                <label for="inputCity" class="form-label">Localidad</label>
                                <asp:TextBox runat="server" Enabled="false" TextMode="SingleLine" class="form-control" ID="txtLocalidad" />
                            </div>
                        </div>

                        <div class="input-group mb-3">
                            <%-- TXT IMAGEN--%>
                            <label class="input-group-text" for="txtImagen">Upload</label>
                            <input type="file" class="form-control" runat="server" id="txtImagen">
                        </div>

                        <div class="row">

                            <div class="col-6" style="margin-top: 8px">
                            <%-- IMAGEN--%>
                                <asp:Image Width="120" AlternateText="FotoPerfil" class="rounded-circle" ID="imgUsuarioRegistro" src="Images/PerfilSinFoto.jpeg" runat="server" />
                            </div>

                            <div class="col-6" style="margin-top: 15px">
                                


                                <%--Boton--%>
                                <asp:Button runat="server" Text="Registrarse" ID="btnRegistrarse" CssClass="btn btn-primary" OnClick="btnRegistrarse_Click" CausesValidation="true" ValidationGroup="RegistroValidationGroup" />


                            </div>
                        </div>
                    </div>


                </div>
            </div>

        </div>
    </section>
</asp:Content>
