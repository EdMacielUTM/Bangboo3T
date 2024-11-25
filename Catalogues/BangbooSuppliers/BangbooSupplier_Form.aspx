<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BangbooSupplier_Form.aspx.cs" Inherits="Bangboo3T.Catalogues.BangbooSuppliers.BangbooSupplier_Form" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="Title_" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
            <asp:Label ID="Subtitle_" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
            <p>
                <asp:Button ID="Return" runat="server" Text="Return to Suppliers" CssClass="btn btn-primary btn-xs" Width="170px" OnClick="Return_Click" />
            </p>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <%--Etiquetado--%>
                    <asp:Label ID="lblName" runat="server" Text="">Supplier Name</asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>

                    <%--Etiquetado--%>
                    <asp:Label ID="lblPhoneNumber" runat="server" Text="">Phone Number</asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control"></asp:TextBox>

                    <%--Etiquetado--%>
                    <asp:Label ID="lblEmail" runat="server" Text="">Email</asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>

                    <br />
                    <br />

                    <%--Etiquetado--%>
                    <asp:Label ID="lblStreetNumber" runat="server" Text="">Street & Number</asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtStreetNumber" runat="server" CssClass="form-control"></asp:TextBox>

                    <%--Etiquetado--%>
                    <asp:Label ID="lblCity" runat="server" Text="">City</asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtCity" runat="server" CssClass="form-control"></asp:TextBox>

                    <%--Etiquetado--%>
                    <asp:Label ID="lblState" runat="server" Text="">State</asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtState" runat="server" CssClass="form-control"></asp:TextBox>

                    <%--Etiquetado--%>
                    <asp:Label ID="lblZipCode" runat="server" Text="">Zip Code</asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtZipCode" runat="server" CssClass="form-control"></asp:TextBox>

                    <br />
                    <br />

                    <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>