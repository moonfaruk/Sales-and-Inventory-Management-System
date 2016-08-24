<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddShope.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddShope" %>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
    <form runat="server">
        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="panel-title">Shope Entry Form</div>
                </div>
                <div class="panel-body">
                    <strong runat="server" id="message"></strong>


                    <div class="form-group">
                        <asp:HiddenField runat="server" ID="formWithShopIdHiddenField" />
                        <asp:Label ID="Label1" runat="server" Text="Code" Class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="shopeCodeTextBox" runat="server" Class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label2" runat="server" Text="Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="shopeNameTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Phone" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="phoneTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Address" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <textarea id="addressTextArea" cols="20" rows="3" runat="server" class="form-control"></textarea><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label5" runat="server" Text="Monthly Rent" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="monthlyRentTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Opening Balance" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="openingBalanceTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="saveButton" runat="server" Text="Save" class="btn btn-default" OnClick="saveButton_Click"  />
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
                    <%--<div style="height: 150px; width: 510px; overflow: auto;">--%>
                    <div class="table-responsive">   
                     <asp:GridView ID="showShopInfoGridView" CssClass="table table-hover" runat="server" Height="188px" Width="610px" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="Serial No.">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("SerialNo") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Code">
                                    <ItemTemplate>
                                        <asp:HiddenField ID="shopIdHiddenFieldGridView" runat="server" Value='<%#Eval("ShopeId") %>' />
                                        <asp:Label runat="server" Text='<%#Eval("ShopeCode") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("ShopeName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Phone">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("ShopePhone") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Address">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("ShopeAddress") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Monthly Rent">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("MonthlyRent") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Op. Balance">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%#Eval("OpeningBalance") %>'></asp:Label>
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
        <!--End GridView-->
    </form>


<%--    <script type="text/javascript" lang="javascript">

        $(document).ready(function () {
            $('#<%=showShopInfoGridView.ClientID %>').Scrollable();
        }
          )
    </script>

     <script src="../Scripts/jquery-2.1.4.min.js"></script>
     <script src="../Scripts/ScrollableGridPlugin.js"></script>--%>

</asp:Content>
