// See https://aka.ms/new-console-template for more information
using Friday.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");
var services = new ServiceCollection();

services.AddDbContext<DatabaseContext>();