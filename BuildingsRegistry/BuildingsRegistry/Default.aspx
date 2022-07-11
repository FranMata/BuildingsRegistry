<%@ Page Async="true" Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BuildingsRegistry._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
    <p>
        <br />
        AGREGAR O ELIMINAR SERVICIO</p>
    <p>
        Edificio</p>
    <p>
        <asp:DropDownList ID="BuildingDD" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Servicio</p>
    <p>
        <asp:DropDownList ID="ServiceDD" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        Fecha limite de pago</p>
    <p>
        <asp:Calendar ID="ExpirationDateC" runat="server"></asp:Calendar>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:CheckBoxList ID="ActionCB" runat="server">
            <asp:ListItem Value="Add">Agregar</asp:ListItem>
            <asp:ListItem Value="Delete">Eliminar</asp:ListItem>
        </asp:CheckBoxList>
    </p>
    <p>
        <asp:Button ID="SaveB" runat="server" OnClick="SaveB_Click" Text="Guardar" />
    </p>

    
</asp:Content>
