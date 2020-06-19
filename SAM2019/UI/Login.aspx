<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SAM2019.UI.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center">
        <div class="card w-50 fl padding-5" style="margin-top: 25px">
            <div class="form-group">
                <label for="exampleInputEmail1">Email address</label>
                <asp:TextBox runat="server" ID="txtUsername" CssClass="form-control" aria-describedby="emailHelp" TextMode="Email"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="exampleInputPassword1">Password</label>
                <asp:TextBox runat="server" ID="txtPWD" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>

            <div class="form=group d-flex justify-content-center">
                <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary" Text="Submit" OnClick="btnSubmit_Click" style="margin-right:5px;"/>
                <asp:LinkButton runat="server" CssClass="btn btn-secondary" Text="Register" PostBackUrl="~/UI/Register.aspx" style="margin-left:5px;"/>
            </div>
        </div>
    </div>

</asp:Content>
