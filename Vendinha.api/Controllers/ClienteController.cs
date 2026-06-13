using Vendinha.Models;
using Vendinha.Services;
using Microsoft.AspNetCore.Mvc;

namespace Vendinha.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService service;

        public ClienteController(ClienteService service)
        {
            this.service = service;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(service.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var cliente = service.BuscarPorId(id);

            if (cliente == null)
                return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }

        [HttpGet("buscar")]
        public IActionResult BuscarPorNome(string nome)
        {
            return Ok(service.BuscarPorNome(nome));
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente cliente)
        {
            var sucesso = service.Criar(cliente, out var erros);

            return sucesso
                ? CreatedAtAction(
                    nameof(GetById),
                    new { id = cliente.Id },
                    cliente)
                : UnprocessableEntity(erros);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Cliente cliente)
        {
            var sucesso = service.Atualizar(id, cliente);

            if (!sucesso)
                return NotFound("Cliente não encontrado.");

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var sucesso = service.Remover(id);

            if (!sucesso)
                return NotFound("Cliente não encontrado.");

            return Ok("Cliente removido com sucesso.");
        }
    }
}