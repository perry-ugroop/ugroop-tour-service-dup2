
FROM microsoft/mssql-server-windows-express
RUN mkdir c:\dockdb
COPY dockdb /dockdb/
CMD c:\dockdb\db_create.bat && cmd
	