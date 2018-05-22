NginxService
===============

Service wrapper that allows you to run nginx.exe as a service on Windows.

Requirements
---------------

.NET 4.0+

Usage
---------------

1. Copy NginxService.exe into the same directory as nginx.exe
2. Run `NginxService.exe install`
3. Run `NginxService.exe start`


About
---------------
Used by the Windows VMs, the NginxService provides a familiar and reliable method of launching the `nginx.exe` process during system bootup.  This is not production code, either in quality or usage, since those environments use load balancers, etc., to manage the different websites that run on a single node.  The Windows developer and tester virtual machines have much more complex setups due to the fact that many sites and services need to run on them (such as PPM, SSO, ResourceManagement, Auth, etc.).
