@ECHO OFF
SET mypath=%~dp0
SET mypath=%mypath:~0,-1%
 
for %%f in (%mypath%) do set CurrDirName=%%~nxf
echo %CurrDirName%
 
dotnet run --project %mypath%/%CurrDirName%.Api --launch-profile %CurrDirName%.Api