<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddPersonalLoanTaken.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddPersonalLoanTaken" %>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
     <form runat="server">
        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="panel-title">Personal Loan Taken/Payment</div>
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
                        <asp:Label ID="Label2" runat="server" Text="Type" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="typeDropDownList" runat="server" class="form-control">
                                <%--<asp:ListItem Value="-->Select one Option-->" />--%>
                                <asp:ListItem Value="" />
                                <asp:ListItem Text="Loan Takan"></asp:ListItem>
                                <asp:ListItem Text="Payment"></asp:ListItem>
                                
                            </asp:DropDownList><br />
                        </div>
                    </div>
                   
                     <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Party" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="partyDropDownList" runat="server" class="form-control"></asp:DropDownList><br />
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
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

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
