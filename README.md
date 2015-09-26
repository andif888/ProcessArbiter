# ProcessArbiter
ProcessArbiter boosts the agility of a Windows Operating System when running multiple applications.

On a single desktop for example you can run multiple applications (backup, CD-burning, video encoding) which consumes many CPU resources in the background. At this moment other application you are trying to run are normally very unresponsive, because the CPU resources are exhausted. ProcessArbiter dynamically adjusts priorities at which an application gets CPU times. This means for example your video encoding application gets dynamically a lower priority. If there is no application which requests CPU time at the moment, your video encoding application can still run on full speed. If you run now an application which currently requests CPU time, it immedially gets scheduled because of its higher priority. Your PC is much more responsive.

In Terminal Server environments (server based computing), when multible users are working with multible application on one Microsoft Windows Server at the same time, ProcessArbiter can show at its best. ProcessArbiter manages priorities of all running application dynamically and fully automated. The users running the terminal sessions will immediately recognize the more snappier behavior and responsiveness of their applications. Administrators can easily run scheduled tasks during work hours without interferring user sessions. 

The best news is, that there is no complicated configuration in ProcessArbiter. After installation, which is a 5 seconds task, ProcessArbiter will do its job. It is implemented as reliably Windows Service with nearly no overhead.

### Software Requirements:
Any of the following operation systems:
Windows 2000, Windows XP (x86, x64), Windows Vista (x86, x64), Windows 7 (x86, x64), Window 8 (x86, x64), Windows 8.1 (x86, x64), Windows 10 (x86, x64)
Windows 2000 Server, Windows Server 2003 (x86, x64), Windows Server 2008 (x86, x64), 
Windows Server 2008 R2, Windows Server 2012, Windows Server 2012 R2 

Microsoft .NET Framework 2.0 or above

### Download and Installation:
Download the [ProcessArbiterSetup-x86.zip](https://github.com/andif888/ProcessArbiter/blob/master/ProcessArbiterSetup-x86.zip) for 32-bit Windows, extract the contents and run setup.exe.

Download the [ProcessArbiterSetup-x64.zip](https://github.com/andif888/ProcessArbiter/blob/master/ProcessArbiterSetup-x64.zip) for 64-bit Windows, extract the contents and run setup.exe.

### Further Information:
You can find a compiled help file in ProcessArbiterHelp/ProcessArbiterHelp.chm, which is also part of the setup.
