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
    public class CadastroLogica
    {
        public static Task ExibirFormulario(HttpContext context)
        {
            var html = HTMLUtils.CarregaArquivoHTML("Formulario");
            return context.Response.WriteAsync(html);
        }

        public static Task ProcessaFormulario(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.Request.Form["titulo"].First(),
                Autor = context.Request.Form["autor"].First()
            };
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return context.Response.WriteAsync("O Livro foi adicionado com sucesso!");
        }

        public static Task NovoLivroParaLer(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.GetRouteValue("nome").ToString(),
                Autor = context.GetRouteValue("autor").ToString()
            };
            var repo = new LivroRepositorioCSV();
            repo.Incluir(livro);

            return context.Response.WriteAsync("O Livro foi adicionado com sucesso!");
        }
    }
}
