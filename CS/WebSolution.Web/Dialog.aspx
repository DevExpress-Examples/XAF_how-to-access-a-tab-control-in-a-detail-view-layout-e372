<%@ Register Assembly="DevExpress.ExpressApp.Web.v8.2" Namespace="DevExpress.ExpressApp.Web.Templates.ActionContainers" TagPrefix="cc2" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v8.2" Namespace="DevExpress.ExpressApp.Web.Templates.Controls" TagPrefix="tc" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v8.2" Namespace="DevExpress.ExpressApp.Web.Controls" TagPrefix="cc4" %>
<%@ Page Language="C#" AutoEventWireup="true" Inherits="DialogPage" EnableViewState="false" validateRequest="false" Codebehind="Dialog.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Dialog Page</title>
	<meta http-equiv="Expires" content="0" />
    <link href="TemplateStyle.css" rel="stylesheet" type="text/css" />	
</head>
<body>
	<cc4:ProgressControl ID="ProgressControl" runat="server" ImageName="~/Images/Progress.gif" CssClass="Progress" Text="" />
	<table id="formTable" cellpadding="0" cellspacing="0" border="0" class="FullWidth"><tr><td>
	<form id="form1" runat="server">
    <asp:Table ID="ViewTitle" runat="server" Width="100%" Height="50px" CellPadding="0" CellSpacing="0" BackColor="#CFE7A5">
        <asp:TableRow ID="TableRow1" runat="server">
            <asp:TableCell ID="TableCell2" runat="server" HorizontalAlign="Left" style="padding: 5px 0px 5px 20px; border-bottom:solid 1px #AECD76">
	            <table cellpadding="0" cellspacing="0" border="0">
		            <tr><td class="ViewImage">
				            <asp:Image ID="ViewImage" runat="server" /></td>
			            <td class="ViewCaption">
				            <asp:Label ID="ViewCaption" runat="server" Text="Contact list"></asp:Label>
			            </td>
		            </tr>
	            </table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
	<table border="0" cellpadding="0" cellspacing="0" width="100%"><tr><td style="padding:17px 17px 0px 17px">
		<tc:ErrorInfoControl ID="ErrorInfo" style="margin: 10px 0px 10px 0px" runat="server">
		</tc:ErrorInfoControl>
        <asp:Table ID="Table1" runat="server" Width="100%" BorderWidth="0px" CellPadding="0" CellSpacing="0">
            <asp:TableRow ID="TableRow5" runat="server">
                <asp:TableCell runat="server" ID="TableCell1" HorizontalAlign="Center" style="padding-bottom:20px;">
									<cc2:HorizontalActionContainer ID="SearchActionContainer" runat="server" ContainerId="Search" CssClass="HContainer" BorderWidth="0px" CellPadding="0" CellSpacing="0">
									</cc2:HorizontalActionContainer>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow2" runat="server">
                <asp:TableCell runat="server" ID="ViewSite" >view's control place holder</asp:TableCell>
            </asp:TableRow>
            <asp:TableRow ID="TableRow3" runat="server">
                <asp:TableCell runat="server" ID="TableCell4" HorizontalAlign="Right" style="padding: 20px 0px 20px 0px" >
                    <cc2:HorizontalActionContainer ID="ObjectsCreationActionContainer" runat="server" CssClass="HContainer" ContainerId="ObjectsCreation" Style="margin-right:0px;display:inline" BorderWidth="0px" CellPadding="0" CellSpacing="0">
										</cc2:HorizontalActionContainer>
                    <cc2:HorizontalActionContainer ID="PopupActions" runat="server" ContainerId="PopupActions" CssClass="HContainer" Style="margin-left:20px;display:inline" BorderWidth="0px" CellPadding="0" CellSpacing="0">
									    </cc2:HorizontalActionContainer>
        		    <cc2:HorizontalActionContainer ID="DiagnosticActionContainer" runat="server" ContainerId="Diagnostic" CssClass="HContainer" Style="margin-left:20px;display:inline" BorderWidth="0px" CellPadding="0" CellSpacing="0">
		                			    </cc2:HorizontalActionContainer>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        </td></tr></table>
	</form>
   </td></tr></table>
</body>
</html>
