using Microsoft.AspNetCore.Mvc;
using Projeto.Model;
using Projeto.Repository;

namespace Projeto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IUEstoqueRepository repository;

        public EstoqueController(IUEstoqueRepository repository)
        {
            this.repository = repository;
        }

        ///Listar todos os Produtos do Estoque.

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var produtos = await this.repository.BuscarProduto();
            return produtos.Any()
                ? Ok(produtos)
                : NoContent();
        }

        ///Listar produtos pelo Indicado

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var produto = await this.repository.BuscarProdutoID(Id);
            return produto != null
                ? Ok(produto)
                : NotFound("Produto não Encontrado!");
        }

        ///Cadastrar produto no estoque

        [HttpPost]
        public async Task<IActionResult> Post(Estoque estoque)
        {
            this.repository.AdicionarProduto(estoque);
            return await this.repository.SaveChangesAsync()
                ? Ok("Produto Cadastrado com Sucesso!")
                : BadRequest("Erro ao Cadastrar Produto!");
        }

        ///Atualizar produto pelo Id indicado 

        [HttpPut("{Id}")]
        public async Task<IActionResult> Put(int Id, Estoque produto)
        {
            var ProdutoBanco = await this.repository.BuscarProdutoID(Id);
            if (ProdutoBanco == null) return NotFound("Produto não Encontrado!");

            ProdutoBanco.Nome = produto.Nome ?? ProdutoBanco.Nome;

            this.repository.AtualizarProduto(ProdutoBanco);

            return await this.repository.SaveChangesAsync()
                ? Ok("Produto Atualizado com Sucesso!")
                : BadRequest("Erro ao Atualizar Produto!");

        }

        ///Deletar produto pelo Id indicado

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var ProdutoBanco = await this.repository.BuscarProdutoID(Id);
            if (ProdutoBanco == null) return NotFound("Produto não Encontrado!");

            this.repository.DeletarProduto(ProdutoBanco);

            return await this.repository.SaveChangesAsync()
                ? Ok("Produto Deletado com Sucesso!")
                : BadRequest("Erro ao Deletar Produto!");

        }
    }
}