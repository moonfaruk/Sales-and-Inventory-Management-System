﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddSupplierBillPayment.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddSupplierBillPayment" %>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
    <form runat="server">
        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="panel-title">Supplier Bill Payment</div>
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
                        <asp:Label ID="Label7" runat="server" Text="Bill No." class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="billNoTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div> 
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Supplier Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="supplierNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div>    
                    
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Payment Mode" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="paymentModeDropDownList" runat="server" class="form-control">
                                <%--<asp:ListItem Value="-->Select one Option-->" />--%>
                                <asp:ListItem Value="" />
                                <asp:ListItem Text="Cash"></asp:ListItem>
                                <asp:ListItem Text="Check"></asp:ListItem>
                            </asp:DropDownList><br />
                        </div>
                    </div>
                   
                     <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Bank Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="bankNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div>  
                    
                     <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Check No." class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="checkNoTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>  
                    
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Check Date" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">

                                <input id="checkDateTextBox" name="checkDateTextBox" type="text" class="form-control" placeholder="Created Date" runat="server" clientidmode="static" />
                                <span class="input-group-addon"><span class="glyphicon glyphicon-th" aria-hidden="true"></span></span>

                            </div>
                            <br />
                        </div>
                    </div>
                    
                     <div class="form-group">
                        <asp:Label ID="Label10" runat="server" Text="Amount" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="amountTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    
                    
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                <asp:Button ID="saveButton" runat="server" Text="Save" class="btn btn-default" OnClick="saveButton_Click"  />
                                <asp:Button ID="cancelButton" runat="server" Text="Cancel" class="btn btn-default" OnClick="cancelButton_Click"  />
                                <asp:Button ID="exitButton" runat="server" Text="Exit" class="btn btn-default" OnClick="exitButton_Click"  />
                                <asp:Button ID="slipButton" runat="server" Text="Slip" class="btn btn-default" OnClick="slipButton_Click"  />
                                <asp:Button ID="firstButton" runat="server" Text="First" class="btn btn-default" OnClick="firstButton_Click"  />
                                <asp:Button ID="nextButton" runat="server" Text="Next" class="btn btn-default" OnClick="nextButton_Click"  />
                                <asp:Button ID="lastButton" runat="server" Text="Last" class="btn btn-default" OnClick="lastButton_Click"  />
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
            $("#checkDateTextBox").datepicker({
                minDate: 0
            });
        });
    </script>
</asp:Content>
