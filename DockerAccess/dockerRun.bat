::docker run
@echo off
if [%3] == [] (goto :withoutport) else (goto :withport)
IF %errorlevel% NEQ 0 (echo "Error") ELSE (echo %errorlevel%)
IF %errorlevel% == 1 (echo "Error") ELSE (echo success)
:withoutport
docker run -d %1 --daemon
goto :eof
:withport
docker run -d -p %2:%3 %1 --daemon
goto :eof