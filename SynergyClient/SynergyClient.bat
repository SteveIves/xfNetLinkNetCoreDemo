IF EXIST "D:\xfNetLinkNetCoreDemo\SynergyClient\bin\SynergyClient.dll" del "D:\xfNetLinkNetCoreDemo\SynergyClient\bin\SynergyClient.dll"
if '%1' == '-p' goto pooling
csc /nologo /target:library /out:"D:\xfNetLinkNetCoreDemo\SynergyClient\bin\SynergyClient.dll" /reference:"%XFNLNET%\xfnlnet.dll" /optimize %SYNCSCOPT% @SynergyClient.rsp
goto done
:pooling
csc /nologo /target:library /define:POOLING /out:"D:\xfNetLinkNetCoreDemo\SynergyClient\bin\SynergyClient.dll" /reference:"%XFNLNET%\xfnlnet.dll" /optimize %SYNCSCOPT% @SynergyClient.rsp
:done
