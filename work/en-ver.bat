@echo off

cd ver
del ..\..\files\patch\version.dat
D:\Krsma\tool\ma43\MAencode43.exe version.unity3d
move version.uni.crack ..\..\files\patch\version.dat
pause