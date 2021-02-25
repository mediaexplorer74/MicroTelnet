TELNET Injector (Experimental Project for Microsoft Lumia 950)
================================================================

My "solution" consists of 2 parts:
A. Backend
B. Frontend

Quick notes:
* Use only if You very experienced IT-man!
* Part 1 is moore useful and stable
* Part 2 is very unstable (RnD zone))


A. BACKEND
----------

INTRO:
 Hello!! ME. Here I'm sharing you the TELNET Injector. My work is based on "CMD Injector" project (author: Fadil Fadz).
 So it's tested for my W10M Lumia 950 having interop unlock. I hope that this project can be useful for ALL W10M devices. Have FUN! :) 

REQUIRED:
 - Interop Unlock
 - Interop Tools (Beta) - https://www.mediafire.com/file/7u8omuqwdb415yn/InteropTools_Beta1.9_pre8_1.9.370.0.zip/file
 - PuTTY - https://www.mediafire.com/file/njgcqqvrccuplox/putty.xap/file

INSTALLATION:
 1) Copy files from Backend folder to Documents folder on internal storage like, This Device\Documents\CMD Injector.
 2) On pour phone: import Import.reg using Interop Tools 1.9.370 and reboot your phone.
 3) Open PuTTY and generate below auth key.
  - Name of private key: Pass
  - Key comment: Sirepuser
  - Type of key to generatate: SSH-2 (RSA)
  - Key size: 1024
 4) And save the below sessions.
 
  - IP: 127.0.0.1
  - Connection Type: SSH
  - PORT:22
  - Username: Sirepuser
  - Private key file for auth: Pass
  - Session name: Telnet Starter
 
  - IP: 127.0.0.1
  - Connection Type: Telnet
  - PORT:23
  - Session name: CMD
  
 5) Open the MicroTelnet session from saved sessions and Input password 1234 when ask.
 6) Type Setup.bat on opened cmd
 7) Done. Now you can delete CMD Injector folder from Documents.

USAGE:
 0) Restart your phone if needed ))
 1) Launch PuTTY and scroll tab to saved sessions.
 2) Open Telnet Starter session and look the message about Telnet start
 3) Close Telnet Starter session.
 4) Open MicroTelnet session and then use CMD and XapInst =) 

NEW BATCH PROGRAMS:
 - XapInst.bat
 
IMPORTANT NOTES:
 - Importing .reg NOT WORKS with Interop Tools that are not Interop Tools 1.9.370 version!
   You can (and must) use the Interop Tools Interop Tools 1.9.370 BETA from the above link. 
 - Due to lack of bootshsvc for locked bootloader, you must need to open Telnet Starter session 
   once AFTER EVERY REBOOT of your phone!
 - Use "XapInst \folder1\folder2\xapfile.xap" syntax from anywhere on CMD to launch Xap installation :)




B. FrontEnd
-----------
MicroTelnet folder -- open-sourced UWP app for XAP installation experiments (use it free for your own RnD))

Problems: Mobile version of MicroTelnet cannot connect to localhost :((((((( 
Please, help (if You know Sockets, TCP Clients, etc.).
Github repo here:
 https://github.com/mediaexplorer74/MicroTelnet 
(for feedback, issues discussion, and your pull requests))


Good luck! 

-- MediaExplorer 2021
