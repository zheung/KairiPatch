set /p type=input mod type:
cd dlljp
copy Assembly-CSharp.%type%.dll assets\bin\Data\Managed\Assembly-CSharp.dll
"C:\Program Files\2345Soft\HaoZip\HaoZipC" a -tzip ..\ma.apk assets
copy ..\ma.apk C:\Users\Administrator\Nox_share\Other\krsma.jp.602.%type%.apk