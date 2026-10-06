# Microsoft Developer Studio Project File - Name="WaldLib" - Package Owner=<4>
# Microsoft Developer Studio Generated Build File, Format Version 5.00
# ** DO NOT EDIT **

# TARGTYPE "Win32 (x86) Dynamic-Link Library" 0x0102

CFG=WaldLib - Win32 Debug
!MESSAGE This is not a valid makefile. To build this project using NMAKE,
!MESSAGE use the Export Makefile command and run
!MESSAGE 
!MESSAGE NMAKE /f "WaldLib.mak".
!MESSAGE 
!MESSAGE You can specify a configuration when running NMAKE
!MESSAGE by defining the macro CFG on the command line. For example:
!MESSAGE 
!MESSAGE NMAKE /f "WaldLib.mak" CFG="WaldLib - Win32 Debug"
!MESSAGE 
!MESSAGE Possible choices for configuration are:
!MESSAGE 
!MESSAGE "WaldLib - Win32 Release" (based on\
 "Win32 (x86) Dynamic-Link Library")
!MESSAGE "WaldLib - Win32 Debug" (based on "Win32 (x86) Dynamic-Link Library")
!MESSAGE 

# Begin Project
# PROP Scc_ProjName ""
# PROP Scc_LocalPath ""
F90=df.exe
MTL=midl.exe
RSC=rc.exe

!IF  "$(CFG)" == "WaldLib - Win32 Release"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 0
# PROP BASE Output_Dir "Release"
# PROP BASE Intermediate_Dir "Release"
# PROP BASE Target_Dir ""
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 0
# PROP Output_Dir "Release"
# PROP Intermediate_Dir "Release"
# PROP Ignore_Export_Lib 0
# PROP Target_Dir ""
# ADD BASE F90 /include:"Release/" /compile_only /nologo /libs:dll /warn:nofileopt /dll
# ADD F90 /include:"Release/" /compile_only /nologo /warn:declarations /libs:dll /warn:argument_checking /warn:errors /warn:nofileopt /dll
# SUBTRACT F90 /warn:stderrors
# ADD BASE MTL /nologo /D "NDEBUG" /mktyplib203 /o NUL /win32
# ADD MTL /nologo /D "NDEBUG" /mktyplib203 /o NUL /win32
# ADD BASE RSC /l 0x410 /d "NDEBUG"
# ADD RSC /l 0x410 /d "NDEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 kernel32.lib /nologo /subsystem:windows /dll /machine:I386
# ADD LINK32 kernel32.lib /nologo /subsystem:windows /dll /machine:I386 /out:"C:\Documents and Settings\Leonardo\Documenti\Visual Studio 2005\Projects\Lancio\Wald.NET\Dll\WaldLib.dll"

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

# PROP BASE Use_MFC 0
# PROP BASE Use_Debug_Libraries 1
# PROP BASE Output_Dir "Debug"
# PROP BASE Intermediate_Dir "Debug"
# PROP BASE Target_Dir ""
# PROP Use_MFC 0
# PROP Use_Debug_Libraries 1
# PROP Output_Dir "Debug"
# PROP Intermediate_Dir "Debug"
# PROP Ignore_Export_Lib 0
# PROP Target_Dir ""
# ADD BASE F90 /include:"Debug/" /compile_only /nologo /libs:dll /debug:full /optimize:0 /warn:nofileopt /dll
# ADD F90 /include:"Debug/" /compile_only /nologo /libs:dll /debug:full /optimize:0 /warn:nofileopt /dll
# ADD BASE MTL /nologo /D "_DEBUG" /mktyplib203 /o NUL /win32
# ADD MTL /nologo /D "_DEBUG" /mktyplib203 /o NUL /win32
# ADD BASE RSC /l 0x410 /d "_DEBUG"
# ADD RSC /l 0x410 /d "_DEBUG"
BSC32=bscmake.exe
# ADD BASE BSC32 /nologo
# ADD BSC32 /nologo
LINK32=link.exe
# ADD BASE LINK32 kernel32.lib /nologo /subsystem:windows /dll /debug /machine:I386 /pdbtype:sept
# ADD LINK32 kernel32.lib /nologo /subsystem:windows /dll /incremental:no /debug /machine:I386 /out:"C:/WINNT/SYSTEM32/WaldLib.dll" /pdbtype:sept

!ENDIF 

# Begin Target

# Name "WaldLib - Win32 Release"
# Name "WaldLib - Win32 Debug"
# Begin Source File

SOURCE=.\Block1DLL.for

!IF  "$(CFG)" == "WaldLib - Win32 Release"

DEP_F90_BLOCK=\
	".\General.fi"\
	".\SELVA.FI"\
	".\WATER.FI"\
	

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

DEP_F90_BLOCK=\
	".\SELVA.FI"\
	

!ENDIF 

# End Source File
# Begin Source File

SOURCE=.\Block2DLL.for

!IF  "$(CFG)" == "WaldLib - Win32 Release"

DEP_F90_BLOCK2=\
	".\General.fi"\
	".\SELVA.FI"\
	".\WATER.FI"\
	

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

DEP_F90_BLOCK2=\
	".\SELVA.FI"\
	

!ENDIF 

# End Source File
# Begin Source File

SOURCE=.\Block3DLL.for

!IF  "$(CFG)" == "WaldLib - Win32 Release"

DEP_F90_BLOCK3=\
	".\General.fi"\
	".\SELVA.FI"\
	".\WATER.FI"\
	

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

DEP_F90_BLOCK3=\
	".\SELVA.FI"\
	

!ENDIF 

# End Source File
# Begin Source File

SOURCE=.\Block4DLL.for

!IF  "$(CFG)" == "WaldLib - Win32 Release"

DEP_F90_BLOCK4=\
	".\General.fi"\
	".\SELVA.FI"\
	".\WATER.FI"\
	

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

DEP_F90_BLOCK4=\
	".\SELVA.FI"\
	

!ENDIF 

# End Source File
# Begin Source File

SOURCE=.\Block5DLL.for

!IF  "$(CFG)" == "WaldLib - Win32 Release"

DEP_F90_BLOCK5=\
	".\CLUBLO.FI"\
	".\DENSLK.FI"\
	".\General.fi"\
	".\KAPBLO.FI"\
	".\MINMAX.FI"\
	".\SELVA.FI"\
	".\VISLIH.FI"\
	".\VISLIK.FI"\
	".\WATER.FI"\
	

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

DEP_F90_BLOCK5=\
	".\SELVA.FI"\
	

!ENDIF 

# End Source File
# Begin Source File

SOURCE=.\LetbanDLL.for

!IF  "$(CFG)" == "WaldLib - Win32 Release"

DEP_F90_LETBA=\
	".\General.fi"\
	".\SELVA.FI"\
	".\WATER.FI"\
	

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

DEP_F90_LETBA=\
	".\SELVA.FI"\
	

!ENDIF 

# End Source File
# Begin Source File

SOURCE=.\Level1DLL.for

!IF  "$(CFG)" == "WaldLib - Win32 Release"

DEP_F90_LEVEL=\
	".\ACRISI.FI"\
	".\DETTAGLI.FI"\
	".\General.fi"\
	".\HYPOT.FI"\
	".\SOLUZ.FI"\
	".\WATER.FI"\
	

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

!ENDIF 

# End Source File
# Begin Source File

SOURCE=.\Level2DLL.for

!IF  "$(CFG)" == "WaldLib - Win32 Release"

DEP_F90_LEVEL2=\
	".\ACRISI.FI"\
	".\DENSLK.FI"\
	".\DETTAGLI.FI"\
	".\General.fi"\
	".\LEVEL2.FI"\
	".\SOLUZ.FI"\
	".\VISLIH.FI"\
	".\VISLIK.FI"\
	".\WATER.FI"\
	

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

DEP_F90_LEVEL2=\
	".\LEVEL2.FI"\
	

!ENDIF 

# End Source File
# Begin Source File

SOURCE=.\Level3aDLL.for

!IF  "$(CFG)" == "WaldLib - Win32 Release"

DEP_F90_LEVEL3=\
	".\ACRISI.FI"\
	".\DETTAGLI.FI"\
	".\FER.FI"\
	".\FERW.FI"\
	".\General.fi"\
	".\INCR1.FI"\
	".\INCRW1.FI"\
	".\SOLUZ.FI"\
	".\WATER.FI"\
	

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

!ENDIF 

# End Source File
# Begin Source File

SOURCE=.\Level3DLL.for

!IF  "$(CFG)" == "WaldLib - Win32 Release"

DEP_F90_LEVEL3D=\
	".\ACRISI.FI"\
	".\CLUBLO.FI"\
	".\DETTAGLI.FI"\
	".\FER.FI"\
	".\FERW.FI"\
	".\General.fi"\
	".\HYPOT.FI"\
	".\INCR1.FI"\
	".\INCRW1.FI"\
	".\KAPBLOA.FI"\
	".\MINMAX.FI"\
	".\SOLUZ.FI"\
	".\TITLE.FI"\
	".\WATER.FI"\
	

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

!ENDIF 

# End Source File
# Begin Source File

SOURCE=.\NselvaDLL.for

!IF  "$(CFG)" == "WaldLib - Win32 Release"

DEP_F90_NSELV=\
	".\DETTAGLI.FI"\
	".\General.fi"\
	".\HYPOT.FI"\
	".\Ris.for"\
	".\SOLUZ.FI"\
	".\TITLE.FI"\
	

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

DEP_F90_NSELV=\
	".\Ris.for"\
	

!ENDIF 

# End Source File
# Begin Source File

SOURCE=.\OutputDLL.for

!IF  "$(CFG)" == "WaldLib - Win32 Release"

DEP_F90_OUTPU=\
	".\DETTAGLI.FI"\
	".\FER.FI"\
	".\FERW.FI"\
	".\General.fi"\
	".\Ris.for"\
	".\SOLUZ.FI"\
	".\TITLE.FI"\
	".\WATER.FI"\
	

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

DEP_F90_OUTPU=\
	".\Ris.for"\
	

!ENDIF 

# End Source File
# Begin Source File

SOURCE=.\Proc1DLL.for

!IF  "$(CFG)" == "WaldLib - Win32 Release"

DEP_F90_PROC1=\
	".\General.fi"\
	".\SOLUZ.FI"\
	".\WATER.FI"\
	

!ELSEIF  "$(CFG)" == "WaldLib - Win32 Debug"

!ENDIF 

# End Source File
# End Target
# End Project
