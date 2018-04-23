<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" Inherits="NestedFrameControl" Codebehind="NestedFrameControl.ascx.cs" %>
<%@ Register Assembly="DevExpress.ExpressApp.Web.v8.2" Namespace="DevExpress.ExpressApp.Web.Templates.ActionContainers" TagPrefix="cc2" %>
<table class="NestedFrame" cellpadding="0" cellspacing="0">
	<tr>
		<td align="left">
			<table border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td class="NestedViewImage">
						<asp:Image ID="ViewImage" runat="server" ImageUrl="~/Images/ViewImage.png" />
					</td>
					<td style="height: 30px">
						<asp:Label ID="ViewCaption" CssClass="NestedViewCaption" runat="server" Text="Contact list" />
					</td>
				</tr>
			</table>
		</td>
		<td align="right" style="padding-bottom: 4px">
			<cc2:HorizontalActionContainer style="display:inline;margin-left:10px" ID="ContextObjectsCreationActionContainer" runat="server" ContainerId="ObjectsCreation" CssClass="HContainer"></cc2:HorizontalActionContainer>
			<cc2:HorizontalActionContainer style="display:inline;margin-left:10px" ID="RecordEditContainer" runat="server" ContainerId="RecordEdit" CssClass="HContainer"></cc2:HorizontalActionContainer>
			<cc2:HorizontalActionContainer style="display:inline;margin-left:10px" ID="ViewContainer" runat="server" ContainerId="View" CssClass="HContainer"></cc2:HorizontalActionContainer>
			<cc2:HorizontalActionContainer style="display:inline;margin-left:10px" ID="DiagnosticActionContainer" runat="server" ContainerId="Diagnostic" CssClass="HContainer"></cc2:HorizontalActionContainer>
			<cc2:HorizontalActionContainer style="display:inline;margin-left:10px" ID="FiltersActionContainer" runat="server" ContainerId="Filters" CssClass="HContainer"></cc2:HorizontalActionContainer>
		</td>
	</tr>
	<tr>
		<td colspan="2">
			<asp:Panel ID="ViewSite" runat="server"> </asp:Panel>
		</td>
	</tr>
</table>
