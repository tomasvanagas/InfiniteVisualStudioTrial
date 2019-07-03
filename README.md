# Infinite Visual Studio Community Trial

This small application is intended to expand Visual Studio Community trial time by month each time computer starts.

## How does it work?

Writen in C#.\
Application copies itself into C:\Windows\Infinite Visual Studio.\
Creating Task Scheduler task to trigger application each time computer starts.\
Using beatcracker's "VSCELicense" powershell tool expanding trial period for one month.

No GUI, just RUN IT and forget it.


## Credits

[beatcracker](https://github.com/beatcracker/VSCELicense)\
[stackoverflow](https://stackoverflow.com/questions/43390466/visual-studio-community-is-a-30-day-trial/45487903#45487903)


## Release

You can download a compiled version:\
[InfiniteVSTrial.exe v1.1](https://github.com/tomasvanagas/InfiniteVisualStudioTrial/releases/download/1.1/InfiniteVSTrial.exe)

Or download source code and compile it yourself :)

Visual Studio 2017 tested on Windows 7, Windows 10.
Visual Studio 2019 tested on Windows 10.
