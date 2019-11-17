using FuncionalChallenge.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionalChallenge.Infra.Mappings
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(160).IsRequired();
            Property(x => x.Industria).HasMaxLength(160).IsRequired();
            Property(x => x.Preco).IsRequired();
            Property(x => x.DataCadastro).IsRequired();

            HasRequired(x => x.Categoria);
        }
    }
}
