<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddEmployee.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="leftContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
    <div class="customize"> 
    <div class="panel panel-success">
        <div class="panel-heading">
            <div class="panel-title">Employee Entry Form</div>
        </div>
        <p runat="server" class="text-center-error" id="message"></p>
         <p runat="server" class="text-center-save" id="messageLabel"></p>
        <div class="panel-body">
            

            <form runat="server">
                <div class="form-group">
                    <asp:Label ID="Label1" runat="server" Text="Employee Code" class="col-sm-4 control-label"></asp:Label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="employeeCodeTextBox" runat="server" class="form-control"></asp:TextBox><br />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label2" runat="server" Text="Employee Name" class="col-sm-4 control-label"></asp:Label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="employeeNameTextBox" runat="server" class="form-control"></asp:TextBox><br />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label5" runat="server" Text="Employee NationalId" class="col-sm-4 control-label"></asp:Label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="employeeNationalIdTextBox" runat="server" class="form-control"></asp:TextBox><br />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label6" runat="server" Text="Employee Phone" class="col-sm-4 control-label"></asp:Label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="employeePhoneTextBox" runat="server" class="form-control"></asp:TextBox><br />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label3" runat="server" Text="Employee Address" class="col-sm-4 control-label"></asp:Label>
                    <div class="col-sm-6">
                        <%--<asp:TextBox ID="TextBox1" runat="server" class="form-control"></asp:TextBox><br />--%>
                        <textarea ID="employeeAddressTextArea" cols="20" rows="3" runat="server" class="form-control"></textarea><br/>
                            
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label7" runat="server" Text="Basic Salary" class="col-sm-4 control-label"></asp:Label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="employeeBasicSalaryTextBox" runat="server" class="form-control"></asp:TextBox><br />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label ID="Label4" runat="server" Text="Opening Balance" class="col-sm-4 control-label"></asp:Label>
                    <div class="col-sm-6">
                        <asp:TextBox ID="employeeOpeningBalanceTextBox" runat="server" class="form-control"></asp:TextBox><br />
                    </div>
                </div>
                <div class="form-group">
                    <div class="row">
                        <div class="col-sm-12">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
