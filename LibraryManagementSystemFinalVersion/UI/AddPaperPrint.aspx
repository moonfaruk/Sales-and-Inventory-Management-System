<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddPaperPrint.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddPaperPrint" %>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
    <form runat="server">
        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="panel-title">Paper Print Entry Form</div>
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
                        <asp:Label ID="Label2" runat="server" Text="Order No" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="orderNoTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label9" runat="server" Text="Press Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="pressNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Year" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="yearTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Printing Type" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="printingTypeDropDownList" runat="server" class="form-control">

                                <asp:ListItem Value="" />
                                <asp:ListItem Text="Book"></asp:ListItem>
                                <asp:ListItem Text="Others"></asp:ListItem>


                            </asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Group Name" class="col-sm-4 control-label"></asp:Label>
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
                        <asp:Label ID="Label4" runat="server" Text="Plate" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="plateTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Forma" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="formaTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Forma Type" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="formaTypeDropDownList" runat="server" class="form-control">

                                <asp:ListItem Value="" />
                                <asp:ListItem Text="A"></asp:ListItem>
                                <asp:ListItem Text="B"></asp:ListItem>
                                <asp:ListItem Text="C"></asp:ListItem>
                                <asp:ListItem Text="D"></asp:ListItem>

                            </asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label12" runat="server" Text="Color Type" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="colorTypeDropDownList" runat="server" class="form-control">

                                <asp:ListItem Value="" />
                                <asp:ListItem Text="White"></asp:ListItem>
                                <asp:ListItem Text="Black"></asp:ListItem>
                                <asp:ListItem Text="Green"></asp:ListItem>

                            </asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label14" runat="server" Text="Paper Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="paperNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label15" runat="server" Text="Paper Type" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="paperTypeDropDownList" runat="server" class="form-control">

                                <asp:ListItem Value="" />
                                <asp:ListItem Text="D/D"></asp:ListItem>
                                <asp:ListItem Text="D/C"></asp:ListItem>
                                <asp:ListItem Text="S/D"></asp:ListItem>

                            </asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label10" runat="server" Text="Book Quantity" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="bookQuantityTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label13" runat="server" Text="Paper Quantity" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="paperQuantityTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                                <asp:Button ID="saveButton" runat="server" Text="Save" class="btn btn-default" OnClick="saveButton_Click" />
                                <asp:Button ID="cancelButton" runat="server" Text="Cancel" class="btn btn-default" OnClick="cancelButton_Click" />
                                <asp:Button ID="exitButton" runat="server" Text="Exit" class="btn btn-default" OnClick="exitButton_Click" />
                                <asp:Button ID="firstButton" runat="server" Text="First" class="btn btn-default" OnClick="firstButton_Click" />
                                <asp:Button ID="nextButton" runat="server" Text="Next" class="btn btn-default" OnClick="nextButton_Click" />
                                <asp:Button ID="previousButton" runat="server" Text="Prev" class="btn btn-default" OnClick="previousButton_Click" />
                                <asp:Button ID="lastButton" runat="server" Text="Last" class="btn btn-default" OnClick="lastButton_Click" />

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

