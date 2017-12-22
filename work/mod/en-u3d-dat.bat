@echo off

:begin
if "%1"=="" goto end

echo %~nx1

D:\Krsma\tool\ma43\MAencode43.exe %1
ren %~dp1%~n1.uni.crack %~n1.dat

shift
goto begin
:end
pause