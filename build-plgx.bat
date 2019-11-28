@ECHO OFF
REM Credit goes to https://github.com/KoenZomers/KeePassOneDriveSync for creating the base of this script
ECHO Creating KeePass plugin package...
SET PLUGIN_NAME=PatternPass
SET SourceFolder=PatternPass
SET KeePassFolder="C:\Program Files (x86)\KeePass Password Safe 2"
SET DotNetVersion=4.0
IF EXIST %~dp0%SourceFolder%\obj RD /s /q %~dp0%SourceFolder%\obj
IF EXIST %~dp0%SourceFolder%\bin RD /s /q %~dp0%SourceFolder%\bin
DEL %~dp0%PLUGIN_NAME%.plgx
%KeePassFolder%\KeePass.exe --plgx-create %~dp0%SourceFolder% --plgx-prereq-net:%DotNetVersion%
REN %~dp0%SourceFolder%.plgx %PLUGIN_NAME%.plgx
ECHO KeePass Plugin package has been created.
IF "%1" == "--debug" (
	COPY %PLUGIN_NAME%.plgx %KeePassFolder%\Plugins\%PLUGIN_NAME%.plgx
	ECHO Running KeePass in debug mode...
	%KeePassFolder%\KeePass.exe --debug
)