using EstoqueConsole.Data;
using EstoqueConsole.Services;
using Microsoft.EntityFrameworkCore;

EstoqueContext context = new(); // ✅ Correto

context.Database.Migrate();

var produtoService = new ProdutoService(context);
var movimentacaoService = new MovimentacaoService(context);

bool sair = false;

while (!sair)
{
    Console.Clear();
    Console.WriteLine("=== SISTEMA DE ESTOQUE ===\n");
    Console.WriteLine("1. Adicionar Produto");
    Console.WriteLine("2. Listar Produtos");
    Console.WriteLine("3. Atualizar Produto");
    Console.WriteLine("4. Remover Produto");
    Console.WriteLine("5. Registrar Entrada de Estoque");
    Console.WriteLine("6. Registrar Saída de Estoque");
    Console.WriteLine("7. Listar Movimentações");
    Console.WriteLine("0. Sair");
    Console.Write("\nEscolha uma opção: ");
    var opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Nome do Produto: ");
            var nome = Console.ReadLine() ?? string.Empty;

            Console.Write("Categoria: ");
            var categoria = Console.ReadLine() ?? string.Empty;

            Console.Write("Quantidade Inicial: ");
            int quantidadeInicial = int.TryParse(Console.ReadLine(), out int qInicial) ? qInicial : 0;

            produtoService.AdicionarProduto(nome, categoria, quantidadeInicial);
            break;

        case "2":
            produtoService.ListarProdutos();
            break;

        case "3":
            Console.Write("ID do Produto para atualizar: ");
            int idAtualizar = int.TryParse(Console.ReadLine(), out int idA) ? idA : 0;

            Console.Write("Novo nome: ");
            var novoNome = Console.ReadLine() ?? string.Empty;

            Console.Write("Nova categoria: ");
            var novaCategoria = Console.ReadLine() ?? string.Empty;
            Console.Write("Nova quantidade: ");
            int novaQuantidade = int.TryParse(Console.ReadLine(), out int qNova) ? qNova : 0;

            produtoService.AtualizarProduto(idAtualizar, novoNome, novaCategoria, novaQuantidade);
            break;

        case "4":
            Console.Write("ID do Produto para remover: ");
            int idRemover = int.TryParse(Console.ReadLine(), out int idR) ? idR : 0;

            produtoService.RemoverProduto(idRemover);
            break;

        case "5":
            Console.Write("ID do Produto para entrada: ");
            int idEntrada = int.TryParse(Console.ReadLine(), out int idE) ? idE : 0;

            Console.Write("Quantidade de entrada: ");
            int quantidadeEntrada = int.TryParse(Console.ReadLine(), out int qEntrada) ? qEntrada : 0;

            movimentacaoService.RegistrarEntrada(idEntrada, quantidadeEntrada);
            break;

        case "6":
            Console.Write("ID do Produto para saída: ");
            int idSaida = int.TryParse(Console.ReadLine(), out int idS) ? idS : 0;

            Console.Write("Quantidade de saída: ");
            int quantidadeSaida = int.TryParse(Console.ReadLine(), out int qSaida) ? qSaida : 0;

            movimentacaoService.RegistrarSaida(idSaida, quantidadeSaida);
            break;

        case "7":
            movimentacaoService.ListarMovimentacoes();
            break;

        case "0":
            sair = true;
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }

    if (!sair)
    {
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}
