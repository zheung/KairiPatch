set /p type=input mod type:
cd dll
copy Assembly-CSharp.%type%.dll assets\bin\Data\Managed\Assembly-CSharp.dll
"E:\Program\HaoZip\HaoZipC" a -tzip ..\ma.apk assets
copy ..\ma.apk D:\File\Nox_share\Other\krsma.cn.602.%type%.apk