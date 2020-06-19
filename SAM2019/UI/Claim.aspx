<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="Claim.aspx.cs" Inherits="SAM2019.UI.Claim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container margin-top-5">
        <div class="row">
            <div class="col-12 d-flex justify-content-center">
                <h3><label>Choose Paper</label></h3>
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <asp:GridView runat="server" ID="gvPapers" DataKeyNames="SubmissionID" AutoGenerateColumns="false" OnSelectedIndexChanged="gvPapers_SelectedIndexChanged"
                    CssClass="table table-striped" HeaderStyle-CssClass="thead-dark">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="cbSelect" AutoPostBack="false"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Title" DataField="Title" />
                        <asp:ButtonField ButtonType="Button" Text="Download" CommandName="Select" ControlStyle-CssClass="btn btn-secondary" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="row">
            <div class="col-12 d-flex justify-content-center">
                <asp:Button runat="server" ID="btnSelect" Text="Select" CssClass="btn btn-primary" OnClick="btnSelect_Click"/>
            </div>
        </div>
    </div>

    

</asp:Content>
