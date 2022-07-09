<%@ Page Async="true" Title="Añadir edificio" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddBuilding.aspx.cs" Inherits="BuildingsRegistry.AddBuilding" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        &nbsp;</p>
    <p>Nombre del edificio</p>
    <p>
        <asp:TextBox ID="BuildingNameTB" runat="server" Width="296px"></asp:TextBox>
    </p>
    <p>Capacidad (cantidad de personas que puede albergar)</p>
    <p>
        <asp:TextBox ID="CapacityTB" runat="server" type="number"></asp:TextBox>
    </p>
    <p>Fecha de adquisición o fecha de alquiler</p>
<p>
    <asp:Calendar ID="GetDateC" runat="server"></asp:Calendar>
</p>
    <p>Provincia donde se ubica (seleccionar de lista)</p>
<p>
    <asp:DropDownList ID="ProvinceDD" runat="server" OnSelectedIndexChanged="ProvinceDD_SelectedValueChangedAsync" AutoPostBack="true">
    </asp:DropDownList>
    </p>
    <p>Cantón donde se ubica (seleccionar de lista)</p>
<p>
    <asp:DropDownList ID="CantonDD" runat="server" Enabled="False" AutoPostBack="true" OnSelectedIndexChanged="CantonDD_SelectedIndexChanged">
    </asp:DropDownList>
    </p>
    <p>Distrito donde se ubica (seleccionar de lista.)</p>
<p>
    <asp:DropDownList ID="AreaDD" runat="server" Enabled="False">
    </asp:DropDownList>
    </p>
    <p>Es adquirido el edificio o es alquilado.</p>
    <p>
        <asp:DropDownList ID="IsRentDD" runat="server">
        </asp:DropDownList>
    </p>
    <p>
        &nbsp;</p>
    <p>
        <asp:Button ID="SaveBuildingB" runat="server" Text="Guardar" OnClick="SaveBuildingB_ClickAsync" />
    </p>
</asp:Content>
