# Infinite Visual Studio Trial

This small application is intended to expand Visual Studio Community trial time by month each time computer starts.


How does it work?
-----------------

Writen in C#.
Application copies itself into C:\Windows\Infinite Visual Studio.
It created Task Scheduler task to trigger application each time computer starts.
Using beatcracker's "VSCELicense" powershell tool expanding trial period for one month.

No GUI, just RUN IT and forget it.
This tool is built for silent deployment in computers.


Credits
-------
[beatcracker](https://github.com/beatcracker/VSCELicense)
[stackoverflow](https://stackoverflow.com/questions/43390466/visual-studio-community-is-a-30-day-trial/45487903#45487903)


Release
-------------
You can download a compiled version:
[InfiniteVSTrial.exe v1.0](https://github.com/tomasvanagas/InfiniteVisualStudioTrial/releases/download/1.0/InfiniteVSTrial.exe)

Or download source code and compile it yourself :)

Built only for Visual Studio 2017.
Tested on Windows 7, Windows 10.
