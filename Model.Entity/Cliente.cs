using System.ComponentModel.DataAnnotations;

namespace Model.Entity
{
    public class Cliente
    {
        private long _idCliente;
        private string _nome;
        private string _cpf;
        private string _endereco;
        private string _telefone;
        private bool _estado;

        [Display(Name ="Código")]
        public long IdCliente { get; set; }

        [Display(Name="Nome")]
        [Required(ErrorMessage = "Informe o Nome do Cliente!")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [MaxLength(11, ErrorMessage = "Digite no máximo 11 caracteres!")]
        public string CPF { get; set; }

        [Display(Name = "Endereco")]
        public string Endereco { get; set; }

        [Display(Name = "Telefone")]
        public string Telefone { get; set; }

        public int Estado { get; set; }

        public Cliente()
        {

        }

        public Cliente(long Id)
        {
            _idCliente = Id;
        }

        public Cliente(long IdCliente, string Nome, string Cpf, string Endereco, string Telefone)
        {
            _idCliente = IdCliente;
            _nome = Nome;
            _cpf = Cpf;
            _endereco = Endereco;
            _telefone = Telefone;
        }
    }
}
