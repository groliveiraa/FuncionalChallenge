using FuncionalChallenge.Domain;
using FuncionalChallenge.Infra.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionalChallenge.Infra.DataContexts
{
    public class FuncionalChallengeDataContext : DbContext
    {
        public FuncionalChallengeDataContext() 
            : base("FuncionalChallengeConnectionString")
        {
            //Database.SetInitializer<FuncionalChallengeDataContext>(new FuncionalChallengeDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProdutoMap());
            modelBuilder.Configurations.Add(new CategoriaMap());
            base.OnModelCreating(modelBuilder);
        }
    }

    public class FuncionalChallengeDataContextInitializer : DropCreateDatabaseIfModelChanges<FuncionalChallengeDataContext>
    {
        protected override void Seed(FuncionalChallengeDataContext context)
        {
            context.Categorias.Add(new Categoria { Id = 1, NomeCategoria = "Xarope" });
            context.Categorias.Add(new Categoria { Id = 2, NomeCategoria = "Cápsulas" });
            context.Categorias.Add(new Categoria { Id = 3, NomeCategoria = "Pomadas" });
            context.SaveChanges();

            context.Produtos.Add(new Produto { Id = 1, CategoriaId = 1, ProdutoAtivo = true, Nome = "Vick", Preco = 30, Industria = "Drogasil", QtdEstoque = 100});
            context.Produtos.Add(new Produto { Id = 2, CategoriaId = 2, ProdutoAtivo = true, Nome = "Dorflex", Preco = 15, Industria = "Bifarma", QtdEstoque = 200});
            context.Produtos.Add(new Produto { Id = 3, CategoriaId = 2, ProdutoAtivo = true, Nome = "Dipirona", Preco = 15, Industria = "Ultrafarma", QtdEstoque = 500});
            context.Produtos.Add(new Produto { Id = 4, CategoriaId = 3, ProdutoAtivo = true, Nome = "Gelol", Preco = 20, Industria = "Drogaria São Paulo", QtdEstoque = 300});
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
