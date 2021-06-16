﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Alura.ListaLeitura.App.HTML
{
    public class HTMLUtils
    {
        public  static string CarregaArquivoHTML(string nomeArquivo)
        {
            var nomeCompletoArquivo = $"Views/{nomeArquivo}.html";
            using (var arquivo = File.OpenText(nomeCompletoArquivo))
            {
                return arquivo.ReadToEnd();
            }
        }
    }
}
