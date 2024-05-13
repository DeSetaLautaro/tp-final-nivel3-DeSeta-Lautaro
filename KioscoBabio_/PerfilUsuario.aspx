<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="PerfilUsuario.aspx.cs" Inherits="KioscoBabio_.PerfilUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


      <%--SCRIPT DE VALIDACIÓN--%>
  <script>
      document.addEventListener("DOMContentLoaded", function () {
          var nombreInput = document.getElementById("<%= txtNombreDeUsuario.ClientID %>");


          nombreInput.addEventListener("input", function () {
              validateInput(nombreInput, /^.{7,}$/);
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

    <div class="container-fluid"; style="background: rgb(182, 207, 225); min-height:90vh; display:flex; align-items:center">

    <div class="row">
            <div class="offset-md-3 col-md-6">
               
                <!-- Agregar la clase offset-md-3 al contenedor del formulario -->
                <h1 style="text-align:center; margin-top:7px; font-family: fantasy">Mi Perfil</h1>
                <div class="row g-3">
                    <div class="col-12">
                        <label for="inputEmail4" class="form-label">Email</label>
                        <asp:TextBox runat="server" TextMode="Email" class="form-control" ID="txtEmail" Enabled="false" />

                    </div>
                    <div class="row" style="margin-top: 4px">
                        <div class="col-6">
                            <label class="form-label">Nombre</label>
                            <asp:TextBox runat="server" class="form-control" ID="txtNombreDeUsuario" TextMode="SingleLine" />
                            <asp:RegularExpressionValidator CssClass="requiredFieldValidatorErrorMessage" ControlToValidate="txtNombreDeUsuario" ErrorMessage="Nombre demasiado corto. 6 caracteres mínimo" runat="server" ValidationGroup="RegistroValidationGroup" ValidationExpression="^.{7,}$"></asp:RegularExpressionValidator>

                        </div>
                        <div class="col-6">
                            <label class="form-label">Apellido</label>
                            <asp:TextBox runat="server" class="form-control" ID="txtApellido" TextMode="SingleLine"/>
                        </div>
                    </div>
                    <div class="row">
                    <div class="col-6 md-12">
                        <label for="inputAddress" class="form-label">Dirección</label>
                        <asp:TextBox runat="server" TextMode="SingleLine" class="form-control" ID="txtDireccion" Enabled="false" />
                    </div>

                        <div class="col-6 md-12">
                            <label for="inputCity" class="form-label">Localidad</label>
                            <asp:TextBox runat="server" TextMode="SingleLine" class="form-control" ID="txtLocalidad" Enabled="false" />
                        </div>
                    </div>

                    <div class="input-group mb-3">
                        <label class="input-group-text" for="txtImagen">Upload</label>
                        <input type="file" class="form-control" runat="server" id="txtImagen">
                    </div>

                    <div class="row">

                        <div class="col-6" style="margin-top: 8px">
                            <asp:Image Width="120" AlternateText="FotoPerfil"  ID="imgUsuarioRegistro" src="Images/PerfilSinFoto.jpeg" runat="server" />
                        </div>

                        <div class="col-6">
                            <div class="form-check" style="margin-top: 5px">
                             
                            </div>
                            <div style="margin-top: 10px">

                                <asp:Button runat="server" Text="Guardar Cambios" ID="btnGuardarCambios" CssClass="btn btn-primary" OnClick="btnGuardarCambios_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                </div>
            </div>
                
    </div> 
</asp:Content>
