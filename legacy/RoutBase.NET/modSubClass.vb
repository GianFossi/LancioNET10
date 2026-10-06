Option Strict Off
Option Explicit On
Module modSubClass
	' *****************************************************
	' Code to subclass a Visual Basic form for
	' WM_HELP messaging for HTML Help purposes
	' Version 3.0b
	' (c)August 1999, Delmar Computing Services
	'
	' Developed by David Liske, Tipton, Michigan, USA
	' Microsoft HTML Help MVP
	' http://www.vbexplorer.com/htmlhelp.asp
	'
	' ATTENTION:
	' Due to the use of the AddressOf operator, this code
	' *will* crash the Visual Basic IDE in Debug mode.
	' If debugging of the application is necessary,
	' uncomment the first Exit Sub in the HHSubclass routine.
	' Again, this routine *cannot* be run in Debug mode.
	'
	' To use this module, the subclassed calling form
	' needs to have the following methods included:
	'
	' Public Sub OnContextMenu(hWndControl As Long)
	' Public Sub OnHelp(hWndControl As Long)
	' Public Sub OnNavComplete(phhnt As Long)
	' Public Sub OnTCard(wParam As Long, lParam As Long)
	' Public Sub OnTrack(phhnn As Long)
	' Public Sub OnWindowCreate(phhnt As Long)
	'
	' Please send any performance or functionality
	' modifications of this file to delmar@tc3net.com
	' Notification codes
	Private Const HHN_FIRST As Short = -860
	Private Const HHN_LAST As Short = -879
	
	Private Const HHN_NAVCOMPLETE As Short = HHN_FIRST
	Private Const HHN_TRACK As Short = HHN_FIRST - 1
	Private Const HHN_WINDOW_CREATE As Short = HHN_FIRST - 2
	
	Private Const HH_MAX_TABS As Short = 19
	
	'Windows messaging
	Private Const WM_CONTEXTMENU As Short = &H7Bs
	Private Const WM_HELP As Short = &H53s
	Private Const WM_NCDESTROY As Short = &H82s
	Private Const WM_NOTIFY As Short = &H4Es
	Private Const WM_TCARD As Short = &H52s
	Private Const WM_PAINT As Short = &HFs
	Private Const GWL_WNDPROC As Short = (-4)
	Private Const HELPINFO_MENUITEM As Short = 1 'da ricercare
	Private Const HELPINFO_WINDOW As Short = 2 'da ricercare
	
	'Keyboard API
	Public Const VK_F1 As Short = &H70s
	Public Const VK_NUMLOCK As Short = &H90s
	Public Const VK_CAPITAL As Short = &H14s
	Public Const VK_SCROLL As Short = &H91s
	
	' UDT for mouse cursor position
	Private Structure POINTAPI
		Dim X As Integer
		Dim y As Integer
	End Structure
	
	Private Structure HELPINFO
		Dim cbSize As Integer
		Dim iContextType As Integer 'vedi HELPINFO_
		Dim iCtrlId As Integer
		Dim hItemHandle As Integer
		Dim dwContextId As Integer
		Dim MousePos As POINTAPI
	End Structure
	
	Private Structure NMHDR
		Dim hwndFrom As Integer
		Dim idfrom As Integer
		Dim Code As Integer
	End Structure
	
	Private Structure RECT
		'UPGRADE_NOTE: Left è stato aggiornato a Left_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
		Dim Left_Renamed As Integer
		Dim Top As Integer
		'UPGRADE_NOTE: Right è stato aggiornato a Right_Renamed. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1061"'
		Dim Right_Renamed As Integer
		Dim Bottom As Integer
	End Structure
	
	' UDT for keyboard API
	Private Structure KeyboardBytes
		<VBFixedArray(255)> Dim kbByte() As Byte
		
		'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
		Public Sub Initialize()
			ReDim kbByte(255)
		End Sub
	End Structure
	
	'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura kbArray prima di poterle utilizzare. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1063"'
	Private kbArray As KeyboardBytes 'era public
	
	Private Structure HH_WINTYPE
		Dim cbStruct As Short ' IN: size of this structure including all
		' Information Types
		Dim fUniCodeStrings As Boolean ' IN/OUT: TRUE if all strings are in UNICODE
		Dim pszType As String ' IN/OUT: Name of a type of window
		Dim fsValidMembers As Object ' IN: Bit flag of valid members
		' (HHWIN_PARAM_)
		Dim fsWinProperties As Object ' IN/OUT: Properties/attributes of the window
		' (HHWIN_)
		Dim pszCaption As String ' IN/OUT: Window title
		Dim dwStyles As Object ' IN/OUT: Window styles
		Dim dwExStyles As Object ' IN/OUT: Extended Window styles
		Dim rcWindowPos As RECT ' IN: Starting position, OUT: current
		' position
		Dim nShowState As Short ' IN: show state (e.g., SW_SHOW)
		Dim hwndHelp As Object ' OUT: window handle
		Dim hwndCaller As Object ' OUT: who called this window
		' The following members are only valid if
		' HHWIN_PROP_TRI_PANE is set
		Dim hwndToolBar As Object ' OUT: toolbar window in tri-pane window
		Dim hwndNavigation As Object ' OUT: navigation window in tri-pane window
		Dim hwndHTML As Object ' OUT: window displaying HTML in tri-pane
		' window
		Dim iNavWidth As Short ' IN/OUT: width of navigation window
		Dim rcHTML As RECT ' OUT: HTML window coordinates
		Dim pszToc As String ' IN: Location of the table of contents file
		Dim pszIndex As String ' IN: Location of the index file
		Dim pszFile As String ' IN: Default location of the html file
		Dim pszHome As String ' IN/OUT: html file to display when Home
		' button is clicked
		Dim fsToolBarFlags As Object ' IN: flags controling the appearance of the
		' toolbar
		Dim fNotExpanded As Boolean ' IN: TRUE/FALSE to contract or expand, OUT:
		' current state
		Dim curNavType As Short ' IN/OUT: UI to display in the navigational
		' pane
		Dim tabpos As Short ' IN/OUT: HHWIN_NAVTAB_TOP, HHWIN_NAVTAB_LEFT,
		' or HHWIN_NAVTAB_BOTTOM
		Dim idNotify As Short ' IN: ID to use for WM_NOTIFY messages
		<VBFixedArray(HH_MAX_TABS + 1)> Dim tabOrder() As Byte ' IN/OUT: tab order: Contents, Index,
		' Search, History, Favorites, Reserved 1-5,
		' Custom tabs
		Dim cHistory As Short ' IN/OUT: number of history items to keep
		' (default is 30)
		Dim pszJump1 As String ' Text for HHWIN_BUTTON_JUMP1
		Dim pszJump2 As String ' Text for HHWIN_BUTTON_JUMP2
		Dim pszUrlJump1 As String ' URL for HHWIN_BUTTON_JUMP1
		Dim pszUrlJump2 As String ' URL for HHWIN_BUTTON_JUMP2
		Dim rcMinSize As RECT ' Minimum size for window (ignored in version
		' 1 of the Workshop)
		Dim cbInfoTypes As Short ' size of paInfoTypes;
		
		'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
		Public Sub Initialize()
			ReDim tabOrder(HH_MAX_TABS + 1)
		End Sub
	End Structure
	
	'UDT for the HHN_TRACK message
	Private Structure tagHHNTRACK
		Dim hdr As NMHDR
		Dim pszCurUrl As String
		Dim idAction As Short
		'UPGRADE_WARNING: È possibile che si debba inizializzare le matrici nella struttura phhWinType prima di poterle utilizzare. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1063"'
		Dim phhWinType As HH_WINTYPE
		
		'UPGRADE_TODO: "Initialize" deve essere chiamato per inizializzare istanze di questa struttura. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1026"'
		Public Sub Initialize()
			phhWinType.Initialize()
		End Sub
	End Structure
	
	'UDT for the HHN_NAVCOMPLETE and HHN_WINDOW_CREATE messages
	Private Structure tagHHN_NOTIFY
		Dim hdr As NMHDR
		Dim pszUrl As String
	End Structure
	'FIXIT: As Any non è supportato in Visual Basic .NET. Utilizzare un tipo specifico.        FixIT90210ae-R5608-H1984
	'UPGRADE_ISSUE: La dichiarazione di un parametro "As Any" non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1016"'
	Private Declare Function CallWindowProc Lib "user32"  Alias "CallWindowProcA"(ByVal lpPrevWndFunc As Integer, ByVal hwnd As Integer, ByVal msgWinMessage As Integer, ByVal wParam As Integer, ByRef lParam As Any) As Integer
	
	'FIXIT: As Any non è supportato in Visual Basic .NET. Utilizzare un tipo specifico.        FixIT90210ae-R5608-H1984
	'UPGRADE_ISSUE: La dichiarazione di un parametro "As Any" non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1016"'
	'UPGRADE_ISSUE: La dichiarazione di un parametro "As Any" non è supportata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1016"'
	Private Declare Sub CopyMemory Lib "kernel32"  Alias "RtlMoveMemory"(ByRef Dest As Any, ByRef Source As Any, ByVal nLen As Integer)
	
	Private Declare Function GetWindowLong Lib "user32"  Alias "GetWindowLongA"(ByVal hwnd As Integer, ByVal nIndex As Integer) As Integer
	
	Private Declare Function SetWindowLong Lib "user32"  Alias "SetWindowLongA"(ByVal hwnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer
	
	Public Declare Function GetKeyState Lib "user32" (ByVal nVirtKey As Integer) As Short
	
	'UPGRADE_WARNING: La struttura KeyboardBytes potrebbe richiedere attributi di marshalling da passare come argomento a questa istruzione Declare. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1050"'
	Public Declare Function SetKeyboardState Lib "user32" (ByRef kbArray As KeyboardBytes) As Integer
	
	Private colHTMLHelp As Collection
	' *****************************************************
	Private Function HHSubclassWndProc(ByVal hwnd As Integer, ByVal msgWinMessage As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer
		
		'FIXIT: Dichiarare "hHelp" con un tipo di dati ad associazione anticipata                  FixIT90210ae-R1672-R1B8ZE
		Dim hHelp As Object
		Dim c As System.Windows.Forms.Control
		Dim xMouse, yMouse As Integer
		On Error Resume Next
		' Loop through all the forms in the collection and use
		' the handle to determing the message the form belongs to
		If colHTMLHelp Is Nothing Then Exit Function
		For	Each hHelp In colHTMLHelp
			'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.hwnd. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
			If (hHelp.hwnd = hwnd) Then
				Exit For
			End If
		Next hHelp
		' Track down which message was sent and run the
		' appropriate procedure on the calling form
		Dim nmhHeader As NMHDR
		Dim hlpHelpInfo As HELPINFO
		Dim SaveScale As Integer
		Select Case (msgWinMessage)
			Case WM_CONTEXTMENU
				' The HELP_CONTEXTMENU command causes Help to
				' display a menu, which is system defined. The
				' menu contains a What's This command and allows
				' users to display Help for the control.
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				Call hHelp.frm.OnContextMenu(wParam)
				
			Case WM_HELP
				' The WM_HELP message is sent whenever the user
				' presses the F1 key.  It also occurs in response
				' to What's This Help requests.
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hlpHelpInfo. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				Call CopyMemory(hlpHelpInfo, lParam, Len(hlpHelpInfo))
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				With hHelp.frm
					'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
					If .hwnd = hlpHelpInfo.hItemHandle Then
						'UPGRADE_ISSUE: La costante vbTwips non è stata aggiornata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2070"'
						'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
						If Not .ScaleMode = vbTwips Then
							'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
							SaveScale = .ScaleMode
							'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
							'UPGRADE_ISSUE: La costante vbTwips non è stata aggiornata. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2070"'
							.ScaleMode = vbTwips
						Else
							SaveScale = -1
						End If
						'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
						xMouse = hlpHelpInfo.MousePos.X * VB6.TwipsPerPixelX - .Left - (.Width - .ScaleWidth)
						'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
						yMouse = hlpHelpInfo.MousePos.y * VB6.TwipsPerPixelY - .Top - (.Height - .ScaleHeight)
						On Error GoTo Errc
						'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
						For	Each c In .Controls
							'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
							If c.Parent Is hHelp.frm Then
								'FIXIT: "Width" non è una proprietà dell'oggetto generico "Control" in Visual Basic .NET. Per accedere a "Width" dichiarare "c" utilizzando il tipo attuale invece di "Control".     FixIT90210ae-R1460-RCFE85
								If (xMouse > VB6.PixelsToTwipsX(c.Left)) And (xMouse < (VB6.PixelsToTwipsX(c.Left) + VB6.PixelsToTwipsX(c.Width))) And (yMouse > VB6.PixelsToTwipsY(c.Top)) And (yMouse < (VB6.PixelsToTwipsY(c.Top) + VB6.PixelsToTwipsY(c.Height))) And c.Visible Then
									'FIXIT: "hwnd" non è una proprietà dell'oggetto generico "Control" in Visual Basic .NET. Per accedere a "hwnd" dichiarare "c" utilizzando il tipo attuale invece di "Control".     FixIT90210ae-R1460-RCFE85
									hlpHelpInfo.hItemHandle = c.Handle.ToInt32
									Exit For
									'forse bisognerebbe sceglierne uno in modo più intelligente
								End If
							End If
Resc: Next c
						On Error Resume Next
						'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
						If Not SaveScale = -1 Then .ScaleMode = SaveScale
					End If
					'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
					Call .OnHelp(hlpHelpInfo.hItemHandle)
				End With
			Case WM_NOTIFY
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto nmhHeader. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				Call CopyMemory(nmhHeader, lParam, Len(nmhHeader))
				
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto HHN_WINDOW_CREATE. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto HHN_TRACK. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto HHN_NAVCOMPLETE. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				Select Case (nmhHeader.Code)
					Case HHN_NAVCOMPLETE
						' Sent when the user successfully navigates to a
						' topic in a compiled HTML Help (.chm) file.
						' Uses the UDT tagHHN_NOTIFY.
						'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
						Call hHelp.frm.OnNavComplete(lParam)
						
					Case HHN_TRACK
						' Sent when a user clicks a button on the toolbar
						' or a tab in the Navigation pane of the HTML Help
						' Viewer. The message is sent before the action is
						' started by the viewer.  Uses the UDT tagHHNTRACK.
						'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
						Call hHelp.frm.OnTrack(lParam)
						
					Case HHN_WINDOW_CREATE
						' Sent right before an HTML Help window is created.
						' Uses the UDT tagHHN_NOTIFY.
						'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
						Call hHelp.frm.OnWindowCreate(lParam)
						
					Case Else
						' Let the message continue on its way
						'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.lpPrevWndFunc. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
						HHSubclassWndProc = CallWindowProc(hHelp.lpPrevWndFunc, hwnd, msgWinMessage, wParam, lParam)
						
				End Select
				
			Case WM_TCARD
				' The WM_TCARD message is sent to a program that
				' has initiated a training card based on Windows
				' Help technology.  Does not apply to training cards
				' created via embedded HTML Help.
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				Call hHelp.frm.OnTCard(wParam, lParam)
			Case WM_PAINT
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				Call hHelp.frm.OnTCard(wParam, lParam)
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.lpPrevWndFunc. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				HHSubclassWndProc = CallWindowProc(hHelp.lpPrevWndFunc, hwnd, msgWinMessage, wParam, lParam)
				
			Case Else
				' Let the message continue on its way
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto hHelp.lpPrevWndFunc. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				HHSubclassWndProc = CallWindowProc(hHelp.lpPrevWndFunc, hwnd, msgWinMessage, wParam, lParam)
				
		End Select
		
		Dim intCount As Short
		If (msgWinMessage = WM_NCDESTROY) Then
			' If the window no longer exists,
			' get it out of the HHSubclass collection
			For intCount = 1 To colHTMLHelp.Count()
				If (hHelp Is colHTMLHelp.Item(intCount)) Then
					Call colHTMLHelp.Remove(intCount)
					Exit For
				End If
			Next intCount
		End If
		Exit Function
Errc: Resume Resc
	End Function
	'FIXIT: Dichiarare "frm" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
	Sub clsHHSubclass(ByRef frm As Object)
		Dim Res As Integer
		Dim hHelp As HTMLHelp
		' Uncomment this line in Debug mode (see the
		' "Attention" section of the comment block for
		' this module):
		'
		Exit Sub
		hHelp = New HTMLHelp
		hHelp.frm = frm
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto frm.hwnd. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		hHelp.hwnd = frm.hwnd
		'UPGRADE_WARNING: Aggiungere un delegato per AddressOf HHSubclassWndProc. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1048"'
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto frm.hwnd. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		hHelp.lpPrevWndFunc = SetWindowLong(frm.hwnd, GWL_WNDPROC, AddressOf HHSubclassWndProc)
		' Put this form into the subclass collection
		' we created in the Declarations section
		If colHTMLHelp Is Nothing Then colHTMLHelp = New Collection
		colHTMLHelp.Add(hHelp)
	End Sub
	'FIXIT: Dichiarare "frm" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
	Sub clsHHUnSubClass(ByRef frm As Object)
		Dim hHelp As New HTMLHelp
		Dim i As Short
		Dim Res As Integer
		' Release the subclassed form
		If colHTMLHelp Is Nothing Then Exit Sub
		For	Each hHelp In colHTMLHelp
			If hHelp.frm Is frm Then
				'UPGRADE_NOTE: È possibile che l'oggetto hHelp.frm non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
				hHelp.frm = Nothing
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto frm.hwnd. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				Res = SetWindowLong(frm.hwnd, GWL_WNDPROC, hHelp.lpPrevWndFunc)
				For i = 1 To colHTMLHelp.Count()
					'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto colHTMLHelp(i).frm. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
					If Not colHTMLHelp.Item(i).frm Is Nothing Then Exit Sub
				Next 
				Do While colHTMLHelp.Count() > 0
					'     Set colHTMLHelp(1) = Nothing
					colHTMLHelp.Remove(1)
				Loop 
				'UPGRADE_NOTE: È possibile che l'oggetto colHTMLHelp non venga eliminato finché non venga raccolto nel Garbage Collector. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1029"'
				colHTMLHelp = Nothing
				Exit Sub
			End If
		Next hHelp
	End Sub
	'FIXIT: Dichiarare "frm" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
	Sub clsHHClose(ByRef frm As Object)
		Dim hHelp As HTMLHelp
		If colHTMLHelp Is Nothing Then Exit Sub
		For	Each hHelp In colHTMLHelp
			If (hHelp.frm Is frm) Then
				hHelp.HHClose()
				Exit Sub
			End If
		Next hHelp
		'Close any open Popup
		'????????? frm.SetFocus
		'If hHelp Is Nothing Then Exit Sub
		'  hHelp.HHClose
		'Set hHelp = Nothing
	End Sub
	'FIXIT: Dichiarare "frm" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
	Sub clsSetCHM(ByRef frm As Object, ByRef File As String)
		Dim hHelp As HTMLHelp
		If colHTMLHelp Is Nothing Then Exit Sub
		For	Each hHelp In colHTMLHelp
			If (hHelp.frm Is frm) Then
				Exit For
			End If
		Next hHelp
		If hHelp Is Nothing Then Exit Sub
		If hHelp.frm Is Nothing Then Exit Sub
		hHelp.CHMFile = File
	End Sub
	'FIXIT: Dichiarare "frm" con un tipo di dati ad associazione anticipata                    FixIT90210ae-R1672-R1B8ZE
	Public Sub clsOnHelp(ByRef frm As Object, ByRef hWndControl As Integer)
		' This procedure allows for the displaying of a Help
		' topic if the F1 key is pressed, or a popup topic if
		' the What's This button is clicked
		On Error GoTo ErrHandler
		Dim ctlControl As System.Windows.Forms.Control
		Dim errNumber As Short
		Dim intF1Key As Short
		Dim intNumLockKey As Short
		Dim intCapLockKey As Short
		Dim intScrollLockKey As Short
		Dim lngScan As Integer
		Dim strCustom As String
		Dim hHelp As HTMLHelp
		Dim MyTopic As Integer
		Dim Trovato As Boolean
		If colHTMLHelp Is Nothing Then
			' MsgBox "colHTMLHelp Is Nothing"
			Exit Sub
		End If
		For	Each hHelp In colHTMLHelp
			If (hHelp.frm Is frm) Then
				Exit For
			End If
		Next hHelp
		If hHelp Is Nothing Then
			' MsgBox "hHelp Is Nothing"
			Exit Sub
		End If
		' Get the latest state of the F1 key
		intF1Key = GetKeyState(VK_F1)
		' If F1 has been pressed, call the Help topic
		If (intF1Key = -127) Or (intF1Key = -128) Then
			' Call the Help topic
			'FIXIT: "HelpContextID" non è una proprietà dell'oggetto generico "Control" in Visual Basic .NET. Per accedere a "HelpContextID" dichiarare "ctlControl" utilizzando il tipo attuale invece di "Control".     FixIT90210ae-R1460-RCFE85
			'UPGRADE_ISSUE: Control proprietà ctlControl.HelpContextID non è stato aggiornato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2064"'
			MyTopic = ctlControl.HelpContextID
			With hHelp
				If MyTopic = 0 Then
					' MsgBox "HHDisplayContents"
					'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto frm.hwnd. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
					.HHDisplayContents(frm.hwnd) 'cmdHelp_Click
				Else
					.HHTopicID = MyTopic
					' MsgBox "HHDisplayTopicID"
					'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto frm.hwnd. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
					.HHDisplayTopicID(frm.hwnd)
				End If
			End With
			GoTo ExitRoutine
		End If
		' If F1 has not been pressed, display a popup by
		' looping through all the controls, finding the one
		' that matches the WM_HELP message parameter, and
		' using the info in the Tag property for the context ID
		Trovato = False
		'    Dim ifl As Integer
		'    ifl = FreeFile
		'    Open "C:\TEXT.TXT" For Output As #ifl
		'    Print #ifl, "Cerco "; str(hWndControl); str(frm.hwnd)
		'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto frm.Controls. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
		For	Each ctlControl In frm.Controls
			'      Print #ifl, ctlControl.Name; str(ctlControl.hwnd)
			'FIXIT: "hwnd" non è una proprietà dell'oggetto generico "Control" in Visual Basic .NET. Per accedere a "hwnd" dichiarare "ctlControl" utilizzando il tipo attuale invece di "Control".     FixIT90210ae-R1460-RCFE85
1000: If (ctlControl.Handle.ToInt32 = hWndControl) Then
				Trovato = True
1010: With hHelp
					' Set the popup type to CHM-based
					' .HHPopupType = HH_CHM_POPUP
					' Specify the CHM file and the internal
					' text popup file
					' .CHMFile = .HHSetHelpFile(1)
					' .HHPopupFile = .HHSetHelpFile(2)
					' Set the colors and text to match those
					' from a HH_TP_HELP_WM_HELP popup
					' .HHPopupCustomColors = True
					' .HHPopupCustomBackColor = &HFFFF
					' .HHPopupCustomTextColor = &HFFFF
					' .HHPopupTextSize = "8"
					' Get the context integer from the Tag property
					' .HHPopupID = CLng(ctlControl.Tag)
					' If the control has a Tag property, we're ok
					'FIXIT: "WhatsThisHelpID" non è una proprietà dell'oggetto generico "Control" in Visual Basic .NET. Per accedere a "WhatsThisHelpID" dichiarare "ctlControl" utilizzando il tipo attuale invece di "Control".     FixIT90210ae-R1460-RCFE85
1018: 'UPGRADE_ISSUE: Control proprietà ctlControl.WhatsThisHelpID non è stato aggiornato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2064"'
					MyTopic = ctlControl.WhatsThisHelpID
					If MyTopic < 0 Then
						.HHPopupID = -MyTopic
						.HHPopupFile = .HHSetHelpFile(3)
						.HHPopupType = HTMLHelp.PopupType.HH_CHM_POPUP
						.HHPopupCustomColors = False
						'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto frm.hwnd. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
						.HHDisplayPopup(frm.hwnd)
					Else
						'FIXIT: "HelpContextID" non è una proprietà dell'oggetto generico "Control" in Visual Basic .NET. Per accedere a "HelpContextID" dichiarare "ctlControl" utilizzando il tipo attuale invece di "Control".     FixIT90210ae-R1460-RCFE85
1020: 'UPGRADE_ISSUE: Control proprietà ctlControl.HelpContextID non è stato aggiornato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2064"'
						MyTopic = ctlControl.HelpContextID
						'FIXIT: "WhatsThisHelpID" non è una proprietà dell'oggetto generico "Control" in Visual Basic .NET. Per accedere a "WhatsThisHelpID" dichiarare "ctlControl" utilizzando il tipo attuale invece di "Control".     FixIT90210ae-R1460-RCFE85
1021: 'UPGRADE_ISSUE: Control proprietà ctlControl.WhatsThisHelpID non è stato aggiornato. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup2064"'
						If MyTopic = 0 Then MyTopic = ctlControl.WhatsThisHelpID
						If MyTopic > 0 Then
							.HHTopicID = MyTopic
							'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto frm.hwnd. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
							.HHDisplayTopicID(frm.hwnd)
						Else
							strCustom = "Non sono disponibili informazioni per questo oggetto"
							.HHPopupCustomColors = False
							.HHPopupText = strCustom
							.HHPopupType = HTMLHelp.PopupType.HH_TEXT_POPUP
							'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto frm.hwnd. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
							.HHDisplayPopup(frm.hwnd)
						End If
					End If
					'          If errNumber <> 438 Then
					'            ' Tag property is empty
					'            If ctlControl.Tag = "" Then
					'              ' No topic ID is specified in the Tag property,
					'              ' so send up a generic message in order to
					'              ' prevent HH error message.
					'              strCustom = "HHSubclass message:" & _
					''                  Chr(10) & _
					''                  "You need to yell at the Help author for " & _
					''                  "not creating a Help topic for this item!"
					'              .HHPopupText = strCustom
					'              .HHPopupType = HH_TEXT_POPUP
					'              .HHDisplayPopup Me.hwnd
					'            Else
					'              ' Display the specified CHM-based popup topic
					'              .HHDisplayPopup Me.hwnd
					'              errNumber = 0
					'            End If
					'          ' If the control doesn't have a Tag property,
					'          ' deal with it.
					'          Else
					'            errNumber = 0
					'          End If
				End With
				Exit For
			End If
2000: 
		Next ctlControl
		'Close #ifl
		If Not Trovato Then
			strCustom = "Probabilmente avete cliccato sulla finestra dove" & vbCrLf
			strCustom = strCustom & "non c'è alcun oggetto, o su di un'etichetta." & vbCrLf
			strCustom = strCustom & "Per ottenere informazioni bisogna cliccare sulle" & vbCrLf
			strCustom = strCustom & "sulle caselle a discesa, sui pulsanti, e su oggetti simili."
			With hHelp
				.HHPopupCustomColors = False
				.HHPopupText = strCustom
				.HHPopupType = HTMLHelp.PopupType.HH_TEXT_POPUP
				'UPGRADE_WARNING: Impossibile risolvere la proprietà predefinita dell'oggetto frm.hwnd. Fare clic qui per ulteriori informazioni: 'ms-help://MS.VSCC.2003/commoner/redir/redirect.htm?keyword="vbup1037"'
				.HHDisplayPopup(frm.hwnd)
			End With
		End If
ExitRoutine: 
		' Clear any previous F1 keypress,
		' but leave the Lock keys alone
		intNumLockKey = GetKeyState(VK_NUMLOCK)
		intCapLockKey = GetKeyState(VK_CAPITAL)
		intScrollLockKey = GetKeyState(VK_SCROLL)
		With kbArray
			.kbByte(VK_F1) = 0
			.kbByte(VK_NUMLOCK) = intNumLockKey
			.kbByte(VK_CAPITAL) = intCapLockKey
			.kbByte(VK_SCROLL) = intScrollLockKey
		End With
		SetKeyboardState(kbArray)
		Exit Sub
ErrHandler: 
		Select Case Err.Number
			Case 438
				Select Case Erl()
					Case 1000 : Resume 2000
					Case 1018 : MyTopic = 0 : Resume 1020
					Case 1020 : MyTopic = 0 : Resume 1021
					Case Else
						' The control being checked doesn't have a
						' Tag property, so set the variable to Err.Number
						' before it gets cleared
						errNumber = Err.Number
						Resume Next
				End Select
			Case Else
				' Nothing else to really be concerned with
				Resume Next
		End Select
	End Sub
End Module