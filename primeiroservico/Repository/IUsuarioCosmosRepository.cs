

using primeiroservico.Model;

namespace primeiroservico.Repository
{
    public interface IUsuarioCosmosRepository
    {

        Task SalvarUsuarioAsync(Usuario usuario);
    }
}