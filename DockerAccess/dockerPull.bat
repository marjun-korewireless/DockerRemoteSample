::batch file to run docker commands
::format - dockerops <option> <args>
::option- 1 - docker pull
::		  2 - docker run
::args - 1 <image_name>
::		 2 <image_name> <commands>
@echo off 
docker pull %1
IF %errorlevel% == 1 (echo "Error") ELSE (echo success)