<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bangboo_Sale_List.aspx.cs" Inherits="Bangboo3T.Catalogues.BangbooSales.BangbooSale_Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Sale Details</h3>
            <%--Boton de agregar--%>
            <p>
                <asp:Button ID="Return" runat="server" Text="Return to Receipts" CssClass="btn btn-primary btn-xs" Width="170px" OnClick="Return_Click" />  
                <asp:Button ID="Insert" runat="server" Text="New Sale Item" CssClass="btn btn-primary btn-xs" Width="150px" OnClick="Insert_Click" />
            </p>
        </div>
        <div class="row">
            <asp:GridView ID="GVSales" runat="server" CssClass="table table-bordered table-striped table-condensed" AutoGenerateColumns="false" DataKeyNames="ID_BangbooSales" OnRowDataBound="GVSales_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ID_BangbooSales" HeaderText="Item ID" ItemStyle-Width="85px" ReadOnly="true" />

                    <asp:BoundField DataField="Bangboo_ID" HeaderText="Bangboo" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-Width="85px" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
