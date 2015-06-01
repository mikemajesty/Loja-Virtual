using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
namespace LojaVirtual.Dominio.Entidades
{
    public class EmailPedido
    {
        private readonly EmailConfiguracoes emailConfiguracao;

        public EmailPedido(EmailConfiguracoes EmailConfiguracao)
        {
            this.emailConfiguracao = EmailConfiguracao;
        }

        public void ProcessarPedido(Carrinho carrinho, Pedido pedido)
        {
            using (var smptCliente = new SmtpClient())
            {
                smptCliente.EnableSsl = emailConfiguracao.UsarSsL;
                smptCliente.Port = emailConfiguracao.ServidorPorta;
                smptCliente.UseDefaultCredentials = false;
                smptCliente.Credentials = new NetworkCredential
                    (emailConfiguracao.Usuario, emailConfiguracao.ServidorSmtp);
                if (emailConfiguracao.EscreverArquivo)
                {
                    smptCliente.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
                    smptCliente.PickupDirectoryLocation = emailConfiguracao.PastaArquivo;
                    smptCliente.EnableSsl = false;
                }

                StringBuilder body = new StringBuilder().AppendLine("Novo Pedido: \n")
                    .AppendLine("-------- \n")
                .AppendLine("Itens\n");

                foreach (var item in carrinho.ItensCarrinho)
                {
                    var subTotal = item.Produto.Preco * item.Quantidade;
                    body.AppendFormat("Quantidade :{0}\n x Nome Do Produto: {1}\n (SubTotal: {2:C}\n)", item.Quantidade, item.Produto.Nome, subTotal);
                }

                body.AppendFormat("Valor Total Do Pedido: {0:C}", carrinho.ObterValorTotal() + "\n")
                    .AppendLine("---------")
                    .AppendLine("Enviar Para:")
                    .AppendLine(pedido.NomeCliente)
                              .AppendLine(pedido.Email)
                    .AppendLine(pedido.Endereco ?? "")
                    .AppendLine(pedido.Cidade ?? "")
                    .AppendLine(pedido.Complemento ?? "")
                    .AppendLine("---------")
                    .AppendFormat("Para Presente?:{0}", pedido.EmbrulhaPresente ? "Sim" : "Nao");

                MailMessage mailMessage = new MailMessage(emailConfiguracao.De, emailConfiguracao.Para, "Novo Pedido", body.ToString());

                if (emailConfiguracao.EscreverArquivo)
                {
                    mailMessage.BodyEncoding = Encoding.GetEncoding("ISO-8859-1");
                }
                smptCliente.Send(mailMessage);
            }

        }
    }
}
