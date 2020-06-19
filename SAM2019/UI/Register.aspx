<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="SAM2019.UI.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center">
        <div class="card w-50" style="margin-top: 25px">

            <div>
                <h3><label>Register</label></h3>
            </div>
            <div runat="server" id="divAlert">
                <asp:Label runat="server" ID="lblWarning" />
            </div>

            <div class="form-group">
                <label>Enter Email:</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" aria-describedby="emailHelp" TextMode="Email"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Enter Name:</label>
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Enter Password</label>
                <asp:TextBox runat="server" ID="txtPWD" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Confirm Password</label>
                <asp:TextBox runat="server" ID="txtPWDConfirm" CssClass="form-control" TextMode="Password"></asp:TextBox>
            </div>

            <div class="form=group justify-content-center">
                <asp:Button runat="server" ID="btnSubmit" CssClass="btn btn-primary" Text="Register" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </div>

</asp:Content>
