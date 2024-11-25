<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Customer_List.aspx.cs" Inherits="Bangboo3T.Catalogues.Customers.Customer_List" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h3>Customer List</h3>
            <%--Boton de agregar--%>
            <p>
                <asp:Button ID="Insert" runat="server" Text="Add Customer" CssClass="btn btn-primary btn-xs" Width="128px" OnClick="Insert_Click" />
            </p>
        </div>
        <div class="row">
            <asp:GridView ID="GVCustomers" runat="server" CssClass="table table-bordered table-striped table-condensed" AutoGenerateColumns="false" DataKeyNames="ID_Customer" OnRowDeleting="GVCustomers_RowDeleting" OnRowCommand="GVCustomers_RowCommand" OnRowDataBound="GVCustomers_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-Width="85px" />

                    <asp:BoundField DataField="Address_ID" HeaderText="Address" ItemStyle-Width="85px" />

                    <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="" Text="Edit" ControlStyle-CssClass="btn btn-primary btn-xs" ItemStyle-Width="50px" />

                    <asp:CommandField ButtonType="Button" HeaderText="" ShowDeleteButton="true" ShowHeader="true" ControlStyle-CssClass="btn btn-danger btn-xs" ItemStyle-Width="50px" />

                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>