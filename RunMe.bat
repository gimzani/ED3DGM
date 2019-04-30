@echo off 

:: set and change directory relative to this file and path to SC.API
set relPath=%~dp0\Dist
cd %relPath%

:: Build dotnet project
::echo Building project... 
::dotnet build

:: Open browser
start http://localhost:7000

:: Run dotnet server
echo * --------------------------------------------------------- 
echo * Starting server... 
echo *  
echo * When the browser opens it will be blank.  Please wait  
echo * and the Server will refresh it when it is ready.  
echo * --------------------------------------------------------- 

EDGM.exe
