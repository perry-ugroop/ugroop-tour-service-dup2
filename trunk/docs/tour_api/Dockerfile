

FROM microsoft/aspnet

# Install chocolatey
ENV chocolateyUseWindowsCompression false
RUN @powershell -NoProfile -ExecutionPolicy unrestricted -Command "(iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))) >$null 2>&1" && SET PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin

#---------------------------------------------------------------------------------------------

# Install tools in container using chocolatey -> sweet
RUN powershell add-windowsfeature web-asp-net45 \
&& choco install microsoft-build-tools -y --allow-empty-checksums -version 14.0.23107.10 \
&& choco install dotnet4.6-targetpack --allow-empty-checksums -y \
&& choco install nuget.commandline --allow-empty-checksums -y \
&& nuget install MSBuild.Microsoft.VisualStudio.Web.targets -Version 14.0.0.3 \
&& nuget install WebConfigTransformRunner -Version 1.0.0.1

#---------------------------------------------------------------------------------------------

# Create a directory to hold our utilities.
RUN md c:\build
WORKDIR c:/build
COPY . c:/build
RUN md c:\webapp

#---------------------------------------------------------------------------------------------

# Restore packages, build, copy
RUN nuget restore \
&& "c:\Program Files (x86)\MSBuild\14.0\Bin\MSBuild.exe" /p:Platform="Any CPU" /p:VisualStudioVersion=12.0 /p:VSToolsPath=c:\MSBuild.Microsoft.VisualStudio.Web.targets.14.0.0.3\tools\VSToolsPath UgroopAPI.sln \
&& xcopy c:\build\ugroop.api.sql_2\bin\* c:\webapp\bin\* /s/y \
&& xcopy c:\build\ugroop.api.sql_2\scripts\* c:\webapp\scripts\* /s/y \
&& xcopy c:\build\ugroop.api.sql_2\views\* c:\webapp\views\* /s/y \
&& xcopy c:\build\ugroop.api.sql_2\packages.config c:\webapp\* /s/y \
&& xcopy c:\build\ugroop.api.sql_2\stormpath.yaml c:\webapp\* /s/y \
&& xcopy c:\build\ugroop.api.sql_2\web.config c:\webapp\* /s/y 

#---------------------------------------------------------------------------------------------

# configure the new site in IIS
RUN powershell -NoProfile -Command \
    Import-module IISAdministration; \
    New-IISSite -Name "tourapi" -PhysicalPath c:\webapp -BindingInformation "*:8000:"

# Open port 8000 and keep alive
EXPOSE 8000
CMD cmd.exe /c 'ping localhost -t' && cmd




