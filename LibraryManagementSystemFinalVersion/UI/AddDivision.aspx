﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddDivision.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddDivision" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">

    <div class="customize">
        <div class="panel panel-success">
            <div class="panel-heading">
                <div class="panel-title">Division Entry Form</div>
            </div>
            <p runat="server" class="text-center-error" id="message"></p>
            <p runat="server" class="text-center-save" id="messageLabel"></p>
            <div class="panel-body">


                <form runat="server">
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Division Code" Class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="divisionCodeTextBox" runat="server" Class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <%-- <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Date" Class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:da ID="TextBox1" runat="server" Class="form-control"></asp:da><br />
                            <input runat="server" type="date"/>
                        </div>
                    </div>--%>

                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Division Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="divisionNameTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="saveButton" runat="server" Text="Save" class="btn btn-default" OnClick="saveButton_Click" />
                                <asp:Button ID="cancelButton" runat="server" Text="Cancel" class="btn btn-default" OnClick="cancelButton_Click" />
                                <asp:Button ID="exitButton" runat="server" Text="Exit" class="btn btn-default" OnClick="exitButton_Click" />
                                <asp:Button ID="firstButton" runat="server" Text="First" class="btn btn-default" OnClick="firstButton_Click1" />
                                <asp:Button ID="nextButton" runat="server" Text="Next" class="btn btn-default" OnClick="nextButton_Click" />
                                <asp:Button ID="lastButton" runat="server" Text="Last" class="btn btn-default" OnClick="lastButton_Click" />

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
