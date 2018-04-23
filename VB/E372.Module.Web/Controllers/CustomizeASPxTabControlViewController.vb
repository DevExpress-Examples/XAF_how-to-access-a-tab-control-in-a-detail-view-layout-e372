Imports System.Web.UI
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Model
Imports DevExpress.Web.ASPxTabControl
Imports DevExpress.ExpressApp.Web.Layout

Namespace E372.Module.Web
	Partial Public Class CustomizeASPxTabControlViewController
		Inherits ViewController(Of DetailView)
		Protected Overrides Overloads Sub OnActivated()
			MyBase.OnActivated()
			AddHandler (CType((CType(View, DetailView)).LayoutManager, WebLayoutManager)).ItemCreated, AddressOf CustomizeASPxTabControlViewController_ItemCreated
		End Sub
		Private Sub CustomizeASPxTabControlViewController_ItemCreated(ByVal sender As Object, ByVal e As ItemCreatedEventArgs)
			If TypeOf e.ModelLayoutElement Is IModelTabbedGroup AndAlso e.TemplateContainer IsNot Nothing Then
				AddHandler e.TemplateContainer.Load, AddressOf TemplateContainer_Load
			End If
		End Sub
		Private Sub TemplateContainer_Load(ByVal sender As Object, ByVal e As EventArgs)
			Dim control As Control = CType(sender, Control)
			RemoveHandler control.Load, AddressOf TemplateContainer_Load
			CustomizeASPxTabControl(FindFirstControl(Of ASPxTabControlBase)(control))
		End Sub
		Private Function FindFirstControl(Of T As Control)(ByVal parent As Control) As T
			For Each control As Control In parent.Controls
				If TypeOf control Is T Then
					Return CType(control, T)
				End If
			Next control
			For Each control As Control In parent.Controls
				Return FindFirstControl(Of T)(control)
			Next control
			Return Nothing
		End Function
		Protected Overrides Overloads Sub OnDeactivated()
			RemoveHandler (CType((CType(View, DetailView)).LayoutManager, WebLayoutManager)).ItemCreated, AddressOf CustomizeASPxTabControlViewController_ItemCreated
			MyBase.OnDeactivated()
		End Sub
		Private Shared Sub CustomizeASPxTabControl(ByVal tabControl As ASPxTabControlBase)
			tabControl.ActiveTabStyle.Border.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
			tabControl.ActiveTabStyle.Border.BorderWidth = 5
			tabControl.ActiveTabStyle.Border.BorderColor = Color.Red
		End Sub
	End Class
End Namespace