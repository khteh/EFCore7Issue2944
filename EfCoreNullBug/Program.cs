using EfCoreNullBug;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
var dbServer = configuration["DatabaseConnection:Server"];
var dbPort = configuration["DatabaseConnection:Port"];
var dbDatabase = configuration["DatabaseConnection:Database"];
var dbUserId = configuration["DatabaseConnection:User Id"];
var dbPassword = configuration["DatabaseConnection:Password"];
var connectionString = $"Server={dbServer};Port={dbPort};Database={dbDatabase};User Id={dbUserId};Password={dbPassword}";

using var db = new EfDbContext(connectionString);

//create
db.Add(new Person
{
    Id = 1,
    Name = "Me",
});
db.SaveChanges();

//read
var pers = db.Persons.SingleOrDefault(o => o.Id == 1);

//update
pers.Name = "You";
pers.Age = 1000;
db.SaveChanges();

//delete
db.Remove(pers);
db.SaveChanges();
