using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.IO;

using var game = new MonoGameExamenVliegtuig.Game1();
game.Run();
var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
var configuration = builder.Build();
string connectionstring = configuration.GetConnectionString("SQLServerConnection");
string databaseType = configuration.GetSection("FileSettings")["databaseType"];

var databaseConnection = new SqlConnection(connectionstring);
