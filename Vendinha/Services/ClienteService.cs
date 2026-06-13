using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Vendinha.Data;
using Vendinha.Models;

namespace Vendinha.Services
{
    public class ClienteService
    {
        private readonly VendinhaDbContext context;

        public ClienteService(VendinhaDbContext context)
        {
            this.context = context;
        }

        public bool Validar(
            Cliente cliente,
            out List<ValidationResult> erros)
        {
            var validation =
                new ValidationContext(cliente);

            erros = new List<ValidationResult>();

            return Validator.TryValidateObject(
                cliente,
                validation,
                erros,
                true);
        }

        public bool Criar(
            Cliente cliente,
            out List<ValidationResult> erros)
        {
            if (!Validar(cliente, out erros))
                return false;

            if (context.Clientes.Any(c => c.cpf == cliente.cpf))
            {
                erros.Add(
                    new ValidationResult(
                        "CPF já cadastrado."));
                return false;
            }

            if (cliente.cpf.Length != 11)
            {
                erros.Add(
                    new ValidationResult(
                        "CPF inválido."));
                return false;
            }

            context.Clientes.Add(cliente);
            context.SaveChanges();

            return true;
        }

        public Cliente? BuscarPorId(int id)
        {
            return context.Clientes
                .FirstOrDefault(c => c.Id == id);
        }

        public List<Cliente> Listar()
        {
            return context.Clientes.ToList();
        }

        public List<Cliente> BuscarPorNome(string nome)
        {
            return context.Clientes
                .Where(c =>
                    c.nome_completo.Contains(nome))
                .ToList();
        }

        public List<Cliente> Listar(int pagina)
        {
            return context.Clientes
                .Skip((pagina - 1) * 10)
                .Take(10)
                .ToList();
        }

        public bool Atualizar(int id, Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public bool Remover(int id)
        {
            throw new NotImplementedException();
        }
    }


}

