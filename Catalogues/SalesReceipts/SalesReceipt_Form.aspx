<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SalesReceipt_Form.aspx.cs" Inherits="Bangboo3T.Catalogues.SalesReceipts.SalesReceipt_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="Title_" runat="server" CssClass="modal-title" Text=""></asp:Label>
            <asp:Label ID="Subtitle_" runat="server" CssClass="modal-title" Text=""></asp:Label>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <%--Etiquetado--%>
                    <asp:Label ID="lblCustomer" runat="server" Text="">Customer</asp:Label>
                    <%--Campo--%>
                    <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="form-control"></asp:DropDownList>
                    <%--Etiquetado--%>
                    <asp:Label ID="lblEmployee" runat="server" Text="">Employee</asp:Label>
                    <%--Campo--%>
                    <asp:DropDownList ID="ddlEmployee" runat="server" CssClass="form-control"></asp:DropDownList>

                    <asp:Button ID="btnReceipt" CssClass="btn btn-primary btn-sm" runat="server" Text="Add Receipt" OnClick="btnReceipt_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
