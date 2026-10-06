Option Strict Off
Option Explicit On
<System.Runtime.InteropServices.ProgId("Tasks_NET.Tasks")> Public Class Tasks
	
	Private Const DEST_TEXT As Short = 0
	Private Const DEST_PIC As Short = 1
	Private Const MNU_COPY As Short = 0
	Private Const MNU_PASTE As Short = 1
	Private Const MNU_PASTELINK As Short = 2
	Private Const NONE As Short = 0
	' LinkMode (forms and controls)
	' Run time errors
	Private Const NO_APP_RESPONDED As Short = 282
	Private Const DDE_REFUSED As Short = 285
	Private Const NILL As Short = 0
	Private Const WM_SYSCOMMAND As Short = &H112s
	Private Const SC_CLOSE As Short = &HF060s
	
	'Declare constants used by GetWindow
	Private Const GW_CHILD As Short = 5
	Private Const GW_HWNDFIRST As Short = 0
	Private Const GW_HWNDLAST As Short = 1
	Private Const GW_HWNDNEXT As Short = 2
	Private Const GW_HWNDPREV As Short = 3
	Private Const GW_OWNER As Short = 4
	'* Windows API function declarations
	'Declare Function GetWindow Lib "user" (ByVal hwnd, ByVal wCmd) As Integer
	Private Declare Function GetWindow Lib "user32" (ByVal hwnd As Integer, ByVal wCmd As Integer) As Integer
	'Declare Function GetWindowText Lib "user" (ByVal hwnd, ByVal lpSting$, ByVal nMaxCount) As Integer
	Private Declare Function GetWindowText Lib "user32"  Alias "GetWindowTextA"(ByVal hwnd As Integer, ByVal lpString As String, ByVal cch As Integer) As Integer
	'Declare Function GetWindowTextLength Lib "user" (ByVal hwnd) As Integer
	Private Declare Function GetWindowTextLength Lib "user32"  Alias "GetWindowTextLengthA"(ByVal hwnd As Integer) As Integer
	'Declare Function SendMessage& Lib "user" (ByVal hwnd%, ByVal wMsg%, ByVal wParam%, ByVal lParam As Long)
	Private Declare Function SendMessage Lib "user32"  Alias "SendMessageA"(ByVal hwnd As Integer, ByVal wMsg As Integer, ByVal wParam As Integer, ByRef lParam As Integer) As Integer
	Private Finito As Boolean
	
	
	'Sub ChiudiWinWord()
	'         Word.Application.Quit
	'End Sub
	
	'FIXIT: Dichiarare "Ctl" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
	Function CreateLink(ByRef Ctl As Object, ByRef appname As String, ByRef topic As String, ByRef Item As String, ByRef LinkType As Short) As Short
		On Error Resume Next
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.LinkMode. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		'UPGRADE_ISSUE: La costante vbLinkNone non è stata aggiornata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2070"'
		Ctl.LinkMode = vbLinkNone
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.LinkTopic. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		Ctl.LinkTopic = appname & "|" & topic
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.LinkItem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		Ctl.LinkItem = Item
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.LinkMode. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		Ctl.LinkMode = LinkType
		CreateLink = Err.Number
		'UPGRADE_ISSUE: La costante vbLinkAutomatic non è stata aggiornata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2070"'
		If Err.Number = 0 And LinkType <> vbLinkAutomatic Then
			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.LinkRequest. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			Ctl.LinkRequest()
		End If
	End Function
	
	'FIXIT: Dichiarare "Ctl" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
	Function IdentificaTask(ByRef Task As String, ByRef Ctl As Object) As String
		Dim i As Short
		On Error GoTo ErrIT
		Call LoadTaskList(Ctl)
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.ListCount. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		For i = 0 To Ctl.ListCount - 1
			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.List. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			If InStr(UCase(Ctl.List(i)), UCase(Task)) Then
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.List. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				IdentificaTask = Ctl.List(i)
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.ListIndex. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				Ctl.ListIndex = i
				Exit Function
			End If
		Next 
ExErr: 
		On Error GoTo 0
		IdentificaTask = ""
		Exit Function
ErrIT: ' MsgBox "IdentificaTask" + Error
		Resume ExErr 'End
	End Function
	
	'FIXIT: Dichiarare "Ctl" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
	Sub IdentificaTaskTutti(ByRef Task As String, ByRef Ctl As Object, ByRef Trovato() As String, ByRef Ntot As Short)
		On Error GoTo ErrITT
		'FIXIT: Dichiarare "i" con un tipo di dati ad associazione anticipata                      FixIT90210ae-R1672-R1B8ZE
		Dim i As Object
		Dim j As Short
		If Finito Then Exit Sub
		Call LoadTaskList(Ctl)
		Trovato(0) = ""
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.ListCount. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		For i = 0 To Ctl.ListCount - 1
			If Finito Then Exit Sub
			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.List. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			If InStr(UCase(Ctl.List(i)), UCase(Task)) Then
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.List. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				Trovato(j) = Ctl.List(i)
				If j = Ntot - 1 Then Exit For
				j = j + 1
			End If
		Next 
ExITT: 
		On Error GoTo 0
		Trovato(j + 1) = ""
		Exit Sub
ErrITT: Resume ExITT
		'MsgBox "IdentificaTaskTutti" + Error
		'End
	End Sub
	
	'FIXIT: Dichiarare "Ctl" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
	Sub LoadTaskList(ByRef Ctl As Object)
		Dim CurrWnd, Eventi, Length As Integer
		Dim ListItem As String
		On Error GoTo ErrLTL
		If Finito Then Exit Sub
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.Clear. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		Ctl.Clear()
		'Get the hWnd of the first item in the master list
		'so we can process the task list entries (top-level only).
10: 'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.Parent. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		CurrWnd = GetWindow(Ctl.Parent.hwnd, GW_HWNDFIRST)
		' Loop while the hWnd returned by GetWindow is valid.
		While CurrWnd <> 0
			'Get the length of the task name identified by CurrWnd in the list.
20: Length = GetWindowTextLength(CurrWnd)
			'Get the task name of the task in the master list.
22: ListItem = Space(Length + 1)
23: Length = GetWindowText(CurrWnd, ListItem, Length + 1)
			If Length > 0 Then
				If Finito Then Exit Sub
				'FIXIT: Sostituire la funzione "Left" con la funzione "Left$"                              FixIT90210ae-R9757-R1B8ZE
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.AddItem. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				Ctl.AddItem(Left(ListItem, Length) & "|" & Str(CurrWnd))
			End If
			'Get the next task list item in the master list.
25: CurrWnd = GetWindow(CurrWnd, GW_HWNDNEXT)
			'UPGRADE_ISSUE: DoEvents non restituisce alcun valore. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1022"'
			Eventi = System.Windows.Forms.Application.DoEvents()
		End While
ExLTL: 
		On Error GoTo 0
		Exit Sub
ErrLTL: Resume ExLTL
		'MsgBox "LoadTaskList " + Error + "(" + Str$(Err) + Str$(Erl) + ")"
		'End
	End Sub
	
	'FIXIT: Dichiarare "Ctl" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
	Sub Uccidi(ByRef Titolo As String, ByRef Ctl As Object)
		Dim Length, Eventi, CurrWnd As Integer
		Dim ListItem As String
		On Error GoTo ErrUccidi
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.Parent. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		CurrWnd = GetWindow(Ctl.Parent.hwnd, GW_HWNDFIRST)
		While CurrWnd <> 0
			Length = GetWindowTextLength(CurrWnd)
			ListItem = Space(Length + 1)
			Length = GetWindowText(CurrWnd, ListItem, Length + 1)
			If Length > 0 Then
				If InStr(ListItem, Titolo) Then
					Eventi = SendMessage(CurrWnd, WM_SYSCOMMAND, SC_CLOSE, NILL)
					'UPGRADE_ISSUE: DoEvents non restituisce alcun valore. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1022"'
					Eventi = System.Windows.Forms.Application.DoEvents()
					Exit Sub
				End If
			End If
			CurrWnd = GetWindow(CurrWnd, GW_HWNDNEXT)
			'UPGRADE_ISSUE: DoEvents non restituisce alcun valore. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1022"'
			Eventi = System.Windows.Forms.Application.DoEvents()
		End While
ExUccidi: 
		On Error GoTo 0
		Exit Sub
ErrUccidi: 
		Resume ExUccidi
		'MsgBox "Uccidi" + Error
		'End
	End Sub
	
	
	'FIXIT: Dichiarare "Ctl" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
	Function IdentificaTaskS(ByRef Task As String, ByRef Ctl As Object) As String
		Dim i As Short
		On Error GoTo ErrITS
		Call LoadTaskList(Ctl)
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.ListCount. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		For i = 0 To Ctl.ListCount - 1
			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.List. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			If Ctl.List(i) = Task Then
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto Ctl.List. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				IdentificaTaskS = Ctl.List(i)
				Exit Function
			End If
		Next 
ExITS: 
		On Error GoTo 0
		IdentificaTaskS = ""
		Exit Function
ErrITS: 
		Resume ExITS
		'MsgBox "IdentificaTaskS" + Error
		'End
	End Function
	
	
	Public Sub Smetti()
		Finito = True
	End Sub
End Class