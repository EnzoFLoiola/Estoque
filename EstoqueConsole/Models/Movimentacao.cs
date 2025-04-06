using System;

namespace EstoqueConsole.Models
{
    public class Movimentacao{
        public int Id {get; set;}
        public int ProdutoId {get; set;}
        public Produto Produto { get; set; } = null!;
        public DateTime Data {get; set;}
        public int Quantidade{get; set;}
        public TipoMovimentacao Tipo { get; set; } // "Entrada" ou "Saída"

    }
}