<%@ Page Title="" Language="C#" MasterPageFile="~/UI/Index.Master" AutoEventWireup="true" CodeBehind="AddSpacymenParty.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.AddSpacymenParty" %>

<asp:Content ID="Content2" ContentPlaceHolderID="middleContentPlaceHolder" runat="server">
    <form runat="server">
        <div class="customize">
            <div class="panel panel-success">
                <div class="panel-heading">
                    <div class="panel-title">Spacymen Party Information Form</div>
                </div>



                <%-- <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="Label12" runat="server" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <div class="input-group pull-right">
                                <input type="text" class="form-control" />
                                <span class="input-group-btn">
                                    <button class="btn btn-default" type="button">Search</button>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>--%>




                <p runat="server" class="text-center-error" id="message"></p>
                <p runat="server" class="text-center-save" id="messageLabel"></p>
                <div class="panel-body">


                    <div class="form-group">
                        <asp:Label ID="Label1" runat="server" Text="District Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <%--<asp:DropDownList id="districtNameDropDownList" runat="server" class="form-control" OnSelectedIndexChanged="districtNameDropDownList_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList><br />--%>
                            <asp:DropDownList id="districtNameDropDownList" runat="server" class="form-control"></asp:DropDownList><br/>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label3" runat="server" Text="Party Code" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="partyCodeTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label4" runat="server" Text="Party Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="partyNameTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label6" runat="server" Text="Party Address" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <textarea id="partyAddressTextArea" cols="20" rows="3" runat="server" class="form-control"></textarea><br />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label ID="Label7" runat="server" Text="School Name" class="col-sm-4 control-label"></asp:Label>
                        <div class="col-sm-6">
                            <asp:TextBox ID="schoolNameTextBox" runat="server" class="form-control"></asp:TextBox><br />
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="row">
                            <div class="col-sm-12">
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;
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
       <%-- <select id="test" runat="server">
            <option>A</option>
            <option>B</option>
        </select>--%>
    </form>
   
    <%--<script>
        $(document).ready(function () {
            ////var test = $("#").val;
            //alert(test);
            $("#test").change(function () {
                alert("Change");
            });

        });
    </script>--%>
</asp:Content>

