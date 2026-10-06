/// This code has been changed by Anup Shinde.
/// contact: anup@micromacs.com   ...:)

/// The original code is written by Matthias Haenel
/// contact: www.intercopmu.de
/// Code was received from: http://www.codeproject.com/cs/miscctrl/winwordcontrol.asp
/// 
/// you can use it free of charge, but please 
/// mention my name ;)
/// 
/// WinWordControl utilizes MS-WinWord2000 and 
/// WinWord-XP


using System;
//using System.Collections;
using System.ComponentModel;
using System.Drawing;
//using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace WinWordControl
{
	/// <summary>
	/// WinWordControl allows you to load doc-Files to your
	/// own application without any loss, because it uses 
	/// the real WinWord.
	/// </summary>
	public class WinWordControl : System.Windows.Forms.UserControl
	{
		#region "API usage declarations"

		[DllImport("user32.dll")]
		public static extern int FindWindow(string strclassName, string strWindowName);

		[DllImport("user32.dll")]
		static extern int SetParent( int hWndChild, int hWndNewParent);

		[DllImport("user32.dll", EntryPoint="SetWindowPos")]
		static extern bool SetWindowPos(
			int hWnd,               // handle to window
			int hWndInsertAfter,    // placement-order handle
			int X,                  // horizontal position
			int Y,                  // vertical position
			int cx,                 // width
			int cy,                 // height
			uint uFlags             // window-positioning options
			);
		
		[DllImport("user32.dll", EntryPoint="MoveWindow")]
		static extern bool MoveWindow(
			int hWnd, 
			int X, 
			int Y, 
			int nWidth, 
			int nHeight, 
			bool bRepaint
			);

		[DllImport("user32.dll", EntryPoint="DrawMenuBar")]
		static extern Int32 DrawMenuBar(
			Int32 hWnd
			);

		[DllImport("user32.dll", EntryPoint="GetMenuItemCount")]
		static extern Int32 GetMenuItemCount(
			Int32 hMenu
			);

		[DllImport("user32.dll", EntryPoint="GetSystemMenu")]
		static extern Int32 GetSystemMenu(
			Int32 hWnd,
			bool bRevert
			);

		[DllImport("user32.dll", EntryPoint="RemoveMenu")]
		static extern Int32 RemoveMenu(
			Int32 hMenu,
			Int32 nPosition,
			Int32 wFlags
			);

		
		private const int MF_BYPOSITION = 0x400;
		private const int MF_REMOVE = 0x1000;

		
		const int SWP_DRAWFRAME = 0x20;
		const int SWP_NOMOVE = 0x2;
		const int SWP_NOSIZE = 0x1;
		const int SWP_NOZORDER = 0x4;

		#endregion

				

		/* I was testing wheater i could fix some exploid bugs or not.
		 * I left this stuff in here for people who need to know how to 
		 * interface the Win32-API

		[StructLayout(LayoutKind.Sequential)]
			public struct RECT 
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}
		
		[DllImport("user32.dll")]
		public static extern int GetWindowRect(int hwnd, ref RECT rc);
		
		[DllImport("user32.dll")]
		public static extern IntPtr PostMessage(
			int hWnd, 
			int msg, 
			int wParam, 
			int lParam
		);
		*/


		/// <summary>
		/// Change. Made the following variables public.
		/// </summary>

		public  Microsoft.Office.Interop.Word.Document document;
        public static Microsoft.Office.Interop.Word.ApplicationClass wd = null;
		public  static int wordWnd				= 0;
		public static string filename			= null;
		private static bool	deactivateevents	= false;
        private static bool DisplayRulers;
		//private static bool MenuAggiustato      = false;

		/// <summary>
		/// needed designer variable
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WinWordControl()
		{
			InitializeComponent();
		}
		/// <summary>
		/// cleanup Ressources
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			CloseControl();
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// !do not alter this code! It's designer code
		/// </summary>
		private void InitializeComponent()
		{
			// 
			// WinWordControl
			// 
			this.Name = "WinWordControl";
			this.Size = new Size(440, 336);
			this.Resize += new EventHandler(this.OnResize);			
		}
		#endregion


		/// <summary>
		/// Preactivation
		/// It's usefull, if you need more speed in the main Program
		/// so you can preload Word.
		/// </summary>
		public void PreActivate()
		{
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			deactivateevents = true;
			if(wd == null) wd = new Microsoft.Office.Interop.Word.ApplicationClass();
			try 
			{
				wd.CommandBars.AdaptiveMenus = false;
				wd.DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(   OnClose);
				//wd.NewDocument += new Word.ApplicationEvents2_NewDocumentEventHandler(OnNewDoc);
				//wd.DocumentOpen+= new Word.ApplicationEvents2_DocumentOpenEventHandler(OnOpenDoc);
                wd.ApplicationEvents2_Event_Quit += new Microsoft.Office.Interop.Word.ApplicationEvents2_QuitEventHandler(OnQuit);
			}
			catch{}
			wordWnd = FindWindow( "Opusapp", null);
			SetParent( wordWnd, this.Handle.ToInt32());				
			deactivateevents = false;
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default;
		}


		/// <summary>
		/// Close the current Document in the control --> you can 
		/// load a new one with LoadDocument
		/// </summary>
		public void CloseControl()
		{
			try
			{
				deactivateevents = true;
				object dummy=null;
				object dummy1= Microsoft.Office.Interop.Word.WdSaveOptions.wdSaveChanges;
				if(document!=null)
				document.Close(ref dummy1 , ref dummy, ref dummy);
				deactivateevents = false;
			}
			catch(Exception ex)
			{
				String strErr = ex.Message;
			}
		}


		/// <summary>
		/// catches Word's close event 
		/// starts a Thread that send a ESC to the word window ;)
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="test"></param>
		private void OnClose(Microsoft.Office.Interop.Word.Document doc, ref bool cancel)
		{
			if(!deactivateevents)
			{
				cancel=true; //perché mai? perché bisogna chiudere da CloseControl
			}
		}

		/// <summary>
		/// catches Word's open event
		/// just close
		/// </summary>
		/// <param name="doc"></param>
		/*private void OnOpenDoc(Word.Document doc)
		{
			OnNewDoc(doc);
		}
		/// <summary>
		/// catches Word's newdocument event
		/// just close
		/// </summary>
		/// <param name="doc"></param>
		private void OnNewDoc(Word.Document doc)
		{
			if(!deactivateevents)
			{
				deactivateevents=true;
				object dummy = null;
				doc.Close(ref dummy,ref dummy,ref dummy);
				deactivateevents=false;
			}
		}
*/

		/// <summary>
		/// catches Word's quit event
		/// normally it should not fire, but just to be shure
		/// safely release the internal Word Instance 
		/// </summary>
		private void OnQuit()
		{/* Nuova versione
			if (File.Exists(NormalSave))
			{
				File.Copy(NormalSave,NormalDot,true);
				File.Delete(NormalSave);}*/
			wd=null;
		}


		/// <summary>
		/// Loads a document into the control
		/// </summary>
		/// <param name="t_filename">path to the file (every type word can handle)</param>
		public void LoadDocument(string t_filename)
	    {
			filename = t_filename;
		
			if(wd == null) PreActivate();
			deactivateevents = true;

			if(document != null) 
			{
				try
				{
					object dummy=null;
					wd.Documents.Close(ref dummy, ref dummy, ref dummy);
				}
				catch{}
			}

			if (wordWnd!=0)
			{
				object fileName = filename;
				object newTemplate = false;
				object docType = 0;
				object isVisible = true;
			
				try
				{
					if( wd == null ){throw new WordInstanceException();}
					if( wd.Documents == null ){throw new DocumentInstanceException();}
					if( wd != null && wd.Documents != null )
					{
						document = wd.Documents.Add(ref fileName, ref newTemplate, ref docType, ref isVisible);
					}
					if(document == null){throw new ValidDocumentException();}
				}
				catch(Exception e){MessageBox.Show(e.Message +'\r'+e.StackTrace);}

/* impossibile aprire il modello del documento
        try{
			
		wd.ActiveDocument.UpdateStylesOnOpen = false;
    	object templateName=(object)mioTemplate;
		interessante //object missing = System.Reflection.Missing.Value; 
		interessante //wd.ActiveDocument.Range(ref missing,ref missing).Text = "Test"; 
		wd.ActiveDocument.set_AttachedTemplate(ref templateName); // "C:\\Programmi\\LancioNET\\Arch\\mioNormal.dot";
		no in Word 2000? //wd.ActiveDocument.XMLSchemaReferences.AutomaticValidation = true;
        no in Word 2000? //wd.ActiveDocument.XMLSchemaReferences.AllowSaveAsXMLWithoutValidation = false;
        wd.ActiveDocument.ToggleFormsDesign();
		wd.CommandBars["Control Toolbox"].Visible = false;}
		catch(Exception e){MessageBox.Show(e.Message +'\r'+e.StackTrace);}

*/				
				
				try
				{
					//wd.ActiveWindow.DisplayRightRuler=true;
					//wd.ActiveWindow.DisplayScreenTips=false;
					//wd.ActiveWindow.DisplayVerticalRuler=true;
                    DisplayRulers=wd.ActiveWindow.ActivePane.DisplayRulers;
					wd.ActiveWindow.ActivePane.DisplayRulers=false;
					wd.ActiveWindow.ActivePane.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdPrintView; 
					//wd.DisplayRecentFiles=false;
					//wd.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView;//wdWebView; // .wdNormalView;
				}
				catch
				{

				}
				/* nuova versione

            if(!MenuAggiustato){
            	AggiustaMenu();
	            MenuAggiustato=true;}
*/				
				// Show the word-document
				try
				{
					wd.Visible = true;
					try{wd.Activate();}
					catch{}
				
					SetWindowPos(wordWnd,this.Handle.ToInt32(),0,0,this.Bounds.Width,this.Bounds.Height, SWP_NOZORDER | SWP_NOMOVE | SWP_DRAWFRAME | SWP_NOSIZE);
					
					//Call onresize--I dont want to write the same lines twice
					OnResize();
				}
				catch(Exception e)
				{
					MessageBox.Show("Error: do not load the document into the control until the parent window is shown!"+e.Message+e.StackTrace);
				}



				this.Parent.Focus();
				
			}
			deactivateevents = false;
		}

		private void AggiustaMenu()
		{
			/// Code Added
			/// Disable the specific buttons of the command bar
			/// By default, we disable/hide the menu bar
			/// The New/Open buttons of the command bar are disabled
			/// Other things can be added as required (and supported ..:) )
			/// Lots of commented code in here, if somebody needs to disable specific menu or sub-menu items.
			/// 
			const int nProibiti=9;
			int[] Proibiti=new int[nProibiti]
										  {
												  18, //&Nuovo
											  2520,
											  23, //&Apri
											  106, //C&hiudi
											  3823, //Salva pagina web
											  3655, //Anteprima web
											  1, //Esporta
											  752, //Esci
											  178}; //Schermo intero
			int counter = wd.ActiveWindow.Application.CommandBars.Count;
			for(int i = 1; i <= counter;i++)
			{
				try
				{
					String nm=wd.ActiveWindow.Application.CommandBars[i].Name;
					if(nm=="Standard"|nm=="Formatting"|nm=="Menu Bar"|
						nm=="Full Screen"|nm=="Word for Windows 2.0")
						for(int k=0;k<nProibiti;k++)
						{
							object missing=System.Reflection.Missing.Value;
							Microsoft.Office.Core.CommandBarControl c;
							c=wd.ActiveWindow.Application.CommandBars[i].FindControl(missing, Proibiti[k], missing, missing,true);
							if(c!=null)
							{
								c.Enabled=false;
							}
						}
					else
					{wd.ActiveWindow.Application.CommandBars[i].Enabled=false;}
				}
				catch(Exception ex)
				{
					MessageBox.Show(ex.ToString());						
				}
			}

			/// We want to remove the system menu also. The title bar is not visible, but we want to avoid accidental minimize, maximize, etc ..by disabling the system menu(Alt+Space)
			try
			{
				int hMenu = GetSystemMenu(wordWnd, false);
				if(hMenu>0)
				{
					int	menuItemCount = GetMenuItemCount(hMenu);
					RemoveMenu(hMenu, menuItemCount - 1, MF_REMOVE | MF_BYPOSITION);
					RemoveMenu(hMenu, menuItemCount - 2, MF_REMOVE | MF_BYPOSITION);
					RemoveMenu(hMenu, menuItemCount - 3, MF_REMOVE | MF_BYPOSITION);
					RemoveMenu(hMenu, menuItemCount - 4, MF_REMOVE | MF_BYPOSITION);
					RemoveMenu(hMenu, menuItemCount - 5, MF_REMOVE | MF_BYPOSITION);
					RemoveMenu(hMenu, menuItemCount - 6, MF_REMOVE | MF_BYPOSITION);
					RemoveMenu(hMenu, menuItemCount - 7, MF_REMOVE | MF_BYPOSITION);
					RemoveMenu(hMenu, menuItemCount - 8, MF_REMOVE | MF_BYPOSITION);
					DrawMenuBar(wordWnd);
				}
			}
			catch{};
		}
		/// <summary>
		/// restores Word.
		/// If the program crashed somehow.
		/// Sometimes Word saves it's temporary settings :(
		/// </summary>
		public void RestoreWord()
		{
			try
			{
		        wd.ActiveWindow.ActivePane.DisplayRulers=DisplayRulers;
				int counter = wd.ActiveWindow.Application.CommandBars.Count;
				for(int i = 0; i < counter;i++)
				{
					try
					{
						wd.ActiveWindow.Application.CommandBars[i].Reset();
					}
					catch
					{

					}
				}
			}
			catch{};
			
		}

		/// <summary>
		/// internal resize function
		/// utilizes the size of the surrounding control
		/// 
		/// optimzed for Word2000 but it works pretty good with WordXP too.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void OnResize()
		{
			//The original one that I used is shown below. Shows the complete window, but its buttons (min, max, restore) are disabled
			//// MoveWindow(wordWnd,0,0,this.Bounds.Width,this.Bounds.Height,true);


			///Change below
			///The following one is better, if it works for you. We donot need the title bar any way. Based on a suggestion.
			int borderWidth = SystemInformation.Border3DSize.Width;
			int borderHeight = SystemInformation.Border3DSize.Height;
			int captionHeight = SystemInformation.CaptionHeight;
			int statusHeight = SystemInformation.ToolWindowCaptionHeight;
			MoveWindow(
				wordWnd, 
				-2*borderWidth,
				-2*borderHeight - captionHeight, 
				this.Bounds.Width + 4*borderWidth, 
				this.Bounds.Height + captionHeight + 4*borderHeight + statusHeight,
				true);

		}

		private void OnResize(object sender, System.EventArgs e)
		{
			OnResize();
		}


		/// Required. 
		/// Without this, the command bar buttons that have been disabled 
		/// will remain disabled permanently (does not occur at every machine or every time)
		public void RestoreNormal()
		{
			deactivateevents = true;
			object dummy=null;
			object dummy2=Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
			CloseControl();
			if(wd != null)
			{
                RestoreWord();
				wd.Quit( ref dummy2,  ref dummy, ref dummy);
 			}
			deactivateevents = false;
		}
	}
	public class DocumentInstanceException : Exception
	{}
	
	public class ValidDocumentException : Exception
	{}

	public class WordInstanceException : Exception
	{}


}
