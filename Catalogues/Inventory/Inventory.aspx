<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="Bangboo3T.Catalogues.Inventory.Inventory_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Inventory</h3>
        </div>
        <div class="row">
            <asp:GridView ID="GVInventory" runat="server" CssClass="table table-bordered table-striped table-condensed" AutoGenerateColumns="false" DataKeyNames="ID_Bangboo" OnRowCommand="GVInventory_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ID_Bangboo" HeaderText="#" ItemStyle-Width="20px" ReadOnly="true" />

                    <asp:BoundField DataField="Name" HeaderText="Bangboo" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="Price" HeaderText="Unit Price" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="Quantity" HeaderText="Stock" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="LastRestockDate" HeaderText="Last Restock Date" ItemStyle-Width="85px" />

                    <asp:ImageField HeaderText="Picture" ReadOnly="true" ItemStyle-Width="100px" ControlStyle-Height="120px" ControlStyle-Width="120px" DataImageUrlField="PictureURL"></asp:ImageField>

                    <asp:ButtonField ButtonType="Button" CommandName="Details" HeaderText="" Text="Details" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />

                    <asp:ButtonField ButtonType="Button" CommandName="Restock" HeaderText="" Text="Restock" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
