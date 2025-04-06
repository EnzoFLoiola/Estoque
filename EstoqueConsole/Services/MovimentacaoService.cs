using EstoqueConsole.Data;
using EstoqueConsole.Models;

namespace EstoqueConsole.Services
{
    public class MovimentacaoService
    {
        private readonly EstoqueContext _context;

        public MovimentacaoService(EstoqueContext context)
        {
            _context = context;
        }

        public void RegistrarEntrada(int produtoId, int quantidade)
        {
            var produto = _context.Produtos.Find(produtoId);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            produto.Quantidade += quantidade;

            var movimentacao = new Movimentacao
            {
                ProdutoId = produtoId,
                Quantidade = quantidade,
                Tipo = TipoMovimentacao.Entrada,
                Data = DateTime.Now
            };

            _context.Movimentacaos.Add(movimentacao);
            _context.SaveChanges();

            Console.WriteLine("Entrada registrada com sucesso.");
        }

        public void RegistrarSaida(int produtoId, int quantidade)
        {
            var produto = _context.Produtos.Find(produtoId);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            if (produto.Quantidade < quantidade)
            {
                Console.WriteLine("Estoque insuficiente.");
                return;
            }

            produto.Quantidade -= quantidade;

            var movimentacao = new Movimentacao
            {
                ProdutoId = produtoId,
                Quantidade = quantidade,
                Tipo = TipoMovimentacao.Saida,
                Data = DateTime.Now
            };

            _context.Movimentacaos.Add(movimentacao);
            _context.SaveChanges();

            Console.WriteLine("Saída registrada com sucesso.");
        }


        public void ListarMovimentacoes()
        {
            var movimentacoes = _context.Movimentacaos
                .OrderByDescending(m => m.Data)
                .ToList();

            Console.WriteLine("\nHistórico de Movimentações:");
            foreach (var m in movimentacoes)
            {
                Console.WriteLine($"Produto ID: {m.ProdutoId}, Tipo: {m.Tipo}, Quantidade: {m.Quantidade}, Data: {m.Data}");
            }
        }
    }
}
