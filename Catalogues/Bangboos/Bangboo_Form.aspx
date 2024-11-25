<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Bangboo_Form.aspx.cs" Inherits="Bangboo3T.Catalogues.Bangboos.Bangboo_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
    <div class="row">
        <asp:Label ID="Title_" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
        <asp:Label ID="Subtitle_" runat="server" CssClass="text-center modal-title" Text=""></asp:Label>
            <p>
                <asp:Button ID="Return" runat="server" Text="Return to Bangboos" CssClass="btn btn-primary btn-xs" Width="170px" OnClick="Return_Click" />
            </p>
    </div>
    <div class="row">
        <div class="col-md-12">
            <div class="form-group">
                <%--Etiquetado--%>
                <asp:Label ID="lblName" runat="server" Text="">Name</asp:Label>
                <%--Campo--%>
                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>

                <%--Etiquetado--%>
                <asp:Label ID="lblModel" runat="server" Text="">Model</asp:Label>
                <%--Campo--%>
                <asp:TextBox ID="txtModel" runat="server" CssClass="form-control"></asp:TextBox>

                <%--Etiquetado--%>
                <asp:Label ID="lblElement" runat="server" Text="">Element</asp:Label>
                <%--Campo--%>
                <asp:TextBox ID="txtElement" runat="server" CssClass="form-control"></asp:TextBox>

                <%--Etiquetado--%>
                <asp:Label ID="lblPrice" runat="server" Text="">Price</asp:Label>
                <%--Campo--%>
                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>

                <br />
                <br />
                <%--Etiquetado--%>
                <asp:Label ID="lblRank" runat="server" Text="">Rank</asp:Label>
                <br />
                <%--Campo--%>
                <asp:CheckBox ID="checkRank" runat="server"></asp:CheckBox>

                <br />
                <br />

                <asp:Label ID="lblPicture" runat="server" Text="">Picture</asp:Label>
                <input type="file" id="pictureUpload" runat="server" class="btn btn-group" />
                <asp:Button ID="btnPictureUpload" runat="server" CssClass="btn btn-primary" Text="Upload Picture" OnClick="btnPictureUpload_Click1" />

                <asp:Label ID="lblPictureURL" runat="server" Text="">Picture</asp:Label>
                <asp:Image ID="imgPicture" Width="100" Height="100" runat="server"/>
                <asp:Image ID="imgBangboo" Width="100" Height="100" runat="server"/>
                <asp:Label ID="pictureURL" runat="server"></asp:Label>

                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
            </div>
        </div>
    </div>
</div>
</asp:Content>
