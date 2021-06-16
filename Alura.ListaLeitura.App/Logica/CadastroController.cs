using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alura.ListaLeitura.App.HTML;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
        public static Task ExibirFormulario(HttpContext context)
        {
            var html = HTMLUtils.CarregaArquivoHTML("Formulario");
            return context.Response.WriteAsync(html);
        }

        public string Incluir(Livro livro)
        {
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return "O Livro foi adicionado com sucesso!";
        }
    }
}
