# GeoLocation
A simple web service with a SQL backing store to lookup ZIP codes and City/States

There are over 70,000 ZIP codes loaded in the database.

#### Load the database
Run the database installer to create a SQL database with all location data.
C:\Windows\Microsoft.NET\Framework\v4.0.30319\InstallUtil.exe Gravitybox.LocationService.Install

When prompted, simply fill in the database connection information on the "Create" tab.

#### Setup web service
Create a web site in IIS and point to the binaries for the **Gravitybox.Webservice.GeoLocationService** project and give the site a port binding like 8080. Change the connection string in the web.config file and the service is ready to go. In this example you would then connect to web service at "http://localhost:8080/GeoLocationService.svc"

#### Use the Service
The service has several methods that allow you to get a ZipInfo object by ZIP code, coordinate, or city/state. The generic **GetLookup** method will figure out what was sent in and do its best to return the best answer.
