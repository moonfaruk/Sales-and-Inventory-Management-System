﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddBookSales.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddBookSales" %>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
     <form runat="server">
        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="panel-title">Book Sales Entry Form</div>
                </div>

                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="Label12" runat="server" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group pull-right">
                                <input type="text" name="memoTextBox" id="memoTextBox" runat="server" class="form-control" placeholder="MemoNo Here" />
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
                        <asp:Label ID="Label9" runat="server" Text="District Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="districtNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div> 
                     <div class="form-group">
                        <asp:Label ID="Label7" runat="server" Text="Party Code" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="partyCodeDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div> 
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Memo No" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="memoNoTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label17" runat="server" Text="Sales Type" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="salesTypeDropDownList" runat="server" class="form-control">
                                <asp:ListItem Value="" />
                                <asp:ListItem Text="Normal"></asp:ListItem>
                                <asp:ListItem Text="Anything"></asp:ListItem>
                            </asp:DropDownList><br />
                        </div>
                    </div>
                    
                    
                    <div class="form-group">
                        <asp:Label ID="Label16" runat="server" Text="Year" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="yearTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Group Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="groupNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div> 
                     <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Book Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="bookNameDropDownList" runat="server" class="form-control" OnSelectedIndexChanged="bookNameDropDownList_OnSelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="Quantity" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="quantityTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div> 
                    <div class="form-group">
                        <asp:Label ID="Label13" runat="server" Text="Book Rate" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="bookRateTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label8" runat="server" Text="Commission" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="commissionTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Sale Rate" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="saleRateTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Total" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="totalTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label10" runat="server" Text="Packing" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="packingTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label14" runat="server" Text="Bonus" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="bonusTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label18" runat="server" Text="Total Price" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="totalPriceTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label19" runat="server" Text="Payment Amount" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="paymentAmountTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label15" runat="server" Text="Dues" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="duesTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    
                    <table>
                        <thead>
                            <tr style="border: 1px solid black">
                                <th>Quantity</th>
                                <th>Group Code</th>
                                <th>Book Code</th>
                                <th>Total</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr style="border: 1px solid black">
                                <td></td>
                                <td></td>
                                <td></td>
                                <td></td>
                            </tr>
                        </tbody>
                    </table>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;<asp:Button ID="saveButton" runat="server" Text="Save" class="btn btn-default" OnClick="saveButton_Click" />
                                <asp:Button ID="cancelButton" runat="server" Text="Cancel" class="btn btn-default" OnClick="cancelButton_Click"  />
                                <asp:Button ID="exitButton" runat="server" Text="Exit" class="btn btn-default" OnClick="exitButton_Click" />
                                <asp:Button ID="firstButton" runat="server" Text="First" class="btn btn-default" OnClick="firstButton_Click"  />
                                <asp:Button ID="nextButton" runat="server" Text="Next" class="btn btn-default" OnClick="nextButton_Click"   />
                                <asp:Button ID="previousButton" runat="server" Text="Prev" class="btn btn-default" OnClick="previousButton_Click"  />
                                <asp:Button ID="lastButton" runat="server" Text="Last" class="btn btn-default" OnClick="lastButton_Click"  />
                                <asp:Button ID="slipButton" runat="server" Text="Memo" class="btn btn-default" OnClick="slipButton_Click" />

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
        $(document).ready(function() {
            $("#dateTextBox").datepicker({
                minDate: 0
            });
            $("[id$='quantityTextBox']").blur(function() {
                var quantity = $("[id$='quantityTextBox']").val();
                if (quantity == "") quantity = 0;
                var saleRate = $("[id$='saleRateTextBox']").val();
                if (saleRate == "") saleRate = 0;
                var result = quantity * saleRate;
                $("[id$='totalTextBox']").val("" + result);
                $("[id$='totalPriceTextBox']").val("" + result);
                return false;
            });
            $("[id$='packingTextBox']").blur(function () {
                var packing = parseFloat($("[id$='packingTextBox']").val());
                if (packing == "") packing = 0;
                var totalPrice = parseFloat($("[id$='totalPriceTextBox']").val());
                if (totalPrice == "") totalPrice = 0;
                var result = totalPrice + packing;
                $("[id$='totalPriceTextBox']").val("" + result);
                return false;
            });
            $("[id$='bonusTextBox']").blur(function () {
                var bonus = parseFloat($("[id$='bonusTextBox']").val());
                var totalPrice = parseFloat($("[id$='totalPriceTextBox']").val());
                var result = totalPrice - bonus;
                $("[id$='totalPriceTextBox']").val("" + result);
                return false;
            });
            $("[id$='paymentAmountTextBox']").blur(function () {
                var paymentAmount = parseFloat($("[id$='paymentAmountTextBox']").val());
                if (paymentAmount == "") paymentAmount = 0;
                var totalPrice = parseFloat($("[id$='totalPriceTextBox']").val());
                if (totalPrice == "") totalPrice = 0;
                var result = totalPrice - paymentAmount;
                $("[id$='duesTextBox']").val("" + result);
                return false;
            });
        });
    </script>
</asp:Content>