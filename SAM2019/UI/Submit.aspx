<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Master.Master" AutoEventWireup="true" CodeBehind="Submit.aspx.cs" Inherits="SAM2019.UI.Submit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        

        input[type="file"] {
    display: none;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-center">
            <div class="card w-50 d-flex padding-5" style="margin-top: 25px">

                <div class="d-flex justify-content-center">
                    <h3><label>Submit Paper</label></h3>
                </div>
                <div runat="server" id="divAlert">
                    <asp:Label runat="server" ID="lblWarning"/>
                </div>

                <div class="form-group">
                    <label class="btn btn-primary">Upload file...<asp:FileUpload runat="server" ID="filePaper" CssClass="form-control-file"
                        onchange="changeText()"/></label>
                    <label id="lblFileUpload"></label>
                </div>
                <div class="form-group">
                    <label>Paper Title:</label>
                    <asp:TextBox runat="server" ID="txtTitle" CssClass="form-control" placeholder="Enter title..."/>
                    
                </div>

                <div class="d-flex form-check justify-content-center">
                    <asp:Button runat="server" ID="btnSubmit" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click"/>
                </div>
            </div>
        </div>

    <script type="text/javascript">
        function changeText()
        {
            document.getElementById('lblFileUpload').innerText = document.getElementById('<%=filePaper.ClientID %>').value
        }
    </script>

</asp:Content>
