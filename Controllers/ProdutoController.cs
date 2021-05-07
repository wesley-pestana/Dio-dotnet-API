using Api.Data.Collections;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        Data.MongoDB _mongoDB;
        IMongoCollection<Produto> _ProdutosCollection;

        public ProdutoController(Data.MongoDB mongoDB)
        {
            _mongoDB = mongoDB;
            _ProdutosCollection = _mongoDB.DB.GetCollection<Produto>(typeof(Produto).Name.ToLower());
        }

        [HttpPost]
        public ActionResult SalvarProduto([FromBody] ProdutoDto dto)
        {
            var Produto = new Produto(dto.Nome, dto.Codigo, dto.Quantidade);

            _ProdutosCollection.InsertOne(Produto);
            
            return StatusCode(201, "Produto adicionado com sucesso");
        }

        [HttpGet]
        public ActionResult ObterProduto()
        {
            var Produtos = _ProdutosCollection.Find(Builders<Produto>.Filter.Empty).ToList();
            
            return Ok(Produtos);
        }

        [HttpPut("{id}")]
        public ActionResult AtualizarQuantidadeProduto([FromBody] ProdutoDto dto, int id)
        {
            _ProdutosCollection.UpdateOne(Builders<Produto>.Filter.Where(_ => _.Id == id), Builders<Produto>.Update.Set("Quantidade", dto.Quantidade));

            return Ok("Atualizado com sucesso");
        }

        [HttpDelete("{id}")]
        public ActionResult DeletarProduto(int id)
        {
            _ProdutosCollection.DeleteOne(Builders<Produto>.Filter.Where(_ => _.Id == id));

            return Ok("Deletado com sucesso");
        }
    }
}
