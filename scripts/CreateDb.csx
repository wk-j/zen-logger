#! "netcoreapp2.1"
#r "nuget:Npgsql.EntityFrameworkCore.PostgreSQL,2.1.1"
#r "nuget:Microsoft.EntityFrameworkCore,2.1.1"
#r "../src/ZenLogger.Entity/obj/Debug/netstandard2.0/ZenLogger.Entity.dll"

using Microsoft.EntityFrameworkCore;
using ZenLogger.Entity;

var connectionString = "Server=localhost;Port=5432;Database=ZenLogger; User Id=postgres;Password=1234;";
var builder = new DbContextOptionsBuilder()
    .UseNpgsql(connectionString);

var context = new ZenContext(builder.Options);
context.Database.EnsureCreated();

