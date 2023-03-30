using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientesAPI.Models
{
    [Table("Clientes")]
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string NumeroResidencia { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public bool Status { get; set; }
    }
}
