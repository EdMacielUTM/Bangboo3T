<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BangbooSupplyDetail_Form.aspx.cs" Inherits="Bangboo3T.Catalogues.BangbooSupplyDetails.BangbooSupplyDetail_Form" %>

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
                    <asp:Label ID="lblBangboo" runat="server" Text="">Bangboo</asp:Label>
                    <%--Campo--%>
                    <asp:DropDownList ID="ddlBangboo" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlBangboo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                    <%--Etiquetado--%>
                    <asp:Label ID="lblSupplier" runat="server" Text="">Supplier</asp:Label>
                    <%--Campo--%>
                    <asp:DropDownList ID="ddlSupplier" runat="server" CssClass="form-control"></asp:DropDownList>

                    <%--Etiquetado--%>
                    <asp:Label ID="lblAmount" runat="server" Text="">Supplied Amount</asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control"></asp:TextBox>

                    <%--Etiquetado--%>
                    <asp:Label ID="lblCost" runat="server" Text="">Unit Cost</asp:Label>
                    <%--Campo--%>
                    <asp:TextBox ID="txtCost" runat="server" CssClass="form-control"></asp:TextBox>

                    <br />
                    <br />

                    <asp:Image DescriptionUrl="txtImage" Width="200px" Height="200px" ID="imgBangboo" runat="server" />

                    <br />
                    <br />

                    <asp:Button ID="btnRestock" CssClass="btn btn-primary btn-sm" runat="server" Text="Restock" OnClick="btnRestock_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
