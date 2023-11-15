# MRE EF Core Null Bug

## Setup
Make a copy of `appsettings.default.json` to `appsettings.json` and set relevant database credentials

Run the following:
```
cd EfCoreNullBug
dotnet ef migrations add <NAME>
dotnet ef migrations update
```

You may need to create the relevant database in PostgreSQL.
Run with F5 in Visual Studio/Code.
