using System.Text.Json;
using EfCoreNullBug;
using Microsoft.Extensions.Configuration;
using static System.Console;
var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var dbServer = configuration["DatabaseConnection:Server"];
var dbPort = configuration["DatabaseConnection:Port"];
var dbDatabase = configuration["DatabaseConnection:Database"];
var dbUserId = configuration["DatabaseConnection:User Id"];
var dbPassword = configuration["DatabaseConnection:Password"];
var connectionString = $"Server={dbServer};Port={dbPort};Database={dbDatabase};User Id={dbUserId};Password={dbPassword};Include Error Detail=true";

try
{
    using var db = new EfDbContext(connectionString);

    //create
    db.Add(new Person
    {
        Id = 1,
        // XXX Ignoring this property string value will throw 23502: null value in column "Name" of relation "Persons" violates not-null constraint DETAIL: Failing row contains(1, null, , , , , null, 0, f).
        Name = "Me",
        // However, value object "Address" without initialized doesn't throw. Why is there such different behaviour?
    });
    db.SaveChanges();

    //read
    Person p = db.Persons.SingleOrDefault(o => o.Id == 1);
    WriteLine($"Person: {JsonSerializer.Serialize(p)}");
    //update
    p.Name = "You";
    p.Age = 1000;
    db.SaveChanges();

    //delete
    db.Remove(p);
    db.SaveChanges();
}
catch (Exception e)
{
    WriteLine($"Exception! {e}");
}