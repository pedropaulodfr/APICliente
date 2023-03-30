using ClientesAPI.Context;
using ClientesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClientesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly Contexto _dbContext;

        public UsuariosController(Contexto dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var usuarios = _dbContext.Usuarios.ToList();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var usuario = _dbContext.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado na base de dados");
            }

            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario) 
        {
            _dbContext.Add(usuario);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Usuario usuarioAtualizado)
        {
            var usuario = _dbContext.Usuarios.Find(id);
            if (usuario == null)
            {
                return NotFound("Usuário não encontrado na base de dados");
            }

            usuario.Id = usuarioAtualizado.Id;
            usuario.Nome = usuarioAtualizado.Nome;
            usuario.email = usuarioAtualizado.email;
            usuario.senha = usuarioAtualizado.senha;

            _dbContext.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var usuario = _dbContext.Usuarios.Find(id);
            if (usuario == null)
            {
                NotFound("Usuário não encontrado na base de dados");
            }

            _dbContext.Remove(id);
            _dbContext.SaveChanges();
            return NoContent();
        }

    }
}
