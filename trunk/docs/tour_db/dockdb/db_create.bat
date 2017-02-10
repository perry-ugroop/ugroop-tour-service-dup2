
@ECHO OFF
SET SERVER=".\SQLEXPRESS" 
SET DB="master"
SET INPUT="c:\dockdb\dockuploaddb.sql"
SET LOGIN="sa"
SET PASSWORD="Password1*"
SET DBFINAL="uGroopDB2_TEST"

ECHO ==========EXECUTING SQL SCRIPT==============
SQLCMD -E -S %SERVER% -d %DB% -i %INPUT%
REM change [sa] password here
SQLCMD -S %SERVER% -d %DBFINAL% -U %LOGIN% -P %PASSWORD%
ECHO ==========     DONE    ==============

ping localhost -t
