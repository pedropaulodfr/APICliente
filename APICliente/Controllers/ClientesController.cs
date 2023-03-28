using APICliente.Context;
using APICliente.Models;
using Microsoft.AspNetCore.Mvc;

namespace APICliente.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly Contexto _dbContext;

        public ClientesController(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var clientes = _dbContext.Clientes.ToList();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cliente = _dbContext.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            _dbContext.Clientes.Add(cliente);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Cliente clienteAtualizado)
        {
            var cliente = _dbContext.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            cliente.Nome = clienteAtualizado.Nome;
            cliente.DataNascimento = clienteAtualizado.DataNascimento;
            cliente.Telefone = clienteAtualizado.Telefone;
            cliente.Endereco = clienteAtualizado.Endereco;
            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cliente = _dbContext.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound();
            }
            _dbContext.Clientes.Remove(cliente);
            _dbContext.SaveChanges();
            return NoContent();
        }
    }

}
