MTK-FirmwareAdapter-Tool
========================

This is latest sources of my program (2.0.0.5). I develop it with MS Visual Studio 2013 on C# .I do not mind if somebody will convert it for others development environments and OS.

Now it have small problems:
- Problem with .img repack if you have Windows XP, Windows 8+, works perfect on Windows 7 (on win8+, cpio.exe worked incorrect).
- Some people have problems with file.exist function (file exist, but program show error because don't find it).

That functions i want to see, but can't do (now i don't have enough time to try do something from this):
- Ext4 packing without device, to make system.img for SP Flash Tool.
Some progres see here: http://4pda.ru/forum/index.php?showtopic=496786&st=940#entry33220483 (new make_ext4fs.exe).
- Logging cmd to file (maybe all started functions, unpack, pack, etc.), and for example to additional debug window, so you can see what problems have arisen at some stage.
- Needed progressbar for some operations (unpack zip, etc.), but to do it, needed to make multithreading, and run background processes.

Thanks for attention, hope my program receive new breath.
