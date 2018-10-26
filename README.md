NginxService
===============

This is a Windows service wrapper that allows you to run nginx.exe on Windows.  It provides a familiar and reliable method of launching the `nginx.exe` process during system bootup.  This is not production code, either in quality or usage, since those environments use load balancers, etc., to manage their sites.  This service is targetted only at developers and testers, since their virtual machines have much more complex setups due to the fact that they need to run many sites (like Ppm, auth service, Resource Management, etc.).

# Requirements

.NET 4.7

This readme assumes you'll be working with nginx-1.13.10.  Update/replace in your mind with whatever version you're using (such as 1.15.5).

## Development Instructions
	- Make some awesome changes
	- Build
	- Test locally
	- Create the ZIP file by running `zip NginxService-1.13.10.zip NginxService\bin\Release\NginxService.exe NginxService\bin\Release\Topshelf.dll` (you might need to install Zip or change the command)
	- Upload the ZIP file to Artifactory in the installs/cookbookresources repository.
	- Make a note of the sha256 checksum
	- Update the daptiv_nginx_ppm_proxy cookbook if you want this to be new default version (don't forget the tests!)
	- Update the daptiv_dev_ppm_role cookbook and set the version & sha256 checksum in the overrides of whichever recipe you want (such as dev_win10).

## Usage

1. Copy NginxService.exe into the same directory as nginx.exe
2. Run `NginxService.exe install`
3. Run `NginxService.exe start`

To uninstall, simply run `nginxservice.exe uninstall`


# Nginx
Download the nginx binary from http://nginx.org/download/nginx-1.13.10.zip.  This project is meant to work with version 1.13.10.  Upgrading the version will require changes to the chef recipe that sets up the VM.

## Setup & Testing
	- Download nginx from http://nginx.org/download/nginx-1.13.10.zip.
	- Unpack the zip to your C: drive (for example, `c:\nginx-1.13.10`)
	- Build this solution
	- Copy `NginxService.exe` and `TopShelf.dll` to `c:\nginx-1.13.10`
	- See the Usage steps above for installation and starting the service

## Improvements
2018-10: The service is updated to check for `nginx.exe` as a running process (rather than looking for the PID file).  The service will stop itself if it can't find the process.  This was done so that the service wouldn't falsly start.  nginx will write the PID file *before* running it's self test.  During this time, this service wrapper will see the PID file and assume everything is OK.  Then, then nginx.exe process will terminate because it's self check fails.  But this wrapper service is running.  Better to just check for the process.
