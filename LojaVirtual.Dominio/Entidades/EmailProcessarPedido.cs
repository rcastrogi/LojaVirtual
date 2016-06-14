using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace LojaVirtual.Dominio.Entidades
{
    public class EmailPedido
    {
        private readonly EmailConfiguracoes _emailConfiguracoes;

        public EmailPedido(EmailConfiguracoes emailConfiguracoes)
        {
            this._emailConfiguracoes = emailConfiguracoes;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            using (var smtpClient = new SmtpClient())
            {
                smtpClient.EnableSsl = _emailConfiguracoes.UsarSSL;
                smtpClient.Host = _emailConfiguracoes.ServidorSMTP;
                smtpClient.Port = _emailConfiguracoes.Port;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(_emailConfiguracoes.Usuario, _emailConfiguracoes.ServidorSMTP);


                if (_emailConfiguracoes.EscreverArquivo)
                {
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smtpClient.PickupDirectoryLocation = _emailConfiguracoes.PastaArquivo;
                }

                StringBuilder body = new StringBuilder()
                .AppendLine("Novo Pedido: ")
                .AppendLine("-----")
                .AppendLine("Itens");

                foreach (var item in carrinho.ListaCarrinho)
                {
                    var subtotal = item.Produto.Preco * item.Quantidade;
                    body.AppendFormat("{0} x {1} (subtotal: {2:c}", item.Quantidade, item.Produto.Nome, subtotal)
                    .AppendLine("");
                }

                body.AppendFormat("Valor Total do pedido: {0:c}", carrinho.ObterValorTotal())
                    .AppendLine("----------------")
                    .AppendLine("Enviar Para: ")
                    .AppendLine(pedido.NomeCliente)
                    .AppendLine(pedido.Email)
                    .AppendLine((pedido.Endereco + " " + pedido.Numero) ?? "")
                    .AppendLine(pedido.Cidade)
                    .AppendLine(pedido.Complemento)
                    .AppendLine(pedido.Bairro)
                    .AppendLine("-----------")
                    .AppendFormat("Para Presente? {0}", pedido.EmbrulhaPresente ? "Sim" : "Não");


                MailMessage mailMessage = new MailMessage(_emailConfiguracoes.De, _emailConfiguracoes.Para, "Novo Pedido", body.ToString());

                if (_emailConfiguracoes.EscreverArquivo)
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                }

                smtpClient.Send(mailMessage);

            }
        }
    }

   
}
