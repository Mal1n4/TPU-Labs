set vShell=WScript.CreateObject("WScript.Shell")
set objShellApp = CreateObject("Shell.Application")
set objFolder = objShellApp.NameSpace("D:\")
set objFolderItem = objFolder.ParseName("X")
MsgBox objFolderItem.Path