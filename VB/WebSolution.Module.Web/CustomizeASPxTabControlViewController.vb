Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.ExpressApp
Imports System.Web.UI
Imports DevExpress.ExpressApp.Editors
Imports DevExpress.Web.ASPxTabControl
Imports System.Drawing

Namespace MainDemo.Module.Web
	Partial Public Class CustomizeASPxTabControlViewController
		Inherits ViewController
		Public Sub New()
			InitializeComponent()
			RegisterActions(components)
			TargetViewType = ViewType.DetailView
		End Sub
		Protected Overrides Sub OnActivated()
			MyBase.OnActivated()
			AddHandler View.ControlsCreated, AddressOf View_ControlsCreated
		End Sub
		Protected Overrides Sub OnDeactivating()
			RemoveHandler View.ControlsCreated, AddressOf View_ControlsCreated
			MyBase.OnDeactivating()
		End Sub
		Private Sub View_ControlsCreated(ByVal sender As Object, ByVal e As EventArgs)
			AddHandler (CType(View.Control, Control)).PreRender, AddressOf CustomizeASPxTabControlViewController_PreRender
		End Sub
		Private Sub CustomizeASPxTabControlViewController_PreRender(ByVal sender As Object, ByVal e As EventArgs)
			RemoveHandler (CType(View.Control, Control)).PreRender, AddressOf CustomizeASPxTabControlViewController_PreRender
			Dim detailView As DetailView = CType(View, DetailView)
			For Each editor As ListPropertyEditor In detailView.GetItems(Of ListPropertyEditor)()
				Dim tabControl As ASPxTabControlBase = TryCast(FindASPxTabControl(TryCast(editor.Control, Control)), ASPxTabControlBase)
				If tabControl IsNot Nothing Then
					CustomizeASPxTabControl(tabControl)
				End If
			Next editor
		End Sub
		Private Function FindASPxTabControl(ByVal control As Control) As Control
			If control Is Nothing OrElse TypeOf control Is ASPxTabControlBase Then
				Return control
			Else
				Return FindASPxTabControl(control.Parent)
			End If
		End Function
		Private Sub CustomizeASPxTabControl(ByVal tabControl As ASPxTabControlBase)
			tabControl.ContentStyle.Border.BorderStyle = System.Web.UI.WebControls.BorderStyle.Solid
			tabControl.ContentStyle.Border.BorderWidth = 5
			tabControl.ContentStyle.Border.BorderColor = Color.Red
		End Sub
	End Class
End Namespace