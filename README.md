NginxService
===============

Service wrapper that allows you to run nginx.exe as a service on Windows.

Requirements
---------------

.NET 4.7

Usage
---------------

1. Copy NginxService.exe into the same directory as nginx.exe
2. Run `NginxService.exe install`
3. Run `NginxService.exe start`

To uninstall, simply run `nginxservice.exe uninstall`


About
---------------

The NginxService is used by the Windows VMs, and it provides a familiar and reliable method of launching the `nginx.exe` process during system bootup.  This is not production code, either in quality or usage, since those environments use load balancers, etc., to manage the different websites that run on a single node.  The Windows developer and tester virtual machines have much more complex setups due to the fact that many sites and services need to run on them (such as PPM, SSO, ResourceManagement, Auth, etc.).

Nginx
---------------
Download the nginx binary from http://nginx.org/download/nginx-1.13.10.zip.  This project is meant to work with version 1.13.10.  Upgrading the version will require changes to the chef recipe that sets up the VM.

Developer Setup
---------------
	- Download nginx from http://nginx.org/download/nginx-1.13.10.zip.
	- Unpack the zip to your C: drive (for example, `c:\nginx-1.13.10`)
	- Build this solution
	- Copy `NginxService.exe` and `TopShelf.dll` to `c:\nginx-1.13.10`
	- See the Usage steps above for installation, etc.
