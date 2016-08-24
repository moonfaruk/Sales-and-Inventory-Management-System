<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddLoanParty.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddLoanParty" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
    <div class="customize">
        <div class="panel panel-success">
            <div class="panel-heading">
                <div class="panel-title">Loan Party Entry Form</div>
            </div>
            <div class="panel-body">
                <strong runat="server" id="message"></strong>

                <form runat="server">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Loan Code" Class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="loanCodeTextBox" runat="server" Class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Loan Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="loanNameTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Remarks" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <%--<asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox><br />--%>
                            <textarea id="remarksTextArea" cols="20" rows="3" runat="server" class="form-control"></textarea><br />

                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="saveButton" runat="server" Text="Save" class="btn btn-default" OnClick="saveButton_Click" />
                                <asp:Button ID="clearButton" runat="server" Text="Clear" class="btn btn-default" OnClick="clearButton_Click" />
                                <asp:Button ID="exitButton" runat="server" Text="Exit" class="btn btn-default" OnClick="exitButton_Click" />

                            </div>
                        </div>
                    </div>
                </form>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="rightContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="backgroundImageContentPlaceHolder" runat="server">
</asp:Content>
