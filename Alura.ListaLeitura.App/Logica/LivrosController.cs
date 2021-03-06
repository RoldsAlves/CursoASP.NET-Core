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
    public class LivrosController
    {

        private static string CarregaLista(IEnumerable<Livro> livros)
        {
            var conteudoArquivo = HTMLUtils.CarregaArquivoHTML("ParaLer");
            foreach(var livro in livros)
            {
                conteudoArquivo = conteudoArquivo.Replace("#NOVO-ITEM", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVO-ITEM");
            }
            return conteudoArquivo.Replace("#NOVO-ITEM", "");
        }

        public static Task ParaLer(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = CarregaLista(_repo.ParaLer.Livros);

            return context.Response.WriteAsync(html);
        }

        public static Task Lendo(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lendo.ToString());
        }

        public static Task Lidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            return context.Response.WriteAsync(_repo.Lidos.ToString());
        }

        public string Detalhes(int id)
        {
            var repo = new LivroRepositorioCSV();
            var livro = repo.Todos.First(l => l.Id == id);
            return livro.Detalhes();
        }

        public string Teste()
        {
            return "Nova funcionalidade foi implementada!";
        }
    }
}
