; Скрипт создан при помощи мастера создания скриптов.
; СМ. ДОКУМЕНТАЦИЮ ДЛЯ ИЗУЧЕНИЯ ДЕТАЛЕЙ ОТНОСИТЕЛЬНО СОЗДАНИЯ ФАЙЛОВ СКРИПТА INNO SETUP!

[Setup]
AppName=MTK FirmwareAdapter Tool
AppVersion=2.0.0.6
VersionInfoVersion=2.0.0.6
AppVerName=MTK FirmwareAdapter Tool 2.0.0.6
DefaultDirName=C:\MTK FirmwareAdapter Tool
DefaultGroupName=MTK FirmwareAdapter Tool
AllowNoIcons=yes
OutputDir=C:\Users\Back37\Desktop
OutputBaseFilename=Setup
SetupIconFile=E:\MTK-FirmwareAdapter-Tool-master\MTK FirmwareAdapter Tool\mediatek.ico
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Languages\English.isl"
Name: "russian"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
Name: "quicklaunchicon"; Description: "{cm:CreateQuickLaunchIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked

[Files]
Source: "E:\MTK-FirmwareAdapter-Tool-master\MTK FirmwareAdapter Tool\bin\Release\MTK FirmwareAdapter Tool.exe"; DestDir: "{app}"; Flags: ignoreversion
; ОТМЕТЬТЕ: Не используйте "Флажки: Проигнорировать версию" на любых общедоступных системных файлах
[InstallDelete]
Name: "{app}\Langs\English.ini"; Type: files
Name: "{app}\Langs\Czech.ini"; Type: files

[Icons]
Name: "{group}\MTK FirmwareAdapter Tool"; Filename: "{app}\MTK FirmwareAdapter Tool.exe"; WorkingDir: {app}
Name: "{group}\{cm:UninstallProgram,MTK FirmwareAdapter Tool}"; Filename: "{uninstallexe}"
Name: "{group}\AdaptedROMS"; Filename: "{app}\AdaptedROMS"; WorkingDir: {app}\AdaptedROMS
Name: "{commondesktop}\MTK FirmwareAdapter Tool"; Filename: "{app}\MTK FirmwareAdapter Tool.exe"; Tasks: desktopicon; WorkingDir: {app}
Name: "{userappdata}\Microsoft\Internet Explorer\Quick Launch\MTK FirmwareAdapter Tool"; Filename: "{app}\MTK FirmwareAdapter Tool.exe"; Tasks: quicklaunchicon; WorkingDir: {app}
Name: "{commondesktop}\AdaptedROMS"; Filename: "{app}\WorkDIR\AdaptedROMS"; WorkingDir: {app}\WorkDIR\AdaptedROMS; Tasks: desktopicon

[Run]
Filename: "{app}\MTK FirmwareAdapter Tool.exe"; Description: "{cm:LaunchProgram,MTK FirmwareAdapter Tool}"; Flags: nowait postinstall skipifsilent

[UninstallDelete]
Name: {userdesktop}\MTK FirmwareAdapter Tool.lnk; Type: files
Name: "{group}"; Type: filesandordirs

[Dirs]
Name: "{app}\WorkDIR\AdaptedROMS"

