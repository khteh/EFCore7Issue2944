# MRE EF Core Null Bug

## Setup
Go into `EfCoreNullBug`, then make a copy of `appsettings.default.json` to `appsettings.json` and set relevant database credentials.

Run the following in the `EfCoreNullbug` directory
```
dotnet ef migrations add <NAME>
dotnet ef migrations update
```

You may need to create the relevant database in PostgreSQL.
Run with F5 in Visual Studio/Code.
