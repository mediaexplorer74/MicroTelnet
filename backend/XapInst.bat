@echo off

setlocal

set "Logger=C:\Data\Users\Public\Documents\XapInst.log"

set "Input=%*"

if not defined Input echo Type XapInst /? for more help&goto :Eof

set "Input=%Input:"=%"

if "%Input%"=="/?" (echo a. Type XapInst "<XapPath>\<XapName>.xap" 0 - To install xap.

echo b. Type XapInst "<XapPath>\<XapName>.xap" 1 - To install xap on SDCard.

echo c. Type XapInst "<XapPath>" 0               - To install multiple xap.

echo d. Type XapInst "<XapPath>" 1               - To install multiple xap on SDCard.

goto :Eof)

set "Xap=%Input:~0,-2%"
 
if %Input:~-1,1%==0 (set Storage=di) else if %Input:~-1,1%==1 (set Storage=dis) else echo Type XapInst /? for more help&goto :Eof

echo "%Input%" >%Logger%

echo "%Xap%">>%Logger%

echo "%Input:~-1,1%" >>%Logger%

sleep 6

for %%a in ("%xap%") do if not "%%~xa"==".xap" if not exist "%Xap%\*.xap" (echo Make sure you have entered correct path&echo Type XapInst /? for more help&goto :Eof&goto :Eof) else (for %%a  in ("%Xap%\*.xap") do echo Installing "%%a"&th "%%a" -u >>%Logger%&sleep 3&th "%%a" -%Storage% >>%Logger%)

if exist "%Xap%\*.xap" goto End

echo Installing "%Xap%"

th "%Xap%" -u >>%Logger%

sleep 3

th "%Xap%" -%Storage% >>%Logger%

:End

endlocal

exit