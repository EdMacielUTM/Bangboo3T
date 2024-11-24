<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bangboo_Sale_Form.aspx.cs" Inherits="Bangboo3T.Catalogues.BangbooSales.Bangboo_Sale_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <asp:Label ID="Title_" runat="server" CssClass="modal-title" Text=""></asp:Label>
            <p>
                <asp:Button ID="Return" runat="server" Text="Return to Receipt" CssClass="btn btn-primary btn-xs" Width="170px" OnClick="Return_Click" />
            </p>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <%--Etiquetado--%>
                    <asp:Label ID="lblBangboo" runat="server" Text="">Bangboo</asp:Label>
                    <%--Campo--%>
                    <asp:DropDownList ID="ddlBangboo" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlBangboo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

                    <%--Etiquetado--%>
                    <asp:Label ID="lblQuantity" runat="server" Text="">Quantity</asp:Label>
                    <asp:Label ID="lblMessage" runat="server"/>
                    <%--Campo--%>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number" OnTextChanged="txtQuantity_TextChanged" AutoPostBack="true"></asp:TextBox>

                    <%--Etiquetado--%>
                    <asp:Label ID="lblCost" runat="server" Text="">Unit Cost</asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtCost" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>

                    <%--Etiquetado--%>
                    <asp:Label ID="lblSubtotal" runat="server" Text="">Subtotal</asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtSubtotal" runat="server" CssClass="form-control" TextMode="Number" ReadOnly="true"></asp:TextBox>

                    <br />
                    <br />

                    <asp:Image DescriptionUrl="txtImage" Width="200px" Height="200px" ID="imgBangboo" runat="server" />

                    <br />
                    <br />

                    <asp:Button ID="btnSale" CssClass="btn btn-primary btn-sm" runat="server" Text="Add to Receipt" OnClick="btnSale_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
