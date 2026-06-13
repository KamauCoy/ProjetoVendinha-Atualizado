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
var cliente = new Cliente { nome_completo = nome };

Console.WriteLine("Digite o seu CPF:");
var cpf = Console.ReadLine();

Console.WriteLine("Digite a Data de Nascimento:");
var data_nascimento = DateTime.Parse(Console.ReadLine());

Console.WriteLine("Digite o seu Email:");
var email = Console.ReadLine();




