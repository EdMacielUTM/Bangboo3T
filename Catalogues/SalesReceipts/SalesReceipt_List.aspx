<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesReceipt_List.aspx.cs" Inherits="Bangboo3T.Catalogues.SalesReceipts.SalesReceipt_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Sales Receipts</h3>
            <%--Boton de agregar--%>
            <p>
                <asp:Button ID="Insert" runat="server" Text="New Sale Receipt" CssClass="btn btn-primary btn-xs" Width="150px" OnClick="Insert_Click" />
            </p>
        </div>
        <div class="row">
            <asp:GridView ID="GVReceipts" runat="server" CssClass="table table-bordered table-striped table-condensed" AutoGenerateColumns="false" DataKeyNames="ID_Sale" OnRowCommand="GVReceipts_RowCommand" OnRowDataBound="GVReceipts_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="ID_Sale" HeaderText="ID_Sale" ItemStyle-Width="85px" ReadOnly="true" />

                    <asp:BoundField DataField="SaleDate" HeaderText="SaleDate" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="Customer_ID" HeaderText="Customer" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="Customer_ID" HeaderText="Employee" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="TotalAmount" HeaderText="Amount" ItemStyle-Width="85px" />

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" Text="Details" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
