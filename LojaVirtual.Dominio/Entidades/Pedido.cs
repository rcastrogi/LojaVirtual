using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LojaVirtual.Dominio.Entidades
{
    public class Pedido
    {
        public int PedidoId { get; set; }

        [Required(ErrorMessage ="Informe o nome do cliente")]
        [Display(Name = "Nome do Cliente:")]
        public string NomeCliente { get; set; }

        [DisplayFormat(DataFormatString = "{00000-000}")]
        [Display(Name ="Cep:")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Informe o Estado")]
        [Display(Name = "Estado:")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Informe a Cidade")]
        [Display(Name = "Cidade:")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe a Bairro")]
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "Informe o endereço")]
        [Display(Name = "Endereço:")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Informe o número")]
        [Display(Name = "Número:")]
        public string Numero { get; set; }

        [Display(Name = "Complemento:")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe seu email")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        [Display(Name = "Email:")]
        public string Email { get; set; }

        public bool EmbrulhaPresente { get; set; }
    }
}
