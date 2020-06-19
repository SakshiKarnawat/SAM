<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="Assign.aspx.cs" Inherits="SAM2019.UI.Assign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container margin-top-5">
        <div class="row">
            <div class="col-12 d-flex justify-content-center">
                <h3><label>Assign Paper</label></h3>
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <asp:GridView runat="server" ID="gvPapers" DataKeyNames="SubmissionID" AutoGenerateColumns="false" OnSelectedIndexChanged="gvPapers_SelectedIndexChanged"
                    CssClass="table table-striped" HeaderStyle-CssClass="thead-dark">
                    <Columns>
                        <asp:TemplateField ItemStyle-Width="10px" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                    <asp:CheckBox runat="server" ID="cbSelect" AutoPostBack="false" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Title" DataField="Title" ItemStyle-VerticalAlign="Middle"/>

                        <asp:TemplateField HeaderText="Reviewer 1">
                            <ItemTemplate>
                                <asp:DropDownList runat="server" ID="ddAssign1" DataTextField="Name" DataValueField="UserID" CssClass="form-control"/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reviewer 2">
                            <ItemTemplate>
                                <asp:DropDownList runat="server" ID="ddAssign2" DataTextField="Name" DataValueField="UserID" CssClass="form-control"/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Reviewer 3">
                            <ItemTemplate>
                                <asp:DropDownList runat="server" ID="ddAssign3" DataTextField="Name" DataValueField="UserID" CssClass="form-control" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:ButtonField ButtonType="Button" Text="Download" CommandName="Select" ControlStyle-CssClass="btn btn-secondary"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="row">
            <div class="col-12 d-flex justify-content-center">
                <asp:Button runat="server" ID="btnSelect" Text="Submit" CssClass="btn btn-primary" OnClick="btnSelect_Click"/>
            </div>
        </div>
    </div>

</asp:Content>
