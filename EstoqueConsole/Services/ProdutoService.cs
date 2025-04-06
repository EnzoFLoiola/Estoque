using EstoqueConsole.Models;
using EstoqueConsole.Data;
using System;
using System.Linq;

namespace EstoqueConsole.Services
{
    public class ProdutoService
    {
        private readonly EstoqueContext _context;

        public ProdutoService(EstoqueContext context)
        {
            _context = context;
        }

        // CREATE
        public void AdicionarProduto(string nome, string categoria, int quantidadeInicial)
        {
            var produto = new Produto
            {
                Nome = nome,
                Categoria = categoria,
                Quantidade = quantidadeInicial
            };

            _context.Produtos.Add(produto);
            _context.SaveChanges();

            Console.WriteLine("Produto adicionado com sucesso!");
        }

        // READ
        public void ListarProdutos()
        {
            var produtos = _context.Produtos.ToList();

            if (produtos.Any())
            {
                Console.WriteLine("\n--- Lista de Produtos ---");
                foreach (var p in produtos)
                {
                    Console.WriteLine($"ID: {p.Id} | Nome: {p.Nome} | Categoria: {p.Categoria} | Quantidade: {p.Quantidade}");
                }
            }
            else
            {
                Console.WriteLine("Nenhum produto cadastrado.");
            }
        }

        // UPDATE
        public void AtualizarProduto(int id, string novoNome, string novaCategoria, int novaQuantidade)
        {
            var produto = _context.Produtos.Find(id);
            if (produto != null)
            {
                produto.Nome = novoNome;
                produto.Categoria = novaCategoria;
                produto.Quantidade = novaQuantidade;

                _context.SaveChanges();
                Console.WriteLine("Produto atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        // DELETE
        public void RemoverProduto(int id)
        {
            var produto = _context.Produtos.Find(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                _context.SaveChanges();
                Console.WriteLine("Produto removido com sucesso!");
            }
            else
            {
                Console.WriteLine("Produto não encontrado.");
            }
        }

        // CONSULTA por ID (opcional)
        public Produto? ObterProdutoPorId(int id)
        {
            return _context.Produtos.Find(id);
        }
    }
}
