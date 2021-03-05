@echo off

sleep 3

@echo off

SET "XAP=%1"

ECHO.&ECHO Installing "%XAP%"

th "%XAP%" -u

sleep 3 

th "%XAP%" -di