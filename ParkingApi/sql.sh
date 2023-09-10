docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password123" -p 1433:1433 -v backup:/var/opt/mssql --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest



