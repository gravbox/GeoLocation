pause

RD /S /Q "C:\Deploy-Geo\temp"

rem UNZIP THE DEPLOY FILE
"C:\Program Files\7-Zip\7z.exe" x -o"C:\Deploy-Geo\temp" "C:\Deploy-Geo\geo-deploy.zip"

rem COPY SERVICES CACHE TO DEPLOY FOLDERS
mkdir C:\Sites\GeoLocation
xcopy /Y /s /i "C:\Deploy-Geo\temp\GeoLocation\Site\*" "C:\Sites\GeoLocation\"


pause