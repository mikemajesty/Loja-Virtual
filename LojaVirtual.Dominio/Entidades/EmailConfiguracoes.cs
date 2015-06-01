using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;

namespace LojaVirtual.Dominio.Entidades
{
     public class EmailConfiguracoes
    {
         public bool UsarSsL = false;

         public int ServidorPorta = 1587;

         public string Usuario = "Mike Lima";

        public string ServidorSmtp = "smtp.LojaVirtual.com.br";

        public bool EscreverArquivo = false;

        public string PastaArquivo = @"C:\envioEmail";

        public string De  = "mikee_2008@hotmail.com";

        public string Para = "mikeemajesty2011@gmail.com";
    }
}
