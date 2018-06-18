NginxService
===============

This is a Windows service wrapper that allows you to run nginx.exe on Windows.  It provides a familiar and reliable method of launching the `nginx.exe` process during system bootup.  This is not production code, either in quality or usage, since those environments use load balancers, etc., to manage their sites.  This service is targetted only at developers and testers, since their virtual machines have much more complex setups due to the fact that they need to run many sites (like Ppm, auth service, Resource Management, etc.).

Requirements
---------------

.NET 4.7

Development Instructions
---------------
	- Make some awesome changes
	- Build
	- Test locally
	- Create the ZIP file by running `zip NginxService-1.13.10.zip NginxService\bin\Release\NginxService.exe NginxService\bin\Release\Topshelf.dll` (you might need to install Zip or change the command)
	- Upload the ZIP file to Artifactory in the installs/cookbookresources repository.


Usage
---------------

1. Copy NginxService.exe into the same directory as nginx.exe
2. Run `NginxService.exe install`
3. Run `NginxService.exe start`

To uninstall, simply run `nginxservice.exe uninstall`


Nginx
---------------
Download the nginx binary from http://nginx.org/download/nginx-1.13.10.zip.  This project is meant to work with version 1.13.10.  Upgrading the version will require changes to the chef recipe that sets up the VM.

Setup & Testing
---------------
	- Download nginx from http://nginx.org/download/nginx-1.13.10.zip.
	- Unpack the zip to your C: drive (for example, `c:\nginx-1.13.10`)
	- Build this solution
	- Copy `NginxService.exe` and `TopShelf.dll` to `c:\nginx-1.13.10`
	- See the Usage steps above for installation and starting the service
