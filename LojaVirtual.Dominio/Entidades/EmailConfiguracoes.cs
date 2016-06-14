using System.Net.Mail;

namespace LojaVirtual.Dominio.Entidades
{
    public class EmailConfiguracoes
    {
        public string De = "rcastrogi@gmail.com";
        public bool EscreverArquivo = true;
        public string Para = "pedido@gmail.com";
        public string PastaArquivo = @"d:\teste";
        public int Port = 587;
        public string Senha = "Bianca2010$";
        public string ServidorSMTP = "smtp.gmail.com.br";
        public bool UsarSSL = false;
        public string Usuario = "rcastrogi";
    }
}