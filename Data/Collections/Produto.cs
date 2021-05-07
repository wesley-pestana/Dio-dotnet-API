using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Data.Collections
{
    public class Produto
    {        
        public Produto(string nome, string codigo, int quantidade)
        {
            this.Id = GetHashCode();
            this.Nome = nome;
            this.Codigo = codigo;
            this.Quantidade = quantidade;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
        public int Quantidade { get; set; }
    }
}
