using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quiron.LojaVirtual.Dominio.Entidades
{
    public class EmailConfiguracoes
    {
        public bool UsarSsl = false;

        public string ServidorSmtp = "";

        public int ServidorPorta = 100;

        public string Usuario = "Lucas";

        public bool EscreverArquivo = false;

        public string PastaArquivo = @"c:\EnvioEmail";

        public string De = "De@email.com.br";

        public string Para = "Para@email.com.br";
    }
}
