@echo off
pushd %~dp0
setlocal

PATH=%XFNLNET%;%PATH%

echo Exporting method catalog...
dbs DBLDIR:genxml -f SynergyClient.xml -i SynergyMethods -d .\SMC -s .\SMC -m .\Repository\rpsmain.ism -t .\Repository\rpstext.ism -n

echo Generating client code
gencs -f SMC\SynergyClient.xml -d SynergyClient -n SynergyClient -o SynergyClient\bin -nr -nd 

endlocal
popd