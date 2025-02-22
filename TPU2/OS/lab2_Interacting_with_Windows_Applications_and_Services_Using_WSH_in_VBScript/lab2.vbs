set vShell = WScript.CreateObject("WScript.Shell")

dim fso, f1, ts, s
set fso = CreateObject("Scripting.FileSystemObject")

set f = fso.GetFile(Wscript.ScriptFullName)
path = fso.GetParentFolderName(f)

set ts = fso.OpenTextFile(path&"\X.txt", 1)
s = ts.ReadLine()
ts.Close
set objRegExp = CreateObject("VBScript.RegExp")
objRegExp.Global = True
objRegExp.Pattern = "[^0-9]"
set objMatches = objRegExp.Execute(s)
if (objMatches.Count) then
MsgBox "Please, use only numbers in "&path&"\X.txt", 0, "Error"
else
	set vNote = vShell.Exec("notepad.exe")
	WScript.Sleep(500)
	set vCalc = vShell.Exec("calc.exe")
	WScript.Sleep(500)

	vShell.AppActivate(vCalc.ProcessID)
	WScript.Sleep(500)	
	vShell.SendKeys("9")
	WScript.Sleep(500)
	vShell.SendKeys("*")
	WScript.Sleep(500)
	vShell.SendKeys(s)
	WScript.Sleep(500)
	vShell.SendKeys("=")
	WScript.Sleep(500)
	vShell.SendKeys("^c")
	WScript.Sleep(500)	
	vShell.SendKeys("%{F4}")
	WScript.Sleep(500)

	notep = vShell.AppActivate(vNote.ProcessID)
	WScript.Sleep(500)
	if notep then vShell.SendKeys("^v")
	WScript.Sleep(500)
End If
