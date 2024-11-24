<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BangbooSupplyDetail_List.aspx.cs" Inherits="Bangboo3T.Catalogues.BangbooSupplyDetails.BangbooSupplyDetail_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Supply history</h3>
            <%--Boton de agregar--%>
            <p>
                <asp:Button ID="Insert" runat="server" Text="Supply Stock" CssClass="btn btn-primary btn-xs" Width="128px" OnClick="Insert_Click" />
            </p>
        </div>
        <div class="row">
            <asp:GridView ID="GVDetails" runat="server" CssClass="table table-bordered table-striped table-condensed" AutoGenerateColumns="false" DataKeyNames="ID_Bangboo" OnRowCommand="GVDetails_RowCommand">
                <Columns>
                    <asp:BoundField DataField="ID_Bangboo" HeaderText="#" ItemStyle-Width="20px" ReadOnly="true" />

                    <asp:BoundField DataField="Name" HeaderText="Bangboo" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="Price" HeaderText="Unit Price" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="SupplyAmount" HeaderText="Restock Amount" ItemStyle-Width="85px" />
                                                            
                    <asp:BoundField DataField="SupplyDate" HeaderText="Restock Date" ItemStyle-Width="85px" />

                    <asp:ImageField HeaderText="Picture" ReadOnly="true" ItemStyle-Width="100px" ControlStyle-Height="120px" ControlStyle-Width="120px" DataImageUrlField="PictureURL"></asp:ImageField>

                    <asp:ButtonField ButtonType="Button" CommandName="Restock" HeaderText="" Text="Restock" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
