<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="Review.aspx.cs" Inherits="SAM2019.UI.Review" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container margin-top-5">
        <div class="row">
            <div class="col-12 d-flex justify-content-center">
                <h3><label>Review Paper</label></h3>
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <asp:GridView runat="server" ID="gvReview" DataKeyNames="ReviewID" AutoGenerateColumns="false" OnSelectedIndexChanged="gvReview_SelectedIndexChanged"
                    CssClass="table table-striped" HeaderStyle-CssClass="thead-dark">
                    <Columns>
                        <asp:BoundField ItemStyle-Width="10px" DataField="SubmissionID" HeaderText="SubmissionID"/>

                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="cbSelect" AutoPostBack="false"/>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField HeaderText="Title" DataField="Title" />

                        <asp:TemplateField HeaderText="Score">
                            <ItemTemplate>
                                <asp:RadioButtonList runat="server" ID="rdScore" RepeatDirection="Horizontal" CssClass="custom-radio">
                                    <asp:ListItem Value="1" Text="1"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="2"></asp:ListItem>
                                    <asp:ListItem Value="3" Text="3"></asp:ListItem>
                                    <asp:ListItem Value="4" Text="4"></asp:ListItem>
                                    <asp:ListItem Value="5" Text="5"></asp:ListItem>
                                </asp:RadioButtonList>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Upload Review" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <asp:FileUpload runat="server" ID="uploadReview" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:ButtonField ButtonType="Button" Text="Download Paper" CommandName="Select"  ControlStyle-CssClass="btn btn-secondary" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center"/>
                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="row">
            <div class="col-12 d-flex justify-content-center">
                <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click"/>
            </div>
        </div>
    </div>

</asp:Content>
