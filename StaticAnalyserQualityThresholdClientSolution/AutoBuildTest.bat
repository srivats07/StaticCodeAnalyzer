@echo off
set "BAT_PATH=%~dp0"



@echo off


call "C:\Program Files (x86)\Microsoft Visual Studio 12.0\Common7\Tools\VsDevCmd.bat"

echo %BAT_PATH%

echo Executing batch file


devenv "%BAT_PATH%\StaticAnalyserQualityThresholdClientSolution.sln" /build Debug 
pause
 

pause
 
set "SIM_PATH=C:\Users\320067390\Downloads\Simian\bin"

echo %SIM_PATH%

cd "%SIM_PATH%"

simian-2.5.10.exe "%BAT_PATH%\**\*.cs"  

pause

cd "%BAT_PATH%StaticAnalyserQualityThresholdConsoleClient\bin\Debug"


call %BAT_PATH%StaticAnalyserQualityThresholdConsoleClient\bin\Debug\StaticAnalyserQualityThresholdConsoleClient.exe


pause