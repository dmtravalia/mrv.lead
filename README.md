# MRV.Lead.Api

MRV.Lead.Api 

## Getting Started

After clone the project 

```
dotnet run
```

Use Swagger in host

```
https://localhost:7196/swagger/index.html
```

### Prerequisites

Microsoft .NET 6.0

SQL Server

#### Database
```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Helloword!" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest
```