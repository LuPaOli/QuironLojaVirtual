using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class Pedido
    {
        //Nome do cliente. Campo de preenchimento obrigatório
        [Required(ErrorMessage = "Informe seu nome.")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }
        //Cep. Este campo não é de preeenchimento obrigatório
        [Display(Name = "Cep:")]
        public string Cep { get; set; }
        //Endereço. Campo de preenchimento obrigatório
        [Required(ErrorMessage = "Informe seu endereço.")]
        [Display(Name = "Endereço:")]
        public string Endereco { get; set; }
        //Complemento.
        [Display(Name = "Complemento:")]
        public string Complemento { get; set; }
        //Cidade. Campo de preenchimento obrigatório
        [Required(ErrorMessage = "Informe sua cidade.")]
        [Display(Name = "Cidade:")]
        public string Cidade { get; set; }
        //Bairro. Campo de preenchimento obrigatório
        [Required(ErrorMessage = "Informe seu bairro.")]
        [Display(Name = "Bairro:")]
        public string Bairro { get; set; }
        //Email. Campo de preenchimento obrigatório
        [Required(ErrorMessage = "Informe seu e-mail.")]
        [Display(Name = "E-mail:")]
        [EmailAddress(ErrorMessage = "E-mail inválido.")]
        public string Email { get; set; }
        //Embrulhar presente
        public bool EmbrulhaPresente { get; set; }

    }
}
