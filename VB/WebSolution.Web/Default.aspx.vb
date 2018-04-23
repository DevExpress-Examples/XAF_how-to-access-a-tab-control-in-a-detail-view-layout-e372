Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Web.UI
Imports System.Drawing
Imports System.Web.UI.WebControls

Imports DevExpress.ExpressApp.Templates
Imports DevExpress.ExpressApp.Web
Imports DevExpress.Persistent.Base
Imports DevExpress.ExpressApp.Utils
Imports DevExpress.ExpressApp.Web.TestScripts
Imports DevExpress.ExpressApp

Partial Public Class [Default]
	Inherits System.Web.UI.Page
	Implements IWindowTemplate, IViewSiteTemplate, ISupportViewControlAdding
	Private contextMenu As ContextActionsMenu
	Protected Overrides Sub InitializeCulture()
		MyBase.InitializeCulture()
		WebApplication.Instance.InitializeCulture()
	End Sub
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		contextMenu = New ContextActionsMenu(Me, "RecordEdit", "ObjectsCreation", "ListView")
		Header.Title = WebApplication.Instance.Title
		ApplicationTitle.Text = WebApplication.Instance.Title
		ApplicationTitle.NavigateUrl = Request.ApplicationPath & "/"
		Copyright.Text = WebApplication.Instance.Info.GetAttributeValue("Copyright")
		Dim logoImageInfo As ImageInfo = ImageLoader.Instance.GetImageInfo(WebApplication.Instance.Info.GetAttributeValue("Logo", "ExpressAppLogo"))
		If (Not logoImageInfo.IsEmpty) Then
			LogoImage.ImageUrl = logoImageInfo.ImageUrl
		Else
			LogoImage.Visible = False
		End If
		WebApplication.Instance.CreateControls(Me)
	End Sub
	Protected Sub Page_Prerender(ByVal sender As Object, ByVal e As EventArgs)
		If TestScriptsManager.EasyTestEnabled Then
			ViewCaption.Attributes(EasyTestTagHelper.TestField) = "FormCaption"
			ViewCaption.Attributes(EasyTestTagHelper.TestControlClassName) = JSLabelTestControl.ClassName
		End If
	End Sub
	Public Overrides Sub Dispose()
		If contextMenu IsNot Nothing Then
			contextMenu.Dispose()
			contextMenu = Nothing
		End If
		MyBase.Dispose()
	End Sub

	#Region "IFrameTemplate Members"

	Public ReadOnly Property DefaultContainer() As IActionContainer Implements DevExpress.ExpressApp.Templates.IFrameTemplate.DefaultContainer
		Get
			Return ViewPresentationActionContainer
		End Get
	End Property

	Public Function GetContainers() As ICollection(Of IActionContainer) Implements DevExpress.ExpressApp.Templates.IFrameTemplate.GetContainers
		Dim result As List(Of IActionContainer) = New List(Of IActionContainer)()
		result.AddRange(contextMenu.Containers)
			'!!!
			'!!!
		result.AddRange(New IActionContainer() { NavigationBarActionContainer1, SearchActionContainer, ContextObjectsCreationActionContainer, RecordsNavigationContainer, ListViewDataManagementActionContainer, ViewPresentationActionContainer, TopRecordEditActionContainer, BottomRecordEditActionContainer, DiagnosticActionContainer, ViewsHistoryNavigationContainer })
		Return result.ToArray()
	End Function

	Public Sub SetView(ByVal view As DevExpress.ExpressApp.View) Implements DevExpress.ExpressApp.Templates.IFrameTemplate.SetView
		ViewSite.Controls.Clear()
		If view IsNot Nothing Then
			contextMenu.CreateControls(view)
			view.CreateControls()
			RaiseEvent ViewControlAdding(Me, EventArgs.Empty)
			ViewSite.Controls.Add(CType(view.Control, Control))
			view.DataBind()
			ViewCaption.Text = view.Caption

			Dim imageInfo As ImageInfo = ImageLoader.Instance.GetLargeImageInfo(view.Info.GetAttributeValue("ImageName"))
			If imageInfo.IsEmpty Then
				ViewImage.Visible = False
			Else
				ViewImage.ImageUrl = imageInfo.ImageUrl
			End If
			Dim colorString As String = view.Info.GetAttributeValue("BackColor")
			If (Not String.IsNullOrEmpty(colorString)) Then
				Try
					Dim _color As KnownColor = CType(System.Enum.Parse(GetType(KnownColor), colorString), KnownColor)
					ViewTitle.BackColor = Color.FromKnownColor(_color)
				Catch e1 As Exception
				End Try
			End If
		End If
	End Sub

	Public Sub SetSettings(ByVal settingsNode As DictionaryNode)
	End Sub
	Public Sub ReloadSettings()
	End Sub
	Public Sub SaveSettings()
	End Sub

	Public Sub SetCaption(ByVal caption As String) Implements IWindowTemplate.SetCaption
		Header.Title = caption
	End Sub

	Public Sub SetStatus(ByVal statusMessages As System.Collections.Generic.ICollection(Of String)) Implements IWindowTemplate.SetStatus
		InfoMessagesPanel.Text = String.Join("<br>", New List(Of String)(statusMessages).ToArray())
	End Sub
	Private isSizeable_Renamed As Boolean
	Public Property IsSizeable() As Boolean Implements IWindowTemplate.IsSizeable
		Get
			Return isSizeable_Renamed
		End Get
		Set(ByVal value As Boolean)
			isSizeable_Renamed = value
		End Set
	End Property
	Public ReadOnly Property ViewSiteControl() As Object Implements IViewSiteTemplate.ViewSiteControl
		Get
			Return ViewSite
		End Get
	End Property
	Public Event ViewControlAdding As EventHandler Implements ISupportViewControlAdding.ViewControlAdding
	#End Region
End Class
