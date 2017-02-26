@echo off

CD c:\dockdb

echo Starting... >> C:\logs\migration.log 2>&1
echo sa_password: %sa_password% >> C:\logs\migration.log 2>&1
sqlcmd -S localhost -E -Q "alter login sa enable"
sqlcmd -S localhost -E -Q "alter login sa with password = '%sa_password%'"
dotnet restore >> C:\logs\migration.log 2>&1
dotnet ef database update >> C:\logs\migration.log 2>&1

ping localhost -t
