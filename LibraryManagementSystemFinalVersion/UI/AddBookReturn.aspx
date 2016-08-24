﻿<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddBookReturn.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddBookRetutn" %>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
    <form runat="server">
        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="panel-title">Book Return Entry Form</div>
                </div>

                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="Label12" runat="server" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group pull-right">
                                <input type="text" name="returnTextBox" id="returnTextBox" runat="server" class="form-control" placeholder="ReturnNo Here" />
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
                        <asp:Label ID="Label11" runat="server" Text="Date" class="col-sm-4 control-label" ></asp:Label>
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
                            <asp:DropDownList ID="districtNameDropDownList" runat="server" class="form-control" ></asp:DropDownList><br />
                        </div>
                    </div> 
                     <div class="form-group">
                        <asp:Label ID="Label7" runat="server" Text="Party Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="partyNameDropDownList" runat="server" class="form-control" ></asp:DropDownList><br />
                        </div>
                    </div> 
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Return No" class="col-sm-4 control-label" ></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="returnNoTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label17" runat="server" Text="Challan Return" class="col-sm-4 control-label" ></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="challanReturnDropDownList" runat="server" class="form-control">
                                <asp:ListItem Value="" />
                                <asp:ListItem Text="Yes"></asp:ListItem>
                                <asp:ListItem Text="No"></asp:ListItem>
                            </asp:DropDownList><br />
                        </div>
                    </div>
                   
                    <div class="form-group">
                        <asp:Label ID="Label16" runat="server" Text="Year" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="yearTextBox" runat="server" class="form-control" ></asp:TextBox><br />
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
                        <asp:Label ID="Label5" runat="server" Text="Return Rate" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="returnRateTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Total" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="totalTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label10" runat="server" Text="Transport Bill" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="transportBillTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label14" runat="server" Text="Less" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="lessTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label15" runat="server" Text="Net Return" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="netReturnTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;
                                <asp:Button ID="saveButton" runat="server" Text="Save" class="btn btn-default" OnClick="saveButton_Click" />
                                <asp:Button ID="cancelButton" runat="server" Text="Cancel" class="btn btn-default" OnClick="cancelButton_Click"  />
                                <asp:Button ID="exitButton" runat="server" Text="Exit" class="btn btn-default" OnClick="exitButton_Click" />
                                <asp:Button ID="firstButton" runat="server" Text="First" class="btn btn-default" OnClick="firstButton_Click"  />
                                <asp:Button ID="nextButton" runat="server" Text="Next" class="btn btn-default" OnClick="nextButton_Click"   />
                                <asp:Button ID="previousButton" runat="server" Text="Prev" class="btn btn-default" OnClick="previousButton_Click"  />
                                <asp:Button ID="lastButton" runat="server" Text="Last" class="btn btn-default" OnClick="lastButton_Click"  />
                                <asp:Button ID="slipButton" runat="server" Text="Report" class="btn btn-default" OnClick="slipButton_Click" />

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

            $("[id$='quantityTextBox']").blur(function () {
                var quantity = $("[id$='quantityTextBox']").val();
                if (quantity == "") quantity = 0;
                var returnRate = $("[id$='returnRateTextBox']").val();
                if (returnRate == "") returnRate = 0;
                var result = quantity * returnRate;
                $("[id$='totalTextBox']").val("" + result);
                $("[id$='netReturnTextBox']").val("" + result);
                return false;
            });
            
            $("[id$='transportBillTextBox']").blur(function () {
                var transportBill = parseFloat($("[id$='transportBillTextBox']").val());
                if (transportBill == "") transportBill = 0;
                var netReturn = parseFloat($("[id$='netReturnTextBox']").val());
                if (netReturn == "") netReturn = 0;
                var result = netReturn + transportBill;
                $("[id$='netReturnTextBox']").val("" + result);
                return false;
            });
            $("[id$='lessTextBox']").blur(function () {
                var netReturn = parseFloat($("[id$='netReturnTextBox']").val());
                var less = parseFloat($("[id$='lessTextBox']").val());
                var result = netReturn - less;
                $("[id$='netReturnTextBox']").val("" + result);
                return false;
            });
        });
    </script>
</asp:Content>
