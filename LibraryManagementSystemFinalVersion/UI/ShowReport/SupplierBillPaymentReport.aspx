<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierBillPaymentReport.aspx.cs" Inherits="LibraryManagementSystemFinalVersion.UI.ShowReport.SupplierBillPaymentReport" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <rsweb:ReportViewer ID="SupplierBillPaymentReportViewer" runat="server" Font-Names="Verdana" Font-Size="8pt" Height="379px" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="80%">
            <LocalReport ReportEmbeddedResource="LibraryManagementSystemFinalVersion.UI.ShowReport.SupplierBillPaymentReport.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="Ds_SupplierBillPayment" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="GetData" TypeName="LibraryManagementSystemFinalVersion.UI.ShowReport.Ds_SupplierBillPaymentTableAdapters.tbl_supplierBillPaymentTableAdapter"></asp:ObjectDataSource>
        <p style="margin-left: 240px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <asp:Button ID="backToButton" runat="server" Text="Back To" Width="113px" OnClick="backToButton_Click" />
        </p>
    
    </div>
    </form>
    <p style="margin-left: 40px">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    </p>
</body>
</html>
