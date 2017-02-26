

FROM microsoft/mssql-server-windows-express

#---------------------------------------------------------------------------------------------

# Install chocolatey
ENV chocolateyUseWindowsCompression false
RUN @powershell -NoProfile -ExecutionPolicy unrestricted -Command "(iex ((new-object net.webclient).DownloadString('https://chocolatey.org/install.ps1'))) >$null 2>&1" && SET PATH=%PATH%;%ALLUSERSPROFILE%\chocolatey\bin

#---------------------------------------------------------------------------------------------

RUN powershell choco install dotnetcore-sdk --allow-empty-checksums -y 

#---------------------------------------------------------------------------------------------

RUN mkdir c:\dockdb
COPY ef_migration /dockdb/
CMD c:\dockdb\db_update.bat && cmd

EXPOSE 1433

VOLUME ["C:/logs"]
	