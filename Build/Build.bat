RD /S /Q "C:\publish\GeoLocation"
mkdir "C:\publish\GeoLocation\Site"
mkdir "C:\publish\GeoLocation\Database"

"C:\Program Files (x86)\Microsoft Visual Studio\2017\BuildTools\MSBuild\15.0\Bin\msbuild.exe" "..\Gravitybox.GeoLocation.sln" /p:Configuration=Release /p:DeployOnBuild=true /p:PublishProfile=FolderProfile

rem COPY DATABASE
copy C:\Projects\GeoLocation\Gravitybox.GeoLocation.Install\bin\Release\Gravitybox.GeoLocation.Install.exe C:\publish\GeoLocation\Database\Gravitybox.GeoLocation.Install.exe

rem CLEAN THE FOLDERS
del /q C:\publish\GeoLocation\Site\web.config

rem ZIP THE FOLDERS
del /q "C:\Sandbox\geo-deploy.zip"

rem ZIP THE FOLDERS
del /q "C:\publish\geo-deploy.zip"
"C:\Program Files\7-Zip\7z.exe" a "C:\publish\geo-deploy.zip" "C:\publish\GeoLocation\"

pause