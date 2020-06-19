<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="SAM2019.UI.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center">
        <div class="card w-75 fl" style="margin-top: 25px">

            <ul class="nav flex-column nav-pills">
                <li class="nav-item">
                    <asp:LinkButton runat="server" ID="linkSubmit" CssClass="nav-link btn btn-primary btn-block margin-top-5" PostBackUrl="~/UI/Submit.aspx" Text="Submit Paper" />
                </li>
                <li class="nav-item">
                    <asp:LinkButton runat="server" ID="linkAssign" CssClass="nav-link btn btn-primary btn-block margin-top-5" PostBackUrl="~/UI/Assign.aspx" Text="Assign papers to PCM" />
                </li>
                <li class="nav-item">
                    <asp:LinkButton runat="server" ID="linkClaim" CssClass="nav-link btn btn-primary btn-block margin-top-5" PostBackUrl="~/UI/Claim.aspx" Text="Select papers of interest" />
                </li>
                <li class="nav-item">
                    <asp:LinkButton runat="server" ID="linkReview" CssClass="nav-link btn btn-primary btn-block margin-top-5" PostBackUrl="~/UI/Review.aspx" Text="Review papers assigned to you" />
                </li>
                <li class="nav-item">
                    <asp:LinkButton runat="server" ID="linkRate" CssClass="nav-link btn btn-primary btn-block margin-top-5" PostBackUrl="~/UI/Rate.aspx" Text="Rate reviewed papers" />
                </li>
            </ul>
        </div>
    </div>
    
</asp:Content>
