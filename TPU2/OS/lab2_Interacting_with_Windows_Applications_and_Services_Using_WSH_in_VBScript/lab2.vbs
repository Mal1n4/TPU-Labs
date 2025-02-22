set vShell = WScript.CreateObject("WScript.Shell")

dim fso, f1, ts, s
set fso = CreateObject("Scripting.FileSystemObject")

set f = fso.GetFile(Wscript.ScriptFullName)
path = fso.GetParentFolderName(f)

set ts = fso.OpenTextFile(path&"\X.txt", 1)
s = ts.ReadLine()
ts.Close
set objRegexp = CreateObject("VBScript.RegExp")
objRegExp.Global = True
objRegExp.Pattern = "[^0-9]"
set objMatches = objRegExp.Execute(s)
if (objMatches.Count) then
MsgBox "Please, use only numbers in "&path&"\X.txt", 0, "Error"
else
	set vNote = vShell.Exec("notepad.exe")
	set vCalc = vShell.Exec("calc.exe")
	calcul = vShell.AppActivate(vCalc.ProcessID)
	if calcul then vShell.SendKeys("9*"&s&"=^c")
	WScript.Sleep(100)
	'vShell.SendKeys "9"
	'WScript.Sleep(100)
	'vShell.SendKeys "*"
	'WScript.Sleep(100)
	'for i=1 to len(s)
	'	cur_num=Mid(s,i,1)
	'	vShell.SendKeys cur_num
	'	WScript.Sleep(100)
	'next
	'vShell.SendKeys "="
	'WScript.Sleep(100)
	'vShell.SendKeys "^C"
	
	'MsgBox "To continue press ok"

	vCalc.Terminate
	notep = vShell.AppActivate(vNote.ProcessID)
	if notep then vShell.SendKeys("^v")
	WScript.Sleep(100)
End If

'set fso=CreateObject("Scripting.FileSystemObject")
'set f1=fso.CreateTextFile("c:\sum.txt", True)
'set ts=fso.OpenTextFile("%COMSPEC%\X.txt", ForReading)
'set s=ts.ReadLine

'MsgBox "Содержимое файла = '" & s & "'"
'ts.Close




'vShell.Run "calc1.exe", 1

