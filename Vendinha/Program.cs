using Vendinha.Data;
using Vendinha.Models;
using Vendinha.Services;

Environment.SetEnvironmentVariable(
    "ConnectionStrings__Default",
    "Server=localhost;Port=5432;Database=Vendinha;User Id=postgres;Password=1234"

    );

var dbcontext = new VendinhaDbContext();
var context = new VendinhaDbContext();

Console.WriteLine("Digite o Nome Completo:");
var nome = Console.ReadLine();
var cliente = new Cliente { NomeCompleto = nome };

Console.WriteLine("Digite o seu CPF:");
var CPF = Console.ReadLine();

Console.WriteLine("Digite a Data de Nascimento:");
var DataNascimento = DateTime.Parse(Console.ReadLine());

Console.WriteLine("Digite o seu Email:");
var Email = Console.ReadLine();




