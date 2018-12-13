::pull a docker image
@echo off 
docker pull %1
IF %errorlevel% == 1 (echo "Error") ELSE (echo success)