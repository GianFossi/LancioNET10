'UPGRADE_WARNING: L'intero progetto deve essere compilato una volta prima di poter visualizzare un form con una matrice di controlli ActiveX.

Imports System.ComponentModel

<ProvideProperty("Index",GetType(AxMSComCtl2.AxUpDown))> Public Class AxUpDownArray
	Inherits Microsoft.VisualBasic.Compatibility.VB6.BaseOcxArray
	Implements IExtenderProvider

	Public Sub New()
		MyBase.New()
	End Sub

	Public Sub New(ByVal Container As IContainer)
		MyBase.New(Container)
	End Sub

	Public Shadows Event [Change] (ByVal sender As System.Object, ByVal e As System.EventArgs)
	Public Shadows Event [DownClick] (ByVal sender As System.Object, ByVal e As System.EventArgs)
	Public Shadows Event [UpClick] (ByVal sender As System.Object, ByVal e As System.EventArgs)
	Public Shadows Event [MouseDownEvent] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_MouseDownEvent)
	Public Shadows Event [MouseMoveEvent] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_MouseMoveEvent)
	Public Shadows Event [MouseUpEvent] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_MouseUpEvent)
	Public Shadows Event [OLEStartDrag] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_OLEStartDragEvent)
	Public Shadows Event [OLEGiveFeedback] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_OLEGiveFeedbackEvent)
	Public Shadows Event [OLESetData] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_OLESetDataEvent)
	Public Shadows Event [OLECompleteDrag] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_OLECompleteDragEvent)
	Public Shadows Event [OLEDragOver] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_OLEDragOverEvent)
	Public Shadows Event [OLEDragDrop] (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_OLEDragDropEvent)

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function CanExtend(ByVal target As Object) As Boolean Implements IExtenderProvider.CanExtend
		If TypeOf target Is AxMSComCtl2.AxUpDown Then
			Return BaseCanExtend(target)
		End If
	End Function

	Public Function GetIndex(ByVal o As AxMSComCtl2.AxUpDown) As Short
		Return BaseGetIndex(o)
	End Function

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub SetIndex(ByVal o As AxMSComCtl2.AxUpDown, ByVal Index As Short)
		BaseSetIndex(o, Index)
	End Sub

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Function ShouldSerializeIndex(ByVal o As AxMSComCtl2.AxUpDown) As Boolean
		Return BaseShouldSerializeIndex(o)
	End Function

	<System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)> Public Sub ResetIndex(ByVal o As AxMSComCtl2.AxUpDown)
		BaseResetIndex(o)
	End Sub

	Default Public ReadOnly Property Item(ByVal Index As Short) As AxMSComCtl2.AxUpDown
		Get
			Item = CType(BaseGetItem(Index), AxMSComCtl2.AxUpDown)
		End Get
	End Property

	Protected Overrides Function GetControlInstanceType() As System.Type
		Return GetType(AxMSComCtl2.AxUpDown)
	End Function

	Protected Overrides Sub HookUpControlEvents(ByVal o As Object)
		Dim ctl As AxMSComCtl2.AxUpDown = CType(o, AxMSComCtl2.AxUpDown)
		MyBase.HookUpControlEvents(o)
		If Not ChangeEvent Is Nothing Then
			AddHandler ctl.Change, New System.EventHandler(AddressOf HandleChange)
		End If
		If Not DownClickEvent Is Nothing Then
			AddHandler ctl.DownClick, New System.EventHandler(AddressOf HandleDownClick)
		End If
		If Not UpClickEvent Is Nothing Then
			AddHandler ctl.UpClick, New System.EventHandler(AddressOf HandleUpClick)
		End If
		If Not MouseDownEventEvent Is Nothing Then
			AddHandler ctl.MouseDownEvent, New AxMSComCtl2.DUpDownEvents_MouseDownEventHandler(AddressOf HandleMouseDownEvent)
		End If
		If Not MouseMoveEventEvent Is Nothing Then
			AddHandler ctl.MouseMoveEvent, New AxMSComCtl2.DUpDownEvents_MouseMoveEventHandler(AddressOf HandleMouseMoveEvent)
		End If
		If Not MouseUpEventEvent Is Nothing Then
			AddHandler ctl.MouseUpEvent, New AxMSComCtl2.DUpDownEvents_MouseUpEventHandler(AddressOf HandleMouseUpEvent)
		End If
		If Not OLEStartDragEvent Is Nothing Then
			AddHandler ctl.OLEStartDrag, New AxMSComCtl2.DUpDownEvents_OLEStartDragEventHandler(AddressOf HandleOLEStartDrag)
		End If
		If Not OLEGiveFeedbackEvent Is Nothing Then
			AddHandler ctl.OLEGiveFeedback, New AxMSComCtl2.DUpDownEvents_OLEGiveFeedbackEventHandler(AddressOf HandleOLEGiveFeedback)
		End If
		If Not OLESetDataEvent Is Nothing Then
			AddHandler ctl.OLESetData, New AxMSComCtl2.DUpDownEvents_OLESetDataEventHandler(AddressOf HandleOLESetData)
		End If
		If Not OLECompleteDragEvent Is Nothing Then
			AddHandler ctl.OLECompleteDrag, New AxMSComCtl2.DUpDownEvents_OLECompleteDragEventHandler(AddressOf HandleOLECompleteDrag)
		End If
		If Not OLEDragOverEvent Is Nothing Then
			AddHandler ctl.OLEDragOver, New AxMSComCtl2.DUpDownEvents_OLEDragOverEventHandler(AddressOf HandleOLEDragOver)
		End If
		If Not OLEDragDropEvent Is Nothing Then
			AddHandler ctl.OLEDragDrop, New AxMSComCtl2.DUpDownEvents_OLEDragDropEventHandler(AddressOf HandleOLEDragDrop)
		End If
	End Sub

	Private Sub HandleChange (ByVal sender As System.Object, ByVal e As System.EventArgs) 
		RaiseEvent [Change] (sender, e)
	End Sub

	Private Sub HandleDownClick (ByVal sender As System.Object, ByVal e As System.EventArgs) 
		RaiseEvent [DownClick] (sender, e)
	End Sub

	Private Sub HandleUpClick (ByVal sender As System.Object, ByVal e As System.EventArgs) 
		RaiseEvent [UpClick] (sender, e)
	End Sub

	Private Sub HandleMouseDownEvent (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_MouseDownEvent) 
		RaiseEvent [MouseDownEvent] (sender, e)
	End Sub

	Private Sub HandleMouseMoveEvent (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_MouseMoveEvent) 
		RaiseEvent [MouseMoveEvent] (sender, e)
	End Sub

	Private Sub HandleMouseUpEvent (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_MouseUpEvent) 
		RaiseEvent [MouseUpEvent] (sender, e)
	End Sub

	Private Sub HandleOLEStartDrag (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_OLEStartDragEvent) 
		RaiseEvent [OLEStartDrag] (sender, e)
	End Sub

	Private Sub HandleOLEGiveFeedback (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_OLEGiveFeedbackEvent) 
		RaiseEvent [OLEGiveFeedback] (sender, e)
	End Sub

	Private Sub HandleOLESetData (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_OLESetDataEvent) 
		RaiseEvent [OLESetData] (sender, e)
	End Sub

	Private Sub HandleOLECompleteDrag (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_OLECompleteDragEvent) 
		RaiseEvent [OLECompleteDrag] (sender, e)
	End Sub

	Private Sub HandleOLEDragOver (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_OLEDragOverEvent) 
		RaiseEvent [OLEDragOver] (sender, e)
	End Sub

	Private Sub HandleOLEDragDrop (ByVal sender As System.Object, ByVal e As AxMSComCtl2.DUpDownEvents_OLEDragDropEvent) 
		RaiseEvent [OLEDragDrop] (sender, e)
	End Sub

End Class

