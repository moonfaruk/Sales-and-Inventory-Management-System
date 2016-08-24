<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddBankAccount.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddBankAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="leftContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
    <form runat="server">
        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="panel-title">Bank Account Entry Form</div>
                </div>
                <p runat="server" class="text-center-error" id="message"></p>
                <p runat="server" class="text-center-save" id="messageLabel"></p>
                <div class="panel-body">



                    <div class="form-group">
                        <asp:HiddenField runat="server" ID="formWithBankAccountIdHiddenField" />
                        <asp:Label ID="Label1" runat="server" Text="Code" Class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="bankCodeTextBox" runat="server" Class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="bankNameTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Account No." class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="accountNoTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Opening Balance" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="bankOpeningBalanceTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
                                <asp:Button ID="saveButton" runat="server" Text="Save" class="btn btn-default" OnClick="saveButton_Click" />
                                <asp:Button ID="clearButton" runat="server" Text="Clear" class="btn btn-default" OnClick="clearButton_Click" />
                                <asp:Button ID="exitButton" runat="server" Text="Exit" class="btn btn-default" OnClick="exitButton_Click" />
                            </div>
                        </div>
                    </div>

                </div>

            </div>
        </div>

        <!--Start GridView -->

        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-body">
                    <div style="height: 150px; width: 510px; overflow: auto;">
                        <asp:GridView ID="showShopInfoGridView" runat="server" Height="150px" Width="520px" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Serial No.">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("SerialNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="bankAccountIdHiddenField" runat="server" Value='<%#Eval("BankAccountId") %>' />
                                        <asp:Label runat="server" Text='<%#Eval("BankAccountCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("BankAccountName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Account No.">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("AccountNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Op. Balance">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("BankAccountOpeningBalance") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="updateButton" runat="server" Text="Update" OnClick="updateButton_OnClick"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="deleteButton" runat="server" Text="Delete" OnClick="deleteButton_OnClick"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </form>
    <!--End GridView-->
</asp:Content>
