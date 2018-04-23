Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Web.Layout
Imports DevExpress.ExpressApp.Templates.ActionContainers

<ParentControlCssClass("NestedFrameControl")> _
Partial Public Class NestedFrameControl
	Inherits System.Web.UI.UserControl
	Implements IFrameTemplate, ISupportActionsToolbarVisibility, IDynamicContainersTemplate, IViewHolder
	Private contextMenu As ContextActionsMenu
	Private actionContainers As New ActionContainerCollection()
'INSTANT VB NOTE: The variable view was renamed since Visual Basic does not allow class members with the same name:
	Private view_Renamed As View
	Private Sub CurrentRequestWindow_PagePreRender(ByVal sender As Object, ByVal e As EventArgs)
		RemoveHandler WebWindow.CurrentRequestWindow.PagePreRender, AddressOf CurrentRequestWindow_PagePreRender
		If ToolBar IsNot Nothing Then
			If actionsToolbarVisibility_Renamed = ActionsToolbarVisibility.Hide Then
				ToolBar.Visible = False
			Else
				ToolBar.Visible = True
			End If
		End If
	End Sub
	Public Sub New()
		contextMenu = New ContextActionsMenu(Me, "Edit", "RecordEdit", "ListView")
		actionContainers.AddRange(contextMenu.Containers)
	End Sub
	Protected Overrides Sub OnLoad(ByVal e As EventArgs)
		MyBase.OnLoad(e)
		If WebWindow.CurrentRequestWindow IsNot Nothing Then
			AddHandler WebWindow.CurrentRequestWindow.PagePreRender, AddressOf CurrentRequestWindow_PagePreRender
		End If
	End Sub
	'B157146, B157117
	Public Overrides Sub Dispose()
		If ToolBar IsNot Nothing Then
			ToolBar.Dispose()
			ToolBar = Nothing
		End If
		If contextMenu IsNot Nothing Then
			contextMenu.Dispose()
			contextMenu = Nothing
		End If
		MyBase.Dispose()
	End Sub
	#Region "IFrameTemplate Members"
	Public ReadOnly Property DefaultContainer() As IActionContainer Implements IFrameTemplate.DefaultContainer
		Get
			Return ToolBar.FindActionContainerById("View")
		End Get
	End Property
	Public Function GetContainers() As ICollection(Of IActionContainer) Implements IFrameTemplate.GetContainers
		Return actionContainers.ToArray()
	End Function
	Public Sub SetView(ByVal view As DevExpress.ExpressApp.View) Implements IFrameTemplate.SetView
		Me.view_Renamed = view
		If view IsNot Nothing Then
			contextMenu.CreateControls(view)
		End If

		OnViewChanged(view)
	End Sub
	#End Region
	Protected Overridable Sub OnViewChanged(ByVal view As DevExpress.ExpressApp.View)
		RaiseEvent ViewChanged(Me, New TemplateViewChangedEventArgs(view))
	End Sub

	#Region "IActionBarVisibilityManager Members"
'INSTANT VB NOTE: The variable actionsToolbarVisibility was renamed since Visual Basic does not allow class members with the same name:
	Private actionsToolbarVisibility_Renamed As ActionsToolbarVisibility = ActionsToolbarVisibility.Default
	Public Property ActionsToolbarVisibility() As ActionsToolbarVisibility Implements ISupportActionsToolbarVisibility.ActionsToolbarVisibility
		Get
			Return actionsToolbarVisibility_Renamed
		End Get
		Set(ByVal value As ActionsToolbarVisibility)
			actionsToolbarVisibility_Renamed = value
		End Set
	End Property
	#End Region
	#Region "IDynamicContainersTemplate Members"
	Private Sub OnActionContainersChanged(ByVal args As ActionContainersChangedEventArgs)
		RaiseEvent ActionContainersChanged(Me, args)
	End Sub
	Public Sub RegisterActionContainers(ByVal actionContainers As IEnumerable(Of IActionContainer)) Implements IDynamicContainersTemplate.RegisterActionContainers
		Dim addedContainers As IEnumerable(Of IActionContainer) = Me.actionContainers.TryAdd(actionContainers)
		If DevExpress.ExpressApp.Utils.Enumerator.Count(addedContainers) > 0 Then
			OnActionContainersChanged(New ActionContainersChangedEventArgs(addedContainers, ActionContainersChangedType.Added))
		End If
	End Sub
	Public Sub UnregisterActionContainers(ByVal actionContainers As IEnumerable(Of IActionContainer)) Implements IDynamicContainersTemplate.UnregisterActionContainers
		Dim removedContainers As IList(Of IActionContainer) = New List(Of IActionContainer)()
		For Each actionContainer As IActionContainer In actionContainers
			If Me.actionContainers.Contains(actionContainer) Then
				Me.actionContainers.Remove(actionContainer)
				removedContainers.Add(actionContainer)
			End If
		Next actionContainer
		If DevExpress.ExpressApp.Utils.Enumerator.Count(removedContainers) > 0 Then
			OnActionContainersChanged(New ActionContainersChangedEventArgs(removedContainers, ActionContainersChangedType.Removed))
		End If
	End Sub
	Public Event ActionContainersChanged As EventHandler(Of ActionContainersChangedEventArgs) Implements IDynamicContainersTemplate.ActionContainersChanged
	#End Region
	Public ReadOnly Property View() As DevExpress.ExpressApp.View Implements IViewHolder.View
		Get
			Return view_Renamed
		End Get
	End Property

	#Region "ISupportViewChanged Members"

	Public Event ViewChanged As EventHandler(Of TemplateViewChangedEventArgs) Implements DevExpress.ExpressApp.Templates.ISupportViewChanged.ViewChanged

	#End Region
End Class
