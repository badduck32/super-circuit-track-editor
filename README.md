# Super Circuit track editor

This is a track editor for Mario Kart Super Circuit, where you can edit a US Mario Kart Super Circuit ROM to create your own custom tracks. The editor does not come with a ROM. This is a fork from [Epic Edit](https://github.com/thomasgoldstein/epicedit) by [Thomas Goldstein](https://github.com/thomasgoldstein).

## Features from Epic Edit to add:
* Modify track tiles and overlay tiles
* Move track lap lines and driver starting positions
* Move and modify track objects
* Modify the AI (the path followed by computer-controlled drivers)
* Modify graphics and colors
* Modify track and driver names
* Modify game settings (item probabilities, attributed score points...)
* Import/export all kinds of data
* Directly compress/decompress data into/from the ROM (advanced users)

## Implemented features:
* None

## Info
This application is written in C# and uses Windows.Forms. It is free and is distributed under the GPL. It requires the .NET Framework 2.0 or above on Windows, and also works with Mono on Linux. It works on Mac too (hopefully), using Mono with an X11 server installed, by passing a command line argument, this way:
> MONO_MWF_MAC_FORCE_X11=1 mono EpicEdit.exe
