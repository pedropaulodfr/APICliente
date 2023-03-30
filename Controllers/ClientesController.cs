using ClientesAPI.Context;
using ClientesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientesAPI.Controllers
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
                return NotFound("Cliente não encontrado na base de dados");
            }
            return Ok(cliente);
        }

        [HttpPost]
        public IActionResult Post(Cliente cliente) 
        {
            _dbContext.Add(cliente);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Cliente clienteAtualizado)
        {
            var cliente = _dbContext.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado na base de dados");
            }

            cliente.Nome = clienteAtualizado.Nome;
            cliente.Telefone = clienteAtualizado.Telefone;
            cliente.DataNascimento = clienteAtualizado.DataNascimento;
            cliente.CEP = clienteAtualizado.CEP;
            cliente.Endereco = clienteAtualizado.Endereco;
            cliente.NumeroResidencia = clienteAtualizado.NumeroResidencia;
            cliente.Complemento = clienteAtualizado.Complemento;
            cliente.Bairro = clienteAtualizado.Bairro;
            cliente.Cidade = clienteAtualizado.Cidade;
            cliente.UF = clienteAtualizado.UF;
            cliente.Status = clienteAtualizado.Status;

            _dbContext.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var cliente = _dbContext.Clientes.Find(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado na base de dados");
            }

            _dbContext.Clientes.Remove(cliente);
            _dbContext.SaveChanges();
            return NoContent();
        }

    }
}
