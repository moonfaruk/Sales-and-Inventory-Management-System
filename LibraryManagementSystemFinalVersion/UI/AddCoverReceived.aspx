<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddCoverReceived.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddCoverReceived" %>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
     <form runat="server">
        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="panel-title">Cover Received Entry Form</div>
                </div>

                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="Label12" runat="server" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group pull-right">
                                <input type="text" name="recvTextBox" id="recvTextBox" runat="server" class="form-control" placeholder="RecvNo Here" />
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
                        <asp:Label ID="Label11" runat="server" Text="Date" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">

                                <input id="dateTextBox" name="dateTextBox" type="text" class="form-control" placeholder="Created Date" runat="server" clientidmode="static" />
                                <span class="input-group-addon"><span class="glyphicon glyphicon-th" aria-hidden="true"></span></span>

                            </div>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Recv No" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="recvNoTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label16" runat="server" Text="Year" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="yearTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label9" runat="server" Text="Group Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="groupNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div> 
                     <div class="form-group">
                        <asp:Label ID="Label7" runat="server" Text="Book Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="bookNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div> 
                    <div class="form-group">
                        <asp:Label ID="Label13" runat="server" Text="Quantity" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="quantityTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="saveButton" runat="server" Text="Save" class="btn btn-default" OnClick="saveButton_Click" />
                                <asp:Button ID="cancelButton" runat="server" Text="Cancel" class="btn btn-default" OnClick="cancelButton_Click"  />
                                <asp:Button ID="exitButton" runat="server" Text="Exit" class="btn btn-default" OnClick="exitButton_Click" />
                                <asp:Button ID="firstButton" runat="server" Text="First" class="btn btn-default" OnClick="firstButton_Click"  />
                                <asp:Button ID="nextButton" runat="server" Text="Next" class="btn btn-default" OnClick="nextButton_Click"  />
                                <asp:Button ID="previousButton" runat="server" Text="Prev" class="btn btn-default" OnClick="previousButton_Click"  />
                                <asp:Button ID="lastButton" runat="server" Text="Last" class="btn btn-default" OnClick="lastButton_Click"  />
                                <asp:Button ID="slipButton" runat="server" Text="Slip" class="btn btn-default" OnClick="slipButton_Click"  />

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
         
    </form>

    <script src="../Scripts/jquery-2.2.0.min.js"></script>
    <script src="../Scripts/jquery-ui-1.11.4.min.js"></script>



    <script>
        $(document).ready(function () {
            $("#dateTextBox").datepicker({
                minDate: 0
            });
        });
    </script>
</asp:Content>
