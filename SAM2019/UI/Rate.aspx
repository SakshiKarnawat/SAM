<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="Rate.aspx.cs" Inherits="SAM2019.UI.Rate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container margin-top-5">
        <div class="row">
            <div class="col-12 d-flex justify-content-center">
                <h3><label>Rate Papers</label></h3>
            </div>
        </div>

        <div class="row">
            <div class="col-12 d-flex justify-content-center">
                <h4 class="w-50 align-self-end"><label>Choose Paper to Rate: </label></h4>
                <asp:DropDownList runat="server" ID="ddPapers" DataTextField="Title" DataValueField="SubmissionID" CssClass="form-control" OnSelectedIndexChanged="ddPapers_SelectedIndexChanged" AutoPostBack="true" />
            </div>
                
        </div>

        <div class="row">
            <div class="col-12">
                <asp:GridView runat="server" ID="gvReviews" DataKeyNames="ReviewID" AutoGenerateColumns="false" OnSelectedIndexChanged="gvPapers_SelectedIndexChanged"
                    CssClass="table table-striped" HeaderStyle-CssClass="thead-dark">
                    <Columns>
                        
                        <asp:BoundField HeaderText="Reviewer" DataField="Name" />
                        <asp:BoundField HeaderText="Email" DataField="Email" />
                        <asp:BoundField HeaderText="Score" DataField="Score" />
                        <asp:ButtonField ButtonType="Button" Text="Download Paper" CommandName="Select" ControlStyle-CssClass="btn btn-secondary" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="margin-top-5 d-flex justify-content-center">
            <asp:Label runat="server" ID="lblFinalScore" Text="Final Score: "></asp:Label>
            <asp:RadioButtonList runat="server" ID="rdScore" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Text="1"></asp:ListItem>
                <asp:ListItem Value="2" Text="2"></asp:ListItem>
                <asp:ListItem Value="3" Text="3"></asp:ListItem>
                <asp:ListItem Value="4" Text="4"></asp:ListItem>
                <asp:ListItem Value="5" Text="5"></asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div class="row margin-top-5">
            <div class="col-12 d-flex justify-content-center">
                <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click"/>
            </div>
        </div>
    </div>

</asp:Content>
