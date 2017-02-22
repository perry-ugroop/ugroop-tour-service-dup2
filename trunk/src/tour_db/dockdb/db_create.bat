
@ECHO OFF
SET SERVER=".\SQLEXPRESS" 
SET DB="master"
SET INPUT="c:\dockdb\dockuploaddb.sql"
SET LOGIN="sa"
SET PASSWORD="Password1*"
SET DBFINAL="uGroopDB2"

ECHO ==========EXECUTING SQL SCRIPT==============
ECHO "Running SQL script..." >> C:\db_create.log
SQLCMD -E -S %SERVER% -d %DB% -i %INPUT% -v DB = %DBFINAL% >> C:\db_create.log  2>&1
REM change [sa] password here
ECHO "After running SQL script..." >> C:\db_create.log
SQLCMD -S %SERVER% -d %DBFINAL% -U %LOGIN% -P %PASSWORD% >> C:\db_create.log  2>&1
ECHO "All done." >> C:\db_create.log
ECHO ==========     DONE    ==============

ping localhost -t
