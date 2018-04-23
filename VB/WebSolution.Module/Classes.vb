Imports Microsoft.VisualBasic
Imports System

Imports DevExpress.Xpo

Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace WebSolution.Module
	<DefaultClassOptions> _
	Public Class MyPerson
		Inherits Person
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		<Association("MyPerson-MyTasks")> _
		Public ReadOnly Property MyTasks() As XPCollection(Of MyTask)
			Get
				Return GetCollection(Of MyTask)("MyTasks")
			End Get
		End Property
	End Class
	Public Class MyTask
		Inherits Task
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Private _myPerson As MyPerson
		<Association("MyPerson-MyTasks")> _
		Public Property MyPerson() As MyPerson
			Get
				Return _myPerson
			End Get
			Set(ByVal value As MyPerson)
				SetPropertyValue("MyPerson", _myPerson, value)
			End Set
		End Property
	End Class
End Namespace
