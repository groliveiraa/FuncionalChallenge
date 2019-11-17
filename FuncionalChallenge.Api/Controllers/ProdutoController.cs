using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FuncionalChallenge.Domain;
using FuncionalChallenge.Infra.DataContexts;

namespace FuncionalChallenge.Api.Controllers
{
    [RoutePrefix("api/v1/public")]
    public class ProdutoController : ApiController
    {
        private FuncionalChallengeDataContext db = new FuncionalChallengeDataContext();

        [Route("produtos")]
        public HttpResponseMessage GetProdutos()
        {
            var result = db.Produtos.Include("Categoria").ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("Categorias")]
        public HttpResponseMessage GetCategorias()
        {
            var result = db.Categorias.ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [Route("Categorias/{categoriaId}/produtos")]
        public HttpResponseMessage GetProdutosByCategorias(int categoriaId)
        {
            var result = db.Produtos.Include("Categoria").Where(x => x.CategoriaId == categoriaId).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpPost]
        [Route("produtos")]
        public HttpResponseMessage PostProduto(Produto produto)
        {
            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Produtos.Add(produto);
                db.SaveChanges();

                var result = produto;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao incluir o Produto");
            }
        }

        [HttpPatch]
        [Route("produtos")]
        public HttpResponseMessage PatchProduto(Produto produto)
        {
            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Produto>(produto).State = EntityState.Modified;
                db.SaveChanges();

                var result = produto;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar produto");
            }
        }

        [HttpPut]
        [Route("produtos")]
        public HttpResponseMessage PutProduto(Produto produto)
        {
            if (produto == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<Produto>(produto).State = EntityState.Modified;
                db.SaveChanges();

                var result = produto;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao alterar produto");
            }
        }

        [HttpDelete]
        [Route("produtos")]
        public HttpResponseMessage DeleteProduto(int produtoId)
        {
            if (produtoId <= 0)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Produtos.Remove(db.Produtos.Find(produtoId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK, "Produto excluido");
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha ao excluir produto");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}