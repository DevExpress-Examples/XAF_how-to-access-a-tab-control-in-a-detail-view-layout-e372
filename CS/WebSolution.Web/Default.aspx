<%@ Page Language="C#" AutoEventWireup="true" Inherits="Default" EnableViewState="false" validateRequest="false" Codebehind="Default.aspx.cs" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v8.2" Namespace="DevExpress.ExpressApp.Web.Templates.ActionContainers" TagPrefix="cc2" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v8.2" Namespace="DevExpress.ExpressApp.Web.Controls" TagPrefix="cc4" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v8.2" Namespace="DevExpress.ExpressApp.Web.Templates.Controls" TagPrefix="tc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>Main Page</title>
	<meta http-equiv="Expires" content="0" />
    <link href="TemplateStyle.css" rel="stylesheet" type="text/css" />	
</head>
<body onload="OnLoad()">
	<form id="form1" runat="server">
    <div id="PageContent">
    <script src="MoveFooter.js" type="text/javascript"></script>
	<cc4:ProgressControl ID="ProgressControl" runat="server" ImageName="~/Images/Progress.gif" CssClass="Progress" Text="" />
	<table id="formTable" cellpadding="0" cellspacing="0" border="0" class="FullWidth" width="800px"><tr><td>
		<table border="0" cellpadding="0" cellspacing="0" class="FullWidth Header">
			<tr><td class="ApplicationTitle">
                    <asp:HyperLink ID="ApplicationTitle" runat="server" ToolTip="Go to Default Page">HyperLink</asp:HyperLink></td>
				<td class="InfoMessagesPanel">
				    <asp:Literal ID="InfoMessagesPanel" runat="server" Text=""></asp:Literal></td>
			</tr>
			<tr><td colspan="2">
		            &nbsp;</td>
			</tr>
		</table>
        <asp:Table ID="ViewTitle" runat="server" Width="100%" Height="50px" CellPadding="0" CellSpacing="0" BackColor="#CFE7A5">
            <asp:TableRow ID="TableRow1" runat="server">
                <asp:TableCell ID="TableCell1" runat="server" HorizontalAlign="Left" style="padding: 5px 0px 5px 21px; border-bottom:solid 1px #AECD76">
                    <cc2:HorizontalActionContainer ID="SearchActionContainer" runat="server" ContainerId="Search" CssClass="HContainer" BorderWidth="0px" CellPadding="0" CellSpacing="0">
		            </cc2:HorizontalActionContainer>
			        <cc2:HorizontalActionContainer ID="RecordsNavigationContainer" runat="server"
				        CssClass="HContainer" ContainerId="RecordsNavigation" BorderWidth="0px" CellPadding="0" CellSpacing="0" Style="margin-left: 10px">
			        </cc2:HorizontalActionContainer>
                </asp:TableCell>
                <asp:TableCell ID="TableCell2" runat="server" HorizontalAlign="Right" style="padding: 5px 20px 5px 0px; border-bottom:solid 1px #AECD76">
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
        <table cellpadding="0" cellspacing="0" border="0" class="FullWidth"><tr>
        <td><div class="Spacer" style="height:30px;width:0px;"></div></td><td valign="middle" style="padding-left:21px; padding-bottom:5px;">
            <cc2:NavigationHistoryActionContainer ID="ViewsHistoryNavigationContainer" runat="server"
                CssClass="NavigationHistoryLinks" ContainerId="ViewsHistoryNavigation">
            </cc2:NavigationHistoryActionContainer>
        </td></tr></table>
		<table cellpadding="0" cellspacing="0" border="0" class="FullWidth">
			<tr>
				<td valign="top" style="width: 195px;padding-right:17px">
					<cc2:NavigationBarActionContainer ID="NavigationBarActionContainer1" ContainerId="ViewsNavigation"
						runat="server" Width="251px">
<ClientSideEvents ItemClick="function (sender, element) {	element.processOnServer = true;}"></ClientSideEvents>

<GroupContentStyle CssClass="ASPxSideBarContent"></GroupContentStyle>

<ItemStyle CssClass="ASPxSideBarItem">
<SelectedStyle CssClass="ASPxSideBarSelectedItem"></SelectedStyle>

<HoverStyle CssClass="ASPxSideBarHoverItem"></HoverStyle>
</ItemStyle>

<GroupHeaderStyle CssClass="ASPxSideBarGroupHeader"></GroupHeaderStyle>

<Border BorderStyle="None"></Border>
					</cc2:NavigationBarActionContainer>
				</td>
				<td valign="top" style="padding-right: 20px;">
					<table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin: 0px 0px 10px 0px">
						<tr><td style="text-align:Left; width:33%">
								<cc2:HorizontalActionContainer ID="ContextObjectsCreationActionContainer" runat="server"
									ContainerId="ObjectsCreation" CssClass="HContainer" BorderWidth="0px" CellPadding="0" CellSpacing="0">
								</cc2:HorizontalActionContainer>
							</td>
							<td style="text-align:center; width:33%;padding: 0px 5px 0px 5px">
            					<table cellpadding="0" cellspacing="0" border="0" width="100%" style="margin: 0px 0px 0px 0px">
            					    <tr>
            					        <td>
								            <cc2:HorizontalActionContainer ID="ListViewDataManagementActionContainer" runat="server"
									            ContainerId="Filters" CssClass="HContainer" BorderWidth="0px" CellPadding="0" CellSpacing="0" style="margin: 0px 5px 0px 5px">
								            </cc2:HorizontalActionContainer>
            					        </td>
            					        <td>
								            <cc2:HorizontalActionContainer ID="TopRecordEditActionContainer" runat="server" HorizontalAlign="Center"
									            CssClass="HContainer" ContainerId="RecordEdit" BorderWidth="0px" CellPadding="0" CellSpacing="0" style="margin: 0px 5px 0px 5px">
								            </cc2:HorizontalActionContainer>
            					        </td>
            					    </tr>
            					</table>
							</td>
							<td style="text-align:right; width:33%">
								<cc2:HorizontalActionContainer ID="ViewPresentationActionContainer" runat="server"
									ContainerId="View" CssClass="HContainer" BorderWidth="0px" CellPadding="0" CellSpacing="0">
								</cc2:HorizontalActionContainer>
							</td>
						</tr>
					</table>
					<tc:ErrorInfoControl ID="ErrorInfo" style="margin: 10px 0px 10px 0px" runat="server">
                    </tc:ErrorInfoControl>
                    <asp:Table ID="Table1" runat="server" Width="100%" CellPadding="0" CellSpacing="0">
                        <asp:TableRow runat="server">
                            <asp:TableCell runat="server" ID="ViewSite">views content here</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
					<cc2:HorizontalActionContainer ID="BottomRecordEditActionContainer" runat="server"
						HorizontalAlign="Center" Visible="false" CssClass="HContainer" Style="padding-top: 10px"
						ContainerId="RecordEdit" BorderWidth="0px" CellPadding="0" CellSpacing="0">
					</cc2:HorizontalActionContainer>
				</td>
			</tr>
			<tr>
				<td>
					<div class="Spacer NullSize" style="width: 200px"></div>
				</td>
				<td align="center" style="padding-top: 20px">
            	    <div id="Spacer" class="Spacer"></div>
				</td>
			</tr>
		</table>
		<div id="Footer" class="Footer">
		<table cellpadding="0" cellspacing="0" border="0" width="100%"><tr>
		<td align="left"><div class="FooterCopyright"><asp:Literal runat="server" ID="Copyright">Copyright text</asp:Literal></div></td>
		<td><cc2:WrappedHorizontalActionContainer ID="DiagnosticActionContainer" runat="server"
						HorizontalAlign="Left" ContainerId="Diagnostic" CssClass="HContainer" BorderWidth="0px" CellPadding="0" CellSpacing="0">
					</cc2:WrappedHorizontalActionContainer>
        </td>
		<td align="right"><asp:Image ID="LogoImage" runat="server" /></td>
		</tr></table></div>
		</td></tr></table>
	<script type="text/javascript">
	<!--
	    function OnLoad() {
	        DXMoveFooter();
            DXattachEventToElement(document.getElementById('formTable'), "resize", DXWindowOnResize);
            DXattachEventToElement(window, "resize", DXWindowOnResize);
        }
    //-->	    
	</script>
	</div>
	</form>
		</body>
</html>
