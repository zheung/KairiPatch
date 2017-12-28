@echo off

cd spr
del ..\..\files\patch\main_c\image\image_sphere.dat
D:\Krsma\tool\ma43\MAencode43.exe image_sphere.unity3d
move image_sphere.uni.crack ..\..\files\patch\main_c\image\image_sphere.dat