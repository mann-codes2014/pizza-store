## Game Store API

### [Secrets management](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows)
```powershell
dotnet user-secrets init
```
```
dotnet user-secrets set "ConnectionStrings:GameStoreContext" "Host=DB_HOST;Username=DB_USER;Password=DB_PASSWORD;Database=DB_NAME"
```
```
dotnet user-secrets list
```

### Packages
```
dotnet  add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet  add package Npgsql.EntityFrameworkCore.PostgreSQL.Design
dotnet add package MinimalApis.Extensions
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
dotnet add package Microsoft.AspNetCore.Authorization
```

## Tools
```
dotnet tool install --global dotnet-ef
```

## Migrations
```
dotnet ef migrations add InitialCreate -o ./Data/Migrations
dotnet ef database update
```