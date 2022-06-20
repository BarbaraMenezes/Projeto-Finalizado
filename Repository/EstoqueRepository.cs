
using Microsoft.EntityFrameworkCore;
using Projeto.Banco;
using Projeto.Model;

namespace Projeto.Repository
{
    public class EstoqueRepository : IUEstoqueRepository
    {
        private readonly EstoqueContext context;

        public EstoqueRepository(EstoqueContext context)
        {
            this.context = context;
        }
        public void AdicionarProduto(Estoque produto)
        {
            this.context.Add(produto);
        }

        public void AtualizarProduto(Estoque produto)
        {
            this.context.Update(produto);
        }

        public async Task<IEnumerable<Estoque>> BuscarProduto()
        {
            return await this.context.Produtos.ToListAsync();
        }

        public async Task<Estoque> BuscarProdutoID(int Id)
        {
            return await this.context.Produtos.Where(x => x.Id == Id)
                                              .FirstOrDefaultAsync();
        }

        public void DeletarProduto(Estoque produto)
        {
            this.context.Remove(produto);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await this.context.SaveChangesAsync() > 0;
        }
    }
}