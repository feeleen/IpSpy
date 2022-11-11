set batpath=%~dp0
sc.exe create IpSpyService binpath= %batpath%bin\debug\net6.0\IpSpy.exe start= auto

sc start IpSpyService

pause