@echo off

cd dll
copy Assembly-CSharp.nan.dll assets\bin\Data\Managed\Assembly-CSharp.dll
"E:\Program\HaoZip\HaoZipC" a -tzip ..\ma.apk assets