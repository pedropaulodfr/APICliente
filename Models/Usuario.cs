using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientesAPI.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
    }
}
