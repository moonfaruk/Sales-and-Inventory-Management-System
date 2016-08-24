<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddGroup.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddGroup" %>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
    <form runat="server">
        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="panel-title">Group Entry Form</div>
                </div>



                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="Label12" runat="server" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group pull-right">
                                <input type="text" name="gTextBox" id="gTextBox" runat="server" class="form-control" placeholder="Code Here" />
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
                        <asp:Label ID="Label3" runat="server" Text="Group Code" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="groupCodeTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Group Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="groupNameTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>

                   


                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; &nbsp;
                                <asp:Button ID="saveButton" runat="server" Text="Save" class="btn btn-default" OnClick="saveButton_Click"  />
                                <asp:Button ID="cancelButton" runat="server" Text="Cancel" class="btn btn-default" OnClick="cancelButton_Click"  />
                                <asp:Button ID="exitButton" runat="server" Text="Exit" class="btn btn-default" OnClick="exitButton_Click"  />
                                <asp:Button ID="lastButton" runat="server" Text="Last" class="btn btn-default" OnClick="lastButton_Click"  />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</asp:Content>
