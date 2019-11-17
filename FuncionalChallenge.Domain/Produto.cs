using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionalChallenge.Domain
{
    public class Produto
    {
        public Produto()
        {
            this.DataCadastro = DateTime.Now;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Industria { get; set; }
        public int Preco { get; set; }
        public int QtdEstoque { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool ProdutoAtivo { get; set; }
        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
