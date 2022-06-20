using Projeto.Model;

namespace Projeto.Repository
{
    public interface IUEstoqueRepository
    {
        Task<IEnumerable<Estoque>> BuscarProduto();
        Task<Estoque> BuscarProdutoID(int Id);
        void AdicionarProduto(Estoque produto);
        void AtualizarProduto(Estoque produto);
        void DeletarProduto(Estoque produto);

        Task<bool> SaveChangesAsync();

    }
}