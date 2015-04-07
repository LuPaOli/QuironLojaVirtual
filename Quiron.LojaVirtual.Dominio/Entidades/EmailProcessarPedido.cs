using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class EmailProcessarPedido
    {
        private readonly EmailConfiguracoes _emailConfiguracoes;

        public EmailProcessarPedido(EmailConfiguracoes emailConfiguracoes)
        {
            emailConfiguracoes = _emailConfiguracoes;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            //Iniciar a utilização da classe SMTP

            using (var smtpClient = new SmtpClient())
            {
                //Variáveis necessárias para SMTP
                smtpClient.EnableSsl = _emailConfiguracoes.UsarSsl;
                smtpClient.Host = _emailConfiguracoes.ServidorSmtp;
                smtpClient.Port = _emailConfiguracoes.ServidorPorta;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailConfiguracoes.Usuario, _emailConfiguracoes.ServidorSmtp);

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivo;
                    smtpClient.EnableSsl = false;
                }

                //StringBuilder para construir o corpo do email
                StringBuilder body = new StringBuilder()
                    .AppendLine("Novo Pedido:")
                    .AppendLine("------------")
                    .AppendLine("Itens");

                //Percorre todos os itens do carrinho = quantidade vezes preço = Subtotal
                foreach (var item in carrinho.itensCarrinho)
                {
                    var subtotal = item.Quantidade*item.Produto.Preco;
                    body.AppendFormat("{0} x {1} (Subtotal: {2:c})", item.Quantidade, item.Produto.Preco, subtotal);
                }

                body.AppendFormat("Valor total do pedido: {0:c} ", carrinho.ValorTotal())
                    .AppendLine("---------------")
                    .AppendLine("Enviar para:")
                    .AppendLine(pedido.Nome)
                    .AppendLine(pedido.Email)
                    .AppendLine(pedido.Endereco ?? "")
                    .AppendLine(pedido.Cidade ?? "")
                    .AppendLine(pedido.Bairro ?? "")
                    .AppendLine(pedido.Complemento ?? "")
                    .AppendLine("----------------------")
                    .AppendFormat("Embrulhar para presente? {0}", pedido.EmbrulhaPresente ? "Sim" : "Não");

                MailMessage mailMessage = new MailMessage(
                    _emailConfiguracoes.De,
                    _emailConfiguracoes.Para,
                    "Novo Pedido",
                    body.ToString());

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                }

                smtpClient.Send(mailMessage);
            }
        }
    }
}
