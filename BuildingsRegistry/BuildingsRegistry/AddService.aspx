<%@ Page Title="Añadir servicio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddService.aspx.cs" Inherits="BuildingsRegistry.AddService" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
    </p>
    <p>
        Nombre del servicio
    </p>
    <p>
        <asp:TextBox ID="NameServiceTB" runat="server" Width="277px"></asp:TextBox>
    </p>
    <p>
        Tipo de servicio, seleccionar de la lista</p>
    <p>
        <asp:DropDownList ID="TypeServiceDD" runat="server" Height="25px" Width="163px">
        </asp:DropDownList>
    </p>
    <p>
        Unidad de medida para el pago</p>
    <p>
        <asp:DropDownList ID="UnitDD" runat="server" Height="16px" Width="162px">
        </asp:DropDownList>
    </p>
    <p>
        Empresa que presta el servicio</p>
    <p>
        <asp:TextBox ID="CompanyNameTB" runat="server" Width="334px"></asp:TextBox>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="SaveServiceB" runat="server" Text="Guardar" OnClick="SaveServiceB_Click" />
    </p>
</asp:Content>
