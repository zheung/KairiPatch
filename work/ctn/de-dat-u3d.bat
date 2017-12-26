@echo off

:begin
if "%1"=="" goto end

echo %~nx1

D:\Krsma\tool\ma43\MA43decode.exe %1
ren %~dp1%~n1.crack %~n1.unity3d
del %1

shift
goto begin
:end
pause