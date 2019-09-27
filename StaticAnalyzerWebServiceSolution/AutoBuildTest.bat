@echo off
@echo off
set "BAT_PATH=%~dp0"

@echo off


call "C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\Tools\VsDevCmd.bat"

echo %BAT_PATH%

echo Executing batch file

devenv "%BAT_PATH%\StaticAnalyzerWebServiceSolution.sln" /build

pause

"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" "%BAT_PATH%\FxCopDataParserLib.Test\bin\Debug\FxCopDataParserLib.Test.dll" /Tests:Given_File_When_ParseInvoked_Exptected_FileNotFound,Given_ValidXmlFileWith10Enteries_When_ParseMethodReturned_Exptected_ListSize10,Given_FileWithOneEntry_When_ParseInvoked_Exptected_ListOfOneEntry

"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" "%BAT_PATH%\FxCopToolLib.Test\bin\Debug\FxCopToolLib.Test.dll" /Tests:Given_NullInputToTool_When_ExecuteToolInvoked_Exptected_Exception,Given_NullExePathWithOtherNotNullValues_When_ExecuteToolInvoked_Exptected_Exception,Given_ValidArgument_When_ExecuteTool_Invoked_ExptectedWin32Exception,Given_InvlaidParmeters_When_ExecuteToolInvoked_Exptected_Exception

"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" "%BAT_PATH%\StyleCopDataParserLib.Test\bin\Debug\StyleCopDataParserLib.Test.dll"
/Tests:Given_InvalidFilePath_When_ParseInvoked_Exptected_FileNotFoundException,Given_FileWithOneEntry_When_ParseInvoked_Exptected_ListOfOneEntry,Given_ValidXmlFileWith10Enteries_When_ParseMethodReturned_Exptected_ListSizeOne

"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" "%BAT_PATH%\StyleCopToolLib.Test\bin\Debug\StyleCopToolLib.Test.dll"
/Tests:Given_NullInputToTool_When_ExecuteToolInvoked_Exptected_Exception,Given_NullExePathWithOtherNotNullValues_When_ExecuteToolInvoked_Exptected_Exception,Given_AllInvalidParmeters_When_ExecuteToolInvoked_Exptected_Exception,Given_InvalidExeParameter_When_ExecuteTool_Invoked_Exptected_Exception


"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" "%BAT_PATH%\ToolConfigurationLib.Test\bin\Debug\ToolConfigurationLib.Test.dll"
/Tests:Given_File_When_ReadToolInfoInvoked_Exptected_FileNotFound,Given_ValidFileWithTwoToolInfoEntry_When_ReadToolInfoInvoked_Exptected_ReturnedListSizeTwo,Given_ValidFile_When_ReadToolInfoInvoked_Exptected_EqualListValues


"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" "%BAT_PATH%\ToolDataCsvWriterLib.Test\bin\Debug\ToolDataCsvWriterLib.Test.dll"
/Tests:Given_InvalidFile_When_WriteInvoked_Exptected_Exception

"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" "%BAT_PATH%\ToolManagerLib.Test\bin\Debug\ToolManagerLib.Test.dll"
/Tests:Given_NullInput_When_StartSessionInvoked_Exptected_ArgumentNullException,When_ParseXMlFilesInvoked_Exptected_FileNotFoundException,When_EndSession_Invoked_Exptected_FileNotFoundException,Given_Parameters_When_EndSession_Invoked_Then_Expected_To_Call_Write_Method_Zero

"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" "%BAT_PATH%\ToolParserConfigurationLib.Test\bin\Debug\ToolParserConfigurationLib.Test.dll"
/Tests:Given_InvalidFile_When_ReadToolParserInfoInvoked_Exptected_FileNotFoundException,Given_ValidFileWithTwoEntry_When_ReadToolParserInfoReturned_Exptected_ListSizeTwo,Given_ValidFileWithTwoEntries_When_ReadToolParserInfoReturned_Exptected_ListWithTwoEntries


"C:\Program Files (x86)\Microsoft Visual Studio\2017\Professional\Common7\IDE\Extensions\TestPlatform\vstest.console.exe" "%BAT_PATH%\ToolRunnerLib.Test\bin\Debug\ToolRunnerLib.Test.dll"
/Tests:Given_NullListInputs_When_RunToolsInvoked_Exptected_Exception,Given_Parameters_When_RunToolsInvoked_Then_Expected_To_Call_ExecuteTool_Method_Zero,Given_Parameters_When_RunToolsInvoked_Then_Expected_To_Call_ExecuteTool_Method_Zero

pause

start "" https://localhost:44305/api/StaticAnalyzer


pause


set "SIM_PATH=C:\Users\320068391\Downloads\Simian\Simian\bin"

cd "%SIM_PATH%"

simian-2.5.10.exe "%BAT_PATH%\**\*.cs"  

pause


