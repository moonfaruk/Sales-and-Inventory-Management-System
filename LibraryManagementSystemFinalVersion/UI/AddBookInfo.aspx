<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddBookInfo.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddBookInfo" %>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
    <form runat="server">
        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="panel-title">Book Entry Form</div>
                </div>



                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="Label12" runat="server" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group pull-right">
                                <input type="text" name="bookInfoTextBox" id="bookInfoTextBox" runat="server" class="form-control" placeholder="Code Here" />
                                <span class="input-group-btn">
                                    
                                    <asp:Button ID="searchButton" runat="server" Text="Search" class="btn btn-default" OnClick="searchButton_Click" /></span>
                            </div>
                        </div>
                    </div>
                </div>




                <p runat="server" class="text-center-error" id="message"></p>
                <p runat="server" class="text-center-save" id="messageLabel"></p>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Book Code" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="bookCodeTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Book Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="bookNameTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Book Size" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="bookSizeTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Book Forma" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="bookFormaTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Book Inar" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="bookInarTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label14" runat="server" Text="Main Book Code" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="mainBookCodeDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Press Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="pressNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label7" runat="server" Text="Binder Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="binderNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Book Rate" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="bookRateTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label9" runat="server" Text="Book Return Rate" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="returnRateTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label11" runat="server" Text="Commission" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="commissionTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label10" runat="server" Text="Opening Balance" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="bookOpeningBalanceTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label13" runat="server" Text="Status" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="statusTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                                <asp:Button ID="saveButton" runat="server" Text="Save" class="btn btn-default" OnClick="saveButton_Click"  />
                                <asp:Button ID="cancelButton" runat="server" Text="Cancel" class="btn btn-default" OnClick="cancelButton_Click"  />
                                <asp:Button ID="exitButton" runat="server" Text="Exit" class="btn btn-default" OnClick="exitButton_Click"  />
                                <asp:Button ID="firstButton" runat="server" Text="First" class="btn btn-default" OnClick="firstButton_Click" />
                                <asp:Button ID="nextButton" runat="server" Text="Next" class="btn btn-default" OnClick="nextButton_Click"  />
                                <asp:Button ID="previousButton" runat="server" Text="Prev" class="btn btn-default" OnClick="previousButton_Click"  />
                                <asp:Button ID="lastButton" runat="server" Text="Last" class="btn btn-default" OnClick="lastButton_Click" />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
