Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports System.Web.UI
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.Web.ASPxTabControl
Imports System.Drawing
Imports DevExpress.ExpressApp.Layout
Imports DevExpress.ExpressApp.Web.Layout
Imports DevExpress.ExpressApp.Model

Namespace MainDemo.Module.Web
	Partial Public Class CustomizeASPxTabControlViewController
		Inherits ViewController
		Public Sub New()
			InitializeComponent()
			RegisterActions(components)
			TargetViewType = ViewType.DetailView
		End Sub
		Protected Overrides Overloads Sub OnActivated()
			MyBase.OnActivated()
			AddHandler (CType((CType(View, DetailView)).LayoutManager, WebLayoutManager)).ItemCreated, AddressOf CustomizeASPxTabControlViewController_ItemCreated
		End Sub
		Private Sub CustomizeASPxTabControlViewController_ItemCreated(ByVal sender As Object, ByVal e As ItemCreatedEventArgs)
			If TypeOf e.ModelLayoutElement Is IModelTabbedGroup Then
				CustomizeASPxTabControl(FindFirstControl(Of ASPxTabControlBase)(e.TemplateContainer))
			End If
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
		Private Sub CustomizeASPxTabControl(ByVal tabControl As ASPxTabControlBase)
			tabControl.ActiveTabStyle.Border.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
			tabControl.ActiveTabStyle.Border.BorderWidth = 5
			tabControl.ActiveTabStyle.Border.BorderColor = Color.Red
		End Sub
	End Class
End Namespace