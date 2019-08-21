;#DropDB ACIMAppEasyTest

#Application ACIMApp.Win
#Application ACIMApp.Web

*FillForm
 User Name = Admin
*Action Log In

#IfDef ACIMApp.Win

*Action About...
 
*Action OK

#EndIf

#IfDef ACIMApp.Web
*Action Navigation(My Details)
#EndIf
