<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddSupplierLedger.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddSupplierLedger" %>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
    <form runat="server">
        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="panel-title">Supplier Ledger</div>
                </div>

                <p runat="server" class="text-center-error" id="message"></p>
                <p runat="server" class="text-center-save" id="messageLabel"></p>
                <div class="panel-body">

                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Select Supplier Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="supplierNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
                        </div>
                    </div>    
                    
                    <div class="form-group">
                        <asp:Label ID="Label11" runat="server" Text="From" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">

                                <input id="fromTextBox" name="fromTextBox" type="text" class="form-control" placeholder="Created Date" runat="server" clientidmode="static" />
                                <span class="input-group-addon"><span class="glyphicon glyphicon-th" aria-hidden="true"></span></span>

                            </div>
                            <br />
                        </div>
                    </div>
                    
                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="To" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group">

                                <input id="toTextBox" name="toTextBox" type="text" class="form-control" placeholder="Created Date" runat="server" clientidmode="static" />
                                <span class="input-group-addon"><span class="glyphicon glyphicon-th" aria-hidden="true"></span></span>

                            </div>
                            <br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

                                <asp:Button ID="partyLedgerButton" runat="server" Text="Party Ledger" class="btn btn-default" OnClick="partyLedgerButton_Click"  />
                                &nbsp;
                                <asp:Button ID="exitButton" runat="server" Text="Exit" class="btn btn-default" OnClick="exitButton_Click"  />
                                &nbsp;
                                <asp:Button ID="clearButton" runat="server" Text="Clear" class="btn btn-default" OnClick="clearButton_Click"  />

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
        $(function () {
            $("#fromTextBox").datepicker();
            $("#toTextBox").datepicker();
        });
    </script>
</asp:Content>
