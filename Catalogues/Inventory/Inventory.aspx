<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Inventory.aspx.cs" Inherits="Bangboo3T.Catalogues.Inventory.Inventory_List" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Inventory</h3>
            <%--Boton de agregar--%>
            <p>
                <asp:Button ID="Insert" runat="server" Text="Resupply Stock" CssClass="btn btn-primary btn-xs" Width="85px" OnClick="Insert_Click" />
            </p>
        </div>
        <div class="row">
            <asp:GridView ID="GVInventory" runat="server" CssClass="table table-bordered table-striped table-condensed" AutoGenerateColumns="false" DataKeyNames="ID_Inventory" OnRowDeleting="GVInventory_RowDeleting" OnRowCommand="GVInventory_RowCommand" OnRowEditing="GVInventory_RowEditing" OnRowCancelingEdit="GVInventory_RowCancelingEdit" OnRowUpdating="GVInventory_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="ID_Inventory" HeaderText="ID_Inventory" ItemStyle-Width="85px" ReadOnly="true" />

                    <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="Model" HeaderText="Model" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="Element" HeaderText="Element" ItemStyle-Width="85px" />

                    <asp:TemplateField HeaderText="Rank" ItemStyle-Width="50px">
                        <ItemTemplate>
                            <div style="width: 100%">
                                <div style="width: 25%; margin: 0 auto;">
                                    <asp:CheckBox ID="checkRank" runat="server" Checked='<%#Eval("Rank")%>' Enabled="false" />
                                </div>
                            </div>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <div style="width: 100%">
                                <div style="width: 25%; margin: 0 auto">
                                    <asp:CheckBox ID="checkEditRank" runat="server" Checked='<%#Eval("Rank")%>' />
                                </div>
                            </div>
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Price" HeaderText="Price" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="PictureURL" HeaderText="PictureURL" ItemStyle-Width="85px" />

                    <asp:ImageField HeaderText="Picture" ReadOnly="true" ItemStyle-Width="120px" ControlStyle-Height="120px" ControlStyle-Width="120px" DataImageUrlField="PictureURL"></asp:ImageField>

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="1" Text="Details" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />

                    <asp:CommandField ButtonType="Button" HeaderText="2" ShowEditButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-warning btn-xs" ItemStyle-Width="50px" />

                    <asp:CommandField ButtonType="Button" HeaderText="2" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
