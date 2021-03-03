"TELNET Injector" / XAPinst/ MicroTelnet 1.0alpha (Experimental Project for Microsoft Lumia 950)
================================================================

MicroTelnet Win10Mobile app  is open-sourced UWP project.
My main goal is to do useful GUI for mobile variant of XAP installation , without any PC ))

My TELNET Injector "solution" consists of 2 parts:
A. Backend
B. Frontend

Quick notes:
* Use only if You very experienced IT-man!
* Part 1 is moore useful and stable
* Part 2 is very unstable (RnD zone))


A. BACKEND
----------

XapInst.bat  - "Telnet Injector" :)

1) Full interop your W10M phone 
2) Copy xapinst.bat to XAPs folder (full path is \data\users\public\xaps\ , on W10M)
3) Use CMD Injector tech , i.e. use Putty and this command:
copy \data\users\public\xaps\xapinst.bat \data\test\bin\


B. FrontEnd
-----------
"Binaries - "standard" appxbundle (.appxbundle + .cer + depandancies) 

Simply install it by App Installer on your Win10Mobile device :)

Known Problems
--------------
In some W10 Phones MicroTelnet cannot connect to localhost.... so, I have problems on my Lumia 950 :(((( 

In my Lumia 950 2 reg files can help , a little:
Microtelnet begins to work after importing "fa_off.reg" and rebooting my phone (FA mains Full Access))
Microtelnet ends  normal work after importing "fa_on.reg" and rebooting my phone again.

"Firewall off" mode violate on some dev procedures... so use it only on your own risk!!

Please, help to improve my code (if You know SA, CSharp system coding, etc.). Feel free to poll request.

 Github repo here:
 https://github.com/mediaexplorer74/MicroTelnet 
(for feedback, issues discussion, and your pull requests))


Good luck! 

-- MediaExplorer 2021
