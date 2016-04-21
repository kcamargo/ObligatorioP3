<%@ Page Title="Registrarse" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="BienvenidosUyInicial.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Crear un nuevo usuario</h4>
        <asp:ValidationSummary runat="server" CssClass="text-danger" />
        <hr />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Correo electrónico</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="El campo de correo electrónico es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Contraseña</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="El campo de contraseña es obligatorio." />
            </div>
        </div>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Nombre" CssClass="col-md-2 control-label">Nombre</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Nombre"  CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Nombre"
                    CssClass="text-danger" ErrorMessage="El campo de nombre es obligatorio." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Apellido" CssClass="col-md-2 control-label">Apellido</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Apellido"  CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Apellido"
                    CssClass="text-danger" ErrorMessage="El campo de Apellido es obligatorio." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Direccion" CssClass="col-md-2 control-label">Dirección</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Direccion"  CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Direccion"
                    CssClass="text-danger" ErrorMessage="El campo de Dirección es obligatorio." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Telefono" CssClass="col-md-2 control-label">Teléfono</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Telefono"  CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Telefono"
                    CssClass="text-danger" ErrorMessage="El campo de Teléfono es obligatorio." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Foto" CssClass="col-md-2 control-label">Foto</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Foto" type="file" CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Foto"
                    CssClass="text-danger" ErrorMessage="El campo de Foto es obligatorio." />
            </div>
        </div>
         <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="Descripcion" CssClass="col-md-2 control-label">Descripción</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Descripcion"  CssClass="form-control" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="Descripcion"
                    CssClass="text-danger" ErrorMessage="El campo de Descripción es obligatorio." />
            </div>
        </div>

        <asp:Label ID="mensaje" runat="server" ></asp:Label>

        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button runat="server" OnClick="CreateUser_Click" Text="Registrarse" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>
