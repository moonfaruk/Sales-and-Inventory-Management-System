<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddMoneyReceipt.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddMoneyReceipt" %>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
    <form runat="server">
        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="panel-title">Collection Entry Form</div>
                </div>
                
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="Label12" runat="server" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group pull-right">
                                <input type="text" name="mrTextBox" id="mrTextBox" runat="server" class="form-control" placeholder="MrNo Here" />
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
                        <asp:Label ID="Label4" runat="server" Text="Mr No." class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="mrNoTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label9" runat="server" Text="District Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="districtNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Party Code" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="partyCodeDropDownList" runat="server" class="form-control" OnSelectedIndexChanged="partyCodeDropDownList_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><br />
                        </div>
                    </div>  
                    
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Party Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="partyNameTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Mode" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="modeDropDownList" runat="server" class="form-control">
                                
                                <asp:ListItem Value="" />
                                <asp:ListItem Text="Cash"></asp:ListItem>
                                <asp:ListItem Text="Cheque"></asp:ListItem>
                                <asp:ListItem Text="D.D"></asp:ListItem>
                                <asp:ListItem Text="T.T"></asp:ListItem>
                                <asp:ListItem Text="Online"></asp:ListItem>
                                <asp:ListItem Text="Bkash"></asp:ListItem>
                            </asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Cheque No." class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="chequeNoTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Cheque Date" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">

                                <input id="chequeDateTextBox" name="chequeDateTextBox" type="text" class="form-control" placeholder="Created Date" runat="server" clientidmode="static" />
                                <span class="input-group-addon"><span class="glyphicon glyphicon-th" aria-hidden="true"></span></span>

                            </div>
                            <br />
                        </div>
                    </div>
                     <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Bank Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="bankNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div>  
                    <div class="form-group">
                        <asp:Label ID="Label7" runat="server" Text="Branch Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="branchNameTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label13" runat="server" Text="Amount" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="amountTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label10" runat="server" Text="Remarks" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <textarea id="remarksTextArea" cols="20" rows="3" runat="server" class="form-control"></textarea><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="saveButton" runat="server" Text="Save" class="btn btn-default" OnClick="saveButton_Click"  />
                                <asp:Button ID="cancelButton" runat="server" Text="Cancel" class="btn btn-default" OnClick="cancelButton_Click"  />
                                <asp:Button ID="exitButton" runat="server" Text="Exit" class="btn btn-default" OnClick="exitButton_Click"  />
                                <asp:Button ID="firstButton" runat="server" Text="First" class="btn btn-default" OnClick="firstButton_Click"   />
                                <asp:Button ID="nextButton" runat="server" Text="Next" class="btn btn-default" OnClick="nextButton_Click"   />
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="previousButton" runat="server" Text="Prev" class="btn btn-default" OnClick="previousButton_Click"   />
                                &nbsp;<asp:Button ID="lastButton" runat="server" Text="Last" class="btn btn-default" OnClick="lastButton_Click"   />
                                &nbsp;
                                <asp:Button ID="moneyReceiptButton" runat="server" Text="Money Receipt" class="btn btn-default" OnClick="moneyReceiptButton_Click"   />

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
            $("#chequeDateTextBox").datepicker({
                minDate: 0

            });
        });
    </script>
</asp:Content>
