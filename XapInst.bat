@echo off

SET "XAP=%1"

ECHO.&ECHO Installing "%XAP%"

th "%XAP%" -u>sleep 5 

th "%XAP%" -di